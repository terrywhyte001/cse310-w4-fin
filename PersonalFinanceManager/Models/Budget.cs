using System;
using System.Collections.Generic;

namespace PersonalFinanceManager.Models
{
    /// <summary>
    /// Represents a budget for a specific category
    /// Demonstrates: Encapsulation, calculation logic
    /// </summary>
    public class Budget
    {
        public string Category { get; set; }
        public decimal LimitAmount { get; set; }
        public decimal CurrentSpent { get; set; }
        public DateTime CreatedDate { get; set; }

        public Budget(string category, decimal limitAmount)
        {
            Category = category;
            LimitAmount = limitAmount;
            CurrentSpent = 0;
            CreatedDate = DateTime.Now;
        }

        /// <summary>
        /// Calculates remaining budget
        /// </summary>
        public decimal GetRemaining()
        {
            return LimitAmount - CurrentSpent;
        }

        /// <summary>
        /// Calculates percentage of budget spent
        /// </summary>
        public double GetPercentageSpent()
        {
            if (LimitAmount == 0)
                return 0;
            return Math.Round((double)(CurrentSpent / LimitAmount) * 100, 2);
        }

        /// <summary>
        /// Checks if budget is exceeded
        /// </summary>
        public bool IsExceeded()
        {
            return CurrentSpent > LimitAmount;
        }

        /// <summary>
        /// Updates spent amount
        /// </summary>
        public void UpdateSpent(decimal amount)
        {
            CurrentSpent += amount;
        }

        public override string ToString()
        {
            string status = IsExceeded() ? "EXCEEDED" : "OK";
            return $"{Category,-15} | Limit: ${LimitAmount,8:F2} | Spent: ${CurrentSpent,8:F2} | Remaining: ${GetRemaining(),8:F2} | {GetPercentageSpent(),6:F1}% | {status}";
        }

        public string ToCSV()
        {
            return $"{Category},{LimitAmount},{CurrentSpent},{CreatedDate:yyyy-MM-dd}";
        }

        public static Budget FromCSV(string csvLine)
        {
            var parts = csvLine.Split(',');
            if (parts.Length < 4)
                throw new FormatException("Invalid CSV format");

            string category = parts[0];
            decimal limitAmount = decimal.Parse(parts[1]);
            decimal currentSpent = decimal.Parse(parts[2]);

            Budget budget = new Budget(category, limitAmount);
            budget.CurrentSpent = currentSpent;
            return budget;
        }
    }
}
