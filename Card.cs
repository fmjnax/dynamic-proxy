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
    public class Card
    {
        public Texture2D texture;
        public Rectangle rect;
        public Vector2 position;
        Vector2 center;

        public Card()
        {
            isUsed = false;
            id = 0;
            left = 0;
            top = 0;
            right = 0;
            bottom = 0;
            level = 0;
            displayName = "";
            fileName = "";
            currentColor = null;
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

        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        public Rectangle Rect
        {
            get { return rect; }
            set { rect = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Vector2 Center
        {
            get { return center; }
            set { center = value; }
        }
    }
}
