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
        public Rectangle topBar;

        private int playerScore = 5;
        private int opponentScore = 5;
        private string gameResult = "";

        private int plcol = 25;
        private int plmove = 25;
        private int orcol = 410;
        private int ormove = -25;

        private int turn;

        public Slot[] slot = new Slot[9];

        Slot placedSlot;
        private CardPictureBox selectedCard;

        private int checkMove = 0;

        private List<CardPictureBox> playerHand = new List<CardPictureBox>();
        private List<CardPictureBox> opponentHand = new List<CardPictureBox>();

        private static GameRules ruleSet;

        public GameBoard(Deck playingHand, GameRules incomingRules)
        {
            InitializeComponent();

            ruleSet = incomingRules;

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
                        cardPctBox.left = card.left;
                        cardPctBox.top = card.top;
                        cardPctBox.right = card.right;
                        cardPctBox.bottom = card.bottom;
                        cardPctBox.isUsed = false;
                        cardPctBox.canBeatLeft = false;
                        cardPctBox.canBeatTop = false;
                        cardPctBox.canBeatRight = false;
                        cardPctBox.canBeatBottom = false;
                        cardPctBox.currentColor = "blue";

                        playerHand.Add(cardPctBox);

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

                        if (ruleSet.open == true)
                        {
                            cardPctBox.Image = Image.FromFile(@"Deck\Red\" + card.fileName + ".jpg");
                        }
                        else
                        {
                            cardPctBox.Image = Image.FromFile(@"skins\cardBack.png");
                        }

                        cardPctBox.card = card;
                        cardPctBox.left = card.left;
                        cardPctBox.top = card.top;
                        cardPctBox.right = card.right;
                        cardPctBox.bottom = card.bottom;
                        cardPctBox.isUsed = false;
                        cardPctBox.canBeatLeft = false;
                        cardPctBox.canBeatTop = false;
                        cardPctBox.canBeatRight = false;
                        cardPctBox.canBeatBottom = false;
                        cardPctBox.currentColor = "red";

                        opponentHand.Add(cardPctBox);

                        break;
                    }
                }
                x++;
            }

            UpdateSlotProperties();

            Random r = new Random();
            turn = r.Next(1, 3);

            if (turn == 1)
            {
                TurnIndicator.Image = Image.FromFile(@"skins\p1-turn.gif");
            }
            else
            {
                TurnIndicator.Image = Image.FromFile(@"skins\p2-turn.gif");
                OpponentTurn();
            }
            
        }

        private void GameBoard_Load(object sender, EventArgs e)
        {

        }

        private void pctPC1_Click(object sender, EventArgs e)
        {
            CardClick((CardPictureBox)playerHand[0], playerHand);
        }

        private void pctPC2_Click(object sender, EventArgs e)
        {
            CardClick((CardPictureBox)playerHand[1], playerHand);
        }

        private void pctPC3_Click(object sender, EventArgs e)
        {
            CardClick((CardPictureBox)playerHand[2], playerHand);
        }

        private void pctPC4_Click(object sender, EventArgs e)
        {
            CardClick((CardPictureBox)playerHand[3], playerHand);
        }

        private void pctPC5_Click(object sender, EventArgs e)
        {
            CardClick((CardPictureBox)playerHand[4], playerHand);
        }

        private void CardClick(CardPictureBox incomingCard, List<CardPictureBox> ownerHand)
        {
            int colAlign = 0, colMove = 0;

            { colAlign = turn == 1 ? plcol : orcol; }
            { colMove = turn == 1 ? plmove : ormove; }

            if (incomingCard.isUsed == false)
            {
                selectedCard = incomingCard;
                for (int x = 4; x > -1; x--)
                {
                    ownerHand[x].SendToBack();
                    if (ownerHand[x].Name != selectedCard.Name && ownerHand[x].isUsed == false)
                    {
                        ownerHand[x].Left = colAlign;
                    }
                }
                selectedCard.BringToFront();

                if (selectedCard.Left == colAlign)
                {
                    selectedCard.Left = selectedCard.Left + colMove;
                }
            }
        }

        private void GameBoard_MouseClick(object sender, MouseEventArgs e)
        {
            if (turn == 1 && selectedCard != null)
            {
                Point point = new Point(e.X, e.Y);

                for (int x = 0; x < 9; x++)
                {
                    if (slot[x].rect.Contains(point.X, point.Y))
                    {
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
            }
        }

        private void PlaceCard(Point point)
        {
            for (int x = 0; x <= 8; x++)
            {
                if (slot[x].rect.Contains(point.X, point.Y) && slot[x].isOccupied == false)
                {
                    if (selectedCard.isUsed == false)
                    {
                        selectedCard.Left = slot[x].rect.X;
                        selectedCard.Top = slot[x].rect.Y;
                        selectedCard.isUsed = true;

                        slot[x].cardSlotted = selectedCard.card;
                        slot[x].isOccupied = true;
                        slot[x].pctBox = selectedCard;

                        UpdateSlotProperties();

                        if (turn == 2 && ruleSet.open == false)
                        {
                            selectedCard.Image = Image.FromFile(@"Deck\Red\" + selectedCard.card.fileName + ".jpg");
                        }
                        
                        placedSlot = slot[x];
                    }
                }
            }
        }

        private void UpdateSlotProperties()
        {
            for (int x=0; x<9; x++)
            {
                int neighbors = 0;
                int openSlots = 0;

                switch (x)
                {
                    case 0:
                        if (slot[1].isOccupied == true) { neighbors++; } else { openSlots++; }
                        if (slot[3].isOccupied == true) { neighbors++; } else { openSlots++; }
                        break;
                    case 1:
                        if (slot[0].isOccupied == true) { neighbors++; } else { openSlots++; }
                        if (slot[2].isOccupied == true) { neighbors++; } else { openSlots++; }
                        if (slot[4].isOccupied == true) { neighbors++; } else { openSlots++; }
                        break;
                    case 2:
                        if (slot[1].isOccupied == true) { neighbors++; } else { openSlots++; }
                        if (slot[5].isOccupied == true) { neighbors++; } else { openSlots++; }
                        break;
                    case 3:
                        if (slot[0].isOccupied == true) { neighbors++; } else { openSlots++; }
                        if (slot[4].isOccupied == true) { neighbors++; } else { openSlots++; }
                        if (slot[6].isOccupied == true) { neighbors++; } else { openSlots++; }
                        break;
                    case 4:
                        if (slot[1].isOccupied == true) { neighbors++; } else { openSlots++; }
                        if (slot[3].isOccupied == true) { neighbors++; } else { openSlots++; }
                        if (slot[5].isOccupied == true) { neighbors++; } else { openSlots++; }
                        if (slot[7].isOccupied == true) { neighbors++; } else { openSlots++; }
                        break;
                    case 5:
                        if (slot[2].isOccupied == true) { neighbors++; } else { openSlots++; }
                        if (slot[4].isOccupied == true) { neighbors++; } else { openSlots++; }
                        if (slot[8].isOccupied == true) { neighbors++; } else { openSlots++; }
                        break;
                    case 6:
                        if (slot[3].isOccupied == true) { neighbors++; } else { openSlots++; }
                        if (slot[7].isOccupied == true) { neighbors++; } else { openSlots++; }
                        break;
                    case 7:
                        if (slot[4].isOccupied == true) { neighbors++; } else { openSlots++; }
                        if (slot[6].isOccupied == true) { neighbors++; } else { openSlots++; }
                        if (slot[8].isOccupied == true) { neighbors++; } else { openSlots++; }
                        break;
                    case 8:
                        if (slot[5].isOccupied == true) { neighbors++; } else { openSlots++; }
                        if (slot[7].isOccupied == true) { neighbors++; } else { openSlots++; }
                        break;
                }

                slot[x].neighbors = neighbors;
                slot[x].openSlots = openSlots;
            }
        }

        private void SwitchTurns()
        {
            { turn = turn == 1 ? 2 : 1; }
            { TurnIndicator.Image = turn == 1 ? Image.FromFile(@"skins\p1-turn.gif") : Image.FromFile(@"skins\p2-turn.gif"); }
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
            if (turn == 2)
            {
                for (int x = 0; x <5; x++)
                {
                    if (opponentHand[x].isUsed == false)
                    {
                        CardClick(opponentHand[x], opponentHand);
                        break;
                    }
                }

                for (int slotLoop = 0; slotLoop < 9; slotLoop++)
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
                }
            }
            */


            //2:
            //first available slot, find slotted neighbors, 
            //first available card to beat else first available card, 
            //if no neighbor, first available card
            /*
            if (turn == 2)
            {
                List<CardPictureBox> candidateCards = new List<CardPictureBox>();

                foreach (CardPictureBox card in opponentHand)
                {
                    if (card.isUsed == false)
                    {
                        candidateCards.Add(card);
                    }
                }

                CardPictureBox playCard = new CardPictureBox();

                Point point = new Point();
                int x = 0;

                for (x = 0; x < 9; x++)
                {
                    if (slot[x].isOccupied == false)
                    {
                        EvaluatePlay(candidateCards, x);
                        playCard = null;
                        playCard = candidateCards.Find(i => i.canBeatLeft == true);

                        if (playCard == null)
                        {
                            playCard = candidateCards.Find(i => i.canBeatTop == true);
                        }

                        if (playCard == null)
                        {
                            playCard = candidateCards.Find(i => i.canBeatRight == true);
                        }

                        if (playCard == null)
                        {
                            playCard = candidateCards.Find(i => i.canBeatBottom == true);
                        }

                        if (playCard == null)
                        {
                            playCard = candidateCards[0];
                        }

                        CardClick(playCard, opponentHand);

                        point = new Point(slot[x].rect.X, slot[x].rect.Y);
                        PlaceCard(point);

                        break;
                    }
                }
            }
            */

            //3:
            //first available slot, find first slotted neighbor, build list of all available cards to beat, 
            //find second slotted neighbor, build list of all available cards to beat, 
            //compare first list and second list, first available match, 
            //if not list match, first available from first list group
            //if no neighbors, first available card
            /*
            if (turn == 2)
            {
                List<CardPictureBox> candidateCards = new List<CardPictureBox>();

                foreach (CardPictureBox card in opponentHand)
                {
                    if (card.isUsed == false)
                    {
                        candidateCards.Add(card);
                    }
                }

                CardPictureBox playCard = new CardPictureBox();

                Point point = new Point();
                int x = 0;

                for (x = 0; x < 9; x++)
                {
                    if (slot[x].isOccupied == false)
                    {
                        EvaluatePlay(candidateCards, x);

                        playCard = null;

                        playCard = candidateCards.Find(i => i.canBeatLeft == true && i.canBeatTop == true);

                        if (playCard == null)
                        {
                            playCard = candidateCards.Find(i => i.canBeatLeft == true && i.canBeatRight == true);
                        }

                        if (playCard == null)
                        {
                            playCard = candidateCards.Find(i => i.canBeatLeft == true && i.canBeatBottom == true);
                        }

                        if (playCard == null)
                        {
                            playCard = candidateCards.Find(i => i.canBeatTop == true && i.canBeatRight == true);
                        }

                        if (playCard == null)
                        {
                            playCard = candidateCards.Find(i => i.canBeatTop == true && i.canBeatBottom == true);
                        }

                        if (playCard == null)
                        {
                            playCard = candidateCards.Find(i => i.canBeatRight == true && i.canBeatBottom == true);
                        }

                        if (playCard == null)
                        {
                            playCard = candidateCards.Find(i => i.canBeatLeft == true);
                        }

                        if (playCard == null)
                        {
                            playCard = candidateCards.Find(i => i.canBeatTop == true);
                        }

                        if (playCard == null)
                        {
                            playCard = candidateCards.Find(i => i.canBeatRight == true);
                        }

                        if (playCard == null)
                        {
                            playCard = candidateCards.Find(i => i.canBeatBottom == true);
                        }

                        if (playCard == null)
                        {
                            playCard = candidateCards[0];
                        }

                        CardClick(playCard, opponentHand);

                        point = new Point(slot[x].rect.X, slot[x].rect.Y);
                        PlaceCard(point);

                        break;
                    }
                }
            }
            */

            //4:
            //first (or random?) available slot, find first slotted neighbor, build list of all available cards to beat, 
            //find second slotted neighbor, build list of all available cards to beat, 
            //find third slotted neighbor, build list of all available cards to beat, 
            //compare all lists, first available match, 
            //if not list match, compare 2 lists (1&2, 1&3, 2&3) for match, first available match
            //if not list match, first available from list group
            //if no neighbors, first available card
            /*
            if (turn == 2)
            {
                List<CardPictureBox> candidateCards = new List<CardPictureBox>();

                foreach (CardPictureBox card in opponentHand)
                {
                    if (card.isUsed == false)
                    {
                        candidateCards.Add(card);
                    }
                }

                CardPictureBox playCard = new CardPictureBox();

                Point point = new Point();
                
                Random r = new Random();
                int x = r.Next(0,8);

                while (!slot[x].isOccupied == false)
                { 
                    x = r.Next(0, 8);
                }

                EvaluatePlay(candidateCards, x);

                playCard = null;

                playCard = candidateCards.Find(i => i.canBeatLeft == true && i.canBeatTop == true && i.canBeatRight == true);

                if (playCard == null)
                {
                    playCard = candidateCards.Find(i => i.canBeatBottom == true && i.canBeatTop == true && i.canBeatRight == true);
                }

                if (playCard == null)
                {
                    playCard = candidateCards.Find(i => i.canBeatLeft == true && i.canBeatBottom == true && i.canBeatRight == true);
                }

                if (playCard == null)
                {
                    playCard = candidateCards.Find(i => i.canBeatLeft == true && i.canBeatTop == true && i.canBeatBottom == true);
                }

                if (playCard == null)
                {
                    playCard = candidateCards.Find(i => i.canBeatLeft == true && i.canBeatTop == true);
                }

                if (playCard == null)
                {
                    playCard = candidateCards.Find(i => i.canBeatLeft == true && i.canBeatRight == true);
                }

                if (playCard == null)
                {
                    playCard = candidateCards.Find(i => i.canBeatLeft == true && i.canBeatBottom == true);
                }

                if (playCard == null)
                {
                    playCard = candidateCards.Find(i => i.canBeatTop == true && i.canBeatRight == true);
                }

                if (playCard == null)
                {
                    playCard = candidateCards.Find(i => i.canBeatTop == true && i.canBeatBottom == true);
                }

                if (playCard == null)
                {
                    playCard = candidateCards.Find(i => i.canBeatRight == true && i.canBeatBottom == true);
                }

                if (playCard == null)
                {
                    playCard = candidateCards.Find(i => i.canBeatLeft == true);
                }

                if (playCard == null)
                {
                    playCard = candidateCards.Find(i => i.canBeatTop == true);
                }

                if (playCard == null)
                {
                    playCard = candidateCards.Find(i => i.canBeatRight == true);
                }

                if (playCard == null)
                {
                    playCard = candidateCards.Find(i => i.canBeatBottom == true);
                }

                if (playCard == null)
                {
                    playCard = candidateCards[0];
                }

                CardClick(playCard, opponentHand);

                point = new Point(slot[x].rect.X, slot[x].rect.Y);
                PlaceCard(point);
            }
            */

            //5:
            //first (or random?) available slot, find first slotted neighbor, build list of all available cards to beat, 
            //find second slotted neighbor, build list of all available cards to beat, 
            //find third slotted neighbor, build list of all available cards to beat, 
            //find fourth slotted neighbor, build list of all available cards to beat, 
            //compare all lists, first available match, 
            //if not list match, compare 3 lists (1&2&3, 1&2&4, 1&3&4, 2&3&4) for match, first available match
            //if not list match, compare 2 lists (1&2, 1&3, 1&4, 2&3, 2&4) for match, first available match
            //if not list match, first available from list group
            //if no neighbors, first available card
            /*
            if (turn == 2)
            {
                List<CardPictureBox> candidateCards = new List<CardPictureBox>();

                foreach (CardPictureBox card in opponentHand)
                {
                    if (card.isUsed == false)
                    {
                        candidateCards.Add(card);
                    }
                }

                CardPictureBox playCard = new CardPictureBox();

                Point point = new Point();

                Random r = new Random();
                int x = r.Next(0, 8);

                while (!slot[x].isOccupied == false)
                {
                    x = r.Next(0, 8);
                }

                EvaluatePlay(candidateCards, x);

                playCard = null;

                playCard = candidateCards.Find(i => i.canBeatLeft == true && i.canBeatTop == true && i.canBeatRight == true && i.canBeatBottom == true);

                if (playCard == null)
                {
                    playCard = candidateCards.Find(i => i.canBeatLeft == true && i.canBeatTop == true && i.canBeatRight == true);
                }

                if (playCard == null)
                {
                    playCard = candidateCards.Find(i => i.canBeatBottom == true && i.canBeatTop == true && i.canBeatRight == true);
                }

                if (playCard == null)
                {
                    playCard = candidateCards.Find(i => i.canBeatLeft == true && i.canBeatBottom == true && i.canBeatRight == true);
                }

                if (playCard == null)
                {
                    playCard = candidateCards.Find(i => i.canBeatLeft == true && i.canBeatTop == true && i.canBeatBottom == true);
                }

                if (playCard == null)
                {
                    playCard = candidateCards.Find(i => i.canBeatLeft == true && i.canBeatTop == true);
                }

                if (playCard == null)
                {
                    playCard = candidateCards.Find(i => i.canBeatLeft == true && i.canBeatRight == true);
                }

                if (playCard == null)
                {
                    playCard = candidateCards.Find(i => i.canBeatLeft == true && i.canBeatBottom == true);
                }

                if (playCard == null)
                {
                    playCard = candidateCards.Find(i => i.canBeatTop == true && i.canBeatRight == true);
                }

                if (playCard == null)
                {
                    playCard = candidateCards.Find(i => i.canBeatTop == true && i.canBeatBottom == true);
                }

                if (playCard == null)
                {
                    playCard = candidateCards.Find(i => i.canBeatRight == true && i.canBeatBottom == true);
                }

                if (playCard == null)
                {
                    playCard = candidateCards.Find(i => i.canBeatLeft == true);
                }

                if (playCard == null)
                {
                    playCard = candidateCards.Find(i => i.canBeatTop == true);
                }

                if (playCard == null)
                {
                    playCard = candidateCards.Find(i => i.canBeatRight == true);
                }

                if (playCard == null)
                {
                    playCard = candidateCards.Find(i => i.canBeatBottom == true);
                }

                if (playCard == null)
                {
                    playCard = candidateCards[0];
                }

                CardClick(playCard, opponentHand);

                point = new Point(slot[x].rect.X, slot[x].rect.Y);
                PlaceCard(point);
            }
            */


            //From here on, instead of first available slot, check for a weighted average based on "stuff"
            //and play the card with the best average
            //TBD: What "stuff" makes up the average? Average of all differences between card side value and opposing
            //side value (and if no neighbor, then card side value)?

            //Possible algorithm:
            //attackScore - How many neighbors and how many of them can be beat (beat/neighbors)?
            //defenseScore - How many open slots? Sum of face value / # of open slots
            //defenseMultiplier - Can the player beat me? N = 1, Y = .5 (If closed rule, assume Y) (average)
            //attackScore x defenseScore x defenseMultiplier = point value of play. Higher = better
            if (turn ==2)
            {
                int x = 0;

                List<CardPictureBox> candidateCards = new List<CardPictureBox>();
                List<CardPictureBox> playableCardsBySlot = new List<CardPictureBox>();

                Point point = new Point();

                foreach (CardPictureBox card in opponentHand)
                {
                    if (card.isUsed == false)
                    {
                        candidateCards.Add(card);
                    }
                }

                //Evaluate every slot
                for (x = 0; x < 9; x++)
                {
                    CardPictureBox playCard = new CardPictureBox();

                    if (slot[x].isOccupied == false)
                    {
                        EvaluatePlay(candidateCards, x);

                        //attackScore = ratio of occupied neighbor slots and how many of them can be beaten
                        CalculateAttack(candidateCards, x);

                        //defenseScore = average face values of unoccupied neighbor slots
                        CalculateDefense(candidateCards, x);

                        //defenseMultiplier = average of open sides that opponent can beat
                        //unbeatable = 1, beatable = .5. If "closed" rule, assume beatable
                        CalculateMultiplier(candidateCards, playerHand, x);

                        //playScore = attackScore x defenseScore x defenseMultiplier
                        CalculatePlayScore(candidateCards, x);

                        playCard = null;

                        //find card for the slot with the highest play score
                        playCard = candidateCards.OrderByDescending(i => i.playScore).FirstOrDefault();
                        playCard.playableSlot = x;

                        //add playCard to the list of cards by slot so that we can determine best play
                        playableCardsBySlot.Add(playCard);

                    }
                }
                CardPictureBox bestCard = new CardPictureBox();

                bestCard = playableCardsBySlot.OrderByDescending(i => i.playScore).FirstOrDefault();
                
                CardClick(bestCard, opponentHand);

                point = new Point(slot[bestCard.playableSlot].rect.X, slot[bestCard.playableSlot].rect.Y);
                PlaceCard(point);
            }

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

        private void CalculatePlayScore(List<CardPictureBox> candidateCards, int candidateSlot)
        {
            foreach (CardPictureBox card in candidateCards)
            {
                card.playScore = card.attackScore * card.defenseScore * card.defenseMultiplier;
            }
        }

        private void CalculateMultiplier(List<CardPictureBox> candidateCards, List<CardPictureBox> playerCards, int candidateSlot)
        {
            foreach (CardPictureBox card in candidateCards)
            {
                foreach (CardPictureBox playerCard in playerCards)
                {
                    double countCanBeat = 0;

                    if (playerCard.isUsed == false)
                    {
                        card.canLoseBottom = false;
                        card.canLoseLeft = false;
                        card.canLoseRight = false;
                        card.canLoseTop = false;

                        switch (candidateSlot)
                        {
                            case 0:
                                if (slot[1].isOccupied == false)
                                {
                                    if (playerCard.left > card.right) { card.canLoseRight = true; countCanBeat = countCanBeat + 0.5; }else { countCanBeat = countCanBeat + 1; }
                                }
                                if (slot[3].isOccupied == false)
                                {
                                    if (playerCard.top > card.bottom) { card.canLoseBottom = true; countCanBeat = countCanBeat + 0.5; } else { countCanBeat = countCanBeat + 1; }
                                }
                                break;
                            case 1:
                                if (slot[0].isOccupied == false)
                                {
                                    if (playerCard.right > card.left) { card.canLoseLeft = true; countCanBeat = countCanBeat + 0.5; } else { countCanBeat = countCanBeat + 1; }
                                }
                                if (slot[2].isOccupied == false)
                                {
                                    if (playerCard.left > card.right) { card.canLoseRight = true; countCanBeat = countCanBeat + 0.5; } else { countCanBeat = countCanBeat + 1; }
                                }
                                if (slot[4].isOccupied == false)
                                {
                                    if (playerCard.top > card.bottom) { card.canLoseBottom = true; countCanBeat = countCanBeat + 0.5; } else { countCanBeat = countCanBeat + 1; }
                                }
                                break;
                            case 2:
                                if (slot[1].isOccupied == false)
                                {
                                    if (playerCard.right > card.left) { card.canLoseLeft = true; countCanBeat = countCanBeat + 0.5; } else { countCanBeat = countCanBeat + 1; }
                                }
                                if (slot[5].isOccupied == false)
                                {
                                    if (playerCard.top > card.bottom) { card.canLoseBottom = true; countCanBeat = countCanBeat + 0.5; } else { countCanBeat = countCanBeat + 1; }
                                }
                                break;
                            case 3:
                                if (slot[0].isOccupied == false)
                                {
                                    if (playerCard.bottom > card.top) { card.canLoseTop = true; countCanBeat = countCanBeat + 0.5; } else { countCanBeat = countCanBeat + 1; }
                                }
                                if (slot[4].isOccupied == false)
                                {
                                    if (playerCard.left > card.right) { card.canLoseRight = true; countCanBeat = countCanBeat + 0.5; } else { countCanBeat = countCanBeat + 1; }
                                }
                                if (slot[6].isOccupied == false)
                                {
                                    if (playerCard.top > card.bottom) { card.canLoseBottom = true; countCanBeat = countCanBeat + 0.5; } else { countCanBeat = countCanBeat + 1; }
                                }
                                break;
                            case 4:
                                if (slot[1].isOccupied == false)
                                {
                                    if (playerCard.bottom > card.top) { card.canLoseTop = true; countCanBeat = countCanBeat + 0.5; } else { countCanBeat = countCanBeat + 1; }
                                }
                                if (slot[3].isOccupied == false)
                                {
                                    if (playerCard.right > card.left) { card.canLoseLeft = true; countCanBeat = countCanBeat + 0.5; } else { countCanBeat = countCanBeat + 1; }
                                }
                                if (slot[5].isOccupied == false)
                                {
                                    if (playerCard.left > card.right) { card.canLoseRight = true; countCanBeat = countCanBeat + 0.5; } else { countCanBeat = countCanBeat + 1; }
                                }
                                if (slot[7].isOccupied == false)
                                {
                                    if (playerCard.top > card.bottom) { card.canLoseBottom = true; countCanBeat = countCanBeat + 0.5; } else { countCanBeat = countCanBeat + 1; }
                                }
                                break;
                            case 5:
                                if (slot[2].isOccupied == false)
                                {
                                    if (playerCard.bottom > card.top) { card.canLoseTop = true; countCanBeat = countCanBeat + 0.5; } else { countCanBeat = countCanBeat + 1; }
                                }
                                if (slot[4].isOccupied == false)
                                {
                                    if (playerCard.right > card.left) { card.canLoseLeft = true; countCanBeat = countCanBeat + 0.5; } else { countCanBeat = countCanBeat + 1; }
                                }
                                if (slot[8].isOccupied == false)
                                {
                                    if (playerCard.top > card.bottom) { card.canLoseBottom = true; countCanBeat = countCanBeat + 0.5; } else { countCanBeat = countCanBeat + 1; }
                                }
                                break;
                            case 6:
                                if (slot[3].isOccupied == false)
                                {
                                    if (playerCard.bottom > card.top) { card.canLoseTop = true; countCanBeat = countCanBeat + 0.5; } else { countCanBeat = countCanBeat + 1; }
                                }
                                if (slot[7].isOccupied == false)
                                {
                                    if (playerCard.left > card.right) { card.canLoseRight = true; countCanBeat = countCanBeat + 0.5; } else { countCanBeat = countCanBeat + 1; }
                                }
                                break;
                            case 7:
                                if (slot[4].isOccupied == false)
                                {
                                    if (playerCard.bottom > card.top) { card.canLoseTop = true; countCanBeat = countCanBeat + 0.5; } else { countCanBeat = countCanBeat + 1; }
                                }
                                if (slot[6].isOccupied == false)
                                {
                                    if (playerCard.right > card.left) { card.canLoseLeft = true; countCanBeat = countCanBeat + 0.5; } else { countCanBeat = countCanBeat + 1; }
                                }
                                if (slot[8].isOccupied == false)
                                {
                                    if (playerCard.left > card.right) { card.canLoseRight = true; countCanBeat = countCanBeat + 0.5; } else { countCanBeat = countCanBeat + 1; }
                                }
                                break;
                            case 8:
                                if (slot[5].isOccupied == false)
                                {
                                    if (playerCard.bottom > card.top) { card.canLoseTop = true; countCanBeat = countCanBeat + 0.5; } else { countCanBeat = countCanBeat + 1; }
                                }
                                if (slot[7].isOccupied == false)
                                {
                                    if (playerCard.right > card.left) { card.canLoseLeft = true; countCanBeat = countCanBeat + 0.5; } else { countCanBeat = countCanBeat + 1; }
                                }
                                break;
                        }
                        
                        if (slot[candidateSlot].openSlots != 0)
                        {
                            if (countCanBeat / slot[candidateSlot].openSlots > card.defenseMultiplier)
                            {
                                card.defenseMultiplier = countCanBeat / slot[candidateSlot].openSlots;
                            }
                        }
                        else
                        {
                            card.defenseMultiplier = 1;
                        }

                        //Multiply by 0 results in skew to playScore. Set to an extremely low value instead
                        if (card.defenseMultiplier == 0) { card.defenseMultiplier = 0.1; }

                        if (ruleSet.open == false) { card.defenseMultiplier = 0.1; }
                    }
                }
            }
        }

        private void CalculateDefense(List<CardPictureBox> candidateCards, int candidateSlot)
        {
            foreach (CardPictureBox card in candidateCards)
            {
                //card.defenseScore = 0;
                double defenseCount = 0;

                switch (candidateSlot)
                {
                    case 0:
                        if (slot[1].isOccupied == false)
                        {
                            defenseCount = defenseCount + card.right;
                        }
                        if (slot[3].isOccupied == false)
                        {
                            defenseCount = defenseCount + card.bottom;
                        }
                        break;
                    case 1:
                        if (slot[0].isOccupied == false)
                        {
                            defenseCount = defenseCount + card.left;
                        }
                        if (slot[2].isOccupied == false)
                        {
                            defenseCount = defenseCount + card.right;
                        }
                        if (slot[4].isOccupied == false)
                        {
                            defenseCount = defenseCount + card.bottom;
                        }
                        break;
                    case 2:
                        if (slot[1].isOccupied == false)
                        {
                            defenseCount = defenseCount + card.left;
                        }
                        if (slot[5].isOccupied == false)
                        {
                            defenseCount = defenseCount + card.bottom;
                        }
                        break;
                    case 3:
                        if (slot[0].isOccupied == false)
                        {
                            defenseCount = defenseCount + card.top;
                        }
                        if (slot[4].isOccupied == false)
                        {
                            defenseCount = defenseCount + card.right;
                        }
                        if (slot[6].isOccupied == false)
                        {
                            defenseCount = defenseCount + card.bottom;
                        }
                        break;
                    case 4:
                        if (slot[1].isOccupied == false)
                        {
                            defenseCount = defenseCount + card.top;
                        }
                        if (slot[3].isOccupied == false)
                        {
                            defenseCount = defenseCount + card.left;
                        }
                        if (slot[5].isOccupied == false)
                        {
                            defenseCount = defenseCount + card.right;
                        }
                        if (slot[7].isOccupied == false)
                        {
                            defenseCount = defenseCount + card.bottom;
                        }
                        break;
                    case 5:
                        if (slot[2].isOccupied == false)
                        {
                            defenseCount = defenseCount + card.top;
                        }
                        if (slot[4].isOccupied == false)
                        {
                            defenseCount = defenseCount + card.left;
                        }
                        if (slot[8].isOccupied == false)
                        {
                            defenseCount = defenseCount + card.bottom;
                        }
                        break;
                    case 6:
                        if (slot[7].isOccupied == false)
                        {
                            defenseCount = defenseCount + card.right;
                        }
                        if (slot[3].isOccupied == false)
                        {
                            defenseCount = defenseCount + card.top;
                        }
                        break;
                    case 7:
                        if (slot[6].isOccupied == false)
                        {
                            defenseCount = defenseCount + card.left;
                        }
                        if (slot[8].isOccupied == false)
                        {
                            defenseCount = defenseCount + card.right;
                        }
                        if (slot[4].isOccupied == false)
                        {
                            defenseCount = defenseCount + card.top;
                        }
                        break;
                    case 8:
                        if (slot[7].isOccupied == false)
                        {
                            defenseCount = defenseCount + card.left;
                        }
                        if (slot[5].isOccupied == false)
                        {
                            defenseCount = defenseCount + card.top;
                        }
                        break;
                }

                if (defenseCount / slot[candidateSlot].openSlots > card.defenseScore)
                {
                    if (slot[candidateSlot].openSlots != 0)
                    {
                        card.defenseScore = defenseCount / slot[candidateSlot].openSlots;
                    }
                    else
                    {
                        card.defenseScore = 0.1;
                    }
                }

                //Multiply by 0 results in skew to playScore. Set to an extremely low value instead
                if (card.defenseScore == 0) { card.defenseScore = 0.1; }
            }
        }

        private void CalculateAttack(List<CardPictureBox> candidateCards, int candidateSlot)
        {
            foreach (CardPictureBox card in candidateCards)
            {
                card.attackScore = 0;
                double beatCount = 0;

                if (card.canBeatLeft == true) { beatCount++; }
                if (card.canBeatTop == true) { beatCount++; }
                if (card.canBeatRight == true) { beatCount++; }
                if (card.canBeatBottom == true) { beatCount++; }

                if (slot[candidateSlot].neighbors != 0)
                {
                    card.attackScore = beatCount / slot[candidateSlot].neighbors;
                }
                else
                {
                    card.attackScore = 1;
                }

                //Multiply by 0 results in skew to playScore. Set to an extremely low value instead
                if (card.attackScore == 0) { card.attackScore = 0.1; }
            }
        }

        private void EvaluatePlay(List<CardPictureBox> candidateCards, int candidateSlot)
        {
            foreach (CardPictureBox card in candidateCards)
            {
                if (ruleSet.same == true)
                {
                    EvaluateSameRule(card, candidateSlot);
                }

                EvaluateDefaultRule(card, candidateSlot);
            }
        }

        private void EvaluateSameRule(CardPictureBox card, int candidateSlot)
        {
            
        }

        private void EvaluateDefaultRule(CardPictureBox card, int candidateSlot)
        {
            switch (candidateSlot)
            {
                case 0:
                    if (slot[1].isOccupied == true && slot[1].pctBox.currentColor == "blue")
                    {
                        card.canBeatRight = card.right > slot[1].pctBox.card.left ? true : false;
                    }
                    if (slot[3].isOccupied == true && slot[3].pctBox.currentColor == "blue")
                    {
                        card.canBeatBottom = card.bottom > slot[3].pctBox.card.top ? true : false;
                    }
                    break;
                case 1:
                    if (slot[0].isOccupied == true && slot[0].pctBox.currentColor == "blue")
                    {
                        card.canBeatLeft = card.left > slot[0].pctBox.card.right ? true : false;
                    }
                    if (slot[2].isOccupied == true && slot[2].pctBox.currentColor == "blue")
                    {
                        card.canBeatRight = card.right > slot[2].pctBox.card.left ? true : false;
                    }
                    if (slot[4].isOccupied == true && slot[4].pctBox.currentColor == "blue")
                    {
                        card.canBeatBottom = card.bottom > slot[4].pctBox.card.top ? true : false;
                    }
                    break;
                case 2:
                    if (slot[1].isOccupied == true && slot[1].pctBox.currentColor == "blue")
                    {
                        card.canBeatLeft = card.left > slot[1].pctBox.card.right ? true : false;
                    }
                    if (slot[5].isOccupied == true && slot[5].pctBox.currentColor == "blue")
                    {
                        card.canBeatBottom = card.bottom > slot[5].pctBox.card.top ? true : false;
                    }
                    break;
                case 3:
                    if (slot[0].isOccupied == true && slot[0].pctBox.currentColor == "blue")
                    {
                        card.canBeatTop = card.top > slot[0].pctBox.card.bottom ? true : false;
                    }
                    if (slot[4].isOccupied == true && slot[4].pctBox.currentColor == "blue")
                    {
                        card.canBeatRight = card.right > slot[4].pctBox.card.left ? true : false;
                    }
                    if (slot[6].isOccupied == true && slot[6].pctBox.currentColor == "blue")
                    {
                        card.canBeatBottom = card.bottom > slot[6].pctBox.card.top ? true : false;
                    }
                    break;
                case 4:
                    if (slot[1].isOccupied == true && slot[1].pctBox.currentColor == "blue")
                    {
                        card.canBeatTop = card.top > slot[1].pctBox.card.bottom ? true : false;
                    }
                    if (slot[3].isOccupied == true && slot[3].pctBox.currentColor == "blue")
                    {
                        card.canBeatLeft = card.left > slot[3].pctBox.card.right ? true : false;
                    }
                    if (slot[5].isOccupied == true && slot[5].pctBox.currentColor == "blue")
                    {
                        card.canBeatRight = card.right > slot[5].pctBox.card.left ? true : false;
                    }
                    if (slot[7].isOccupied == true && slot[7].pctBox.currentColor == "blue")
                    {
                        card.canBeatBottom = card.bottom > slot[7].pctBox.card.top ? true : false;
                    }
                    break;
                case 5:
                    if (slot[2].isOccupied == true && slot[2].pctBox.currentColor == "blue")
                    {
                        card.canBeatTop = card.top > slot[2].pctBox.card.bottom ? true : false;
                    }
                    if (slot[4].isOccupied == true && slot[4].pctBox.currentColor == "blue")
                    {
                        card.canBeatLeft = card.left > slot[4].pctBox.card.right ? true : false;
                    }
                    if (slot[8].isOccupied == true && slot[8].pctBox.currentColor == "blue")
                    {
                        card.canBeatBottom = card.bottom > slot[8].pctBox.card.top ? true : false;
                    }
                    break;
                case 6:
                    if (slot[7].isOccupied == true && slot[7].pctBox.currentColor == "blue")
                    {
                        card.canBeatRight = card.right > slot[7].pctBox.card.left ? true : false;
                    }
                    if (slot[3].isOccupied == true && slot[3].pctBox.currentColor == "blue")
                    {
                        card.canBeatTop = card.top > slot[3].pctBox.card.bottom ? true : false;
                    }
                    break;
                case 7:
                    if (slot[6].isOccupied == true && slot[6].pctBox.currentColor == "blue")
                    {
                        card.canBeatLeft = card.left > slot[6].pctBox.card.right ? true : false;
                    }
                    if (slot[8].isOccupied == true && slot[8].pctBox.currentColor == "blue")
                    {
                        card.canBeatRight = card.right > slot[8].pctBox.card.left ? true : false;
                    }
                    if (slot[4].isOccupied == true && slot[4].pctBox.currentColor == "blue")
                    {
                        card.canBeatTop = card.top > slot[4].pctBox.card.bottom ? true : false;
                    }
                    break;
                case 8:
                    if (slot[7].isOccupied == true && slot[7].pctBox.currentColor == "blue")
                    {
                        card.canBeatLeft = card.left > slot[7].pctBox.card.right ? true : false;
                    }
                    if (slot[5].isOccupied == true && slot[5].pctBox.currentColor == "blue")
                    {
                        card.canBeatTop = card.top > slot[5].pctBox.card.bottom ? true : false;
                    }
                    break;
            }
        }

        private void UpdateScore()
        {
            int blue = 0;
            int red = 0;
            
            for (int x = 0; x<5; x++)
            {
                if (playerHand[x].currentColor == "blue")
                {
                    blue++;
                }
                else
                {
                    red++;
                }

                if (opponentHand[x].currentColor == "blue")
                {
                    blue++;
                }
                else
                {
                    red++;
                }
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
