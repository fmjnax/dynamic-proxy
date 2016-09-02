using System;
using System.Windows.Forms;
using TripleTriadOffline.Classes;

namespace TripleTriadOffline
{
    partial class GameBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameBoard));
            this.lblTop = new System.Windows.Forms.Label();
            this.lblRedScore = new System.Windows.Forms.Label();
            this.lblBlueScore = new System.Windows.Forms.Label();
            this.lblGameResult = new System.Windows.Forms.Label();
            this.TurnIndicator = new System.Windows.Forms.PictureBox();
            this.pctOC5 = new TripleTriadOffline.Classes.CardPictureBox();
            this.pctOC4 = new TripleTriadOffline.Classes.CardPictureBox();
            this.pctOC3 = new TripleTriadOffline.Classes.CardPictureBox();
            this.pctOC2 = new TripleTriadOffline.Classes.CardPictureBox();
            this.pctOC1 = new TripleTriadOffline.Classes.CardPictureBox();
            this.pctPC5 = new TripleTriadOffline.Classes.CardPictureBox();
            this.pctPC4 = new TripleTriadOffline.Classes.CardPictureBox();
            this.pctPC3 = new TripleTriadOffline.Classes.CardPictureBox();
            this.pctPC2 = new TripleTriadOffline.Classes.CardPictureBox();
            this.pctPC1 = new TripleTriadOffline.Classes.CardPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.TurnIndicator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctOC5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctOC4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctOC3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctOC2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctOC1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPC5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPC4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPC3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPC2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPC1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTop
            // 
            this.lblTop.BackColor = System.Drawing.Color.Transparent;
            this.lblTop.Location = new System.Drawing.Point(2, 2);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(496, 15);
            this.lblTop.TabIndex = 5;
            this.lblTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTop_MouseDown);
            this.lblTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblTop_MouseMove);
            this.lblTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblTop_MouseUp);
            // 
            // lblRedScore
            // 
            this.lblRedScore.AutoSize = true;
            this.lblRedScore.BackColor = System.Drawing.Color.Transparent;
            this.lblRedScore.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRedScore.ForeColor = System.Drawing.Color.White;
            this.lblRedScore.Location = new System.Drawing.Point(428, 356);
            this.lblRedScore.Name = "lblRedScore";
            this.lblRedScore.Size = new System.Drawing.Size(30, 32);
            this.lblRedScore.TabIndex = 11;
            this.lblRedScore.Text = "5";
            this.lblRedScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBlueScore
            // 
            this.lblBlueScore.AutoSize = true;
            this.lblBlueScore.BackColor = System.Drawing.Color.Transparent;
            this.lblBlueScore.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlueScore.ForeColor = System.Drawing.Color.White;
            this.lblBlueScore.Location = new System.Drawing.Point(40, 356);
            this.lblBlueScore.Name = "lblBlueScore";
            this.lblBlueScore.Size = new System.Drawing.Size(30, 32);
            this.lblBlueScore.TabIndex = 12;
            this.lblBlueScore.Text = "5";
            this.lblBlueScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGameResult
            // 
            this.lblGameResult.BackColor = System.Drawing.Color.Transparent;
            this.lblGameResult.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameResult.ForeColor = System.Drawing.Color.White;
            this.lblGameResult.Location = new System.Drawing.Point(91, 356);
            this.lblGameResult.Name = "lblGameResult";
            this.lblGameResult.Size = new System.Drawing.Size(317, 32);
            this.lblGameResult.TabIndex = 13;
            this.lblGameResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TurnIndicator
            // 
            this.TurnIndicator.BackColor = System.Drawing.Color.Transparent;
            this.TurnIndicator.Location = new System.Drawing.Point(223, 49);
            this.TurnIndicator.Name = "TurnIndicator";
            this.TurnIndicator.Size = new System.Drawing.Size(55, 29);
            this.TurnIndicator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.TurnIndicator.TabIndex = 14;
            this.TurnIndicator.TabStop = false;
            // 
            // pctOC5
            // 
            this.pctOC5.BackColor = System.Drawing.Color.Black;
            this.pctOC5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pctOC5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctOC5.bottom = 0;
            this.pctOC5.card = null;
            this.pctOC5.currentColor = null;
            this.pctOC5.displayName = null;
            this.pctOC5.fileName = null;
            this.pctOC5.id = 0;
            this.pctOC5.isUsed = false;
            this.pctOC5.left = 0;
            this.pctOC5.level = 0;
            this.pctOC5.Location = new System.Drawing.Point(410, 275);
            this.pctOC5.Name = "pctOC5";
            this.pctOC5.native = 0;
            this.pctOC5.right = 0;
            this.pctOC5.Size = new System.Drawing.Size(66, 66);
            this.pctOC5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctOC5.TabIndex = 10;
            this.pctOC5.TabStop = false;
            this.pctOC5.top = 0;
            this.pctOC5.Click += new System.EventHandler(this.pctOC5_Click);
            // 
            // pctOC4
            // 
            this.pctOC4.BackColor = System.Drawing.Color.Black;
            this.pctOC4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pctOC4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctOC4.bottom = 0;
            this.pctOC4.card = null;
            this.pctOC4.currentColor = null;
            this.pctOC4.displayName = null;
            this.pctOC4.fileName = null;
            this.pctOC4.id = 0;
            this.pctOC4.isUsed = false;
            this.pctOC4.left = 0;
            this.pctOC4.level = 0;
            this.pctOC4.Location = new System.Drawing.Point(410, 225);
            this.pctOC4.Name = "pctOC4";
            this.pctOC4.native = 0;
            this.pctOC4.right = 0;
            this.pctOC4.Size = new System.Drawing.Size(66, 66);
            this.pctOC4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctOC4.TabIndex = 9;
            this.pctOC4.TabStop = false;
            this.pctOC4.top = 0;
            this.pctOC4.Click += new System.EventHandler(this.pctOC4_Click);
            // 
            // pctOC3
            // 
            this.pctOC3.BackColor = System.Drawing.Color.Black;
            this.pctOC3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pctOC3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctOC3.bottom = 0;
            this.pctOC3.card = null;
            this.pctOC3.currentColor = null;
            this.pctOC3.displayName = null;
            this.pctOC3.fileName = null;
            this.pctOC3.id = 0;
            this.pctOC3.isUsed = false;
            this.pctOC3.left = 0;
            this.pctOC3.level = 0;
            this.pctOC3.Location = new System.Drawing.Point(410, 175);
            this.pctOC3.Name = "pctOC3";
            this.pctOC3.native = 0;
            this.pctOC3.right = 0;
            this.pctOC3.Size = new System.Drawing.Size(66, 66);
            this.pctOC3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctOC3.TabIndex = 8;
            this.pctOC3.TabStop = false;
            this.pctOC3.top = 0;
            this.pctOC3.Click += new System.EventHandler(this.pctOC3_Click);
            // 
            // pctOC2
            // 
            this.pctOC2.BackColor = System.Drawing.Color.Black;
            this.pctOC2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pctOC2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctOC2.bottom = 0;
            this.pctOC2.card = null;
            this.pctOC2.currentColor = null;
            this.pctOC2.displayName = null;
            this.pctOC2.fileName = null;
            this.pctOC2.id = 0;
            this.pctOC2.isUsed = false;
            this.pctOC2.left = 0;
            this.pctOC2.level = 0;
            this.pctOC2.Location = new System.Drawing.Point(410, 125);
            this.pctOC2.Name = "pctOC2";
            this.pctOC2.native = 0;
            this.pctOC2.right = 0;
            this.pctOC2.Size = new System.Drawing.Size(66, 66);
            this.pctOC2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctOC2.TabIndex = 7;
            this.pctOC2.TabStop = false;
            this.pctOC2.top = 0;
            this.pctOC2.Click += new System.EventHandler(this.pctOC2_Click);
            // 
            // pctOC1
            // 
            this.pctOC1.BackColor = System.Drawing.Color.Black;
            this.pctOC1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pctOC1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctOC1.bottom = 0;
            this.pctOC1.card = null;
            this.pctOC1.currentColor = null;
            this.pctOC1.displayName = null;
            this.pctOC1.fileName = null;
            this.pctOC1.id = 0;
            this.pctOC1.isUsed = false;
            this.pctOC1.left = 0;
            this.pctOC1.level = 0;
            this.pctOC1.Location = new System.Drawing.Point(410, 75);
            this.pctOC1.Name = "pctOC1";
            this.pctOC1.native = 0;
            this.pctOC1.right = 0;
            this.pctOC1.Size = new System.Drawing.Size(66, 66);
            this.pctOC1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctOC1.TabIndex = 6;
            this.pctOC1.TabStop = false;
            this.pctOC1.top = 0;
            this.pctOC1.Click += new System.EventHandler(this.pctOC1_Click);
            // 
            // pctPC5
            // 
            this.pctPC5.BackColor = System.Drawing.Color.Black;
            this.pctPC5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pctPC5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctPC5.bottom = 0;
            this.pctPC5.card = null;
            this.pctPC5.currentColor = null;
            this.pctPC5.displayName = null;
            this.pctPC5.fileName = null;
            this.pctPC5.id = 0;
            this.pctPC5.isUsed = false;
            this.pctPC5.left = 0;
            this.pctPC5.level = 0;
            this.pctPC5.Location = new System.Drawing.Point(25, 275);
            this.pctPC5.Name = "pctPC5";
            this.pctPC5.native = 0;
            this.pctPC5.right = 0;
            this.pctPC5.Size = new System.Drawing.Size(66, 66);
            this.pctPC5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctPC5.TabIndex = 4;
            this.pctPC5.TabStop = false;
            this.pctPC5.top = 0;
            this.pctPC5.Click += new System.EventHandler(this.pctPC5_Click);
            // 
            // pctPC4
            // 
            this.pctPC4.BackColor = System.Drawing.Color.Black;
            this.pctPC4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pctPC4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctPC4.bottom = 0;
            this.pctPC4.card = null;
            this.pctPC4.currentColor = null;
            this.pctPC4.displayName = null;
            this.pctPC4.fileName = null;
            this.pctPC4.id = 0;
            this.pctPC4.isUsed = false;
            this.pctPC4.left = 0;
            this.pctPC4.level = 0;
            this.pctPC4.Location = new System.Drawing.Point(25, 225);
            this.pctPC4.Name = "pctPC4";
            this.pctPC4.native = 0;
            this.pctPC4.right = 0;
            this.pctPC4.Size = new System.Drawing.Size(66, 66);
            this.pctPC4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctPC4.TabIndex = 3;
            this.pctPC4.TabStop = false;
            this.pctPC4.top = 0;
            this.pctPC4.Click += new System.EventHandler(this.pctPC4_Click);
            // 
            // pctPC3
            // 
            this.pctPC3.BackColor = System.Drawing.Color.Black;
            this.pctPC3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pctPC3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctPC3.bottom = 0;
            this.pctPC3.card = null;
            this.pctPC3.currentColor = null;
            this.pctPC3.displayName = null;
            this.pctPC3.fileName = null;
            this.pctPC3.id = 0;
            this.pctPC3.isUsed = false;
            this.pctPC3.left = 0;
            this.pctPC3.level = 0;
            this.pctPC3.Location = new System.Drawing.Point(25, 175);
            this.pctPC3.Name = "pctPC3";
            this.pctPC3.native = 0;
            this.pctPC3.right = 0;
            this.pctPC3.Size = new System.Drawing.Size(66, 66);
            this.pctPC3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctPC3.TabIndex = 2;
            this.pctPC3.TabStop = false;
            this.pctPC3.top = 0;
            this.pctPC3.Click += new System.EventHandler(this.pctPC3_Click);
            // 
            // pctPC2
            // 
            this.pctPC2.BackColor = System.Drawing.Color.Black;
            this.pctPC2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pctPC2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctPC2.bottom = 0;
            this.pctPC2.card = null;
            this.pctPC2.currentColor = null;
            this.pctPC2.displayName = null;
            this.pctPC2.fileName = null;
            this.pctPC2.id = 0;
            this.pctPC2.isUsed = false;
            this.pctPC2.left = 0;
            this.pctPC2.level = 0;
            this.pctPC2.Location = new System.Drawing.Point(25, 125);
            this.pctPC2.Name = "pctPC2";
            this.pctPC2.native = 0;
            this.pctPC2.right = 0;
            this.pctPC2.Size = new System.Drawing.Size(66, 66);
            this.pctPC2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctPC2.TabIndex = 1;
            this.pctPC2.TabStop = false;
            this.pctPC2.top = 0;
            this.pctPC2.Click += new System.EventHandler(this.pctPC2_Click);
            // 
            // pctPC1
            // 
            this.pctPC1.BackColor = System.Drawing.Color.Black;
            this.pctPC1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pctPC1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctPC1.bottom = 0;
            this.pctPC1.card = null;
            this.pctPC1.currentColor = null;
            this.pctPC1.displayName = null;
            this.pctPC1.fileName = null;
            this.pctPC1.id = 0;
            this.pctPC1.isUsed = false;
            this.pctPC1.left = 0;
            this.pctPC1.level = 0;
            this.pctPC1.Location = new System.Drawing.Point(25, 75);
            this.pctPC1.Name = "pctPC1";
            this.pctPC1.native = 0;
            this.pctPC1.right = 0;
            this.pctPC1.Size = new System.Drawing.Size(66, 66);
            this.pctPC1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctPC1.TabIndex = 0;
            this.pctPC1.TabStop = false;
            this.pctPC1.top = 0;
            this.pctPC1.Click += new System.EventHandler(this.pctPC1_Click);
            // 
            // GameBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.ControlBox = false;
            this.Controls.Add(this.TurnIndicator);
            this.Controls.Add(this.lblGameResult);
            this.Controls.Add(this.lblBlueScore);
            this.Controls.Add(this.lblRedScore);
            this.Controls.Add(this.pctOC5);
            this.Controls.Add(this.pctOC4);
            this.Controls.Add(this.pctOC3);
            this.Controls.Add(this.pctOC2);
            this.Controls.Add(this.pctOC1);
            this.Controls.Add(this.lblTop);
            this.Controls.Add(this.pctPC5);
            this.Controls.Add(this.pctPC4);
            this.Controls.Add(this.pctPC3);
            this.Controls.Add(this.pctPC2);
            this.Controls.Add(this.pctPC1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameBoard";
            this.Load += new System.EventHandler(this.GameBoard_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GameBoard_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.TurnIndicator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctOC5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctOC4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctOC3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctOC2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctOC1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPC5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPC4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPC3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPC2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPC1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CardPictureBox pctPC1;
        private CardPictureBox pctPC2;
        private CardPictureBox pctPC3;
        private CardPictureBox pctPC4;
        private CardPictureBox pctPC5;
        private Label lblTop;
        private CardPictureBox pctOC5;
        private CardPictureBox pctOC4;
        private CardPictureBox pctOC3;
        private CardPictureBox pctOC2;
        private CardPictureBox pctOC1;
        private Label lblRedScore;
        private Label lblBlueScore;
        private Label lblGameResult;
        private PictureBox TurnIndicator;
    }
}