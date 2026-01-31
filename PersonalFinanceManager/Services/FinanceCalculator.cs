using System;
using System.Collections.Generic;
using System.Linq;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Services
{
    /// <summary>
    /// Handles financial calculations
    /// Demonstrates: Basic calculations, LINQ, aggregate operations
    /// </summary>
    public static class FinanceCalculator
    {
        /// <summary>
        /// Calculates total income
        /// </summary>
        public static decimal CalculateTotalIncome(List<Transaction> transactions)
        {
            return transactions
                .Where(t => t.Type == TransactionType.Income)
                .Sum(t => t.Amount);
        }

        /// <summary>
        /// Calculates total expenses
        /// </summary>
        public static decimal CalculateTotalExpenses(List<Transaction> transactions)
        {
            return transactions
                .Where(t => t.Type == TransactionType.Expense)
                .Sum(t => t.Amount);
        }

        /// <summary>
        /// Calculates net balance (income - expenses)
        /// </summary>
        public static decimal CalculateNetBalance(List<Transaction> transactions)
        {
            return CalculateTotalIncome(transactions) - CalculateTotalExpenses(transactions);
        }

        /// <summary>
        /// Calculates income by category
        /// </summary>
        public static Dictionary<string, decimal> GetIncomeByCategory(List<Transaction> transactions)
        {
            return transactions
                .Where(t => t.Type == TransactionType.Income)
                .GroupBy(t => t.Category)
                .ToDictionary(g => g.Key, g => g.Sum(t => t.Amount));
        }

        /// <summary>
        /// Calculates expenses by category
        /// </summary>
        public static Dictionary<string, decimal> GetExpensesByCategory(List<Transaction> transactions)
        {
            return transactions
                .Where(t => t.Type == TransactionType.Expense)
                .GroupBy(t => t.Category)
                .ToDictionary(g => g.Key, g => g.Sum(t => t.Amount));
        }

        /// <summary>
        /// Gets transactions for a specific month
        /// </summary>
        public static List<Transaction> GetTransactionsByMonth(List<Transaction> transactions, int year, int month)
        {
            return transactions
                .Where(t => t.Date.Year == year && t.Date.Month == month)
                .OrderBy(t => t.Date)
                .ToList();
        }

        /// <summary>
        /// Calculates average transaction amount
        /// </summary>
        public static decimal CalculateAverageTransaction(List<Transaction> transactions)
        {
            if (transactions.Count == 0)
                return 0;

            return transactions.Average(t => t.Amount);
        }

        /// <summary>
        /// Calculates average expense by category
        /// </summary>
        public static Dictionary<string, decimal> GetAverageExpenseByCategory(List<Transaction> transactions)
        {
            return transactions
                .Where(t => t.Type == TransactionType.Expense)
                .GroupBy(t => t.Category)
                .ToDictionary(g => g.Key, g => Math.Round(g.Average(t => t.Amount), 2));
        }

        /// <summary>
        /// Gets top spending categories
        /// </summary>
        public static List<(string Category, decimal Amount)> GetTopSpendingCategories(List<Transaction> transactions, int topN = 5)
        {
            return transactions
                .Where(t => t.Type == TransactionType.Expense)
                .GroupBy(t => t.Category)
                .Select(g => (g.Key, g.Sum(t => t.Amount)))
                .OrderByDescending(x => x.Item2)
                .Take(topN)
                .ToList();
        }

        /// <summary>
        /// Calculates budget utilization by category
        /// </summary>
        public static Dictionary<string, double> GetBudgetUtilization(List<Transaction> transactions, List<Budget> budgets)
        {
            var expensesByCategory = GetExpensesByCategory(transactions);
            var utilization = new Dictionary<string, double>();

            foreach (var budget in budgets)
            {
                decimal spent = expensesByCategory.ContainsKey(budget.Category)
                    ? expensesByCategory[budget.Category]
                    : 0;

                double percentage = budget.LimitAmount == 0 ? 0 : (double)(spent / budget.LimitAmount) * 100;
                utilization[budget.Category] = Math.Round(percentage, 2);
            }

            return utilization;
        }

        /// <summary>
        /// Finds the highest single transaction
        /// </summary>
        public static Transaction GetHighestTransaction(List<Transaction> transactions)
        {
            return transactions.OrderByDescending(t => t.Amount).FirstOrDefault();
        }

        /// <summary>
        /// Finds the lowest single transaction
        /// </summary>
        public static Transaction GetLowestTransaction(List<Transaction> transactions)
        {
            return transactions.OrderBy(t => t.Amount).FirstOrDefault();
        }

        /// <summary>
        /// Generates a summary report
        /// </summary>
        public static string GenerateSummaryReport(List<Transaction> transactions, List<Budget> budgets)
        {
            var report = new System.Text.StringBuilder();
            report.AppendLine("========== FINANCIAL SUMMARY ==========");
            report.AppendLine($"Generated: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            report.AppendLine();

            decimal totalIncome = CalculateTotalIncome(transactions);
            decimal totalExpenses = CalculateTotalExpenses(transactions);
            decimal netBalance = CalculateNetBalance(transactions);

            report.AppendLine("--- OVERALL SUMMARY ---");
            report.AppendLine($"Total Income:    ${totalIncome:F2}");
            report.AppendLine($"Total Expenses:  ${totalExpenses:F2}");
            report.AppendLine($"Net Balance:     ${netBalance:F2}");
            report.AppendLine();

            if (transactions.Count > 0)
            {
                var highest = GetHighestTransaction(transactions);
                var lowest = GetLowestTransaction(transactions);
                report.AppendLine("--- TRANSACTION EXTREMES ---");
                report.AppendLine($"Highest: {highest?.Description} (${highest?.Amount:F2})");
                report.AppendLine($"Lowest:  {lowest?.Description} (${lowest?.Amount:F2})");
                report.AppendLine();
            }

            var topCategories = GetTopSpendingCategories(transactions, 3);
            if (topCategories.Count > 0)
            {
                report.AppendLine("--- TOP SPENDING CATEGORIES ---");
                foreach (var (category, amount) in topCategories)
                {
                    report.AppendLine($"{category,-15}: ${amount:F2}");
                }
                report.AppendLine();
            }

            if (budgets.Count > 0)
            {
                report.AppendLine("--- BUDGET STATUS ---");
                foreach (var budget in budgets)
                {
                    string status = budget.IsExceeded() ? "EXCEEDED" : "OK";
                    report.AppendLine($"{budget.Category,-15}: {budget.GetPercentageSpent(),6:F1}% spent [{status}]");
                }
            }

            return report.ToString();
        }
    }
}
