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
        Timer time;
        int speedX = 8;
        int speedY = 8;

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

            count = 0;
            time = new Timer();
            time.Enabled = true;
            time.Tick += new EventHandler(timerTick);

            this.TopMost = true;
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
            counter.Text = "Hits \n " + count;
        }

        void timerTick(object sender, EventArgs e)
        {
            ball.Location = new Point(ball.Location.X + speedX, ball.Location.Y + speedY);
            wallCheck();

        }// timerTick

        void wallCheck()
        {
            if (ball.Location.Y > this.Bottom - 50 || ball.Location.Y < 0)
            {
                speedY = -speedY;
            }
            else if (ball.Location.X > this.Width - 10 || ball.Location.X < 10)
            {
                ball.Location = new Point(ballX, ballY);
            }
        }// wallCheck

        void paddleCheck()
        {

        }

        void movePlayer()
        {

        }

        void moveAI()
        {

        }
           
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
