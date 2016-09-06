using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TripleTriadOffline.Classes
{
    public class CardPictureBox : PictureBox
    {

        public CardPictureBox():base()
        {

        }

        public bool isUsed { get; set; }
        public int id { get; set; }
        public int left { get; set; }
        public int top { get; set; }
        public int right { get; set; }
        public int bottom { get; set; }
        public int level { get; set; }
        public string displayName { get; set; }
        public string fileName { get; set; }
        public string currentColor { get; set; }
        public int native { get; set; }
        public Card card { get; set; }
        public bool canBeatLeft { get; set; }
        public bool canBeatRight { get; set; }
        public bool canBeatTop { get; set; }
        public bool canLoseBottom { get; set; }
        public bool canLoseLeft { get; set; }
        public bool canLoseRight { get; set; }
        public bool canLoseTop { get; set; }
        public bool canBeatBottom { get; set; }
        public double attackScore { get; set; }
        public double defenseScore { get; set; }
        public double defenseMultiplier { get; set; }
        public double playScore { get; set; }
        public int playableSlot { get; set; }
    }
}
