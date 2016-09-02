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
using TripleTriadOffline.Classes;

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

        Slot placedSlot;

        private int checkMove = 0;

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

            //Player hand
            var x = 1;
            foreach (var card in playingHand)
            {
                foreach (Control pctBox in this.Controls)
                {
                    if (pctBox is PictureBox && pctBox.Name.Contains("PC" + x.ToString()))
                    {
                        CardPictureBox cardPctBox = (CardPictureBox)pctBox;

                        cardPctBox.Image = Image.FromFile(@"Deck\Blue\" + card.fileName + ".jpg");
                        cardPctBox.card = card;
                        cardPctBox.isUsed = false;
                        cardPctBox.currentColor = "blue";
                        break;
                    }
                }
                x++;
            }

            //Opponent hand
            x = 1;
            foreach (var card in playingHand)
            {
                foreach (Control pctBox in this.Controls)
                {
                    if (pctBox is PictureBox && pctBox.Name.Contains("OC" + x.ToString()))
                    {
                        CardPictureBox cardPctBox = (CardPictureBox)pctBox;

                        cardPctBox.Image = Image.FromFile(@"Deck\Red\" + card.fileName + ".jpg");
                        cardPctBox.card = card;
                        cardPctBox.isUsed = false;
                        cardPctBox.currentColor = "red";
                        break;
                    }
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

        private void pctOC1_Click(object sender, EventArgs e)
        {
            CardClick(pctOC1);
        }

        private void pctOC2_Click(object sender, EventArgs e)
        {
            CardClick(pctOC2);
        }

        private void pctOC3_Click(object sender, EventArgs e)
        {
            CardClick(pctOC3);
        }

        private void pctOC4_Click(object sender, EventArgs e)
        {
            CardClick(pctOC4);
        }

        private void pctOC5_Click(object sender, EventArgs e)
        {
            CardClick(pctOC5);
        }

        private void CardClick(PictureBox cardBox)
        {
            CardPictureBox cardPctBox = (CardPictureBox)cardBox;

            if (cardPctBox.isUsed == false)
            {
                foreach (Control x in this.Controls)
                {
                    if (x is PictureBox && x.Name.Contains("pct"))
                    {
                        CardPictureBox cpb = (CardPictureBox)x;
                        if (cpb.isUsed == false)
                        {
                            pctPC5.SendToBack();
                            pctPC4.SendToBack();
                            pctPC3.SendToBack();
                            pctPC2.SendToBack();
                            pctPC1.SendToBack();

                            pctOC5.SendToBack();
                            pctOC4.SendToBack();
                            pctOC3.SendToBack();
                            pctOC2.SendToBack();
                            pctOC1.SendToBack();

                            if (cpb.Name.Contains("PC") && cpb.Name != cardPctBox.Name)
                            {
                                cpb.Left = plcol;
                            }
                            else if (cpb.Name.Contains("OC") && cpb.Name != cardPctBox.Name)
                            {
                                cpb.Left = orcol;
                            }
                        }
                    }
                }

                cardPctBox.BringToFront();

                if (cardPctBox.Name.Contains("pctPC") && cardPctBox.isUsed == false && cardPctBox.Left == plcol)
                {
                    cardPctBox.Left = cardPctBox.Left + plmove;
                }
                else if (cardPctBox.Name.Contains("pctOC") && cardPctBox.isUsed == false && cardPctBox.Left == orcol)
                {
                    cardPctBox.Left = cardPctBox.Left + ormove;
                }
            }
        }

        private void GameBoard_MouseClick(object sender, MouseEventArgs e)
        {
            for (int x = 0; x <= 8; x++)
            {
                if (slot[x].rect.Contains(e.X, e.Y) && slot[x].isOccupied == false)
                {
                    foreach (Control pctBox in this.Controls)
                    {
                        if (pctBox is PictureBox && pctBox.Left > plmove)
                        {
                            CardPictureBox cardPctBox = (CardPictureBox)pctBox;

                            if (cardPctBox.isUsed == false)
                            {
                                cardPctBox.Left = slot[x].rect.X;
                                cardPctBox.Top = slot[x].rect.Y;
                                cardPctBox.isUsed = true;

                                slot[x].cardSlotted = cardPctBox.card;
                                slot[x].isOccupied = true;
                                slot[x].pctBox = cardPctBox;


                                //selected card is moved to an open slot. Now let's calculate the move and switch turns
                                placedSlot = slot[x];
                                checkMove = 1;

                                CheckMove(placedSlot);
                            }
                            break;
                        }
                    }
                    break;
                }
            }
        }

        private void CheckMove(Slot placedSlot)
        {
            string color = "";

            if (checkMove == 1) { color = placedSlot.pctBox.currentColor == "red" ? "red" : "blue"; }

            if (placedSlot == slot[0] && checkMove == 1)
            {
                //check slots 1 and 3
                if (slot[1].isOccupied == true && placedSlot.pctBox.card.right > slot[1].pctBox.card.left)
                {
                    slot[1].pctBox.Image = Image.FromFile(@"Deck\" + color + @"\" + slot[1].pctBox.card.fileName + ".jpg");
                    slot[1].pctBox.currentColor = color;
                }
                if (slot[3].isOccupied == true && placedSlot.pctBox.card.bottom > slot[3].pctBox.card.top)
                {
                    slot[3].pctBox.Image = Image.FromFile(@"Deck\" + color + @"\" + slot[3].pctBox.card.fileName + ".jpg");
                    slot[3].pctBox.currentColor = color;
                }
            }
            if (placedSlot == slot[1] && checkMove == 1)
            {
                //check slots 0, 2, and 4
                if (slot[0].isOccupied == true && placedSlot.pctBox.card.left > slot[0].pctBox.card.right)
                {
                    slot[0].pctBox.Image = Image.FromFile(@"Deck\" + color + @"\" + slot[0].pctBox.card.fileName + ".jpg");
                    slot[0].pctBox.currentColor = color;
                }
                if (slot[2].isOccupied == true && placedSlot.pctBox.card.bottom > slot[2].pctBox.card.top)
                {
                    slot[2].pctBox.Image = Image.FromFile(@"Deck\" + color + @"\" + slot[2].pctBox.card.fileName + ".jpg");
                    slot[2].pctBox.currentColor = color;
                }
                if (slot[4].isOccupied == true && placedSlot.pctBox.card.right > slot[4].pctBox.card.left)
                {
                    slot[4].pctBox.Image = Image.FromFile(@"Deck\" + color + @"\" + slot[4].pctBox.card.fileName + ".jpg");
                    slot[4].pctBox.currentColor = color;
                }
            }
            else if (placedSlot == slot[2] && checkMove == 1)
            {
                //check slots 1 and 5
                if (slot[1].isOccupied == true && placedSlot.pctBox.card.left > slot[1].pctBox.card.right)
                {
                    slot[1].pctBox.Image = Image.FromFile(@"Deck\" + color + @"\" + slot[1].pctBox.card.fileName + ".jpg");
                    slot[1].pctBox.currentColor = color;
                }
                if (slot[5].isOccupied == true && placedSlot.pctBox.card.bottom > slot[5].pctBox.card.top)
                {
                    slot[5].pctBox.Image = Image.FromFile(@"Deck\" + color + @"\" + slot[5].pctBox.card.fileName + ".jpg");
                    slot[5].pctBox.currentColor = color;
                }
            }
            else if (placedSlot == slot[3] && checkMove == 1)
            {
                //check slots 0, 4, and 6
                if (slot[0].isOccupied == true && placedSlot.pctBox.card.top > slot[0].pctBox.card.bottom)
                {
                    slot[0].pctBox.Image = Image.FromFile(@"Deck\" + color + @"\" + slot[0].pctBox.card.fileName + ".jpg");
                    slot[0].pctBox.currentColor = color;
                }
                if (slot[4].isOccupied == true && placedSlot.pctBox.card.right > slot[4].pctBox.card.left)
                {
                    slot[4].pctBox.Image = Image.FromFile(@"Deck\" + color + @"\" + slot[4].pctBox.card.fileName + ".jpg");
                    slot[4].pctBox.currentColor = color;
                }
                if (slot[6].isOccupied == true && placedSlot.pctBox.card.bottom > slot[6].pctBox.card.top)
                {
                    slot[6].pctBox.Image = Image.FromFile(@"Deck\" + color + @"\" + slot[6].pctBox.card.fileName + ".jpg");
                    slot[6].pctBox.currentColor = color;
                }
            }
            else if (placedSlot == slot[4] && checkMove == 1)
            {
                //check slots 1, 3, 5, and 7
                if (slot[1].isOccupied == true && placedSlot.pctBox.card.top > slot[1].pctBox.card.bottom)
                {
                    slot[1].pctBox.Image = Image.FromFile(@"Deck\" + color + @"\" + slot[1].pctBox.card.fileName + ".jpg");
                    slot[1].pctBox.currentColor = color;
                }
                if (slot[3].isOccupied == true && placedSlot.pctBox.card.left > slot[3].pctBox.card.right)
                {
                    slot[3].pctBox.Image = Image.FromFile(@"Deck\" + color + @"\" + slot[3].pctBox.card.fileName + ".jpg");
                    slot[3].pctBox.currentColor = color;
                }
                if (slot[5].isOccupied == true && placedSlot.pctBox.card.right > slot[5].pctBox.card.left)
                {
                    slot[5].pctBox.Image = Image.FromFile(@"Deck\" + color + @"\" + slot[5].pctBox.card.fileName + ".jpg");
                    slot[5].pctBox.currentColor = color;
                }
                if (slot[7].isOccupied == true && placedSlot.pctBox.card.bottom > slot[7].pctBox.card.top)
                {
                    slot[7].pctBox.Image = Image.FromFile(@"Deck\" + color + @"\" + slot[7].pctBox.card.fileName + ".jpg");
                    slot[7].pctBox.currentColor = color;
                }
            }
            else if (placedSlot == slot[5] && checkMove == 1)
            {
                //check slots 2, 4, and 8
                if (slot[2].isOccupied == true && placedSlot.pctBox.card.top > slot[2].pctBox.card.bottom)
                {
                    slot[2].pctBox.Image = Image.FromFile(@"Deck\" + color + @"\" + slot[2].pctBox.card.fileName + ".jpg");
                    slot[2].pctBox.currentColor = color;
                }
                if (slot[4].isOccupied == true && placedSlot.pctBox.card.left > slot[4].pctBox.card.right)
                {
                    slot[4].pctBox.Image = Image.FromFile(@"Deck\" + color + @"\" + slot[4].pctBox.card.fileName + ".jpg");
                    slot[4].pctBox.currentColor = color;
                }
                if (slot[8].isOccupied == true && placedSlot.pctBox.card.bottom > slot[8].pctBox.card.top)
                {
                    slot[8].pctBox.Image = Image.FromFile(@"Deck\" + color + @"\" + slot[8].pctBox.card.fileName + ".jpg");
                    slot[8].pctBox.currentColor = color;
                }
            }
            else if (placedSlot == slot[6] && checkMove == 1)
            {
                //check slots 3 and 7
                if (slot[3].isOccupied == true && placedSlot.pctBox.card.top > slot[3].pctBox.card.bottom)
                {
                    slot[3].pctBox.Image = Image.FromFile(@"Deck\" + color + @"\" + slot[3].pctBox.card.fileName + ".jpg");
                    slot[3].pctBox.currentColor = color;
                }
                if (slot[7].isOccupied == true && placedSlot.pctBox.card.right > slot[7].pctBox.card.left)
                {
                    slot[7].pctBox.Image = Image.FromFile(@"Deck\" + color + @"\" + slot[7].pctBox.card.fileName + ".jpg");
                    slot[7].pctBox.currentColor = color;
                }
            }
            else if (placedSlot == slot[7] && checkMove == 1)
            {
                //check slots 4, 6, and 8
                if (slot[4].isOccupied == true && placedSlot.pctBox.card.top > slot[4].pctBox.card.bottom)
                {
                    slot[4].pctBox.Image = Image.FromFile(@"Deck\" + color + @"\" + slot[4].pctBox.card.fileName + ".jpg");
                    slot[4].pctBox.currentColor = color;
                }
                if (slot[6].isOccupied == true && placedSlot.pctBox.card.right > slot[6].pctBox.card.left)
                {
                    slot[6].pctBox.Image = Image.FromFile(@"Deck\" + color + @"\" + slot[6].pctBox.card.fileName + ".jpg");
                    slot[6].pctBox.currentColor = color;
                }
                if (slot[8].isOccupied == true && placedSlot.pctBox.card.left > slot[8].pctBox.card.right)
                {
                    slot[8].pctBox.Image = Image.FromFile(@"Deck\" + color + @"\" + slot[8].pctBox.card.fileName + ".jpg");
                    slot[8].pctBox.currentColor = color;
                }
            }
            else if (placedSlot == slot[8] && checkMove == 1)
            {
                //check slots 5 and 7
                if (slot[5].isOccupied == true && placedSlot.pctBox.card.top > slot[5].pctBox.card.bottom)
                {
                    slot[5].pctBox.Image = Image.FromFile(@"Deck\" + color + @"\" + slot[5].pctBox.card.fileName + ".jpg");
                    slot[5].pctBox.currentColor = color;
                }
                if (slot[7].isOccupied == true && placedSlot.pctBox.card.left > slot[7].pctBox.card.right)
                {
                    slot[7].pctBox.Image = Image.FromFile(@"Deck\" + color + @"\" + slot[7].pctBox.card.fileName + ".jpg");
                    slot[7].pctBox.currentColor = color;
                }
            }
            checkMove = 0;
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
