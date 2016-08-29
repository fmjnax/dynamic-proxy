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

        public SelectCards()
        {
            InitializeComponent();
        }

        private void btnSelectCard_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void SelectCards_Load(object sender, EventArgs e)
        {
            Card[] playerCard = new Card[5];

            List<string> playerCardList = new List<string>();
            playerCardList.Add("1");
            playerCardList.Add("3");
            playerCardList.Add("5");
            playerCardList.Add("7");
            playerCardList.Add("9");

            LoadPlayingHand(playerCardList, playerCard, "blue", true);
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
            lstAvailable.Items.Clear();

            foreach (var r in masterDeckCards)
            {
                lstAvailable.Items.Add(r.DisplayName);
            }
        }
    }
}
