using System;

namespace PersonalFinanceManager.Models
{
    /// <summary>
    /// Represents a financial transaction (income or expense)
    /// Demonstrates: Encapsulation, OOP principles
    /// </summary>
    public class Transaction
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }

        /// <summary>
        /// Constructor for creating a new transaction
        /// </summary>
        public Transaction(int id, string description, decimal amount, TransactionType type, string category, DateTime date)
        {
            Id = id;
            Description = description;
            Amount = amount;
            Type = type;
            Category = category;
            Date = date;
        }

        /// <summary>
        /// Returns a string representation of the transaction
        /// </summary>
        public override string ToString()
        {
            return $"[{Id}] {Date:yyyy-MM-dd} | {Type,-7} | {Category,-15} | {Description,-20} | ${Amount,8:F2}";
        }

        /// <summary>
        /// Exports transaction to CSV format
        /// </summary>
        public string ToCSV()
        {
            return $"{Id},{Date:yyyy-MM-dd},{Type},{Category},{Description},{Amount}";
        }

        /// <summary>
        /// Creates a transaction from CSV string
        /// </summary>
        public static Transaction FromCSV(string csvLine)
        {
            var parts = csvLine.Split(',');
            if (parts.Length < 6)
                throw new FormatException("Invalid CSV format");

            int id = int.Parse(parts[0]);
            DateTime date = DateTime.Parse(parts[1]);
            TransactionType type = (TransactionType)Enum.Parse(typeof(TransactionType), parts[2]);
            string category = parts[3];
            string description = parts[4];
            decimal amount = decimal.Parse(parts[5]);

            return new Transaction(id, description, amount, type, category, date);
        }
    }

    /// <summary>
    /// Enum for transaction types
    /// </summary>
    public enum TransactionType
    {
        Income,
        Expense
    }
}
