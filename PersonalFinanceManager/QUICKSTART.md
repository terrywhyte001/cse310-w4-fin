# Quick Start Guide - Personal Finance Manager

## Prerequisites
- .NET 6.0 SDK or later installed
- Windows, macOS, or Linux
- A terminal/command prompt

## Installation & Setup

### 1. Build the Project
```bash
cd c:\Users\hp\OneDrive\Desktop\cse310-w4-fin\PersonalFinanceManager
dotnet build
```

Expected output: `Build succeeded.`

### 2. Run the Application
```bash
dotnet run
```

## First Time Setup

When you first run the application:

1. **Main Menu** appears
2. **Create Initial Budgets** (Recommended)
   - Select: 2 → 1
   - Categories: Salary, Food, Transportation, Entertainment, Utilities, etc.
   - Set reasonable limits for each

3. **Add Initial Income**
   - Select: 1 → 1
   - Category: Salary
   - Description: Monthly Salary
   - Amount: Your income
   - Date: Today

4. **Add Expenses**
   - Select: 1 → 2
   - Choose category
   - Enter description and amount
   - Track daily spending

## Common Tasks

### Task 1: Add an Income Transaction
```
Main Menu → 1 (Manage Transactions) → 1 (Add Income)
1. Select category (e.g., "Salary")
2. Enter description: "Monthly Salary"
3. Enter amount: 3000.00
4. Enter date: 2024-01-15 (or press Enter for today)
```

### Task 2: Add an Expense Transaction
```
Main Menu → 1 (Manage Transactions) → 2 (Add Expense)
1. Select category (e.g., "Food")
2. Enter description: "Groceries"
3. Enter amount: 50.50
4. Enter date: 2024-01-15 (or press Enter for today)
```

### Task 3: Create a Budget
```
Main Menu → 2 (Manage Budgets) → 1 (Create Budget)
1. Select category (e.g., "Food")
2. Enter budget limit: 500.00 (monthly limit)
Budget created! The app tracks spending against this limit.
```

### Task 4: View All Transactions
```
Main Menu → 1 (Manage Transactions) → 3 (View All Transactions)
Shows: ID | Date | Type | Category | Description | Amount
Displays summary totals at bottom
```

### Task 5: View All Budgets
```
Main Menu → 2 (Manage Budgets) → 2 (View All Budgets)
Shows: Category | Limit | Spent | Remaining | %Spent | Status
Status shows "OK" or "EXCEEDED"
```

### Task 6: Check Financial Summary
```
Main Menu → 3 (View Financial Summary)
Displays:
- Total Income
- Total Expenses
- Net Balance
- Budget Status for each category
- Top spending categories
```

### Task 7: Generate Reports
```
Main Menu → 4 (Generate Reports)
Option 1: Export transactions to report.txt
Option 2: View category expense breakdown
```

### Task 8: Delete a Transaction
```
Main Menu → 1 (Manage Transactions) → 5 (Delete Transaction)
1. Shows recent transactions
2. Enter transaction ID to delete
3. Transaction removed (budget updated if expense)
```

### Task 9: Update a Budget
```
Main Menu → 2 (Manage Budgets) → 3 (Update Budget)
1. Select budget to update
2. Enter new limit amount
3. Budget updated
```

### Task 10: Delete a Budget
```
Main Menu → 2 (Manage Budgets) → 4 (Delete Budget)
1. Select budget to delete
2. Budget removed (transactions unaffected)
```

## Default Categories

The application includes these default categories:
- **Income**: Salary, Freelance
- **Expenses**: Food, Transportation, Entertainment, Utilities, Healthcare, Shopping, Education, Other

You can use any category - the app automatically recognizes new ones.

## Data Storage

All data is automatically saved to the `Data/` directory:
- **transactions.csv**: All transaction records
- **budgets.csv**: All budget records
- **report.txt**: Generated when you export

These files are human-readable CSV format (editable in Excel/notepad if needed).

## Sample Data Entry

### Creating a Sample Month of Data

**Step 1: Add Income**
```
Amount: 3000.00, Category: Salary, Description: Monthly Salary
```

**Step 2: Add Typical Expenses**
```
Food:           $120.00 (Groceries)
Transportation: $80.00  (Gas)
Entertainment:  $50.00  (Movie ticket)
Utilities:      $100.00 (Electric bill)
Shopping:       $200.00 (Clothes)
Healthcare:     $50.00  (Pharmacy)
Other:          $30.00  (Miscellaneous)
```

**Step 3: Create Budgets**
```
Food:          $500.00
Transportation:$300.00
Entertainment: $150.00
Utilities:     $200.00
Shopping:      $500.00
Healthcare:    $100.00
```

**Step 4: View Summary**
```
See your financial health:
- Income: $3,000.00
- Expenses: $630.00
- Balance: $2,370.00
- Budget Status: All within limits
```

## Tips & Tricks

### 💡 Input Tips
- **Dates**: Use format `yyyy-MM-dd` (e.g., 2024-01-15)
- **Amounts**: Use decimal format (e.g., 100.50)
- **Text**: Keep descriptions clear and concise
- **Categories**: You can use custom names (not limited to defaults)

### 💡 Budget Tips
- Set realistic monthly limits
- Review budgets quarterly
- The app warns when approaching limits
- Exceeded budgets show "EXCEEDED" status

### 💡 Organization Tips
- Use consistent category names (the app is case-sensitive)
- Update descriptions for easy searching
- Export monthly reports for record-keeping
- Clear old test data before using for real

### 💡 Analysis Tips
- View category breakdown to identify spending patterns
- Check monthly summaries for trends
- Monitor which categories exceed budgets
- Use reports for future planning

## Troubleshooting

### "Input cannot be empty"
- You pressed Enter without typing
- Solution: Type a value and press Enter

### "Please enter a valid decimal number"
- You entered text instead of a number
- Solution: Use format like 100 or 100.50

### "Date cannot be in the future"
- You entered a date that hasn't occurred yet
- Solution: Use today's date or a past date

### "Budget for [Category] already exists"
- You tried to create a budget for an existing category
- Solution: Update the existing budget instead

### "Transaction [ID] not found"
- The ID you entered doesn't exist
- Solution: View transactions first to see valid IDs

### "No transactions found"
- You haven't added any transactions yet
- Solution: Add some income/expense transactions first

### Data directory issues
- The `Data/` folder is created automatically
- If you delete it, the app recreates it on next run
- All data files will be reset

## Keyboard Shortcuts

| Action | Key |
|--------|-----|
| Menu Selection | Type number (1-5) + Enter |
| Navigate Back | Type "6" or go back through menus |
| Exit Program | Main Menu → 5 → Exit |
| Continue | Press any key |

## File Locations

```
c:\Users\hp\OneDrive\Desktop\cse310-w4-fin\PersonalFinanceManager\
├── bin/
│   └── Debug/net6.0/
│       └── PersonalFinanceManager.exe    (Executable)
├── Data/                                  (Auto-created)
│   ├── transactions.csv
│   ├── budgets.csv
│   └── report.txt
├── Models/
│   ├── Transaction.cs
│   └── Budget.cs
├── Services/
│   ├── InputValidator.cs
│   ├── FileService.cs
│   ├── FinanceCalculator.cs
│   └── FinanceManager.cs
├── Program.cs
├── PersonalFinanceManager.csproj
├── README.md
├── PROJECT_SUMMARY.md
└── QUICKSTART.md
```

## Typical Usage Flow

```
1. START → dotnet run
   ↓
2. CREATE BUDGETS → Set spending limits
   ↓
3. ADD INCOME → Record paychecks
   ↓
4. ADD EXPENSES → Track daily spending
   ↓
5. MONITOR BUDGETS → Check vs actual
   ↓
6. VIEW SUMMARY → Analyze finances
   ↓
7. EXPORT REPORT → Keep records
   ↓
8. EXIT → Save and close
```

## Performance Notes

- Application loads data on startup
- Saves changes immediately to files
- Handles thousands of transactions efficiently
- CSV files are text-based (human-readable)
- No database required - works offline

## Features You Can Explore

✅ Add/View/Delete Transactions
✅ Add/Update/Delete Budgets
✅ Track spending by category
✅ Generate financial reports
✅ Export transaction records
✅ Analyze spending patterns
✅ Monitor budget status
✅ Calculate averages and totals

## Next Steps

1. **Get Familiar**: Run the app and explore menus
2. **Add Test Data**: Create sample transactions
3. **Set Budgets**: Create category limits
4. **Monitor**: Check summaries regularly
5. **Analyze**: Review spending patterns
6. **Plan**: Adjust budgets as needed

## Support & Documentation

- **Full Documentation**: See README.md
- **Technical Details**: See PROJECT_SUMMARY.md
- **Code Files**: Check Models/ and Services/ folders
- **Data Files**: Check Data/ folder for CSV records

## Getting Help

If you encounter issues:
1. Check the error message
2. Review the Troubleshooting section above
3. Verify input format (see Tips & Tricks)
4. Check that Data/ directory exists
5. Review README.md for detailed documentation

---

**Ready to manage your finances?** Type `dotnet run` and start tracking!

Happy personal finance management! 📊💰
