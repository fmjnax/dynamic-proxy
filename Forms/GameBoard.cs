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

        private int playerScore = 5;
        private int opponentScore = 5;

        private string gameResult = "";

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
        private Card selectedCard;

        private int checkMove = 0;

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

            TurnIndicator.Image = Image.FromFile(@"skins\p1-turn.gif");
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

            selectedCard = null;

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
                selectedCard = cardPctBox.card;

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
            if (turn == 1 && selectedCard != null)
            {
                Point point = new Point(e.X, e.Y);
                PlaceCard(point);

                checkMove = 1;
                CheckMove(placedSlot);

                UpdateScore();

                if (IsGameFinished() == false)
                {
                    SwitchTurns();

                    if (turn == 2)
                    {
                        OpponentTurn();
                    }
                }
                else
                {
                    //GameOver
                }
            }
        }

        private void PlaceCard(Point point)
        {
            for (int x = 0; x <= 8; x++)
            {
                if (slot[x].rect.Contains(point.X, point.Y) && slot[x].isOccupied == false)
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
                            }
                            break;
                        }
                    }
                    break;
                }
            }
        }

        private void SwitchTurns()
        {
            if (turn == 1)
            {
                turn = 2;
                TurnIndicator.Image = Image.FromFile(@"skins\p2-turn.gif");
            }
            else
            {
                turn = 1;
                TurnIndicator.Image = Image.FromFile(@"skins\p1-turn.gif");
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
                    FlipCard(slot[1], color);
                }
                if (slot[3].isOccupied == true && placedSlot.pctBox.card.bottom > slot[3].pctBox.card.top)
                {
                    FlipCard(slot[3], color);
                }
            }
            if (placedSlot == slot[1] && checkMove == 1)
            {
                //check slots 0, 2, and 4
                if (slot[0].isOccupied == true && placedSlot.pctBox.card.left > slot[0].pctBox.card.right)
                {
                    FlipCard(slot[0], color);
                }
                if (slot[2].isOccupied == true && placedSlot.pctBox.card.right > slot[2].pctBox.card.left)
                {
                    FlipCard(slot[2], color);
                }
                if (slot[4].isOccupied == true && placedSlot.pctBox.card.bottom > slot[4].pctBox.card.top)
                {
                    FlipCard(slot[4], color);
                }
            }
            else if (placedSlot == slot[2] && checkMove == 1)
            {
                //check slots 1 and 5
                if (slot[1].isOccupied == true && placedSlot.pctBox.card.left > slot[1].pctBox.card.right)
                {
                    FlipCard(slot[1], color);
                }
                if (slot[5].isOccupied == true && placedSlot.pctBox.card.bottom > slot[5].pctBox.card.top)
                {
                    FlipCard(slot[5], color);
                }
            }
            else if (placedSlot == slot[3] && checkMove == 1)
            {
                //check slots 0, 4, and 6
                if (slot[0].isOccupied == true && placedSlot.pctBox.card.top > slot[0].pctBox.card.bottom)
                {
                    FlipCard(slot[0], color);
                }
                if (slot[4].isOccupied == true && placedSlot.pctBox.card.right > slot[4].pctBox.card.left)
                {
                    FlipCard(slot[4], color);
                }
                if (slot[6].isOccupied == true && placedSlot.pctBox.card.bottom > slot[6].pctBox.card.top)
                {
                    FlipCard(slot[6], color);
                }
            }
            else if (placedSlot == slot[4] && checkMove == 1)
            {
                //check slots 1, 3, 5, and 7
                if (slot[1].isOccupied == true && placedSlot.pctBox.card.top > slot[1].pctBox.card.bottom)
                {
                    FlipCard(slot[1], color);
                }
                if (slot[3].isOccupied == true && placedSlot.pctBox.card.left > slot[3].pctBox.card.right)
                {
                    FlipCard(slot[3], color);
                }
                if (slot[5].isOccupied == true && placedSlot.pctBox.card.right > slot[5].pctBox.card.left)
                {
                    FlipCard(slot[5], color);
                }
                if (slot[7].isOccupied == true && placedSlot.pctBox.card.bottom > slot[7].pctBox.card.top)
                {
                    FlipCard(slot[7], color);
                }
            }
            else if (placedSlot == slot[5] && checkMove == 1)
            {
                //check slots 2, 4, and 8
                if (slot[2].isOccupied == true && placedSlot.pctBox.card.top > slot[2].pctBox.card.bottom)
                {
                    FlipCard(slot[2], color);
                }
                if (slot[4].isOccupied == true && placedSlot.pctBox.card.left > slot[4].pctBox.card.right)
                {
                    FlipCard(slot[4], color);
                }
                if (slot[8].isOccupied == true && placedSlot.pctBox.card.bottom > slot[8].pctBox.card.top)
                {
                    FlipCard(slot[8], color);
                }
            }
            else if (placedSlot == slot[6] && checkMove == 1)
            {
                //check slots 3 and 7
                if (slot[3].isOccupied == true && placedSlot.pctBox.card.top > slot[3].pctBox.card.bottom)
                {
                    FlipCard(slot[3], color);
                }
                if (slot[7].isOccupied == true && placedSlot.pctBox.card.right > slot[7].pctBox.card.left)
                {
                    FlipCard(slot[7], color);
                }
            }
            else if (placedSlot == slot[7] && checkMove == 1)
            {
                //check slots 4, 6, and 8
                if (slot[4].isOccupied == true && placedSlot.pctBox.card.top > slot[4].pctBox.card.bottom)
                {
                    FlipCard(slot[4], color);
                }
                if (slot[6].isOccupied == true && placedSlot.pctBox.card.left > slot[6].pctBox.card.right)
                {
                    FlipCard(slot[6], color);
                }
                if (slot[8].isOccupied == true && placedSlot.pctBox.card.right > slot[8].pctBox.card.left)
                {
                    FlipCard(slot[8], color);
                }
            }
            else if (placedSlot == slot[8] && checkMove == 1)
            {
                //check slots 5 and 7
                if (slot[5].isOccupied == true && placedSlot.pctBox.card.top > slot[5].pctBox.card.bottom)
                {
                    FlipCard(slot[5], color);
                }
                if (slot[7].isOccupied == true && placedSlot.pctBox.card.left > slot[7].pctBox.card.right)
                {
                    FlipCard(slot[7], color);
                }
            }
            checkMove = 0;
        }

        private void FlipCard(Slot slot, string color)
        {
            slot.pctBox.Image = Image.FromFile(@"Deck\" + color + @"\" + slot.pctBox.card.fileName + ".jpg");
            slot.pctBox.currentColor = color;
        }

        private void OpponentTurn()
        {
            //AI ranking, from easiest to hardest
            //1:
            //first available card in the first available slot
            //INITIAL LOGIC - Already Exists
            /*
            int slotLoop = 0;

            if (turn == 2)
            {
                foreach (Control oppCard in this.Controls)
                {
                    if (oppCard is PictureBox && oppCard.Name.Contains("OC"))
                    {
                        CardPictureBox cpb = (CardPictureBox)oppCard;
                        if (cpb.isUsed == false)
                        {
                            CardClick(cpb);
                            break;
                        }
                    }
                }

                while (slotLoop < 9)
                {
                    if (slot[slotLoop].isOccupied == false)
                    {
                        Point point = new Point(slot[slotLoop].rect.X, slot[slotLoop].rect.Y);
                        PlaceCard(point);
                        //PlayCard(selectedCard, gameBoard.slot[slotLoop]);
                        //reload the texture, in case "closed" rule
                        //selectedCard.Texture = Content.Load<Texture2D>("deck/" + selectedCard.currentColor + "/" + selectedCard.fileName);
                        break;
                    }
                    slotLoop++;
                }
            }
            */


            //2:
            //first available slot, find first slotted neighbor, first available card to beat else first available card, if no neighbor, first available card
            if (turn == 2)
            {
                int x = 0;

                for (x = 0; x < 9; x++)
                {
                    if (slot[x].isOccupied == false)
                    {
                        switch (x)
                        {
                            case 0:
                                if (slot[1].isOccupied == true)
                                {
                                    foreach (Control oppCard in this.Controls)
                                    {
                                        if (oppCard is PictureBox && oppCard.Name.Contains("OC"))
                                        {
                                            CardPictureBox cpb = (CardPictureBox)oppCard;
                                            if (cpb.isUsed == false && cpb.card.right > slot[1].pctBox.card.left)
                                            {
                                                CardClick(cpb);

                                                Point point = new Point(slot[x].rect.X, slot[x].rect.Y);
                                                PlaceCard(point);

                                                break;
                                            }
                                        }
                                    }
                                }
                                else if (slot[3].isOccupied == true)
                                {
                                    foreach (Control oppCard in this.Controls)
                                    {
                                        if (oppCard is PictureBox && oppCard.Name.Contains("OC"))
                                        {
                                            CardPictureBox cpb = (CardPictureBox)oppCard;
                                            if (cpb.isUsed == false && cpb.card.bottom > slot[3].pctBox.card.top)
                                            {
                                                CardClick(cpb);

                                                Point point = new Point(slot[x].rect.X, slot[x].rect.Y);
                                                PlaceCard(point);

                                                break;
                                            }
                                        }
                                    }
                                }
                                else
                                {

                                }

                                break;
                            case 1:
                                break;
                            case 2:
                                break;
                            case 3:
                                break;
                            case 4:
                                break;
                            case 5:
                                break;
                            case 6:
                                break;
                            case 7:
                                break;
                            case 8:
                                break;
                        }

                        break;
                    }
                    x++;
                }
            }

            //3:
            //first available slot, find first slotted neighbor, build list of all available cards to beat, 
            //find second slotted neighbor, build list of all available cards to beat, 
            //compare first list and second list, first available match, 
            //if not list match, first available from first list group
            //if no neighbors, first available card

            //4:
            //first available slot, find first slotted neighbor, build list of all available cards to beat, 
            //find second slotted neighbor, build list of all available cards to beat, 
            //find third slotted neighbor, build list of all available cards to beat, 
            //compare all lists, first available match, 
            //if not list match, compare 2 lists (1&2, 1&3, 2&3) for match, first available match
            //if not list match, first available from list group
            //if no neighbors, first available card

            //5:
            //first available slot, find first slotted neighbor, build list of all available cards to beat, 
            //find second slotted neighbor, build list of all available cards to beat, 
            //find third slotted neighbor, build list of all available cards to beat, 
            //find fourth slotted neighbor, build list of all available cards to beat, 
            //compare all lists, first available match, 
            //if not list match, compare 3 lists (1&2&3, 1&2&4, 1&3&4, 2&3&4) for match, first available match
            //if not list match, compare 2 lists (1&2, 1&3, 1&4, 2&3, 2&4) for match, first available match
            //if not list match, first available from list group
            //if no neighbors, first available card

            //6:
            //use AI 5 logic, except instead of first available:
            //card with highest number facing first open slot

            //7:
            //use AI 5 logic, except instead of first available:
            //card with highest number AVERAGE facing two open slots

            //8:
            //use AI 5 logic, except instead of first available:
            //card with highest number AVERAGE facing three open slots

            //9:
            //use AI 5 logic, except instead of first available:
            //card with highest number AVERAGE facing four open slots

            //10:
            //use AI 9 logic, but add GOD MODE!!!!! (TBD)
            //Maybe God mode scans player hand and compares open facing card with opposite side of opponent hand
            //and picks the card that the player cannot beat. Would be unavailable in a "closed" table, though.
            //Instead of looking at the first available slot, look at them all and determine which card is the best play
            //Maybe more ideas will come as above AI is implemented and tested
            //Add more thoughts as needed. 


           

            checkMove = 1;
            CheckMove(placedSlot);

            UpdateScore();

            if (IsGameFinished() == false)
            {
                SwitchTurns();
            }
            else
            {
                //GameOver
            }
        }

        private void UpdateScore()
        {
            int blue = 0;
            int red = 0;
            int x = 0;

            foreach (Control pctBox in this.Controls)
            {
                if (pctBox is PictureBox && pctBox.Name.Contains("pct"))
                {
                    CardPictureBox cpb = (CardPictureBox)pctBox;
                    if (cpb.Name.Contains("PC") && cpb.isUsed == false)
                    {
                        blue++;
                    }
                    else if (cpb.Name.Contains("OC") && cpb.isUsed == false)
                    {
                        red++;
                    }
                }
            }

            x = 0;
            while (x < 9)
            {
                if (slot[x].isOccupied)
                {
                    if (slot[x].pctBox.currentColor == "red")
                    {
                        red++;
                    }
                    if (slot[x].pctBox.currentColor == "blue")
                    {
                        blue++;
                    }
                }
                x++;
            }
            playerScore = blue;
            opponentScore = red;

            lblBlueScore.Text = playerScore.ToString();
            lblRedScore.Text = opponentScore.ToString();
        }

        private bool IsGameFinished()
        {
            bool returnCondition = false;

            int x = 0;
            int spacesOccupied = 0;

            while (x < 9)
            {
                if (slot[x].isOccupied == true)
                {
                    spacesOccupied++;
                }
                x++;
            }

            if (spacesOccupied == 9)
            {
                //Game is over. Check for winner/loser
                if (playerScore > opponentScore)
                {
                    gameResult = "You win!";
                }
                else if (opponentScore > playerScore)
                {
                    gameResult = "You lose!";
                }
                else if (playerScore == opponentScore)
                {
                    gameResult = "Tie game!";
                }

                lblGameResult.Text = gameResult;
                returnCondition = true;
            }
            return returnCondition;
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
