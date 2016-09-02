using System.Drawing;

namespace TripleTriadOffline
{
    public class Card
    {
        //public Texture2D texture;
        public Rectangle rect;

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
            native = 0;
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

        //public Texture2D Texture
        //{
        //    get { return texture; }
        //    set { texture = value; }
        //}

        public Rectangle Rect
        {
            get { return rect; }
            set { rect = value; }
        }
    }
}
