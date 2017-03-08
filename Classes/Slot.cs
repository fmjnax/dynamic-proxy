using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using TripleTriadOffline.Classes;

namespace TripleTriadOffline
{
    public class Slot
    {
        public Card cardSlotted;
        //public Slot(){}
        public Slot(string Name, Rectangle Rect)
        {
            name = Name;
            rect = Rect;
            isOccupied = false;
            pctBox = null;
            neighbors = 0;
            openSlots = 0;
        }

        public string name { get; set; }
        public Rectangle rect { get; set; }
        public bool isOccupied { get; set; }
        public CardPictureBox pctBox { get; set; }
        //public Card CardSlotted 
        //{
        //    get {return cardSlotted;}
        //    set {cardSlotted = value;}
        //}
        public double neighbors { get; set; }
        public double openSlots { get; set; }
    }
}
