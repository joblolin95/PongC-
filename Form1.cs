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
            nameBox.Visible = true;
            nameMessage.Visible = true;
       
            count = 0;
            rand = new Random();
            startSpeedX = rand.Next(2, 10);
            startSpeedY = rand.Next(1, 5);
            speedX = startSpeedX;
            speedY = startSpeedY;
            time = new Timer();
            time.Enabled = true;
            time.Interval = 1;
            time.Tick += new EventHandler(timerTick);

            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.WindowState = FormWindowState.Maximized;
            paddlePlayerY = (this.Height / 2) - 100;
            paddlePlayerX = this.Left + 20;
            paddlePlayer.Location = new Point(paddlePlayerX, paddlePlayerY);

            paddleAIY = (this.Height / 2) - 100;
            paddleAIX = this.Right - 50;
            paddleAI.Location = new Point(paddleAIX, paddleAIY);

            ballX = this.Width / 2;
            ballY = (this.Height / 2) - 75;
            ball.Location = new Point(ballX, ballY);

            counter.Location = new Point(this.Width / 2, this.Top + 20);
            EndMessage.Visible = false;
            PauseMsg.Visible = false;
            Scores.Visible = false;
            Scores.Location = new Point(EndMessage.Location.X, EndMessage.Location.Y + 150);
            nameMessage.Location = new Point(this.Width/2, this.Height / 2 + 30);
            nameBox.Location = new Point(this.Width / 2, this.Height / 2);
            nameMessage.Visible = false;
            nameBox.Visible = false;
            
            
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
            if (ball.Location.Y > this.Bottom - 50 || ball.Location.Y < 0)
            {
                speedY = -speedY;
            }
            else if (ball.Location.X > this.Width - 10 || ball.Location.X < 10)
            {
                time.Enabled = false;
                EndMessage.Visible = true;

                if (!File.Exists("pong.db")){
                    SQLiteConnection.CreateFile("pong.db");
                }

                using (SQLiteConnection conn = new SQLiteConnection("Data Source = pong.db; Version = 3;"))
                {
                    string sql = @"create table if not exists highScores(
                                    [ID] INTEGER primary key autoincrement,
                                    [NAME] text not null,
                                    [HIGH] int not null
                                    );";
                    conn.Open();
                    SQLiteCommand command = new SQLiteCommand(sql, conn);
                    command.ExecuteNonQuery();
                    sql = @"insert into highScores values(null, 'Blaine'," + count + ");";
                    command.CommandText = sql;                     
                    command.ExecuteNonQuery();
                    sql = "select * from highScores order by HIGH desc limit 5;";
                    command.CommandText = sql;
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Scores.Text += "\n" + reader["NAME"] + "   " + reader["HIGH"];
                        }

                    }                    
                    conn.Close();
                }
                Scores.Visible = true;
            }
        }// wallCheck

        void paddleCheck()
        {
            if(ball.Bounds.IntersectsWith(paddlePlayer.Bounds) && speedX < 0 || ball.Bounds.Contains(paddlePlayer.Bounds))
            {                
                count++;
                speedY = count % 3 == 0 ? speedY + 3 : speedY;
                speedX = -speedX;
                
            }
            else if (ball.Bounds.IntersectsWith(paddleAI.Bounds) || ball.Bounds.Contains(paddleAI.Bounds))
            {
                speedX = -speedX;
            }
        }// paddleCheck

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
            if (ball.Location.Y + 100 < this.Height ){
                paddleAI.Location = new Point(paddleAIX, ball.Location.Y);
          }// if
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void nameBox_Enter(object sender, EventArgs e)
        {
            name = nameBox.Text;
            nameBox.Text = "";
            nameBox.Visible = false;
            nameMessage.Visible = false;
            Scores.Visible = true;
        }
    }
}
