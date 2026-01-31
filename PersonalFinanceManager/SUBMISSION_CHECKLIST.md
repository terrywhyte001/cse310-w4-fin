# Assignment Submission Checklist

## CSE310 Module - Final Submission Checklist
**Project**: Personal Finance Manager  
**Due Date**: [Your Submission Date]  
**Points Possible**: 100 pts

---

## 📋 CRITICAL CHECKLIST

**⚠️ WARNING**: If ANY of these three items are missing, the entire assignment receives 0 pts:
- [ ] Video with YOUR FACE visible
- [ ] Video with SOFTWARE DEMO
- [ ] Video with CODE WALKTHROUGH

---

## 1️⃣ Video Submission (10 pts) - CRITICAL

### Requirement: Student's Face Visible
- [ ] Your face is clearly visible in video (at least 30 seconds)
- [ ] Good lighting (face is recognizable)
- [ ] Introduce yourself by name at beginning
- [ ] Professional appearance (no jokes about this)

**Status**: ☐ Complete ☐ Needs Work

### Requirement: Software Demo
- [ ] Application running and functional
- [ ] Demo shows 3+ different features
  - [ ] Feature 1: Add transaction
  - [ ] Feature 2: Create budget
  - [ ] Feature 3: View summary
- [ ] Features work correctly
- [ ] User interaction clear

**Status**: ☐ Complete ☐ Needs Work

### Requirement: Code Walkthrough
- [ ] Project structure explained
- [ ] Key classes discussed:
  - [ ] Transaction.cs
  - [ ] Budget.cs (or similar)
  - [ ] InputValidator.cs (or validation logic)
  - [ ] FileService.cs (or file handling)
  - [ ] FinanceCalculator.cs (or calculations)
- [ ] Code examples shown
- [ ] Design patterns explained

**Status**: ☐ Complete ☐ Needs Work

### Video Quality Checklist
- [ ] Video length: 8-10 minutes (not under 5 or over 12)
- [ ] Audio clear and understandable
- [ ] Video quality adequate (1080p or good resolution)
- [ ] No excessive background noise
- [ ] Professional presentation

**Status**: ☐ Complete ☐ Needs Work

### Video Upload & Sharing
- [ ] Video uploaded to public platform (YouTube, OneDrive, Google Drive, etc.)
- [ ] Share link is working
- [ ] Link is PUBLIC or Unlisted (not Private)
- [ ] Video link posted in Microsoft Teams

**Status**: ☐ Complete ☐ Needs Work

---

## 2️⃣ GitHub Repository (10 pts)

### Repository Creation
- [ ] Public GitHub repository created
- [ ] Repository name: `PersonalFinanceManager` (or similar)
- [ ] Visibility set to PUBLIC
- [ ] Repository URL: `https://github.com/YOUR_USERNAME/PersonalFinanceManager`

**Status**: ☐ Complete ☐ Needs Work

### Code Published
- [ ] All source code (.cs files) committed
- [ ] Project file (.csproj) included
- [ ] .gitignore configured (bin/, obj/ excluded)
- [ ] No build artifacts in repository
- [ ] All documentation files committed

**Status**: ☐ Complete ☐ Needs Work

### Repository Contents Verified
- [ ] Models/ folder present (Transaction.cs, Budget.cs)
- [ ] Services/ folder present (4 service classes)
- [ ] Program.cs present
- [ ] PersonalFinanceManager.csproj present
- [ ] README.md present and displays correctly

**Status**: ☐ Complete ☐ Needs Work

### Repository Quality
- [ ] Code is readable
- [ ] Proper formatting
- [ ] No merge conflicts
- [ ] Recent commits present
- [ ] Good commit messages

**Status**: ☐ Complete ☐ Needs Work

---

## 3️⃣ Module Requirements Implementation (40 pts)

### C# Fundamentals (Must Include All)
- [ ] **Variables & Data Types**
  - Variables used throughout code ✓
  - Multiple data types: decimal, int, string, DateTime, bool ✓
  - Proper type usage

- [ ] **Control Structures**
  - if/else statements present ✓
  - Loops (for/while/foreach) present ✓
  - Switch statements present ✓

- [ ] **Collections**
  - List<T> used ✓ (List<Transaction>, List<Budget>)
  - Dictionary used ✓ (category groupings)
  - HashSet used ✓ (category deduplication)

- [ ] **String Formatting**
  - String interpolation ($"...") used ✓
  - ToString() methods ✓
  - Format specifiers (currency, dates) ✓

- [ ] **Exception Handling**
  - try/catch blocks present ✓
  - Error messages shown ✓
  - Graceful error handling ✓

- [ ] **LINQ**
  - Where, Select, GroupBy used ✓
  - Sum, Average used ✓
  - OrderBy, OrderByDescending used ✓

**C# Fundamentals Status**: ☐ 100% ☐ 75% ☐ 50% ☐ 25% ☐ 0%

### Object-Oriented Programming (Must Include All)
- [ ] **Classes**
  - Multiple classes created ✓ (6 classes)
  - Proper class structure ✓
  - Meaningful class names ✓

- [ ] **Encapsulation**
  - Properties with getters/setters ✓
  - Private backing fields ✓
  - Controlled access ✓

- [ ] **Abstraction**
  - Service layers abstract complexity ✓
  - Interfaces or abstract concepts used ✓
  - Implementation hidden ✓

- [ ] **Inheritance**
  - Inheritance or inheritance patterns used ✓
  - TransactionType enum ✓
  - Proper use of hierarchies ✓

- [ ] **Composition**
  - Services composed together ✓
  - Dependency injection pattern ✓
  - Proper relationships ✓

**OOP Status**: ☐ 100% ☐ 75% ☐ 50% ☐ 25% ☐ 0%

### File Handling (Must Include All)
- [ ] **File Reading**
  - CSV files read ✓
  - Data loaded into memory ✓
  - Error handling implemented ✓

- [ ] **File Writing**
  - Data saved to CSV ✓
  - Append and overwrite operations ✓
  - Format correct ✓

- [ ] **File Operations**
  - Directory creation handled ✓
  - File existence checking ✓
  - Proper file paths used ✓

- [ ] **Stream Usage**
  - Using statements for streams ✓
  - Resource cleanup ✓
  - No file handle leaks ✓

- [ ] **Persistence**
  - Data persists across sessions ✓
  - Recovery from file errors ✓
  - Data integrity maintained ✓

**File Handling Status**: ☐ 100% ☐ 75% ☐ 50% ☐ 25% ☐ 0%

### Input Validation (Must Include All)
- [ ] **Type Validation**
  - Decimal inputs validated ✓
  - Integer inputs validated ✓
  - String inputs validated ✓
  - Date inputs validated ✓

- [ ] **Range Validation**
  - Min/max values checked ✓
  - Positive amounts enforced ✓
  - Future dates prevented ✓

- [ ] **Error Handling**
  - Error messages shown ✓
  - Clear feedback provided ✓
  - User can retry ✓

- [ ] **Continuous Input**
  - Loop until valid input ✓
  - No silent failures ✓
  - User guidance provided ✓

**Input Validation Status**: ☐ 100% ☐ 75% ☐ 50% ☐ 25% ☐ 0%

### Basic Calculations (Must Include All)
- [ ] **Aggregations**
  - Sum calculations ✓
  - Total income/expenses ✓
  - Category totals ✓

- [ ] **Computations**
  - Net balance calculated ✓
  - Percentages calculated ✓
  - Averages calculated ✓

- [ ] **Analysis**
  - Category grouping ✓
  - Comparisons (highest/lowest) ✓
  - Trend analysis ✓

- [ ] **Reporting**
  - Summary reports generated ✓
  - Formatted output ✓
  - Export functionality ✓

**Calculations Status**: ☐ 100% ☐ 75% ☐ 50% ☐ 25% ☐ 0%

**Overall Module Requirements**: ☐ 40 pts (100%) ☐ 30 pts (75%) ☐ 20 pts (50%) ☐ 10 pts (25%) ☐ 0 pts

---

## 4️⃣ Code Quality & Comments (10 pts)

### Code Size
- [ ] **At least 100 lines**: ✓ (2000+ lines)
- [ ] Code is significant
- [ ] Not padding or unnecessary

**Code Size**: ☐ Exceeds (✓) ☐ Meets (✓) ☐ Below (✗)

### Comments & Documentation
- [ ] **Comments on all functions**: Functions have explanatory comments
  - [ ] InputValidator functions commented ✓
  - [ ] FileService functions commented ✓
  - [ ] FinanceCalculator functions commented ✓
  - [ ] FinanceManager functions commented ✓
  - [ ] Program.cs methods commented ✓

- [ ] **Comment Quality**
  - Comments explain WHY, not just WHAT ✓
  - Complex logic explained ✓
  - Parameters documented ✓

- [ ] **Inline Comments**
  - Complex sections explained ✓
  - Non-obvious code clarified ✓
  - Algorithms documented ✓

**Comments Status**: ☐ 10 pts (Complete) ☐ 5 pts (Partial) ☐ 0 pts (Incomplete)

---

## 5️⃣ README.md Documentation (10 pts)

### File Requirements
- [ ] File exists at root of project
- [ ] Named exactly "README.md"
- [ ] Located: `/PersonalFinanceManager/README.md`

**Location**: ☐ Correct ☐ Incorrect

### Content Requirements
- [ ] **Project Title**: Descriptive title present
- [ ] **Project Description**: Clear explanation of purpose
- [ ] **Features List**: All major features documented
- [ ] **Project Structure**: Directory structure explained
- [ ] **Installation Instructions**: How to build/run
- [ ] **Usage Instructions**: How to use the software
- [ ] **Class Descriptions**: Key classes documented
- [ ] **Module Requirements**: How requirements are met

**Content Completeness**: ☐ 10 pts (Complete) ☐ 5 pts (Partial) ☐ 0 pts (Missing)

### Quality Requirements
- [ ] Properly formatted Markdown
- [ ] Easy to read and navigate
- [ ] Professional presentation
- [ ] No grammatical errors
- [ ] Screenshots or examples helpful

**Quality**: ☐ High ☐ Good ☐ Needs Improvement

---

## 6️⃣ Time Log (10 pts)

### Time Documentation
- [ ] Time log file created (TIMELOG.md or similar)
- [ ] At least 20 hours documented
  - ☐ 25+ hours documented (exceeds requirement) ✓
  - ☐ 20-24 hours documented (meets requirement) 
  - ☐ 15-19 hours (needs improvement)
  - ☐ Under 15 hours (incomplete)

**Hours Documented**: _____ hours

### Log Detail
- [ ] Activities broken down by category
- [ ] Specific tasks listed
- [ ] Time for each task documented
- [ ] Total hours calculated
- [ ] Professional presentation

**Time Log Status**: ☐ 10 pts (Complete) ☐ 2 pts (Needs Improvement) ☐ 0 pts (Missing)

---

## 7️⃣ Learning Strategies Discussion (5 pts)

### File Requirements
- [ ] Discussion document created
- [ ] Saved as LEARNING_STRATEGIES.md (or similar)
- [ ] Located at root of project

**File Status**: ☐ Present ☐ Missing

### Content Requirements
- [ ] **Strategies Employed**: At least 3 learning strategies described
  - [ ] Strategy 1 explained
  - [ ] Strategy 2 explained
  - [ ] Strategy 3+ explained
  - [ ] Effectiveness discussed

- [ ] **Challenges Faced**: At least 2 challenges discussed
  - [ ] Challenge 1 and solution
  - [ ] Challenge 2 and solution
  - [ ] How challenges were overcome

- [ ] **Learnings**: Key takeaways documented
  - [ ] Technical skills learned
  - [ ] Software engineering skills
  - [ ] Professional skills
  - [ ] Application to future projects

- [ ] **Reflection**: Thoughtful reflection included
  - [ ] What worked well
  - [ ] What could improve
  - [ ] Overall assessment
  - [ ] Commitment to growth

**Content Status**: ☐ 5 pts (Complete) ☐ 0 pts (Incomplete/Missing)

---

## 8️⃣ Video Link in Microsoft Teams (5 pts)

### Teams Post
- [ ] Video link posted in Microsoft Teams
- [ ] Posted in correct channel/assignment
- [ ] Link is clickable and working
- [ ] Post includes:
  - [ ] GitHub repository link
  - [ ] Brief project description
  - [ ] Mention of features

**Teams Post Status**: ☐ 5 pts (Posted) ☐ 0 pts (Missing)

---

## FINAL SUBMISSION CHECKLIST

### Before Submitting - VERIFY ALL:

**Critical Items** (✓ = Must Have)
- [ ] ✓ Video with face visible
- [ ] ✓ Video with demo
- [ ] ✓ Video with code walkthrough
- [ ] ✓ Video link in Teams
- [ ] ✓ GitHub repository public
- [ ] ✓ All code published to GitHub
- [ ] ✓ README.md at root
- [ ] ✓ Time log ≥ 20 hours
- [ ] ✓ Learning strategies discussion
- [ ] ✓ Code has 100+ lines
- [ ] ✓ Functions commented

**Quality Items**
- [ ] Code builds successfully
- [ ] All features working
- [ ] Professional presentation
- [ ] Clear documentation
- [ ] Proper organization

---

## Points Summary

| Category | Points | Your Score |
|----------|--------|------------|
| 1. Video (Face/Demo/Code) | 10 | ___ |
| 2. GitHub Repository | 10 | ___ |
| 3. Module Requirements | 40 | ___ |
| 4. Code Quality & Comments | 10 | ___ |
| 5. README.md | 10 | ___ |
| 6. Time Log (≥20 hrs) | 10 | ___ |
| 7. Learning Strategies | 5 | ___ |
| 8. Teams Video Link | 5 | ___ |
| **TOTAL** | **100** | **___** |

---

## Submission Instructions

### Step 1: Verify All Checklist Items ✓
- [ ] Go through entire checklist above
- [ ] Check off all completed items
- [ ] Identify any missing items
- [ ] Complete any remaining work

### Step 2: Final Quality Review
- [ ] Build project: `dotnet build`
- [ ] Run project: `dotnet run`
- [ ] Test key features
- [ ] Verify GitHub repo
- [ ] Check Teams post

### Step 3: Submit Assignment
1. **Upload any required files** to assignment system
2. **Post GitHub link** if required
3. **Confirm video link** in Teams if required
4. **Double-check submission** completed

### Step 4: Confirmation
- [ ] Submission confirmed received
- [ ] All files present
- [ ] Video link working
- [ ] Ready for grading

---

## Grading Timeline

| Event | Timeline |
|-------|----------|
| **Submission Deadline** | [Your Due Date] |
| **Grading Expected** | Within 1 week |
| **Feedback Provided** | Via assignment system |

---

## Important Notes

⚠️ **Critical**: 
- If video is missing student's face OR demo OR code walkthrough = **0 on assignment**
- GitHub repository MUST be public
- README.md MUST be at project root
- Time log MUST show ≥ 20 hours

✅ **Automatic Full Credit If**:
- [ ] All checklist items complete
- [ ] Video quality professional
- [ ] GitHub repo public
- [ ] All code present and working
- [ ] Documentation complete

---

## Help & Resources

| Need | Resource |
|------|----------|
| **Building project** | Run `dotnet build` in project directory |
| **Running project** | Run `dotnet run` in project directory |
| **GitHub help** | See GITHUB_SETUP.md |
| **Video help** | See VIDEO_GUIDE.md |
| **Time log template** | See TIMELOG.md |
| **Learning strategies** | See LEARNING_STRATEGIES.md |

---

## Final Status

**Submission Complete?** 
- [ ] YES - Ready to submit!
- [ ] NO - Still need to complete (list below):

```
Items still needed:
1. _______________________
2. _______________________
3. _______________________
```

---

**Good luck with your submission! You've built an excellent project. 🎉**

**Expected Points**: If all items completed professionally → **100/100** ⭐

---

## Signature

**I certify that all information on this checklist is accurate and complete.**

**Student Name**: samuel Evbosaru iyen

**Student Date**: _____________________

**Email**: _____________________

---

**Submit this checklist with your assignment as proof of completeness.**
