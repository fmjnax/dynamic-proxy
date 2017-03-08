using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleTriadOffline.Classes
{
    public class CardSlot : CardPictureBox
    {
        public CardSlot():base()
        {

        }

        public CardSlot(CardPictureBox cardPictureBox)
        {
            this.cardPictureBox = cardPictureBox;
        }

        public CardPictureBox cardPictureBox { get; set; }
        public int playSlot { get; set; }
        public double playScore { get; set; }
    }
}
