using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.SQLite;

namespace Pong
{
    public partial class Form1 : Form
    {
        #region Data fields
        int count;
        Random rand;
        Timer time;
        int startSpeed = 10;
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

            speedX = startSpeed;
            speedY = startSpeed;
            count = 0;
            time = new Timer();
            time.Enabled = true;
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

            counter.Location = new Point(this.Width / 2, this.Top + 50);
            EndMessage.Visible = false;
        }

        void timerTick(object sender, EventArgs e)
        {
            ball.Location = new Point(ball.Location.X + speedX, ball.Location.Y + speedY);
            wallCheck();
            paddleCheck();
            counter.Text = "Hits \n " + count;
            moveAI();

        }// timerTick

        void wallCheck()
        {
            if (ball.Location.Y > this.Bottom - 50 || ball.Location.Y < 0)
            {
                speedY = -speedY > 0 ? -speedY - 1 : -speedY + 1;
            }
            else if (ball.Location.X > this.Width - 10 || ball.Location.X < 10)
            {
                ball.Location = new Point(ballX, ballY);
                time.Enabled = false;
                EndMessage.Visible = true;
            }
        }// wallCheck

        void paddleCheck()
        {
            if(ball.Bounds.IntersectsWith(paddlePlayer.Bounds) && speedX < 0)
            {
                //int change = count % 4 == 0 && speedX > 0 ? rand.Next(speedX, speedX * 2) : rand.Next(speedX * 2, speedX);
                //speedX = -speedX - change;
                speedX = count % 4 == 0 && count != 0 ? -speedX * 2 : -speedX;
                count++;
            }
            else if (ball.Bounds.IntersectsWith(paddleAI.Bounds))
            {
                speedX = -speedX;
            }
        }// paddleCheck

        void keyPress(object sender, KeyEventArgs e)
        {
            // Close
            if(e.KeyCode == Keys.Escape) { this.Close(); }
            // Restart
            else if(e.KeyCode == Keys.Space)
            {
                EndMessage.Visible = false;
                time.Enabled = true;
                count = 0;
                speedX = startSpeed;
                speedY = startSpeed;
            }
            // Pause
            else if(e.KeyCode == Keys.P)
            {
                if (time.Enabled)
                    time.Enabled = false;
                else
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
    }
}
