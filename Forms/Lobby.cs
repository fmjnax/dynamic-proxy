using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TripleTriadOffline.Forms
{
    public partial class Lobby : Form
    {
        private static Deck masterDeck;
        private static Deck playerDeck;

        public Lobby()
        {
            InitializeComponent();
        }

        private void btnChallenge_Click(object sender, EventArgs e)
        {
            Game.Challenge();
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        public void showFormModal(Form form)
        {
            form.ShowDialog(this);
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }
        
        private void Lobby_Load(object sender, EventArgs e)
        {
            playerDeck = Game.GetPlayerDeck();
            masterDeck = Game.GetMasterDeck();

            UpdatePlayerCardViewer(playerDeck);
            UpdateShopCardViewer(masterDeck);
        }

        private void cboPlayerCards_SelectedIndexChanged(object sender, EventArgs e)
        {
            Card card = masterDeck.GetCardByName(cboPlayerCards.Text);

            pctPlayerCard.Image = Image.FromFile(@"Deck\Blue\" + card.fileName + ".jpg");
            lblPCLevel.Text = card.level.ToString();
            lblPCCount.Text = playerDeck.GetCountById(card.id).ToString();
        }

        private void cboShop_SelectedIndexChanged(object sender, EventArgs e)
        {
            Card card = masterDeck.GetCardByName(cboShop.Text);

            pctShop.Image = Image.FromFile(@"Deck\Blue\" + card.fileName + ".jpg");
            lblSLevel.Text = card.level.ToString();
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(txtPCSell.Text) > Int32.Parse(lblPCCount.Text))
            {
                MessageBox.Show("You cannot sell more cards than you own");
            }
            else
            {
                pctPlayerCard.Image = null;
                lblPCLevel.Text = "0";
                lblPCCount.Text = "0";
                lblPCOffensive.Text = "0";
                lblPCDefensive.Text = "0";
                
                Game.SellCard(cboPlayerCards.Text, Int32.Parse(txtPCSell.Text));
                
                UpdatePlayerCardViewer(playerDeck);

                txtPCSell.Text = "0";
            }
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            int oldIndex = cboPlayerCards.SelectedIndex;

            Game.BuyCard(cboShop.Text, Int32.Parse(txtSBuy.Text));
            
            UpdatePlayerCardViewer(playerDeck);

            cboPlayerCards.SelectedIndex = oldIndex;
            txtSBuy.Text = "0";
        }

        private void UpdatePlayerCardViewer(Deck playerDeck)
        {
            cboPlayerCards.Items.Clear();

            foreach (var card in playerDeck)
            {
                if (!cboPlayerCards.Items.Contains(card.displayName))
                {
                    cboPlayerCards.Items.Add(card.displayName);
                }
            }
            if (cboPlayerCards.Items.Count > 0)
            {
                cboPlayerCards.SelectedIndex = 0;
            }
        }

        private void UpdateShopCardViewer(Deck masterDeck)
        {
            foreach (var card in masterDeck)
            {
                if (card.level != 99)
                {
                    cboShop.Items.Add(card.displayName);
                }
            }
            cboShop.SelectedIndex = 0;
        }
        
        private void txtPCSell_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                txtPCSell.Text = "0";
            }
        }

        private void txtSBuy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                txtSBuy.Text = "0";
            }
        }

        private void txtPCSell_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (!Int32.TryParse(txtPCSell.Text, out x))
            {
                txtPCSell.Text = "0";
            }
        }

        private void txtSBuy_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            if (!Int32.TryParse(txtSBuy.Text, out x))
            {
                txtSBuy.Text = "0";
            }
        }
    }
}
