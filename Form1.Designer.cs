namespace Pong
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.paddleAI = new System.Windows.Forms.PictureBox();
            this.paddlePlayer = new System.Windows.Forms.PictureBox();
            this.ball = new System.Windows.Forms.PictureBox();
            this.EndMessage = new System.Windows.Forms.Label();
            this.counter = new System.Windows.Forms.Label();
            this.PauseMsg = new System.Windows.Forms.Label();
            this.Scores = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.nameMessage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.paddleAI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paddlePlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).BeginInit();
            this.SuspendLayout();
            // 
            // paddleAI
            // 
            this.paddleAI.BackColor = System.Drawing.Color.Blue;
            this.paddleAI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paddleAI.Location = new System.Drawing.Point(564, 114);
            this.paddleAI.Name = "paddleAI";
            this.paddleAI.Size = new System.Drawing.Size(14, 76);
            this.paddleAI.TabIndex = 0;
            this.paddleAI.TabStop = false;
            // 
            // paddlePlayer
            // 
            this.paddlePlayer.BackColor = System.Drawing.Color.Red;
            this.paddlePlayer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paddlePlayer.Location = new System.Drawing.Point(12, 114);
            this.paddlePlayer.Name = "paddlePlayer";
            this.paddlePlayer.Size = new System.Drawing.Size(14, 76);
            this.paddlePlayer.TabIndex = 1;
            this.paddlePlayer.TabStop = false;
            // 
            // ball
            // 
            this.ball.BackColor = System.Drawing.Color.Lime;
            this.ball.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ball.Location = new System.Drawing.Point(282, 142);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(17, 17);
            this.ball.TabIndex = 2;
            this.ball.TabStop = false;
            // 
            // EndMessage
            // 
            this.EndMessage.AutoSize = true;
            this.EndMessage.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.EndMessage.Font = new System.Drawing.Font("Biondi", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndMessage.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.EndMessage.Location = new System.Drawing.Point(142, 193);
            this.EndMessage.Name = "EndMessage";
            this.EndMessage.Size = new System.Drawing.Size(299, 96);
            this.EndMessage.TabIndex = 5;
            this.EndMessage.Text = "Game Over \r\nSPACE - Restart \r\nESC - Exit";
            this.EndMessage.Visible = false;
            // 
            // counter
            // 
            this.counter.AutoSize = true;
            this.counter.Font = new System.Drawing.Font("Biondi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.counter.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.counter.Location = new System.Drawing.Point(452, 13);
            this.counter.Name = "counter";
            this.counter.Size = new System.Drawing.Size(75, 23);
            this.counter.TabIndex = 6;
            this.counter.Text = "Score";
            // 
            // PauseMsg
            // 
            this.PauseMsg.AutoSize = true;
            this.PauseMsg.Font = new System.Drawing.Font("Biondi", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PauseMsg.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.PauseMsg.Location = new System.Drawing.Point(656, 297);
            this.PauseMsg.Name = "PauseMsg";
            this.PauseMsg.Size = new System.Drawing.Size(288, 128);
            this.PauseMsg.TabIndex = 7;
            this.PauseMsg.Text = "Game Paused\r\nR - Resume\r\nSPACE - Restart\r\nESC - Exit";
            // 
            // Scores
            // 
            this.Scores.AutoSize = true;
            this.Scores.Font = new System.Drawing.Font("Biondi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Scores.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Scores.Location = new System.Drawing.Point(360, 266);
            this.Scores.Name = "Scores";
            this.Scores.Size = new System.Drawing.Size(142, 23);
            this.Scores.TabIndex = 8;
            this.Scores.Text = "High Scores";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(652, 114);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(116, 20);
            this.nameBox.TabIndex = 9;
            // 
            // nameMessage
            // 
            this.nameMessage.Font = new System.Drawing.Font("Biondi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameMessage.Location = new System.Drawing.Point(643, 142);
            this.nameMessage.Name = "nameMessage";
            this.nameMessage.Size = new System.Drawing.Size(125, 48);
            this.nameMessage.TabIndex = 10;
            this.nameMessage.Text = "Enter Name";
            this.nameMessage.UseVisualStyleBackColor = true;
            this.nameMessage.Click += new System.EventHandler(this.nameBox_Enter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1012, 565);
            this.Controls.Add(this.nameMessage);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.Scores);
            this.Controls.Add(this.PauseMsg);
            this.Controls.Add(this.counter);
            this.Controls.Add(this.EndMessage);
            this.Controls.Add(this.ball);
            this.Controls.Add(this.paddlePlayer);
            this.Controls.Add(this.paddleAI);
            this.Name = "Form1";
            this.Text = "Pong";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyPress);
            ((System.ComponentModel.ISupportInitialize)(this.paddleAI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paddlePlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox paddleAI;
        private System.Windows.Forms.PictureBox paddlePlayer;
        private System.Windows.Forms.PictureBox ball;
        private System.Windows.Forms.Label EndMessage;
        private System.Windows.Forms.Label counter;
        private System.Windows.Forms.Label PauseMsg;
        private System.Windows.Forms.Label Scores;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Button nameMessage;
    }
}

