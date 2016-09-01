using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
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

        private bool dragging;
        private Point pointClicked;

        public Rectangle rect;
        public Rectangle topBar;

        private int plcol = 25;

        private int plrow = 25;
        private int ploffset = 50;

        private int plmove = 25;

        private int orcol = 410;
        private int orrow = 25;
        private int oroffset = 50;
        private int ormove = -25;

        private int turn = 1;

        public Slot[] slot = new Slot[9];
        
        public Vector2 position;
         Vector2 center;

        public GameBoard(Deck playingHand)
        {
            InitializeComponent();

            topBar = new Rectangle(0, 0, 496, 15);

            slot[0] = new Slot("TL", new Rectangle(152, 114, 65, 65));
            slot[1] = new Slot("TM", new Rectangle(219, 114, 65, 65));
            slot[2] = new Slot("TR", new Rectangle(286, 114, 65, 65));
            slot[3] = new Slot("ML", new Rectangle(152, 182, 65, 65));
            slot[4] = new Slot("MM", new Rectangle(219, 182, 65, 65));
            slot[5] = new Slot("MR", new Rectangle(286, 182, 65, 65));
            slot[6] = new Slot("BL", new Rectangle(152, 250, 65, 65));
            slot[7] = new Slot("BM", new Rectangle(219, 250, 65, 65));
            slot[8] = new Slot("BR", new Rectangle(286, 250, 65, 65));

            
            var x = 1;
            foreach (var card in playingHand)
            {
                switch (x)
                {
                    case 1:
                        pctPC1.Image = Image.FromFile(@"Deck\Blue\" + card.fileName + ".jpg");
                        break;
                    case 2:
                        pctPC2.Image = Image.FromFile(@"Deck\Blue\" + card.fileName + ".jpg");
                        break;
                    case 3:
                        pctPC3.Image = Image.FromFile(@"Deck\Blue\" + card.fileName + ".jpg");
                        break;
                    case 4:
                        pctPC4.Image = Image.FromFile(@"Deck\Blue\" + card.fileName + ".jpg");
                        break;
                    case 5:
                        pctPC5.Image = Image.FromFile(@"Deck\Blue\" + card.fileName + ".jpg");
                        break;
                }
                x++;
            }
        }

        private void GameBoard_Load(object sender, EventArgs e)
        {

        }

        private void pctPC1_Click(object sender, EventArgs e)
        {
            CardClick(pctPC1);
        }

        private void pctPC2_Click(object sender, EventArgs e)
        {
            CardClick(pctPC2);
        }

        private void pctPC3_Click(object sender, EventArgs e)
        {
            CardClick(pctPC3);
        }

        private void pctPC4_Click(object sender, EventArgs e)
        {
            CardClick(pctPC4);
        }

        private void pctPC5_Click(object sender, EventArgs e)
        {
            CardClick(pctPC5);
        }

        private void CardClick(PictureBox cardBox)
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Name.Contains("pctPC"))
                {
                    //x.SendToBack();
                    pctPC5.SendToBack();
                    pctPC4.SendToBack();
                    pctPC3.SendToBack();
                    pctPC2.SendToBack();
                    pctPC1.SendToBack();
                    x.Left = plcol;
                }
            }

            cardBox.BringToFront();
            cardBox.Left = cardBox.Left + plmove;
        }

        private void GameBoard_MouseClick(object sender, MouseEventArgs e)
        {
            for (int x = 0; x <= 8; x++)
            {
                if (slot[x].rect.Contains(e.X, e.Y))
                {
                    pctPC1.Left = slot[x].rect.X;
                    pctPC1.Top = slot[x].rect.Y;
                    break;
                }
            }
        }
 
        private void lblTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                pointClicked = new Point(e.X, e.Y);
            }
            else
            {
                dragging = false;
            }
        }

        private void lblTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point pointMoveTo;
                pointMoveTo = this.PointToScreen(new Point(e.X, e.Y));

                pointMoveTo.Offset(-pointClicked.X, -pointClicked.Y);

                this.Location = pointMoveTo;
            }
        }

        private void lblTop_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}
