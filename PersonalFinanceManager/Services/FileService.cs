using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Services
{
    /// <summary>
    /// Handles file operations for saving and loading financial data
    /// Demonstrates: File handling requirements
    /// </summary>
    public class FileService
    {
        private readonly string _transactionsFile;
        private readonly string _budgetsFile;
        private readonly string _dataDirectory;

        public FileService(string dataDirectory = "Data")
        {
            _dataDirectory = dataDirectory;
            _transactionsFile = Path.Combine(dataDirectory, "transactions.csv");
            _budgetsFile = Path.Combine(dataDirectory, "budgets.csv");

            // Create data directory if it doesn't exist
            if (!Directory.Exists(dataDirectory))
            {
                Directory.CreateDirectory(dataDirectory);
            }

            // Create headers if files don't exist
            InitializeFiles();
        }

        /// <summary>
        /// Initializes CSV files with headers if they don't exist
        /// </summary>
        private void InitializeFiles()
        {
            if (!File.Exists(_transactionsFile))
            {
                File.WriteAllText(_transactionsFile, "Id,Date,Type,Category,Description,Amount\n");
            }

            if (!File.Exists(_budgetsFile))
            {
                File.WriteAllText(_budgetsFile, "Category,LimitAmount,CurrentSpent,CreatedDate\n");
            }
        }

        /// <summary>
        /// Saves a transaction to file
        /// </summary>
        public void SaveTransaction(Transaction transaction)
        {
            try
            {
                File.AppendAllText(_transactionsFile, transaction.ToCSV() + "\n");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error saving transaction: {ex.Message}");
            }
        }

        /// <summary>
        /// Loads all transactions from file
        /// </summary>
        public List<Transaction> LoadTransactions()
        {
            var transactions = new List<Transaction>();

            try
            {
                if (!File.Exists(_transactionsFile))
                    return transactions;

                var lines = File.ReadAllLines(_transactionsFile);
                foreach (var line in lines.Skip(1)) // Skip header
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    try
                    {
                        transactions.Add(Transaction.FromCSV(line));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error parsing transaction: {ex.Message}");
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error loading transactions: {ex.Message}");
            }

            return transactions;
        }

        /// <summary>
        /// Saves all transactions to file (overwrites existing)
        /// </summary>
        public void SaveAllTransactions(List<Transaction> transactions)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_transactionsFile))
                {
                    writer.WriteLine("Id,Date,Type,Category,Description,Amount");
                    foreach (var transaction in transactions)
                    {
                        writer.WriteLine(transaction.ToCSV());
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error saving all transactions: {ex.Message}");
            }
        }

        /// <summary>
        /// Saves a budget to file
        /// </summary>
        public void SaveBudget(Budget budget)
        {
            try
            {
                File.AppendAllText(_budgetsFile, budget.ToCSV() + "\n");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error saving budget: {ex.Message}");
            }
        }

        /// <summary>
        /// Loads all budgets from file
        /// </summary>
        public List<Budget> LoadBudgets()
        {
            var budgets = new List<Budget>();

            try
            {
                if (!File.Exists(_budgetsFile))
                    return budgets;

                var lines = File.ReadAllLines(_budgetsFile);
                foreach (var line in lines.Skip(1)) // Skip header
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    try
                    {
                        budgets.Add(Budget.FromCSV(line));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error parsing budget: {ex.Message}");
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error loading budgets: {ex.Message}");
            }

            return budgets;
        }

        /// <summary>
        /// Saves all budgets to file (overwrites existing)
        /// </summary>
        public void SaveAllBudgets(List<Budget> budgets)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_budgetsFile))
                {
                    writer.WriteLine("Category,LimitAmount,CurrentSpent,CreatedDate");
                    foreach (var budget in budgets)
                    {
                        writer.WriteLine(budget.ToCSV());
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error saving all budgets: {ex.Message}");
            }
        }

        /// <summary>
        /// Exports transactions to a report file
        /// </summary>
        public void ExportTransactionsReport(List<Transaction> transactions, string fileName = "report.txt")
        {
            try
            {
                string filePath = Path.Combine(_dataDirectory, fileName);
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("========== TRANSACTION REPORT ==========");
                    writer.WriteLine($"Generated: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                    writer.WriteLine();

                    if (transactions.Count == 0)
                    {
                        writer.WriteLine("No transactions found.");
                        return;
                    }

                    foreach (var transaction in transactions.OrderBy(t => t.Date))
                    {
                        writer.WriteLine(transaction.ToString());
                    }

                    writer.WriteLine();
                    writer.WriteLine($"Total Transactions: {transactions.Count}");
                    writer.WriteLine($"Total Income: ${transactions.Where(t => t.Type == TransactionType.Income).Sum(t => t.Amount):F2}");
                    writer.WriteLine($"Total Expenses: ${transactions.Where(t => t.Type == TransactionType.Expense).Sum(t => t.Amount):F2}");
                }

                Console.WriteLine($"Report exported to: {filePath}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error exporting report: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets the next available transaction ID
        /// </summary>
        public int GetNextTransactionId(List<Transaction> transactions)
        {
            return transactions.Count == 0 ? 1 : transactions.Max(t => t.Id) + 1;
        }
    }
}
