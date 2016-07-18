using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

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
