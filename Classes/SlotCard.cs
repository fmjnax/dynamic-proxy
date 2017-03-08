using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleTriadOffline.Classes
{
    public class SlotCard : CardPictureBox
    {
        public SlotCard():base()
        {

        }

        public SlotCard(Card card)
        {
            this.card = card;
        }

        public SlotCard(CardPictureBox cardPictureBox)
        {
            this.cardPictureBox = cardPictureBox;
        }

        public SlotCard(CardPictureBox cardPictureBox, Card card)
        {
            this.cardPictureBox = cardPictureBox;
            this.card = card;
        }

        public CardPictureBox cardPictureBox { get; set; }
        public int playSlot { get; set; }
        public double playScore { get; set; }
    }
}
