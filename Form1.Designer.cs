﻿namespace Pong
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
            this.counter = new System.Windows.Forms.GroupBox();
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
            this.ball.Size = new System.Drawing.Size(14, 14);
            this.ball.TabIndex = 2;
            this.ball.TabStop = false;
            // 
            // counter
            // 
            this.counter.Font = new System.Drawing.Font("Biondi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.counter.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.counter.Location = new System.Drawing.Point(12, 12);
            this.counter.Name = "counter";
            this.counter.Size = new System.Drawing.Size(70, 55);
            this.counter.TabIndex = 4;
            this.counter.TabStop = false;
            this.counter.Text = "Hits: ";
            this.counter.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(592, 375);
            this.Controls.Add(this.counter);
            this.Controls.Add(this.ball);
            this.Controls.Add(this.paddlePlayer);
            this.Controls.Add(this.paddleAI);
            this.Name = "Form1";
            this.Text = "Pong";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.paddleAI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paddlePlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox paddleAI;
        private System.Windows.Forms.PictureBox paddlePlayer;
        private System.Windows.Forms.PictureBox ball;
        private System.Windows.Forms.GroupBox counter;
    }
}
