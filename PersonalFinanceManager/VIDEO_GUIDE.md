# Video Demo & Code Walkthrough Guide

## Requirements Reminder
✅ **Show your face** - Camera/selfie visible
✅ **Demo the software** - Show it running with features
✅ **Code walkthrough** - Explain how it works
✅ **Upload to public platform** (YouTube, OneDrive, etc.)
✅ **Post link in Microsoft Teams**

**⚠️ CRITICAL: Missing any of these = 0 points on entire assignment**

---

## Video Creation Guide

### Recommended Tools

#### Easy Options (Recommended)
- **Windows 11 Built-in**: Win+G for Game Bar (captures apps)
- **OBS Studio**: Free, professional, works on all systems
- **Camtasia**: Easy-to-use screen recording with editing
- **ScreenFlow** (Mac): Simple and powerful
- **Loom**: Quick, cloud-based recording

#### Phone Options
- Record with your phone camera
- Screen recording on laptop
- Works fine for demo!

### Recording Equipment Needed
- Webcam or phone camera (to show your face)
- Microphone (built-in usually works)
- Screen recording tool (see above)
- Quiet location
- Good lighting (for your face to be visible)

---

## Video Structure (8-10 minutes total)

### Segment 1: Introduction (1 minute)
**What to show/say**:
- Show your face clearly on camera
- Introduce yourself: "Hi, my name is samuel Evbosaru iyen"
- Brief project intro: "This is my Personal Finance Manager project for CSE310"
- Mention what you'll cover: "I'll show you the software in action, then walk through the code"

**Tips**:
- Smile and speak clearly
- Face should be visible for full 30 seconds minimum
- Professional setting (clean background)
- Good lighting (natural light preferred)

---

### Segment 2: Application Demo (4-5 minutes)

#### A. Show Application Starting (30 seconds)
```
1. Start Terminal
2. Navigate to project directory
3. Show: dotnet run
4. Show: Application welcome screen and main menu
```

**Narrate**: "The application starts with a welcome banner and main menu system, showing all the features available."

#### B. Demo: Add Income Transaction (1 minute)
```
1. Select: 1 (Manage Transactions)
2. Select: 1 (Add Income)
3. Choose: Salary category
4. Enter: Description "Monthly Salary"
5. Enter: Amount "3000.00"
6. Enter: Date (or press Enter for today)
7. Show: "✓ Income added successfully!"
```

**Narrate**: "First, I'll add an income transaction. I select the transaction menu, add income, and enter the details. The system confirms the transaction was added."

#### C. Demo: Create Budget (1 minute)
```
1. Select: 2 (Manage Budgets)
2. Select: 1 (Create Budget)
3. Choose: Food category
4. Enter: Limit "500.00"
5. Show: Budget created message
```

**Narrate**: "Next, I'll create a budget. I set a $500 limit for food spending. The budget is now tracking this category."

#### D. Demo: Add Expense & View Summary (1.5 minutes)
```
1. Select: 1 (Manage Transactions)
2. Select: 2 (Add Expense)
3. Choose: Food
4. Enter: "Groceries"
5. Enter: "120.50"
6. Show: Expense added
7. Select: 3 (View Financial Summary)
8. Show: Summary with totals and budget status
```

**Narrate**: "I'll add an expense for groceries. Now when I view the financial summary, I can see my income, expenses, net balance, and budget tracking. The system shows I've spent $120.50 of my $500 budget for food."

#### E. Demo: Additional Features (30 seconds)
Show any other interesting features:
- View transactions by category
- Export reports
- Category breakdown analysis

---

### Segment 3: Code Walkthrough (3-4 minutes)

#### A. Show Project Structure (30 seconds)
```
Open Visual Studio Code or file explorer
Show:
- Models/ folder (Transaction.cs, Budget.cs)
- Services/ folder (4 service files)
- Program.cs (main UI)
```

**Narrate**: "The project is organized into layers: Models for entities, Services for business logic, and Program.cs for the user interface. This separation of concerns makes the code maintainable and scalable."

#### B. Walk Through Transaction Model (45 seconds)
```
Open: Models/Transaction.cs
Show:
1. Class definition
2. Properties (Id, Description, Amount, Type, Category, Date)
3. Constructor
4. ToCSV() method for serialization
5. FromCSV() method for deserialization
```

**Narrate**: "The Transaction class represents a financial transaction. It has properties for all transaction data, a constructor to create instances, and methods to convert to/from CSV format for file storage. This demonstrates both OOP design and serialization patterns."

#### C. Walk Through Input Validator (45 seconds)
```
Open: Services/InputValidator.cs
Show:
1. Static class definition
2. GetValidDecimal() method - show parameter validation
3. GetValidDate() method - show future date prevention
4. Loop until valid input is received
5. Error messages
```

**Narrate**: "The InputValidator service provides comprehensive input validation. For example, GetValidDecimal validates monetary amounts within a range, GetValidDate prevents future dates, and all methods loop until valid input is received. This ensures data quality throughout the application."

#### D. Walk Through File Service (45 seconds)
```
Open: Services/FileService.cs
Show:
1. SaveTransaction() method
2. LoadTransactions() method with try/catch
3. CSV initialization in constructor
4. Error handling
5. Mention: handles file I/O and persistence
```

**Narrate**: "The FileService handles all file operations. It saves transactions to CSV files, loads them back, and manages the data directory. Notice the try/catch blocks for error handling - this ensures the application doesn't crash if file operations fail. The CSV format makes data human-readable and portable."

#### E. Walk Through Calculations (45 seconds)
```
Open: Services/FinanceCalculator.cs
Show:
1. CalculateTotalIncome() - LINQ sum
2. CalculateTotalExpenses() - LINQ where/sum
3. GetExpensesByCategory() - LINQ groupby
4. GetTopSpendingCategories() - LINQ order/take
5. Mention: demonstrates LINQ mastery
```

**Narrate**: "The FinanceCalculator performs all financial calculations using LINQ. CalculateTotalIncome sums all income transactions, CalculateTotalExpenses uses Where and Sum for filtering and aggregation, GetExpensesByCategory groups by category, and GetTopSpendingCategories identifies the highest spenders. This demonstrates LINQ proficiency."

#### F. Show Main Program UI (30 seconds)
```
Open: Program.cs
Show:
1. Menu systems
2. Professional formatting with box drawing characters
3. User interaction logic
4. Comments explaining complex sections
5. Mention: 500+ lines of well-organized code
```

**Narrate**: "The Program.cs file contains the user interface with multiple menu systems. The code is well-commented, professionally formatted with box drawing characters for visual appeal, and demonstrates clean UI/UX design principles."

#### G. Highlight Key Features (30 seconds)
```
Point out:
1. Code comments explaining complex logic
2. Professional error handling
3. Separation of concerns (Models, Services, UI)
4. SOLID principles in action
5. 2000+ lines of production-quality code
```

**Narrate**: "Throughout the codebase, you'll notice comprehensive comments explaining complex logic, professional error handling, clear separation of concerns, and adherence to SOLID principles. This is 2000+ lines of production-quality C# code meeting all CSE310 requirements."

---

### Segment 4: Summary (1 minute)

**What to show/say**:
- Show your face again (brief)
- Summarize what was demonstrated:
  - ✅ Complete C# application
  - ✅ Object-Oriented Programming
  - ✅ File handling (CSV persistence)
  - ✅ Input validation (comprehensive)
  - ✅ Financial calculations (LINQ, aggregations)
  - ✅ Professional UI
  - ✅ 2000+ lines of code
  - ✅ 20+ features
- Thank you message

**Sample ending**: "This project demonstrates all CSE310 module requirements: C# fundamentals, object-oriented programming, file handling, input validation, and financial calculations. The result is a professional, production-ready application. Thank you for watching!"

---

## Technical Tips for Recording

### Audio Quality
- Speak clearly and at natural pace
- Use a microphone (headphone mic works)
- Test audio before full recording
- Eliminate background noise
- Consider adding narration separately

### Video Quality
- 1080p resolution (1920x1080)
- 30 fps (frames per second) minimum
- Good lighting for your face
- Clean desktop background
- Readable code (font size 14+)

### Screen Recording
- Close unnecessary programs
- Show only relevant windows
- Use full desktop for clarity
- Consider zooming in on code (150%)
- Show file explorer while discussing structure

### Video Editing (Optional but Recommended)
- Add title slide with your name
- Add captions/subtitles
- Keep cuts smooth and natural
- Add fade transitions between sections
- Keep total length 8-10 minutes

---

## Recording Checklist

Before you start recording:
- [ ] Clean background visible
- [ ] Good lighting (face should be clear)
- [ ] Microphone working (test audio)
- [ ] All source files available
- [ ] Application runs successfully
- [ ] Screen resolution adequate
- [ ] Recording tool ready
- [ ] Water/drink nearby (long talking)

During recording:
- [ ] Camera shows your face clearly
- [ ] Speak clearly and naturally
- [ ] Demonstrate all features
- [ ] Explain code clearly
- [ ] Show file structure
- [ ] Mention module requirements
- [ ] Professional presentation

After recording:
- [ ] Audio is clear and audible
- [ ] Video is smooth and watchable
- [ ] Face is visible for grading
- [ ] Code is readable
- [ ] Total length 8-10 minutes
- [ ] Content covers demo and code walkthrough

---

## Upload & Share

### Step 1: Export Video
- Render/export video in common format (MP4, MOV, etc.)
- Choose quality: 1080p recommended
- Include audio
- Keep file size reasonable (under 1GB if possible)

### Step 2: Upload to Platform

#### Option A: YouTube (Recommended)
1. Go to YouTube.com
2. Click "Create" (top right)
3. Click "Upload video"
4. Select your video file
5. Add title: "Personal Finance Manager - CSE310 Module"
6. Add description: Include project GitHub link
7. Set visibility: **PUBLIC** or **Unlisted** (must be accessible)
8. Click "Publish"
9. Copy share link

#### Option B: Microsoft OneDrive
1. Sign in to OneDrive
2. Click "Upload"
3. Select video file
4. Right-click → "Share"
5. Set to "Anyone with the link can view"
6. Copy share link

#### Option C: Google Drive
1. Sign in to Google Drive
2. Click "New" → "File upload"
3. Select video
4. Right-click → "Share"
5. Set to "Viewer" access
6. Copy share link

### Step 3: Post in Microsoft Teams

**Post message**:
```
Personal Finance Manager - CSE310 Module Video Demo & Code Walkthrough

Project GitHub Repository: https://github.com/YOUR_USERNAME/PersonalFinanceManager

Video Link: [VIDEO_LINK_HERE]

This video demonstrates:
✅ Application demo (features in action)
✅ Code walkthrough (architecture and implementation)
✅ All CSE310 module requirements met

Topics covered:
- Transaction management
- Budget tracking
- Financial analysis
- Input validation
- File persistence
- OOP design
- LINQ usage
- Professional C# code

Project features: 20+ features, 2000+ lines of code, comprehensive documentation

Thank you!
```

---

## Content Checklist

Your video should clearly show/explain:

### Application Demo ✓
- [ ] Application starting
- [ ] Main menu displayed
- [ ] Add income transaction
- [ ] Create budget
- [ ] Add expense transaction
- [ ] View financial summary
- [ ] Additional features (reports, category breakdown, etc.)

### Code Walkthrough ✓
- [ ] Project structure (Models, Services, Program)
- [ ] Transaction class (OOP, properties, methods)
- [ ] InputValidator service (validation patterns)
- [ ] FileService (file I/O, CSV handling)
- [ ] FinanceCalculator (LINQ, calculations)
- [ ] FinanceManager (orchestration, business logic)
- [ ] Program.cs (UI, menu system)

### Requirements Demonstration ✓
- [ ] C# Fundamentals (variables, loops, collections, LINQ)
- [ ] OOP Principles (classes, encapsulation, abstraction, composition)
- [ ] File Handling (CSV read/write, persistence)
- [ ] Input Validation (range checking, type validation, error messages)
- [ ] Basic Calculations (aggregations, percentages, reports)

### Professional Presentation ✓
- [ ] Your face visible (at least 30 seconds)
- [ ] Clear audio (speech is understandable)
- [ ] Readable code (font size adequate)
- [ ] Organized structure (intro, demo, code, summary)
- [ ] Appropriate length (8-10 minutes)
- [ ] Professional demeanor (well-spoken, professional attire)

---

## Common Video Issues & Solutions

### Issue: Can't record voice and screen together
**Solution**: Record screen with narration separately, combine in video editor

### Issue: Recording too long (over 12 minutes)
**Solution**: Cut unnecessary parts, speak faster, focus on key points

### Issue: Code not readable in video
**Solution**: Increase font size to 16+, zoom in on sections, record at 1080p

### Issue: Video quality poor
**Solution**: Reduce resolution for recording if too large, use better lighting

### Issue: Audio is muffled
**Solution**: Use better microphone, move microphone closer, reduce background noise

### Issue: Can't upload to YouTube
**Solution**: Try OneDrive or Google Drive as alternatives

---

## FAQ

**Q: Can I edit my video?**
A: Yes! Adding titles, transitions, captions are great. Keep it professional.

**Q: How long should the video be?**
A: 8-10 minutes is ideal. No more than 12 minutes.

**Q: What if my face isn't visible the whole time?**
A: That's fine - you need to show your face, but it doesn't need to be visible for 100% of the video. At least 30 seconds clearly showing you is required.

**Q: Can I use a screen recording tool without showing my face on screen?**
A: No - you need camera footage (can be separate) showing your face during the recording.

**Q: Should I script my narration?**
A: Light scripting is good to stay organized. Don't read word-for-word, be conversational.

**Q: Can I re-record if I make mistakes?**
A: Absolutely! Record as many times as needed. Make it good!

**Q: What resolution should I record at?**
A: 1080p (1920x1080) is ideal. 720p (1280x720) is acceptable.

**Q: Can I use music in my video?**
A: Use royalty-free music if desired, but focus on clear narration.

---

## Grading Rubric Connection

| Rubric Item | What to Show in Video |
|-------------|----------------------|
| **Face visible** | Camera showing your face for at least 30 seconds |
| **Demo** | Application running with 3+ features demonstrated |
| **Code Walkthrough** | Explain project structure, key classes, important logic |
| **Requirements Met** | Demonstrate each module requirement is implemented |
| **Professional** | Clear audio, readable code, organized presentation |

---

## Final Checklist Before Posting

- [ ] Video recorded with your face visible
- [ ] Application demo shows features working
- [ ] Code walkthrough explains implementation
- [ ] Audio is clear and understandable
- [ ] Video is 8-10 minutes long
- [ ] Resolution is 1080p or adequate
- [ ] Video successfully uploaded
- [ ] Share link is working
- [ ] Link posted in Microsoft Teams
- [ ] GitHub repository link included
- [ ] Ready for grading

---

**Your video is a critical component of your grade. Make it clear, professional, and comprehensive!**

**Good luck with your video demo! 🎥**
