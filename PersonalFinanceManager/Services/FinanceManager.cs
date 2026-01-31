using System;
using System.Collections.Generic;
using System.Linq;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Services
{
    /// <summary>
    /// Main service class for managing finances
    /// Demonstrates: OOP, encapsulation, business logic
    /// </summary>
    public class FinanceManager
    {
        private List<Transaction> _transactions;
        private List<Budget> _budgets;
        private FileService _fileService;
        private readonly string[] _defaultCategories = 
        { 
            "Salary", "Freelance", "Food", "Transportation", "Entertainment", 
            "Utilities", "Healthcare", "Shopping", "Education", "Other" 
        };

        public FinanceManager(string dataDirectory = "Data")
        {
            _fileService = new FileService(dataDirectory);
            _transactions = _fileService.LoadTransactions();
            _budgets = _fileService.LoadBudgets();
        }

        /// <summary>
        /// Adds a new transaction
        /// </summary>
        public void AddTransaction(string description, decimal amount, TransactionType type, string category, DateTime? date = null)
        {
            if (!InputValidator.IsValidString(description))
                throw new ArgumentException("Description cannot be empty");

            if (!InputValidator.IsValidAmount(amount))
                throw new ArgumentException("Amount must be positive");

            int newId = _fileService.GetNextTransactionId(_transactions);
            var transaction = new Transaction(
                newId,
                description,
                amount,
                type,
                category,
                date ?? DateTime.Now
            );

            _transactions.Add(transaction);
            _fileService.SaveTransaction(transaction);

            // Update budget if it's an expense
            if (type == TransactionType.Expense)
            {
                var budget = _budgets.FirstOrDefault(b => b.Category == category);
                if (budget != null)
                {
                    budget.UpdateSpent(amount);
                    _fileService.SaveAllBudgets(_budgets);
                }
            }
        }

        /// <summary>
        /// Creates a new budget
        /// </summary>
        public void CreateBudget(string category, decimal limitAmount)
        {
            if (!InputValidator.IsValidString(category))
                throw new ArgumentException("Category cannot be empty");

            if (!InputValidator.IsValidAmount(limitAmount))
                throw new ArgumentException("Limit amount must be positive");

            // Check if budget already exists
            if (_budgets.Any(b => b.Category == category))
                throw new InvalidOperationException($"Budget for '{category}' already exists");

            var budget = new Budget(category, limitAmount);
            
            // Calculate current spending in this category
            var categoryExpenses = _transactions
                .Where(t => t.Type == TransactionType.Expense && t.Category == category)
                .Sum(t => t.Amount);
            
            budget.UpdateSpent(categoryExpenses);
            _budgets.Add(budget);
            _fileService.SaveBudget(budget);
        }

        /// <summary>
        /// Updates an existing budget
        /// </summary>
        public void UpdateBudget(string category, decimal newLimitAmount)
        {
            var budget = _budgets.FirstOrDefault(b => b.Category == category);
            if (budget == null)
                throw new InvalidOperationException($"Budget for '{category}' not found");

            budget.LimitAmount = newLimitAmount;
            _fileService.SaveAllBudgets(_budgets);
        }

        /// <summary>
        /// Deletes a transaction
        /// </summary>
        public void DeleteTransaction(int transactionId)
        {
            var transaction = _transactions.FirstOrDefault(t => t.Id == transactionId);
            if (transaction == null)
                throw new InvalidOperationException($"Transaction {transactionId} not found");

            // Update budget if it was an expense
            if (transaction.Type == TransactionType.Expense)
            {
                var budget = _budgets.FirstOrDefault(b => b.Category == transaction.Category);
                if (budget != null)
                {
                    budget.CurrentSpent -= transaction.Amount;
                    _fileService.SaveAllBudgets(_budgets);
                }
            }

            _transactions.Remove(transaction);
            _fileService.SaveAllTransactions(_transactions);
        }

        /// <summary>
        /// Gets all transactions
        /// </summary>
        public List<Transaction> GetAllTransactions()
        {
            return _transactions.OrderByDescending(t => t.Date).ToList();
        }

        /// <summary>
        /// Gets transactions by category
        /// </summary>
        public List<Transaction> GetTransactionsByCategory(string category)
        {
            return _transactions
                .Where(t => t.Category == category)
                .OrderByDescending(t => t.Date)
                .ToList();
        }

        /// <summary>
        /// Gets transactions by type
        /// </summary>
        public List<Transaction> GetTransactionsByType(TransactionType type)
        {
            return _transactions
                .Where(t => t.Type == type)
                .OrderByDescending(t => t.Date)
                .ToList();
        }

        /// <summary>
        /// Gets all budgets
        /// </summary>
        public List<Budget> GetAllBudgets()
        {
            return _budgets;
        }

        /// <summary>
        /// Gets a specific budget
        /// </summary>
        public Budget GetBudget(string category)
        {
            return _budgets.FirstOrDefault(b => b.Category == category);
        }

        /// <summary>
        /// Deletes a budget
        /// </summary>
        public void DeleteBudget(string category)
        {
            var budget = _budgets.FirstOrDefault(b => b.Category == category);
            if (budget == null)
                throw new InvalidOperationException($"Budget for '{category}' not found");

            _budgets.Remove(budget);
            _fileService.SaveAllBudgets(_budgets);
        }

        /// <summary>
        /// Gets default categories
        /// </summary>
        public string[] GetDefaultCategories()
        {
            return _defaultCategories;
        }

        /// <summary>
        /// Gets all unique categories from transactions
        /// </summary>
        public List<string> GetAllCategories()
        {
            var categories = new HashSet<string>(_defaultCategories);
            categories.UnionWith(_transactions.Select(t => t.Category));
            return categories.OrderBy(c => c).ToList();
        }

        /// <summary>
        /// Exports transactions report
        /// </summary>
        public void ExportTransactionsReport(string fileName = "report.txt")
        {
            _fileService.ExportTransactionsReport(_transactions, fileName);
        }

        /// <summary>
        /// Gets financial summary
        /// </summary>
        public string GetFinancialSummary()
        {
            return FinanceCalculator.GenerateSummaryReport(_transactions, _budgets);
        }
    }
}
