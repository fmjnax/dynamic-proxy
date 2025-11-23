using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace TripleTriadOffline
{
    public class Slot
    {
        public Card cardSlotted;
        public Slot(){}
        public Slot(string Name, Rectangle Rect)
        {
            name = Name;
            rect = Rect;
            isOccupied = false;
        }

        public string name { get; set; }
        public Rectangle rect { get; set; }
        public bool isOccupied { get; set; }
        public Card CardSlotted 
        {
            get {return cardSlotted;}
            set {cardSlotted = value;}
        }
    }
}
