using System;
using System.Windows.Forms;

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
            this.pctPC1 = new System.Windows.Forms.PictureBox();
            this.pctPC2 = new System.Windows.Forms.PictureBox();
            this.pctPC3 = new System.Windows.Forms.PictureBox();
            this.pctPC4 = new System.Windows.Forms.PictureBox();
            this.pctPC5 = new System.Windows.Forms.PictureBox();
            this.lblTop = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pctPC1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPC2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPC3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPC4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPC5)).BeginInit();
            this.SuspendLayout();
            // 
            // pctPC1
            // 
            this.pctPC1.BackColor = System.Drawing.Color.Black;
            this.pctPC1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pctPC1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctPC1.Location = new System.Drawing.Point(25, 75);
            this.pctPC1.Name = "pctPC1";
            this.pctPC1.Size = new System.Drawing.Size(66, 66);
            this.pctPC1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctPC1.TabIndex = 0;
            this.pctPC1.TabStop = false;
            this.pctPC1.Click += new System.EventHandler(this.pctPC1_Click);
            // 
            // pctPC2
            // 
            this.pctPC2.BackColor = System.Drawing.Color.Black;
            this.pctPC2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pctPC2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctPC2.Location = new System.Drawing.Point(25, 125);
            this.pctPC2.Name = "pctPC2";
            this.pctPC2.Size = new System.Drawing.Size(66, 66);
            this.pctPC2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctPC2.TabIndex = 1;
            this.pctPC2.TabStop = false;
            this.pctPC2.Click += new System.EventHandler(this.pctPC2_Click);
            // 
            // pctPC3
            // 
            this.pctPC3.BackColor = System.Drawing.Color.Black;
            this.pctPC3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pctPC3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctPC3.Location = new System.Drawing.Point(25, 175);
            this.pctPC3.Name = "pctPC3";
            this.pctPC3.Size = new System.Drawing.Size(66, 66);
            this.pctPC3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctPC3.TabIndex = 2;
            this.pctPC3.TabStop = false;
            this.pctPC3.Click += new System.EventHandler(this.pctPC3_Click);
            // 
            // pctPC4
            // 
            this.pctPC4.BackColor = System.Drawing.Color.Black;
            this.pctPC4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pctPC4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctPC4.Location = new System.Drawing.Point(25, 225);
            this.pctPC4.Name = "pctPC4";
            this.pctPC4.Size = new System.Drawing.Size(66, 66);
            this.pctPC4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctPC4.TabIndex = 3;
            this.pctPC4.TabStop = false;
            this.pctPC4.Click += new System.EventHandler(this.pctPC4_Click);
            // 
            // pctPC5
            // 
            this.pctPC5.BackColor = System.Drawing.Color.Black;
            this.pctPC5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pctPC5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctPC5.Location = new System.Drawing.Point(25, 275);
            this.pctPC5.Name = "pctPC5";
            this.pctPC5.Size = new System.Drawing.Size(66, 66);
            this.pctPC5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctPC5.TabIndex = 4;
            this.pctPC5.TabStop = false;
            this.pctPC5.Click += new System.EventHandler(this.pctPC5_Click);
            // 
            // lblTop
            // 
            this.lblTop.BackColor = System.Drawing.Color.Transparent;
            this.lblTop.Location = new System.Drawing.Point(2, 2);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(496, 15);
            this.lblTop.TabIndex = 5;
            this.lblTop.MouseDown += new MouseEventHandler(this.lblTop_MouseDown);
            this.lblTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblTop_MouseUp);
            this.lblTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblTop_MouseMove);

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
            ((System.ComponentModel.ISupportInitialize)(this.pctPC1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPC2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPC3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPC4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPC5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pctPC1;
        private System.Windows.Forms.PictureBox pctPC2;
        private System.Windows.Forms.PictureBox pctPC3;
        private System.Windows.Forms.PictureBox pctPC4;
        private System.Windows.Forms.PictureBox pctPC5;
        private Label lblTop;
    }
}