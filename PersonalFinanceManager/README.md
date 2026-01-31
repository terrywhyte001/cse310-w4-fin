# Personal Finance Manager

A comprehensive console-based personal finance management application built in C# that helps users track income, expenses, and budgets.

## Project Overview
This Personal Finance Manager application is designed to help users effectively manage their personal finances through a console interface. It allows users to record income and expenses, set budgets, and view financial summaries and reports.
For a live demonstration, watch the

[ software demo video](https://youtu.be/KpVDlR-g55o)

This project fulfills module requirements by demonstrating:
- **C# Fundamentals**: Variables, loops, conditionals, collections
- **Object-Oriented Programming**: Classes, inheritance, encapsulation, abstraction
- **File Handling**: CSV file operations, data persistence
- **Input Validation**: Comprehensive validation for all user inputs
- **Basic Calculations**: Financial aggregations, percentages, trend analysis

## Features

### 1. Transaction Management
- **Add Income**: Record income transactions with categories and dates
- **Add Expenses**: Record expense transactions with full details
- **View Transactions**: Display all transactions or filter by category
- **Delete Transactions**: Remove incorrect or outdated transactions
- **Transaction Persistence**: All transactions are saved to CSV files

### 2. Budget Management
- **Create Budgets**: Set spending limits for different categories
- **View Budgets**: Monitor budget status and spending percentage
- **Update Budgets**: Adjust budget limits as needed
- **Delete Budgets**: Remove budgets when no longer needed
- **Budget Alerts**: Visual indicators for exceeded budgets

### 3. Financial Analysis
- **Financial Summary**: View overall income, expenses, and net balance
- **Category Breakdown**: Analyze spending by category
- **Top Spending Categories**: Identify where most money is spent
- **Budget Utilization**: Track spending against set budgets
- **Transaction Extremes**: Find highest and lowest transactions

### 4. Reporting
- **Export Reports**: Generate detailed transaction reports
- **Category Analysis**: Detailed breakdown of expenses by category
- **Summary Statistics**: Average transactions, category averages

## Project Structure

```
PersonalFinanceManager/
├── Models/
│   ├── Transaction.cs      - Transaction entity and serialization
│   └── Budget.cs           - Budget entity and calculations
├── Services/
│   ├── InputValidator.cs   - Input validation utilities
│   ├── FileService.cs      - File I/O operations
│   ├── FinanceCalculator.cs - Financial calculations and analysis
│   └── FinanceManager.cs   - Main business logic and orchestration
├── Data/                   - Data storage directory
│   ├── transactions.csv    - Transaction records
│   └── budgets.csv         - Budget records
├── PersonalFinanceManager.csproj
├── Program.cs              - Console application entry point
└── README.md
```

## Class Descriptions

### Transaction (Models/Transaction.cs)
Represents a single financial transaction with:
- Properties: Id, Description, Amount, Type, Category, Date
- Methods: ToString(), ToCSV(), FromCSV()
- Enum: TransactionType (Income/Expense)

### Budget (Models/Budget.cs)
Manages budget information with:
- Properties: Category, LimitAmount, CurrentSpent, CreatedDate
- Methods: GetRemaining(), GetPercentageSpent(), IsExceeded(), UpdateSpent()
- CSV serialization support

### InputValidator (Services/InputValidator.cs)
Provides validated input methods:
- GetValidDecimal() - Validates monetary amounts
- GetValidInteger() - Validates whole numbers
- GetValidString() - Validates text input
- GetValidDate() - Validates date input with future date prevention
- GetValidChoice() - Validates choice from options

### FileService (Services/FileService.cs)
Handles all file operations:
- SaveTransaction() - Append transaction to file
- LoadTransactions() - Load all transactions from CSV
- SaveAllTransactions() - Overwrite transactions file
- SaveBudget() - Append budget to file
- LoadBudgets() - Load all budgets from CSV
- SaveAllBudgets() - Overwrite budgets file
- ExportTransactionsReport() - Generate detailed report

### FinanceCalculator (Services/FinanceCalculator.cs)
Performs financial calculations:
- CalculateTotalIncome() - Sum all income
- CalculateTotalExpenses() - Sum all expenses
- CalculateNetBalance() - Income minus expenses
- GetIncomeByCategory() - Group income by category
- GetExpensesByCategory() - Group expenses by category
- GetTransactionsByMonth() - Filter by date range
- GetTopSpendingCategories() - Identify main expenses
- GenerateSummaryReport() - Create comprehensive report

### FinanceManager (Services/FinanceManager.cs)
Main orchestration service:
- AddTransaction() - Record new transaction
- CreateBudget() - Set up new budget
- UpdateBudget() - Modify budget limit
- DeleteTransaction() - Remove transaction
- DeleteBudget() - Remove budget
- GetAllTransactions() - Retrieve all transactions
- GetTransactionsByCategory() - Filter by category
- GetAllBudgets() - Retrieve all budgets
- ExportTransactionsReport() - Generate reports

## Key Features & Requirements Met

### C# Fundamentals
✓ Variables and data types (decimal, int, string, DateTime)
✓ Control structures (if/else, while, foreach)
✓ Collections (List<T>, Dictionary<K,V>, HashSet<T>)
✓ String manipulation and formatting
✓ Exception handling (try/catch)

### Object-Oriented Programming
✓ Class design and encapsulation
✓ Properties with getters and setters
✓ Method organization and responsibilities
✓ Enumerations (TransactionType)
✓ Static utility classes (InputValidator, FinanceCalculator)
✓ Composition (FinanceManager uses FileService)

### File Handling
✓ CSV file read/write operations
✓ File streaming and writing
✓ Data persistence across sessions
✓ Directory creation and management
✓ Error handling for file operations

### Input Validation
✓ Decimal validation with range checking
✓ Integer validation
✓ String validation with length limits
✓ Date validation with future date prevention
✓ Choice validation from options
✓ Error messages for invalid input
✓ Continuous prompting until valid input

### Calculations
✓ Basic arithmetic (sum, difference)
✓ Percentages (budget utilization)
✓ Aggregations (by category, by type)
✓ Averages and extremes
✓ Date-based filtering

## Usage Instructions

### Building the Project
```bash
cd PersonalFinanceManager
dotnet build
```

### Running the Application
```bash
dotnet run
```

### Main Menu Options

1. **Manage Transactions**
   - Add Income transactions
   - Add Expense transactions
   - View all transactions
   - View transactions by category
   - Delete transactions

2. **Manage Budgets**
   - Create new budget limits
   - View all budgets and spending status
   - Update existing budgets
   - Delete budgets

3. **View Financial Summary**
   - See total income and expenses
   - View net balance
   - Check budget status
   - Identify top spending categories

4. **Generate Reports**
   - Export detailed transaction report
   - View category breakdown analysis

5. **Exit**
   - Close the application (data is automatically saved)

## Data Storage

All data is automatically persisted in CSV format:

### transactions.csv
```
Id,Date,Type,Category,Description,Amount
1,2024-01-15,Income,Salary,Monthly salary,3000.00
2,2024-01-16,Expense,Food,Groceries,50.00
```

### budgets.csv
```
Category,LimitAmount,CurrentSpent,CreatedDate
Food,500.00,50.00,2024-01-01
Entertainment,300.00,0.00,2024-01-01
```

## Example Workflow

1. **Start Application** → Create initial budgets
2. **Add Income** → Record salary or freelance earnings
3. **Add Expenses** → Log daily spending by category
4. **Monitor Budgets** → Check spending against limits
5. **View Summary** → Analyze financial health
6. **Generate Reports** → Export transaction history

## Error Handling

The application includes comprehensive error handling:
- Invalid input types → Prompts for retry
- File I/O errors → Displays error message and continues
- Transaction/Budget not found → Shows user-friendly error
- CSV parsing errors → Logs issue and continues loading other records

## Future Enhancements

Possible additions to extend the project:
- Monthly/yearly reporting views
- Recurring transactions
- Transaction search and filtering
- Budget forecasting
- Data backup and restore
- Configuration settings
- Multi-user support
- Database integration instead of CSV

## Learning Outcomes

This project demonstrates:
- How to structure a C# console application
- File I/O and data persistence patterns
- SOLID principles in action
- User input validation best practices
- Financial calculation implementations
- Report generation techniques
- Collections and LINQ usage
- Exception handling strategies

## Notes

- All monetary amounts are stored with 2 decimal precision
- Dates are validated to prevent future entries
- Budget tracking is automatic when expenses are added
- Exceeded budgets are clearly marked in budget view
- All data is loaded at startup for performance
- Changes are persisted immediately after each operation

---

**Author**: Samuel Evbosaru
**Version**: 1.0
**Language**: C# (.NET 6.0)
**License**: Educational Use

# useful_links 
Github Repository 
VS code
