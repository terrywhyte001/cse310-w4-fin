# Personal Finance Manager - Testing Guide

## 🧪 Comprehensive Testing Guide

This guide provides structured test cases to verify all functionality of the Personal Finance Manager application.

## Pre-Test Checklist

- [ ] Application builds successfully (`dotnet build`)
- [ ] No compilation errors
- [ ] Data/ directory exists or will be created
- [ ] .NET 6.0 or later is installed

## Test Scenarios

### Phase 1: Application Launch & Basic UI

**Test 1.1: Application Startup**
```
GIVEN:  User runs "dotnet run"
WHEN:   Application starts
THEN:   
  ✓ Welcome banner displays
  ✓ Main menu shows 5 options
  ✓ Prompt asks for user input
```

**Test 1.2: Menu Navigation**
```
GIVEN:  Main menu is displayed
WHEN:   User enters "1" then "6"
THEN:   
  ✓ Submenu opens
  ✓ User can navigate back to main menu
  ✓ No errors occur
```

**Test 1.3: Invalid Menu Choice**
```
GIVEN:  Main menu is displayed
WHEN:   User enters invalid choice (e.g., "9" or "abc")
THEN:   
  ✓ Error message displays: "Invalid choice"
  ✓ Menu redisplays
  ✓ User can retry
```

---

### Phase 2: Input Validation

**Test 2.1: Decimal Input Validation - Valid**
```
GIVEN:  Application prompts for decimal amount
WHEN:   User enters valid decimal: "100.50"
THEN:   
  ✓ Input accepted
  ✓ Proceeds to next step
```

**Test 2.2: Decimal Input Validation - Invalid**
```
GIVEN:  Application prompts for decimal amount
WHEN:   User enters invalid input: "abc"
THEN:   
  ✓ Error: "Please enter a valid decimal number"
  ✓ Prompt repeats
  ✓ User can retry
```

**Test 2.3: Decimal Input - Negative Value**
```
GIVEN:  Application prompts for amount (must be positive)
WHEN:   User enters negative: "-50"
THEN:   
  ✓ Error: "Amount must be between X and Y"
  ✓ Prompt repeats
```

**Test 2.4: String Input - Empty**
```
GIVEN:  Application prompts for text (e.g., description)
WHEN:   User presses Enter without typing
THEN:   
  ✓ Error: "Input cannot be empty"
  ✓ Prompt repeats
```

**Test 2.5: String Input - Too Long**
```
GIVEN:  Application prompts for string with max 100 chars
WHEN:   User enters >100 characters
THEN:   
  ✓ Error: "Input length must be between..."
  ✓ Prompt repeats
```

**Test 2.6: Date Input - Future Date**
```
GIVEN:  Application prompts for date
WHEN:   User enters future date: "2099-01-01"
THEN:   
  ✓ Error: "Date cannot be in the future"
  ✓ Prompt repeats
```

**Test 2.7: Date Input - Valid Format**
```
GIVEN:  Application prompts for date
WHEN:   User enters valid: "2024-01-15"
THEN:   
  ✓ Input accepted
  ✓ Proceeds to next step
```

**Test 2.8: Date Input - Default (Empty)**
```
GIVEN:  Application prompts for date
WHEN:   User presses Enter without input
THEN:   
  ✓ Current date is used
  ✓ Proceeds to next step
```

---

### Phase 3: Transaction Management

**Test 3.1: Add Income Transaction**
```
GIVEN:  In Transaction Menu → Add Income
WHEN:   
  - Select Category: "Salary"
  - Description: "Monthly Salary"
  - Amount: "3000.00"
  - Date: "2024-01-15"
THEN:   
  ✓ Success message: "Income of $3000.00 added successfully!"
  ✓ Data saved to file
  ✓ Can view in transaction list
```

**Test 3.2: Add Expense Transaction**
```
GIVEN:  In Transaction Menu → Add Expense
WHEN:   
  - Select Category: "Food"
  - Description: "Groceries"
  - Amount: "50.50"
  - Date: "2024-01-16"
THEN:   
  ✓ Success message: "Expense of $50.50 added successfully!"
  ✓ Budget for Food updated (if exists)
  ✓ Data saved to file
```

**Test 3.3: Add Transaction with Custom Category**
```
GIVEN:  In Add Expense, select category
WHEN:   User enters new category (not in defaults)
THEN:   
  ✓ Custom category accepted
  ✓ Transaction created
  ✓ Category available for future use
```

**Test 3.4: View All Transactions**
```
GIVEN:  In Transaction Menu → View All Transactions
WHEN:   Transactions exist in system
THEN:   
  ✓ All transactions display in table format
  ✓ Each transaction shows: ID, Date, Type, Category, Description, Amount
  ✓ Summary shows Total Income
  ✓ Summary shows Total Expenses
  ✓ Summary shows Balance
```

**Test 3.5: View Transactions by Category**
```
GIVEN:  In Transaction Menu → View by Category
WHEN:   
  - Select Category: "Food"
  - Food transactions exist
THEN:   
  ✓ Only Food transactions display
  ✓ Total shown for category
  ✓ Correct filtering applied
```

**Test 3.6: Delete Transaction**
```
GIVEN:  In Transaction Menu → Delete Transaction
WHEN:   
  - Transaction ID 1 exists
  - User enters ID: "1"
THEN:   
  ✓ Success: "Transaction deleted successfully!"
  ✓ Transaction no longer in view list
  ✓ Budget updated if was expense
  ✓ Data persisted to file
```

**Test 3.7: Delete Nonexistent Transaction**
```
GIVEN:  In Transaction Menu → Delete Transaction
WHEN:   User enters invalid ID: "999"
THEN:   
  ✓ Error: "Transaction 999 not found"
  ✓ Menu remains available
```

**Test 3.8: Transaction Persistence**
```
GIVEN:  Transactions added to system
WHEN:   
  - Add multiple transactions
  - Exit application
  - Restart application
THEN:   
  ✓ All transactions still present
  ✓ Data loaded from CSV
  ✓ Nothing lost
```

---

### Phase 4: Budget Management

**Test 4.1: Create Budget**
```
GIVEN:  In Budget Menu → Create Budget
WHEN:   
  - Select Category: "Food"
  - Limit: "500.00"
THEN:   
  ✓ Success: "Budget for Food created successfully!"
  ✓ Budget visible in list
  ✓ Saved to budget file
```

**Test 4.2: Create Duplicate Budget**
```
GIVEN:  Budget for "Food" exists
WHEN:   Try to create another "Food" budget
THEN:   
  ✓ Error: "Budget for 'Food' already exists"
  ✓ Cannot create duplicate
```

**Test 4.3: View All Budgets**
```
GIVEN:  In Budget Menu → View All Budgets
WHEN:   Budgets exist
THEN:   
  ✓ All budgets display in table
  ✓ Shows: Category, Limit, Spent, Remaining, %Spent, Status
  ✓ Status shows "OK" or "EXCEEDED"
```

**Test 4.4: Budget with Expenses**
```
GIVEN:  
  - Budget created: Food = $500
  - Expense added: Food = $100
WHEN:   View budgets
THEN:   
  ✓ Spent: $100.00
  ✓ Remaining: $400.00
  ✓ %Spent: 20.0%
  ✓ Status: OK
```

**Test 4.5: Budget Exceeded**
```
GIVEN:  
  - Budget created: Food = $100
  - Expense added: Food = $150
WHEN:   View budgets
THEN:   
  ✓ Spent: $150.00
  ✓ Remaining: -$50.00
  ✓ %Spent: 150.0%
  ✓ Status: EXCEEDED
```

**Test 4.6: Update Budget**
```
GIVEN:  Budget for Food = $500 exists
WHEN:   
  - Select Budget: Food
  - New Limit: "600.00"
THEN:   
  ✓ Budget updated to $600
  ✓ Previous expenses retained
  ✓ Changes persisted
```

**Test 4.7: Delete Budget**
```
GIVEN:  Budget for Food exists
WHEN:   Delete Food budget
THEN:   
  ✓ Success: "Budget deleted successfully!"
  ✓ Budget no longer in view
  ✓ Transactions unaffected
  ✓ Changes persisted
```

---

### Phase 5: Financial Calculations

**Test 5.1: Financial Summary - Basic**
```
GIVEN:  
  - Income: $3000
  - Expenses: $500
WHEN:   View Financial Summary
THEN:   
  ✓ Total Income: $3000.00
  ✓ Total Expenses: $500.00
  ✓ Net Balance: $2500.00
```

**Test 5.2: Financial Summary - Multiple Incomes**
```
GIVEN:  
  - Income 1: $3000 (Salary)
  - Income 2: $500 (Freelance)
  - Expenses: $200
WHEN:   View Financial Summary
THEN:   
  ✓ Total Income: $3500.00
  ✓ Net Balance: $3300.00
```

**Test 5.3: Summary Shows Categories**
```
GIVEN:  
  - Expenses in multiple categories
  - Budgets created for each
WHEN:   View Financial Summary
THEN:   
  ✓ Budget status shown for each category
  ✓ Top spending categories listed
  ✓ Exceeded budgets marked
```

**Test 5.4: Empty System Summary**
```
GIVEN:  New system with no transactions
WHEN:   View Financial Summary
THEN:   
  ✓ All totals show: $0.00
  ✓ No errors
  ✓ "No transactions found" messages as appropriate
```

---

### Phase 6: Reports & Exports

**Test 6.1: Export Transaction Report**
```
GIVEN:  
  - Multiple transactions exist
  - In Reports Menu → Export Report
WHEN:   Choose Export option
THEN:   
  ✓ Success: "Report exported to Data/report.txt"
  ✓ File created in Data/ directory
  ✓ Contains all transactions
```

**Test 6.2: Report Content Verification**
```
GIVEN:  Report file generated
WHEN:   Open Data/report.txt
THEN:   
  ✓ Report header shows
  ✓ Generated timestamp included
  ✓ All transactions listed
  ✓ Totals calculated and shown
```

**Test 6.3: Category Breakdown Report**
```
GIVEN:  
  - Expenses in Food ($100), Transport ($50), etc.
  - In Reports → View Category Breakdown
WHEN:   View report
THEN:   
  ✓ Categories listed with amounts
  ✓ Highest spenders first
  ✓ Total expenses shown
```

**Test 6.4: Empty Report Export**
```
GIVEN:  No transactions exist
WHEN:   Export report
THEN:   
  ✓ Report created successfully
  ✓ Contains: "No transactions found"
  ✓ No errors
```

---

### Phase 7: File Operations

**Test 7.1: Data Directory Creation**
```
GIVEN:  Fresh run, no Data/ directory
WHEN:   Application starts
THEN:   
  ✓ Data/ directory auto-created
  ✓ transactions.csv initialized with header
  ✓ budgets.csv initialized with header
```

**Test 7.2: Data Persistence - Transactions**
```
GIVEN:  Transactions added and saved
WHEN:   
  - Exit application
  - Reopen application
THEN:   
  ✓ All transactions still present
  ✓ Data read from transactions.csv
  ✓ No data loss
```

**Test 7.3: Data Persistence - Budgets**
```
GIVEN:  Budgets created and saved
WHEN:   
  - Exit application
  - Reopen application
THEN:   
  ✓ All budgets still present
  ✓ Spending amounts preserved
  ✓ All details intact
```

**Test 7.4: CSV File Format**
```
GIVEN:  Data has been saved
WHEN:   Open Data/transactions.csv in notepad
THEN:   
  ✓ Format: Id,Date,Type,Category,Description,Amount
  ✓ Each transaction on separate line
  ✓ Readable CSV format
```

---

### Phase 8: Edge Cases & Error Handling

**Test 8.1: Very Large Amount**
```
GIVEN:  In Add Transaction
WHEN:   Enter amount: "999999999.99"
THEN:   
  ✓ Accepted and processed
  ✓ Displayed correctly
  ✓ No overflow errors
```

**Test 8.2: Very Long Description**
```
GIVEN:  In Add Transaction
WHEN:   Enter 100-character description (max)
THEN:   
  ✓ Accepted and saved
  ✓ Displays correctly
  ✓ No truncation
```

**Test 8.3: Special Characters in Description**
```
GIVEN:  In Add Transaction
WHEN:   Enter: "Buy @ Store (50% off)"
THEN:   
  ✓ Special characters preserved
  ✓ Saved correctly to CSV
  ✓ Displayed as entered
```

**Test 8.4: Zero Amount**
```
GIVEN:  In Add Transaction
WHEN:   Enter amount: "0"
THEN:   
  ✓ Error: "Amount must be between 0.01 and..."
  ✓ Minimal accepted amount: $0.01
```

**Test 8.5: Rapid Successive Operations**
```
GIVEN:  Add multiple transactions quickly
WHEN:   Add 10+ transactions in sequence
THEN:   
  ✓ All saved correctly
  ✓ No data corruption
  ✓ IDs assigned sequentially
```

---

### Phase 9: Category Management

**Test 9.1: Default Categories Available**
```
GIVEN:  In Add Transaction
WHEN:   View category list
THEN:   
  ✓ All 10 defaults present:
    - Salary, Freelance, Food, Transportation
    - Entertainment, Utilities, Healthcare, Shopping
    - Education, Other
```

**Test 9.2: Custom Category Creation**
```
GIVEN:  In Add Transaction
WHEN:   Enter new category: "Gifts"
THEN:   
  ✓ Category accepted
  ✓ Available for future transactions
  ✓ Shows in category list next time
```

**Test 9.3: Case Sensitivity**
```
GIVEN:  Categories "Food" and "food" entered
WHEN:   View categories or filter
THEN:   
  ✓ Treated as different categories
  ✓ Both appear in list
  ✓ Transactions filtered accordingly
```

---

### Phase 10: Workflow Tests

**Test 10.1: Complete Monthly Workflow**
```
WORKFLOW:
  1. Add salary income ($3000)
  2. Create budgets for 5 categories
  3. Add 10+ expenses
  4. View summary
  5. Export report
THEN:   
  ✓ All steps complete without error
  ✓ Data correctly calculated
  ✓ Report generated successfully
```

**Test 10.2: Budget Tracking Workflow**
```
WORKFLOW:
  1. Create Food budget ($500)
  2. Add expense ($100)
  3. Check remaining ($400)
  4. Add more expenses
  5. View when exceeded
THEN:   
  ✓ Budget tracking accurate
  ✓ Notifications correct
  ✓ Calculations right
```

**Test 10.3: Data Management Workflow**
```
WORKFLOW:
  1. Add 5 transactions
  2. Create 3 budgets
  3. Delete 1 transaction
  4. Update 1 budget
  5. Exit & restart
THEN:   
  ✓ All changes persisted
  ✓ No data loss
  ✓ System stable
```

---

## Test Results Template

```
TEST RESULT SUMMARY
==================

Date: ___________
Tester: ___________
Platform: Windows / macOS / Linux
.NET Version: ___________

Phase 1: UI & Navigation    [ ] PASS [ ] FAIL
Phase 2: Input Validation   [ ] PASS [ ] FAIL
Phase 3: Transactions       [ ] PASS [ ] FAIL
Phase 4: Budgets            [ ] PASS [ ] FAIL
Phase 5: Calculations       [ ] PASS [ ] FAIL
Phase 6: Reports            [ ] PASS [ ] FAIL
Phase 7: File Operations    [ ] PASS [ ] FAIL
Phase 8: Edge Cases         [ ] PASS [ ] FAIL
Phase 9: Categories         [ ] PASS [ ] FAIL
Phase 10: Workflows         [ ] PASS [ ] FAIL

OVERALL: [ ] PASS [ ] FAIL

Issues Found:
_________________________________
_________________________________
_________________________________

Notes:
_________________________________
_________________________________
```

---

## Acceptance Criteria

✅ **All 10 phases pass**
✅ **No compilation errors**
✅ **No runtime errors**
✅ **Data persists correctly**
✅ **All validations work**
✅ **Reports generate successfully**
✅ **UI is responsive**
✅ **Edge cases handled**
✅ **Calculations accurate**
✅ **User experience smooth**

---

## Performance Testing

**Test**: Add 1000 transactions, then:
- [ ] View all transactions - should load in <1 second
- [ ] Filter by category - should complete in <1 second
- [ ] Generate summary - should complete in <1 second
- [ ] View budgets - should load immediately

---

## Regression Testing

After any code changes:
1. Run all 10 phases again
2. Verify no new issues introduced
3. Check data integrity
4. Confirm backward compatibility

---

## Sign-Off

✅ **Testing Complete**
✅ **All Major Features Verified**
✅ **Application Ready for Use**

---

**Note**: This comprehensive test suite covers all features and edge cases. Success in these tests indicates a fully functional Personal Finance Manager application ready for educational and practical use.
