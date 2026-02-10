using System;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToeGame
{
    public partial class TicTacToeGame : Form
    {
        private Button[,] buttons = new Button[3, 3];
        private char currentPlayer = 'X';
        private Label statusLabel;
        private Button resetButton;
        private int xWins = 0;
        private int oWins = 0;
        private int draws = 0;
        private Label scoreLabel;
        private bool gameOver = false;

        public TicTacToeGame()
        {
            InitializeComponent();
            InitializeGameComponents();
        }

        private void InitializeGameComponents()
        {
            // Window settings
            this.Text = "Tic-Tac-Toe Game";
            this.Size = new Size(450, 600);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 240, 245);

            // Game title
            Label titleLabel = new Label
            {
                Text = "TIC-TAC-TOE",
                Font = new Font("Arial", 24, FontStyle.Bold),
                ForeColor = Color.FromArgb(41, 128, 185),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, 15),
                Size = new Size(434, 40)
            };
            this.Controls.Add(titleLabel);

            // Score board
            scoreLabel = new Label
            {
                Text = $"X: {xWins}  |  O: {oWins}  |  Draws: {draws}",
                Font = new Font("Arial", 12, FontStyle.Regular),
                ForeColor = Color.FromArgb(52, 73, 94),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, 60),
                Size = new Size(434, 25)
            };
            this.Controls.Add(scoreLabel);

            // Game status
            statusLabel = new Label
            {
                Text = "Player X, your turn!",
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(231, 76, 60),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, 95),
                Size = new Size(434, 30)
            };
            this.Controls.Add(statusLabel);

            // Create the 9 board buttons
            int startX = 67;
            int startY = 145;
            int buttonSize = 100;
            int spacing = 10;

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    buttons[row, col] = new Button
                    {
                        Size = new Size(buttonSize, buttonSize),
                        Location = new Point(
                            startX + col * (buttonSize + spacing),
                            startY + row * (buttonSize + spacing)
                        ),
                        Font = new Font("Arial", 36, FontStyle.Bold),
                        BackColor = Color.White,
                        FlatStyle = FlatStyle.Flat,
                        Cursor = Cursors.Hand,
                        Tag = new Point(row, col)
                    };

                    buttons[row, col].FlatAppearance.BorderSize = 2;
                    buttons[row, col].FlatAppearance.BorderColor = Color.FromArgb(189, 195, 199);
                    buttons[row, col].Click += Button_Click;

                    this.Controls.Add(buttons[row, col]);
                }
            }

            // Reset button
            resetButton = new Button
            {
                Text = "New Game",
                Font = new Font("Arial", 12, FontStyle.Bold),
                Size = new Size(200, 45),
                Location = new Point(117, 490),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            resetButton.FlatAppearance.BorderSize = 0;
            resetButton.Click += ResetButton_Click;
            this.Controls.Add(resetButton);

            // Reset score button
            Button resetScoreButton = new Button
            {
                Text = "Reset Score",
                Font = new Font("Arial", 10, FontStyle.Regular),
                Size = new Size(130, 30),
                Location = new Point(152, 540),
                BackColor = Color.FromArgb(149, 165, 166),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            resetScoreButton.FlatAppearance.BorderSize = 0;
            resetScoreButton.Click += (s, e) =>
            {
                xWins = 0;
                oWins = 0;
                draws = 0;
                UpdateScoreLabel();
            };
            this.Controls.Add(resetScoreButton);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (gameOver) return;

            Button clickedButton = (Button)sender;
            
            // Check if the button has already been clicked
            if (!string.IsNullOrEmpty(clickedButton.Text))
                return;

            // Place the current player's mark
            clickedButton.Text = currentPlayer.ToString();
            clickedButton.ForeColor = currentPlayer == 'X' 
                ? Color.FromArgb(231, 76, 60)  // Red for X
                : Color.FromArgb(52, 152, 219); // Blue for O

            // Check for winner
            if (CheckWinner())
            {
                gameOver = true;
                statusLabel.Text = $"🎉 Player {currentPlayer} wins!";
                statusLabel.ForeColor = Color.FromArgb(39, 174, 96);
                
                if (currentPlayer == 'X')
                    xWins++;
                else
                    oWins++;
                
                UpdateScoreLabel();
                HighlightWinningCombination();
                return;
            }

            // Check for draw
            if (IsBoardFull())
            {
                gameOver = true;
                statusLabel.Text = "😐 It's a draw!";
                statusLabel.ForeColor = Color.FromArgb(241, 196, 15);
                draws++;
                UpdateScoreLabel();
                return;
            }

            // Switch player
            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
            statusLabel.Text = $"Player {currentPlayer}, your turn!";
            statusLabel.ForeColor = currentPlayer == 'X'
                ? Color.FromArgb(231, 76, 60)
                : Color.FromArgb(52, 152, 219);
        }

        private bool CheckWinner()
        {
            // Check rows
            for (int row = 0; row < 3; row++)
            {
                if (!string.IsNullOrEmpty(buttons[row, 0].Text) &&
                    buttons[row, 0].Text == buttons[row, 1].Text &&
                    buttons[row, 1].Text == buttons[row, 2].Text)
                {
                    return true;
                }
            }

            // Check columns
            for (int col = 0; col < 3; col++)
            {
                if (!string.IsNullOrEmpty(buttons[0, col].Text) &&
                    buttons[0, col].Text == buttons[1, col].Text &&
                    buttons[1, col].Text == buttons[2, col].Text)
                {
                    return true;
                }
            }

            // Check main diagonal
            if (!string.IsNullOrEmpty(buttons[0, 0].Text) &&
                buttons[0, 0].Text == buttons[1, 1].Text &&
                buttons[1, 1].Text == buttons[2, 2].Text)
            {
                return true;
            }

            // Check secondary diagonal
            if (!string.IsNullOrEmpty(buttons[0, 2].Text) &&
                buttons[0, 2].Text == buttons[1, 1].Text &&
                buttons[1, 1].Text == buttons[2, 0].Text)
            {
                return true;
            }

            return false;
        }

        private void HighlightWinningCombination()
        {
            Color winColor = Color.FromArgb(46, 204, 113);

            // Check rows
            for (int row = 0; row < 3; row++)
            {
                if (!string.IsNullOrEmpty(buttons[row, 0].Text) &&
                    buttons[row, 0].Text == buttons[row, 1].Text &&
                    buttons[row, 1].Text == buttons[row, 2].Text)
                {
                    buttons[row, 0].BackColor = winColor;
                    buttons[row, 1].BackColor = winColor;
                    buttons[row, 2].BackColor = winColor;
                    return;
                }
            }

            // Check columns
            for (int col = 0; col < 3; col++)
            {
                if (!string.IsNullOrEmpty(buttons[0, col].Text) &&
                    buttons[0, col].Text == buttons[1, col].Text &&
                    buttons[1, col].Text == buttons[2, col].Text)
                {
                    buttons[0, col].BackColor = winColor;
                    buttons[1, col].BackColor = winColor;
                    buttons[2, col].BackColor = winColor;
                    return;
                }
            }

            // Check main diagonal
            if (!string.IsNullOrEmpty(buttons[0, 0].Text) &&
                buttons[0, 0].Text == buttons[1, 1].Text &&
                buttons[1, 1].Text == buttons[2, 2].Text)
            {
                buttons[0, 0].BackColor = winColor;
                buttons[1, 1].BackColor = winColor;
                buttons[2, 2].BackColor = winColor;
                return;
            }

            // Check secondary diagonal
            if (!string.IsNullOrEmpty(buttons[0, 2].Text) &&
                buttons[0, 2].Text == buttons[1, 1].Text &&
                buttons[1, 1].Text == buttons[2, 0].Text)
            {
                buttons[0, 2].BackColor = winColor;
                buttons[1, 1].BackColor = winColor;
                buttons[2, 0].BackColor = winColor;
            }
        }

        private bool IsBoardFull()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (string.IsNullOrEmpty(buttons[row, col].Text))
                        return false;
                }
            }
            return true;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            // Clear all buttons
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    buttons[row, col].Text = "";
                    buttons[row, col].BackColor = Color.White;
                }
            }

            // Reset game
            currentPlayer = 'X';
            gameOver = false;
            statusLabel.Text = "Player X, your turn!";
            statusLabel.ForeColor = Color.FromArgb(231, 76, 60);
        }

        private void UpdateScoreLabel()
        {
            scoreLabel.Text = $"X: {xWins}  |  O: {oWins}  |  Draws: {draws}";
        }
    }
}