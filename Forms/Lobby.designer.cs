using System;
using System.Windows.Forms;

namespace TripleTriadOffline.Forms
{
    partial class Lobby
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lobby));
            this.btnChallenge = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pctPlayerCard = new System.Windows.Forms.PictureBox();
            this.cboPlayerCards = new System.Windows.Forms.ComboBox();
            this.pctShop = new System.Windows.Forms.PictureBox();
            this.cboShop = new System.Windows.Forms.ComboBox();
            this.lblPCLevel = new System.Windows.Forms.Label();
            this.lblPCCount = new System.Windows.Forms.Label();
            this.lblPCOffensive = new System.Windows.Forms.Label();
            this.lblPCDefensive = new System.Windows.Forms.Label();
            this.lblSLevel = new System.Windows.Forms.Label();
            this.btnSell = new System.Windows.Forms.Button();
            this.txtPCSell = new System.Windows.Forms.TextBox();
            this.txtSBuy = new System.Windows.Forms.TextBox();
            this.btnBuy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pctPlayerCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctShop)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChallenge
            // 
            this.btnChallenge.BackColor = System.Drawing.Color.Transparent;
            this.btnChallenge.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnChallenge.FlatAppearance.BorderSize = 0;
            this.btnChallenge.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChallenge.Location = new System.Drawing.Point(643, 423);
            this.btnChallenge.Name = "btnChallenge";
            this.btnChallenge.Size = new System.Drawing.Size(82, 17);
            this.btnChallenge.TabIndex = 1;
            this.btnChallenge.TabStop = false;
            this.btnChallenge.UseVisualStyleBackColor = false;
            this.btnChallenge.Click += new System.EventHandler(this.btnChallenge_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Location = new System.Drawing.Point(3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(19, 13);
            this.btnClose.TabIndex = 2;
            this.btnClose.TabStop = false;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pctPlayerCard
            // 
            this.pctPlayerCard.BackColor = System.Drawing.Color.Black;
            this.pctPlayerCard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pctPlayerCard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pctPlayerCard.Location = new System.Drawing.Point(26, 85);
            this.pctPlayerCard.Name = "pctPlayerCard";
            this.pctPlayerCard.Size = new System.Drawing.Size(70, 70);
            this.pctPlayerCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctPlayerCard.TabIndex = 3;
            this.pctPlayerCard.TabStop = false;
            // 
            // cboPlayerCards
            // 
            this.cboPlayerCards.BackColor = System.Drawing.Color.Black;
            this.cboPlayerCards.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlayerCards.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPlayerCards.ForeColor = System.Drawing.Color.White;
            this.cboPlayerCards.FormattingEnabled = true;
            this.cboPlayerCards.ItemHeight = 13;
            this.cboPlayerCards.Location = new System.Drawing.Point(102, 85);
            this.cboPlayerCards.MaxDropDownItems = 100;
            this.cboPlayerCards.Name = "cboPlayerCards";
            this.cboPlayerCards.Size = new System.Drawing.Size(161, 21);
            this.cboPlayerCards.Sorted = true;
            this.cboPlayerCards.TabIndex = 4;
            this.cboPlayerCards.SelectedIndexChanged += new System.EventHandler(this.cboPlayerCards_SelectedIndexChanged);
            // 
            // pctShop
            // 
            this.pctShop.BackColor = System.Drawing.Color.Black;
            this.pctShop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pctShop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pctShop.Location = new System.Drawing.Point(26, 235);
            this.pctShop.Name = "pctShop";
            this.pctShop.Size = new System.Drawing.Size(70, 70);
            this.pctShop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctShop.TabIndex = 5;
            this.pctShop.TabStop = false;
            // 
            // cboShop
            // 
            this.cboShop.BackColor = System.Drawing.Color.Black;
            this.cboShop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboShop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboShop.ForeColor = System.Drawing.Color.White;
            this.cboShop.FormattingEnabled = true;
            this.cboShop.ItemHeight = 13;
            this.cboShop.Location = new System.Drawing.Point(102, 235);
            this.cboShop.MaxDropDownItems = 100;
            this.cboShop.Name = "cboShop";
            this.cboShop.Size = new System.Drawing.Size(161, 21);
            this.cboShop.Sorted = true;
            this.cboShop.TabIndex = 6;
            this.cboShop.SelectedIndexChanged += new System.EventHandler(this.cboShop_SelectedIndexChanged);
            // 
            // lblPCLevel
            // 
            this.lblPCLevel.AutoSize = true;
            this.lblPCLevel.BackColor = System.Drawing.Color.Transparent;
            this.lblPCLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPCLevel.ForeColor = System.Drawing.Color.White;
            this.lblPCLevel.Location = new System.Drawing.Point(179, 107);
            this.lblPCLevel.Name = "lblPCLevel";
            this.lblPCLevel.Size = new System.Drawing.Size(9, 9);
            this.lblPCLevel.TabIndex = 7;
            this.lblPCLevel.Text = "0";
            // 
            // lblPCCount
            // 
            this.lblPCCount.AutoSize = true;
            this.lblPCCount.BackColor = System.Drawing.Color.Transparent;
            this.lblPCCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPCCount.ForeColor = System.Drawing.Color.White;
            this.lblPCCount.Location = new System.Drawing.Point(179, 117);
            this.lblPCCount.Name = "lblPCCount";
            this.lblPCCount.Size = new System.Drawing.Size(9, 9);
            this.lblPCCount.TabIndex = 8;
            this.lblPCCount.Text = "0";
            // 
            // lblPCOffensive
            // 
            this.lblPCOffensive.AutoSize = true;
            this.lblPCOffensive.BackColor = System.Drawing.Color.Transparent;
            this.lblPCOffensive.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPCOffensive.ForeColor = System.Drawing.Color.White;
            this.lblPCOffensive.Location = new System.Drawing.Point(179, 135);
            this.lblPCOffensive.Name = "lblPCOffensive";
            this.lblPCOffensive.Size = new System.Drawing.Size(9, 9);
            this.lblPCOffensive.TabIndex = 9;
            this.lblPCOffensive.Text = "0";
            // 
            // lblPCDefensive
            // 
            this.lblPCDefensive.AutoSize = true;
            this.lblPCDefensive.BackColor = System.Drawing.Color.Transparent;
            this.lblPCDefensive.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPCDefensive.ForeColor = System.Drawing.Color.White;
            this.lblPCDefensive.Location = new System.Drawing.Point(179, 145);
            this.lblPCDefensive.Name = "lblPCDefensive";
            this.lblPCDefensive.Size = new System.Drawing.Size(9, 9);
            this.lblPCDefensive.TabIndex = 10;
            this.lblPCDefensive.Text = "0";
            // 
            // lblSLevel
            // 
            this.lblSLevel.AutoSize = true;
            this.lblSLevel.BackColor = System.Drawing.Color.Transparent;
            this.lblSLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSLevel.ForeColor = System.Drawing.Color.White;
            this.lblSLevel.Location = new System.Drawing.Point(179, 294);
            this.lblSLevel.Name = "lblSLevel";
            this.lblSLevel.Size = new System.Drawing.Size(9, 9);
            this.lblSLevel.TabIndex = 11;
            this.lblSLevel.Text = "0";
            // 
            // btnSell
            // 
            this.btnSell.Location = new System.Drawing.Point(26, 157);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(70, 20);
            this.btnSell.TabIndex = 12;
            this.btnSell.Text = "Sell";
            this.btnSell.UseVisualStyleBackColor = true;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // txtPCSell
            // 
            this.txtPCSell.BackColor = System.Drawing.Color.Black;
            this.txtPCSell.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPCSell.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPCSell.ForeColor = System.Drawing.Color.White;
            this.txtPCSell.Location = new System.Drawing.Point(179, 162);
            this.txtPCSell.MaxLength = 1;
            this.txtPCSell.Name = "txtPCSell";
            this.txtPCSell.Size = new System.Drawing.Size(11, 17);
            this.txtPCSell.TabIndex = 13;
            this.txtPCSell.Text = "0";
            this.txtPCSell.TextChanged += new System.EventHandler(this.txtPCSell_TextChanged);
            this.txtPCSell.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPCSell_KeyPress);
            // 
            // txtSBuy
            // 
            this.txtSBuy.BackColor = System.Drawing.Color.Black;
            this.txtSBuy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSBuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSBuy.ForeColor = System.Drawing.Color.White;
            this.txtSBuy.Location = new System.Drawing.Point(179, 266);
            this.txtSBuy.MaxLength = 1;
            this.txtSBuy.Name = "txtSBuy";
            this.txtSBuy.Size = new System.Drawing.Size(11, 17);
            this.txtSBuy.TabIndex = 14;
            this.txtSBuy.Text = "0";
            this.txtSBuy.TextChanged += new System.EventHandler(this.txtSBuy_TextChanged);
            this.txtSBuy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSBuy_KeyPress);
            // 
            // btnBuy
            // 
            this.btnBuy.Location = new System.Drawing.Point(26, 307);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(70, 20);
            this.btnBuy.TabIndex = 15;
            this.btnBuy.Text = "Buy";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // Lobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(780, 580);
            this.ControlBox = false;
            this.Controls.Add(this.btnBuy);
            this.Controls.Add(this.txtSBuy);
            this.Controls.Add(this.txtPCSell);
            this.Controls.Add(this.btnSell);
            this.Controls.Add(this.lblSLevel);
            this.Controls.Add(this.lblPCDefensive);
            this.Controls.Add(this.lblPCOffensive);
            this.Controls.Add(this.lblPCCount);
            this.Controls.Add(this.lblPCLevel);
            this.Controls.Add(this.cboShop);
            this.Controls.Add(this.pctShop);
            this.Controls.Add(this.cboPlayerCards);
            this.Controls.Add(this.pctPlayerCard);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnChallenge);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Lobby";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Triple Triad Offline";
            this.Load += new System.EventHandler(this.Lobby_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctPlayerCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctShop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChallenge;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pctPlayerCard;
        private System.Windows.Forms.ComboBox cboPlayerCards;
        private System.Windows.Forms.PictureBox pctShop;
        private System.Windows.Forms.ComboBox cboShop;
        private System.Windows.Forms.Label lblPCLevel;
        private System.Windows.Forms.Label lblPCCount;
        private System.Windows.Forms.Label lblPCOffensive;
        private System.Windows.Forms.Label lblPCDefensive;
        private System.Windows.Forms.Label lblSLevel;
        private System.Windows.Forms.Button btnSell;
        private System.Windows.Forms.TextBox txtPCSell;
        private System.Windows.Forms.TextBox txtSBuy;
        private System.Windows.Forms.Button btnBuy;
    }
}