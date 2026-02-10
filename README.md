<h1>Tic-Tac-Toe Game</h1>
<h2>📋 Project Overview</h2>
<p>
Tic-Tac-Toe Game is a classic two-player game implementation developed in C# using Windows Forms. This project provides both a console-based version and a modern graphical desktop application, demonstrating fundamental programming concepts and GUI development principles.
</p>

<h2>🎯 Project Purpose</h2>
<p>
This project was created as an educational exercise to demonstrate:

Object-oriented programming principles in C#
Windows Forms application development
Game logic implementation
User interface design
Event-driven programming
</p>

<h2>Game Rules</h2>
<ul>
<li>The game is played on a 3x3 grid</li>
<li>Player X always goes first</li>
<li>Players alternate turns</li>
<li>The first player to get 3 marks in a row (horizontal, vertical, or diagonal) wins</li>
<li>If all 9 squares are filled and no player has won, the game is a draw</li>
<li>Red color for Player X</li>
<li>Blue color for Player O</li>
<li>Green highlighting for winning combinations</li>
</ul>

<h2>Game Controls:</h2>

<li>New Game button to restart quickly</li>
<li>Reset Score button to clear statistics</li>
<li>Status Display: Real-time game status and turn indicator</li>
<li>Win Detection: Automatic detection of all winning patterns</li>
<li>Draw Detection: Identifies when the game ends in a tie</li>
<li>User-Friendly: Click-to-play interface with visual feedback</li>

<h2>🛠️ Technologies Used</h2>

<li>Language: C# (.NET Framework 10)</li>
<li>GUI Framework: Windows Forms</li>
<li>Development Environment: Visual Studio 2021</li>
<li>Architecture: Event-driven, object-oriented design</li>

<h2> 📁 Project Structure </h2>

```
TicTacToeGame/
├── Console Version/
│   ├── TicTacToe.cs               # Console game implementation
│   └── README.md                  # Console version documentation
│
├── Desktop Version/
│   ├── TicTacToeGame.cs           # Main game logic and UI
│   ├── TicTacToeGame.Designer.cs  # Windows Forms designer file
│   ├── Program.cs                 # Application entry point
│   └── README_Desktop_English.md  # Desktop version documentation
│
└── Documentation/
    ├── SOLUTION_GUIDE.md          # Troubleshooting guide
    └── RENAMING_GUIDE.md          # File naming conventions
```

<h2>🎨 Design Highlights</h2>

<ul>
<li>Color Scheme</li>
<li>Background: Soft gray (#F0F0F5)</li>
<li>Player X: Red (#E74C3C)</li>
<li>Player O: Blue (#3498DB)</li>
<li>Winning Combination: Green (#2ECC71)</li>
<li>Buttons: Various professional colors for different actions</li>
</ul>

<h2>🎓 Learning Outcomes</h2>

<ul>
<li>This project demonstrates proficiency in:</li>
<li>C# Programming:</li>
<li>Classes and objects</li>
<li>Arrays and matrices (2D arrays)</li>
<li>Methods and event handlers</li>
<li>Conditional logic and loops</li>
<li>String manipulation</li>
</ul>

<ul>
<li>Game Logic:</li>
<li>State management</li>
<li>Win condition checking (rows, columns, diagonals)</li>
<li>Turn-based mechanics</li>
<li>Score tracking</li>
<li>Board validation</li>
</ul>
