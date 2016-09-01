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
    public partial class ConfirmHand : Form
    {
        private Deck playingHand;

        public ConfirmHand()
        {
            InitializeComponent();
        }

        public ConfirmHand(Deck playingHand)
        {
            this.playingHand = playingHand;
            InitializeComponent();
        }

        private void ConfirmHand_Load(object sender, EventArgs e)
        {
            var x = 1;
            foreach (var card in playingHand)
            {
                switch (x)
                {
                    case 1:
                        pctCard1.Image = Image.FromFile(@"Deck\Blue\" + card.fileName + ".jpg");
                        break;
                    case 2:
                        pctCard2.Image = Image.FromFile(@"Deck\Blue\" + card.fileName + ".jpg");
                        break;
                    case 3:
                        pctCard3.Image = Image.FromFile(@"Deck\Blue\" + card.fileName + ".jpg");
                        break;
                    case 4:
                        pctCard4.Image = Image.FromFile(@"Deck\Blue\" + card.fileName + ".jpg");
                        break;
                    case 5:
                        pctCard5.Image = Image.FromFile(@"Deck\Blue\" + card.fileName + ".jpg");
                        break;
                }
                x++;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Game.RejectHand(playingHand);
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            Game.AcceptHand(playingHand);
        }
    }
}
