using System;
using System.Collections.Generic;
using System.Linq;
using PersonalFinanceManager.Models;
using PersonalFinanceManager.Services;

namespace PersonalFinanceManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new FinanceManager();
            bool running = true;

            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║   Personal Finance Manager v1.0        ║");
            Console.WriteLine("║   Manage your finances efficiently      ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.WriteLine();

            while (running)
            {
                DisplayMainMenu();
                string choice = Console.ReadLine()?.ToUpper() ?? "";

                try
                {
                    switch (choice)
                    {
                        case "1":
                            HandleTransactionMenu(manager);
                            break;
                        case "2":
                            HandleBudgetMenu(manager);
                            break;
                        case "3":
                            DisplayFinancialSummary(manager);
                            break;
                        case "4":
                            DisplayReports(manager);
                            break;
                        case "5":
                            running = false;
                            Console.WriteLine("\nThank you for using Personal Finance Manager. Goodbye!");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nError: {ex.Message}\n");
                }

                if (running && !choice.Equals("3", StringComparison.OrdinalIgnoreCase) 
                    && !choice.Equals("4", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        static void DisplayMainMenu()
        {
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("         MAIN MENU");
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("1. Manage Transactions");
            Console.WriteLine("2. Manage Budgets");
            Console.WriteLine("3. View Financial Summary");
            Console.WriteLine("4. Generate Reports");
            Console.WriteLine("5. Exit");
            Console.WriteLine("═══════════════════════════════════════");
            Console.Write("Select an option (1-5): ");
        }

        static void HandleTransactionMenu(FinanceManager manager)
        {
            bool inMenu = true;
            while (inMenu)
            {
                Console.Clear();
                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine("      TRANSACTION MANAGEMENT");
                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine("1. Add Income");
                Console.WriteLine("2. Add Expense");
                Console.WriteLine("3. View All Transactions");
                Console.WriteLine("4. View Transactions by Category");
                Console.WriteLine("5. Delete Transaction");
                Console.WriteLine("6. Back to Main Menu");
                Console.WriteLine("═══════════════════════════════════════");
                Console.Write("Select an option (1-6): ");

                string choice = Console.ReadLine()?.ToUpper() ?? "";

                switch (choice)
                {
                    case "1":
                        AddTransaction(manager, TransactionType.Income);
                        break;
                    case "2":
                        AddTransaction(manager, TransactionType.Expense);
                        break;
                    case "3":
                        ViewAllTransactions(manager);
                        break;
                    case "4":
                        ViewTransactionsByCategory(manager);
                        break;
                    case "5":
                        DeleteTransaction(manager);
                        break;
                    case "6":
                        inMenu = false;
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                if (inMenu && !choice.Equals("3", StringComparison.OrdinalIgnoreCase) 
                    && !choice.Equals("4", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        static void AddTransaction(FinanceManager manager, TransactionType type)
        {
            Console.Clear();
            Console.WriteLine($"═══════════════════════════════════════");
            Console.WriteLine($"    ADD {type.ToString().ToUpper()}");
            Console.WriteLine($"═══════════════════════════════════════");

            var categories = manager.GetAllCategories();
            Console.WriteLine("\nAvailable categories:");
            for (int i = 0; i < categories.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {categories[i]}");
            }

            int categoryIndex = InputValidator.GetValidInteger("\nSelect category (number): ", 1, categories.Count) - 1;
            string category = categories[categoryIndex];

            string description = InputValidator.GetValidString("Description: ", 1, 100);
            decimal amount = InputValidator.GetValidDecimal("Amount: $", 0.01m, decimal.MaxValue);
            DateTime date = InputValidator.GetValidDate("Date (yyyy-MM-dd) [press Enter for today]: ");

            manager.AddTransaction(description, amount, type, category, date);
            Console.WriteLine($"\n✓ {type} of ${amount:F2} added successfully!");
        }

        static void ViewAllTransactions(FinanceManager manager)
        {
            Console.Clear();
            var transactions = manager.GetAllTransactions();

            if (transactions.Count == 0)
            {
                Console.WriteLine("No transactions found.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("                        ALL TRANSACTIONS");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════");

            decimal totalIncome = 0, totalExpenses = 0;

            foreach (var transaction in transactions)
            {
                Console.WriteLine(transaction.ToString());
                if (transaction.Type == TransactionType.Income)
                    totalIncome += transaction.Amount;
                else
                    totalExpenses += transaction.Amount;
            }

            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════");
            Console.WriteLine($"Total Income: ${totalIncome:F2}");
            Console.WriteLine($"Total Expenses: ${totalExpenses:F2}");
            Console.WriteLine($"Balance: ${totalIncome - totalExpenses:F2}");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        static void ViewTransactionsByCategory(FinanceManager manager)
        {
            Console.Clear();
            var categories = manager.GetAllCategories();

            if (categories.Count == 0)
            {
                Console.WriteLine("No categories found.");
                return;
            }

            Console.WriteLine("Available categories:");
            for (int i = 0; i < categories.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {categories[i]}");
            }

            int categoryIndex = InputValidator.GetValidInteger("Select category (number): ", 1, categories.Count) - 1;
            string category = categories[categoryIndex];

            var transactions = manager.GetTransactionsByCategory(category);

            Console.Clear();
            Console.WriteLine($"═══════════════════════════════════════════════════════════════════════════");
            Console.WriteLine($"                    TRANSACTIONS - {category.ToUpper()}");
            Console.WriteLine($"═══════════════════════════════════════════════════════════════════════════");

            if (transactions.Count == 0)
            {
                Console.WriteLine($"No transactions found for {category}.");
            }
            else
            {
                decimal total = 0;
                foreach (var transaction in transactions)
                {
                    Console.WriteLine(transaction.ToString());
                    total += transaction.Amount;
                }

                Console.WriteLine("═══════════════════════════════════════════════════════════════════════════");
                Console.WriteLine($"Total: ${total:F2}");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        static void DeleteTransaction(FinanceManager manager)
        {
            Console.Clear();
            var transactions = manager.GetAllTransactions();

            if (transactions.Count == 0)
            {
                Console.WriteLine("No transactions to delete.");
                return;
            }

            Console.WriteLine("Recent transactions:");
            for (int i = 0; i < Math.Min(10, transactions.Count); i++)
            {
                Console.WriteLine(transactions[i].ToString());
            }

            int transactionId = InputValidator.GetValidInteger("\nEnter transaction ID to delete: ", 1, int.MaxValue);
            manager.DeleteTransaction(transactionId);
            Console.WriteLine("✓ Transaction deleted successfully!");
        }

        static void HandleBudgetMenu(FinanceManager manager)
        {
            bool inMenu = true;
            while (inMenu)
            {
                Console.Clear();
                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine("       BUDGET MANAGEMENT");
                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine("1. Create Budget");
                Console.WriteLine("2. View All Budgets");
                Console.WriteLine("3. Update Budget");
                Console.WriteLine("4. Delete Budget");
                Console.WriteLine("5. Back to Main Menu");
                Console.WriteLine("═══════════════════════════════════════");
                Console.Write("Select an option (1-5): ");

                string choice = Console.ReadLine()?.ToUpper() ?? "";

                switch (choice)
                {
                    case "1":
                        CreateBudget(manager);
                        break;
                    case "2":
                        ViewAllBudgets(manager);
                        break;
                    case "3":
                        UpdateBudget(manager);
                        break;
                    case "4":
                        DeleteBudget(manager);
                        break;
                    case "5":
                        inMenu = false;
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                if (inMenu && !choice.Equals("2", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        static void CreateBudget(FinanceManager manager)
        {
            Console.Clear();
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("        CREATE BUDGET");
            Console.WriteLine("═══════════════════════════════════════");

            var categories = manager.GetAllCategories();
            var existingBudgets = manager.GetAllBudgets();
            var availableCategories = categories
                .Where(c => !existingBudgets.Any(b => b.Category == c))
                .ToList();

            if (availableCategories.Count == 0)
            {
                Console.WriteLine("All categories already have budgets.");
                return;
            }

            Console.WriteLine("\nAvailable categories:");
            for (int i = 0; i < availableCategories.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {availableCategories[i]}");
            }

            int categoryIndex = InputValidator.GetValidInteger("Select category (number): ", 1, availableCategories.Count) - 1;
            string category = availableCategories[categoryIndex];

            decimal limitAmount = InputValidator.GetValidDecimal("Budget limit: $", 0.01m, decimal.MaxValue);

            manager.CreateBudget(category, limitAmount);
            Console.WriteLine($"✓ Budget for {category} created successfully!");
        }

        static void ViewAllBudgets(FinanceManager manager)
        {
            Console.Clear();
            var budgets = manager.GetAllBudgets();

            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("                        ALL BUDGETS");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════");

            if (budgets.Count == 0)
            {
                Console.WriteLine("No budgets set.");
            }
            else
            {
                foreach (var budget in budgets)
                {
                    Console.WriteLine(budget.ToString());
                }
            }

            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        static void UpdateBudget(FinanceManager manager)
        {
            Console.Clear();
            var budgets = manager.GetAllBudgets();

            if (budgets.Count == 0)
            {
                Console.WriteLine("No budgets to update.");
                return;
            }

            Console.WriteLine("Existing budgets:");
            for (int i = 0; i < budgets.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {budgets[i].Category} - ${budgets[i].LimitAmount:F2}");
            }

            int budgetIndex = InputValidator.GetValidInteger("Select budget (number): ", 1, budgets.Count) - 1;
            var selectedBudget = budgets[budgetIndex];

            decimal newLimit = InputValidator.GetValidDecimal($"New limit for {selectedBudget.Category}: $", 0.01m, decimal.MaxValue);

            manager.UpdateBudget(selectedBudget.Category, newLimit);
            Console.WriteLine("✓ Budget updated successfully!");
        }

        static void DeleteBudget(FinanceManager manager)
        {
            Console.Clear();
            var budgets = manager.GetAllBudgets();

            if (budgets.Count == 0)
            {
                Console.WriteLine("No budgets to delete.");
                return;
            }

            Console.WriteLine("Existing budgets:");
            for (int i = 0; i < budgets.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {budgets[i].Category} - ${budgets[i].LimitAmount:F2}");
            }

            int budgetIndex = InputValidator.GetValidInteger("Select budget to delete (number): ", 1, budgets.Count) - 1;
            var selectedBudget = budgets[budgetIndex];

            manager.DeleteBudget(selectedBudget.Category);
            Console.WriteLine("✓ Budget deleted successfully!");
        }

        static void DisplayFinancialSummary(FinanceManager manager)
        {
            Console.Clear();
            Console.WriteLine(manager.GetFinancialSummary());
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        static void DisplayReports(FinanceManager manager)
        {
            Console.Clear();
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("       REPORTS");
            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("1. Export Transactions Report");
            Console.WriteLine("2. View Category Breakdown");
            Console.WriteLine("3. Back to Main Menu");
            Console.WriteLine("═══════════════════════════════════════");
            Console.Write("Select an option (1-3): ");

            string choice = Console.ReadLine()?.ToUpper() ?? "";

            switch (choice)
            {
                case "1":
                    manager.ExportTransactionsReport();
                    Console.WriteLine("✓ Report exported to Data/report.txt");
                    break;
                case "2":
                    DisplayCategoryBreakdown(manager);
                    break;
                case "3":
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            if (!choice.Equals("3", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void DisplayCategoryBreakdown(FinanceManager manager)
        {
            Console.Clear();
            var transactions = manager.GetAllTransactions();
            var expensesByCategory = FinanceCalculator.GetExpensesByCategory(transactions);

            Console.WriteLine("═══════════════════════════════════════");
            Console.WriteLine("    EXPENSE BREAKDOWN BY CATEGORY");
            Console.WriteLine("═══════════════════════════════════════");

            if (expensesByCategory.Count == 0)
            {
                Console.WriteLine("No expenses found.");
            }
            else
            {
                decimal totalExpenses = 0;
                foreach (var category in expensesByCategory.OrderByDescending(x => x.Value))
                {
                    decimal percentage = totalExpenses > 0 ? (category.Value / totalExpenses) * 100 : 0;
                    Console.WriteLine($"{category.Key,-15} : ${category.Value,8:F2}");
                    totalExpenses += category.Value;
                }

                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine($"{"TOTAL",-15} : ${totalExpenses,8:F2}");
            }
        }
    }
}
