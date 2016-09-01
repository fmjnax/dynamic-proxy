using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TripleTriadOffline.Forms
{
    public partial class SelectCards : Form
    {
        private static Deck playerDeck;
        private static Deck playingHand;

        public SelectCards()
        {
            InitializeComponent();
        }

        private void btnSelectCard_Click(object sender, EventArgs e)
        {
            if (playingHand.GetCount() < 5)
            {
                int count = Int32.Parse(lblPCCount.Text);

                Card card = playerDeck.GetCardByName(lstAvailable.Text);
                playingHand.AddCard(card);
                playerDeck.RemoveCardByName(lstAvailable.Text);

                RefreshAvailableCardList(card.level);

                if (playingHand.GetCount() == 5)
                {
                    Game.ConfirmHand(playingHand);
                }
            }
        }

        private void SelectCards_Load(object sender, EventArgs e)
        {
            playingHand = new Deck();
            playerDeck = Game.GetPlayerDeck();
            RefreshAvailableCardList(1);
            /*
            Card[] playerCard = new Card[5];

            List<string> playerCardList = new List<string>();
            playerCardList.Add("1");
            playerCardList.Add("3");
            playerCardList.Add("5");
            playerCardList.Add("7");
            playerCardList.Add("9");

            LoadPlayingHand(playerCardList, playerCard, "blue", true);
            */
        }

        internal void RejectHand(Deck rejectedHand)
        {
            foreach (var card in rejectedHand)
            {
                playerDeck.AddCard(card);
            }

            playingHand.Clear();
            RefreshAvailableCardList(1);
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

        private void LoadPlayingHand(List<string> cardList, Card[] card, string color, bool open)
        {
            int x = 0;

            

            foreach (string cardId in cardList)
            {
               
            }
        }

        private void btnLevel1_Click(object sender, EventArgs e)
        {
            RefreshAvailableCardList(1);
        }

        private void RefreshAvailableCardList(int level)
        {
            lstAvailable.Items.Clear();
            pctPlayerCard.Image = null;
            lblPCCount.Text = "0";

            foreach (var card in playerDeck)
            {
                if (!lstAvailable.Items.Contains(card.displayName))
                {
                    if (card.level == level)
                    {
                        lstAvailable.Items.Add(card.displayName);
                    }
                }
            }
            if (lstAvailable.Items.Count > 0)
            {
                lstAvailable.SelectedIndex = 0;
            }
        }

        private void btnLevel2_Click(object sender, EventArgs e)
        {
            RefreshAvailableCardList(2);
        }

        private void btnLevel3_Click(object sender, EventArgs e)
        {
            RefreshAvailableCardList(3);
        }

        private void btnLevel4_Click(object sender, EventArgs e)
        {
            RefreshAvailableCardList(4);
        }

        private void btnLevel5_Click(object sender, EventArgs e)
        {
            RefreshAvailableCardList(5);
        }

        private void btnLevel6_Click(object sender, EventArgs e)
        {
            RefreshAvailableCardList(6);
        }

        private void btnLevel7_Click(object sender, EventArgs e)
        {
            RefreshAvailableCardList(7);
        }

        private void btnLevel8_Click(object sender, EventArgs e)
        {
            RefreshAvailableCardList(8);
        }

        private void btnLevel9_Click(object sender, EventArgs e)
        {
            RefreshAvailableCardList(9);
        }

        private void btnLevel10_Click(object sender, EventArgs e)
        {
            RefreshAvailableCardList(10);
        }

        private void lstAvailable_SelectedIndexChanged(object sender, EventArgs e)
        {
            Card card = playerDeck.GetCardByName(lstAvailable.Text);

            pctPlayerCard.Image = Image.FromFile(@"Deck\Blue\" + card.fileName + ".jpg");
            lblPCCount.Text = playerDeck.GetCountById(card.id).ToString();
        }

        public void showFormModal(Form form)
        {
            form.ShowDialog(this);
        }
    }
}
