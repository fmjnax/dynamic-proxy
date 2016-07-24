using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TripleTriadOffline
{
    public partial class GameBoard : Form
    {
        public Rectangle rect;

        public Slot[] slot = new Slot[9];
        
        public Vector2 position;
         Vector2 center;

        public GameBoard()
        {
            InitializeComponent();

            slot[0] = new Slot("TL", new Rectangle(152, 114, 65, 65));
            slot[1] = new Slot("TM", new Rectangle(219, 114, 65, 65));
            slot[2] = new Slot("TR", new Rectangle(286, 114, 65, 65));
            slot[3] = new Slot("ML", new Rectangle(152, 182, 65, 65));
            slot[4] = new Slot("MM", new Rectangle(219, 182, 65, 65));
            slot[5] = new Slot("MR", new Rectangle(286, 182, 65, 65));
            slot[6] = new Slot("BL", new Rectangle(152, 250, 65, 65));
            slot[7] = new Slot("BM", new Rectangle(219, 250, 65, 65));
            slot[8] = new Slot("BR", new Rectangle(286, 250, 65, 65));
        }

        private void GameBoard_Load(object sender, EventArgs e)
        {

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
