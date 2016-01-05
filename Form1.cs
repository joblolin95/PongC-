using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace Pong
{
    public partial class Form1 : Form
    {
        #region Data fields
        int count;
        String name;
        Random rand;
        Timer time;
        int startSpeedX; //usually started at 2
        int startSpeedY;
        int speedX;
        int speedY;

        // Beginning coordinates for the paddles and the ball
        int paddleAIX;
        int paddleAIY;
        int paddlePlayerX;
        int paddlePlayerY;
        int ballX;
        int ballY;
        #endregion
        public Form1()
        {
            InitializeComponent();

            // Initialize data fields
            count = 0;
            rand = new Random();
            startSpeedX = rand.Next(2, 10);
            startSpeedY = rand.Next(1, 5);
            speedX = startSpeedX;
            speedY = startSpeedY;

            // Start the timer
            time = new Timer();
            time.Enabled = true;
            time.Interval = 1;
            time.Tick += new EventHandler(timerTick);

            // Make the windows full screen
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.WindowState = FormWindowState.Maximized;

            // Set the beginning coordinates for both paddles and the ball
            paddlePlayerY = (this.Height / 2) - 100;
            paddlePlayerX = this.Left + 20;
            paddlePlayer.Location = new Point(paddlePlayerX, paddlePlayerY);

            paddleAIY = (this.Height / 2) - 100;
            paddleAIX = this.Right - 50;
            paddleAI.Location = new Point(paddleAIX, paddleAIY);

            ballX = this.Width / 2;
            ballY = (this.Height / 2) - 75;
            ball.Location = new Point(ballX, ballY);

            // Set the location of the score counter
            counter.Location = new Point(this.Width / 2, this.Top + 20);

            // Ensure that the message controls are not visible at the beginning of the game.
            EndMessage.Visible = false;
            PauseMsg.Visible = false;
            Scores.Visible = false;
            nameMessage.Visible = false;
            nameBox.Visible = false;

            // Set the locations of the controls
            EndMessage.Location = new Point(this.Width / 2 - 100, this.Height / 2 - 250);
            Scores.Location = new Point(EndMessage.Location.X, EndMessage.Location.Y + 150);
            nameMessage.Location = new Point(this.Width/2, this.Height / 2 + 30);
            nameBox.Location = new Point(this.Width / 2, this.Height / 2);
        }

        void timerTick(object sender, EventArgs e)
        {
            ball.Location = new Point(ball.Location.X + speedX, ball.Location.Y + speedY);
            wallCheck();
            paddleCheck();
            counter.Text = "Score: " + count;
            moveAI();
        }// timerTick

        void wallCheck()
        {
            // check if ball hits lower or upper bound of the window
            if (ball.Location.Y > this.Bottom - 50 || ball.Location.Y < 0)
            {
                speedY = -speedY;
            }
            // check if ball gets past either of the paddles
            else if (ball.Location.X > this.Width - 10 || ball.Location.X < 10)
            {
                time.Enabled = false;
                nameMessage.Visible = true;
                nameBox.Visible = true;              
            }
        }// wallCheck

        void paddleCheck()
        {
            // Check if ball contacts the player's paddle
            if(ball.Bounds.IntersectsWith(paddlePlayer.Bounds) && speedX < 0 || ball.Bounds.Contains(paddlePlayer.Bounds))
            {                
                count++;
                speedY = count % 3 == 0 ? speedY + 3 : speedY;
                speedX = -speedX;
                
            }
            // Check if ball contacts the AI's paddle
            else if (ball.Bounds.IntersectsWith(paddleAI.Bounds) || ball.Bounds.Contains(paddleAI.Bounds))
            {
                speedX = -speedX;
            }
        }// paddleCheck

        // Method to handle the various key presses
        void keyPress(object sender, KeyEventArgs e)
        {
            // Close
            if(e.KeyCode == Keys.Escape) { this.Close(); }
            // Restart
            else if(e.KeyCode == Keys.Space && nameBox.Visible == false)
            {
                ball.Location = new Point(ballX, ballY);
                EndMessage.Visible = false;
                PauseMsg.Visible = false;
                Scores.Visible = false;
                Scores.Text = "High Scores";
                time.Enabled = true;
                count = 0;
                startSpeedX = rand.Next(2, 10);
                startSpeedY = rand.Next(1, 5);
                speedX = startSpeedX;
                speedY = startSpeedY;
            }
            // Pause
            else if(e.KeyCode == Keys.P && nameBox.Visible == false)
            {
                PauseMsg.Visible = true;
                time.Enabled = false;
            }
            // Resume
            else if(e.KeyCode == Keys.R && nameBox.Visible == false)
            {
                PauseMsg.Visible = false;
                time.Enabled = true;
            }
            // Down Arrow
            else if(e.KeyCode == Keys.Down && paddlePlayer.Location.Y + 150 < this.Height)
            {
                paddlePlayer.Location = new Point(paddlePlayer.Location.X, paddlePlayer.Location.Y + paddlePlayer.Height / 2);
            }
            // Up Arrow
            else if (e.KeyCode == Keys.Up && paddlePlayer.Location.Y - 17 > 0)
            {
                paddlePlayer.Location = new Point(paddlePlayer.Location.X, paddlePlayer.Location.Y - paddlePlayer.Height / 2);
            }
        }//keyPress
        

        void moveAI()
        {
            // Ensures that the AI's paddle follows the ball
            if (ball.Location.Y + 100 < this.Height ){
                paddleAI.Location = new Point(paddleAIX, ball.Location.Y);
          }// if
        }

        

        // Event handler for if the Enter Name button is clicked
        private void nameBox_Enter(object sender, EventArgs e)
        {
            // Retrieves and resets the name
            name = nameBox.Text;
            nameBox.Text = "";
            nameBox.Visible = false;
            nameMessage.Visible = false;
            EndMessage.Visible = true;
            Scores.Visible = true;
            EndMessage.Focus();

            if (name != "")
            {
                addToDatabase();
            }// end if
        }

        // Requires: That name is not an empty String
        // Ensures:  if name is not in the database, name and count are put in the database.
        //           else if name is in the database and count is higher than the high score
        //           in the database, the high score for that name is updated using count
        void addToDatabase()
        {
            // Creates database if it doesn't already exist
            if (!File.Exists("pong.db"))
            {
                SQLiteConnection.CreateFile("pong.db");
            }

            // Connects to database
            using (SQLiteConnection conn = new SQLiteConnection("Data Source = pong.db; Version = 3;"))
            {
                // Creates the highScores table if it doesn't already exist
                string sql = @"create table if not exists highScores(
                                    [NAME] text primary key not null,
                                    [HIGH] int not null
                                    );";
                conn.Open();
                SQLiteCommand command = new SQLiteCommand(sql, conn);
                command.ExecuteNonQuery();
                // Counts number of records where NAME = name
                sql = "select count(*) from highScores where NAME = '" + name + "';";
                command.CommandText = sql;
                Int32 num = Convert.ToInt32(command.ExecuteScalar());

                // If name is not in the database, insert a new record into the database using
                // name and count
                if (num == 0)
                {
                    sql = @"insert into highScores values('" + name + "' ," + count + ");";
                }// if
                // Else, update the high score corresponding to name, granted that the high score in the database
                // is lower than count
                else
                {
                    sql = "update highScores set HIGH = " + count + " where NAME = '" + name + "' and HIGH < " + count + ";";
                }
                command.CommandText = sql;
                command.ExecuteNonQuery();
                // Display the top 5 high scores in the database.
                sql = "select * from highScores order by HIGH desc limit 5;";
                command.CommandText = sql;
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Scores.Text += "\n" + reader["NAME"] + "   " + reader["HIGH"];
                    }

                }// reader using
                conn.Close();
            }// database connection using
        }
    }
}
