using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TripleTriadOffline.Classes;
using TripleTriadOffline.Forms;

namespace TripleTriadOffline 
{
    public class Game
    {
        private Rectangle mainFrame;
        
        private int playerScore = 5;
        private int opponentScore = 5;

        
        private int checkMove = 0;

        private string gameResult = "";

        private static Deck masterDeck;
        private static Deck playerDeck;
        private static Lobby lobby;

        private static Challenge challenge;
        private static SelectCards selectCards;
        private static ConfirmHand confirmHand;
        private static GameBoard gameBoard;


        public void Start()
        {
            masterDeck = new Deck();
            
            var masterCards = from r in Global.masterDeckXml.Descendants("card")

            select new
            {
                ID = r.Element("id").Value,
                DisplayName = r.Element("displayName").Value,
                FileName = r.Element("fileName").Value,
                Left = r.Element("left").Value,
                Top = r.Element("top").Value,
                Right = r.Element("right").Value,
                Bottom = r.Element("bottom").Value,
                Level = r.Element("level").Value,
                Native = r.Element("native").Value
            };

            foreach (var r in masterCards)
            {
                Card card = new Card();
                card.id = Int32.Parse(r.ID);
                card.displayName = r.DisplayName;
                card.fileName = r.FileName;
                card.left = Int32.Parse(r.Left);
                card.top = Int32.Parse(r.Top);
                card.right = Int32.Parse(r.Right);
                card.bottom = Int32.Parse(r.Bottom);
                card.level = Int32.Parse(r.Level);
                card.native = Int32.Parse(r.Native);

                masterDeck.AddCard(card);
            }

            playerDeck = new Deck();

            var cards = from r in Global.playerDeckXml.Descendants("card")

            select new
            {
                ID = r.Element("id").Value,
            };

            foreach (var r in cards)
            {
                playerDeck.AddCard(masterDeck.GetCardById(Int32.Parse(r.ID)));
            }

            lobby = new Lobby();

            lobby.Show();

            /*
            Card[] playerCard = new Card[5];
            Card[] opponentCard = new Card[5];

            //Card selectedCard;

            //Slot placedSlot;

            List<string> playerCardList = new List<string>();
            playerCardList.Add("1");
            playerCardList.Add("3");
            playerCardList.Add("5");
            playerCardList.Add("7");
            playerCardList.Add("9");

            List<string> opponentCardList = new List<string>();
            opponentCardList.Add("2");
            opponentCardList.Add("4");
            opponentCardList.Add("6");
            opponentCardList.Add("8");
            opponentCardList.Add("10");

            LoadPlayingHand(playingHand, playerCard, "blue", true);
            LoadPlayingHand(playingHand, opponentCard, "red", true);            
            */
        }

        internal static void AcceptHand(Deck playingHand)
        {
            DisposeChildForms();

            gameBoard = new GameBoard(playingHand);

            lobby.showFormModal(gameBoard);
        }

        private static void DisposeChildForms()
        {
            confirmHand.Dispose();
            selectCards.Dispose();
            challenge.Dispose();
        }

        internal static void RejectHand(Deck playingHand)
        {
            confirmHand.Dispose();
            selectCards.RejectHand(playingHand);
        }

        internal static Deck GetPlayerDeck()
        {
            return playerDeck;
        }

        internal static Deck GetMasterDeck()
        {
            return masterDeck;
        }

        internal static void Challenge()
        {
            challenge = new Challenge();
            lobby.showFormModal(challenge);
        }

        internal static void SelectCards()
        {
            selectCards = new SelectCards();
            //lobby = Application.OpenForms["Lobby"] as Lobby;
            challenge.Dispose();
            lobby.showFormModal(selectCards);
        }

        internal static void ConfirmHand(Deck playingHand)
        {
            confirmHand = new ConfirmHand(playingHand);
            selectCards.showFormModal(confirmHand);
        }


        internal static void SellCard(string cardName, int count)
        {
            Card card = masterDeck.GetCardByName(cardName);

            var deletedCard = from r in Global.playerDeckXml.Descendants("card")
                                where r.Element("id").Value == card.id.ToString()

                                select r;


            var x = 1;

            while (x <= count)
            {
                foreach (var r in deletedCard.Reverse())
                {
                    r.Remove();
                    break;
                }

                playerDeck.RemoveCardByName(cardName);

                x++;
            }

            Global.playerDeckXml.Save("playerDeck.xml");
        }

        public Game()
        {

        }

        internal static void BuyCard(string cardName, int count)
        {
            Card card = masterDeck.GetCardByName(cardName);

            var x = 1;

            while (x <= count)
            {
                playerDeck.AddCard(card);

                Global.playerDeckXml.Element("deck").Element("cards").Add(new XElement("card", new XElement("id", card.id)));
                Global.playerDeckXml.Save("playerDeck.xml");

                x++;
            }
        }

        private void Game_Load(object sender, EventArgs e)
        {
            
        }

        static void LoadPlayingHand(List<string> cardList, Card[] card, string color, bool open)
        {
            int x = 0;

            XDocument document = XDocument.Load("deck.xml");

            foreach (string cardId in cardList)
            {
                var cards = from r in document.Descendants("card")
                            where r.Attribute("id").Value == cardId
                            select new
                            {
                                ID = r.Element("id").Value,
                                DisplayName = r.Element("displayName").Value,
                                FileName = r.Element("fileName").Value,
                                Left = r.Element("left").Value,
                                Top = r.Element("top").Value,
                                Right = r.Element("right").Value,
                                Bottom = r.Element("bottom").Value,
                                Level = r.Element("level").Value
                            };

                foreach (var r in cards)
                {
                    card[x] = new Card();
                    if (open == true)
                    {
                        //card[x].Texture = Content.Load<Texture2D>("deck/" + color + "/" + r.FileName);
                    }
                    else
                    {
                       // card[x].Texture = Content.Load<Texture2D>("cardBack");
                    }
                    card[x].currentColor = color;
                    card[x].id = Int32.Parse(r.ID);
                    card[x].fileName = r.FileName;
                    card[x].displayName = r.DisplayName;
                    card[x].left = Int32.Parse(r.Left);
                    card[x].right = Int32.Parse(r.Right);
                    card[x].top = Int32.Parse(r.Top);
                    card[x].bottom = Int32.Parse(r.Bottom);
                    x++;
                }
            }
        }

        //protected override void UnloadContent()
        //{
        //}

            /*
        protected override void Update(GameTime gameTime)
        {
            var mouseState = Mouse.GetState();
            var mousePosition = new Point(mouseState.X, mouseState.Y);

            PlayerTurn(mouseState, mousePosition);

            OpponentTurn();

            CheckMove(placedSlot);

            UpdateScore();

            EndGame();
            
            base.Update(gameTime);
        }
        */
        private void EndGame()
        {
            int x = 0;
            int spacesOccupied = 0;

            while (x<9)
            {
                if (gameBoard.slot[x].isOccupied == true)
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
            }
        }

        /*
        private void OpponentTurn()
        {
            int x = 0;
            int slotLoop = 0;

            if (turn == 2)
            {
                x = 0;
                while (x < 5)
                {
                    //select first available card
                    SelectCard(opponentCard[x]);
                    //find open slots
                    while (slotLoop < 9)
                    {
                        if (gameBoard.slot[slotLoop].isOccupied == false)
                        {
                            PlayCard(selectedCard, gameBoard.slot[slotLoop]);
                            //reload the texture, in case "closed" rule
                            //selectedCard.Texture = Content.Load<Texture2D>("deck/" + selectedCard.currentColor + "/" + selectedCard.fileName);
                            break;
                        }
                        slotLoop++;
                    }
                    if (turn == 2)
                    {
                        x++;
                    }
                    else
                    {
                        break;
                    }
                };
                turn = 1;
            }
        }
        */

        /*
        private void PlayerTurn(MouseState mouseState, Point mousePosition)
        {
            int x = 0;

            if (turn == 1 && mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
            {
                while (x < 5)
                {
                    if (playerCard[x].Rect.Contains(mousePosition))
                    {
                        SelectCard(playerCard[x]);
                    }
                    x++;
                };

                x = 0;
                while (x < 9)
                {
                    if (gameBoard.slot[x].rect.Contains(mousePosition))
                    {
                        PlayCard(selectedCard, gameBoard.slot[x]);
                        break;
                    }
                    x++;
                };

                CreateCardBounds();

                CheckMove(placedSlot);
            }

            oldMouseState = mouseState;
        }
        */

        /*
        private void UpdateScore()
        {
            int blue = 0;
            int red = 0;
            int x = 0;

            while (x<5)
            {
                if (playerCard[x].isUsed == false)
                {
                    blue++;
                }
                if (opponentCard[x].isUsed == false)
                {
                    red++;
                }
                x++;
            }

            x = 0;
            while (x<9)
            {
                if (gameBoard.slot[x].isOccupied)
                {
                    if (gameBoard.slot[x].cardSlotted.currentColor == "red")
                    {
                        red++;
                    }
                    if (gameBoard.slot[x].cardSlotted.currentColor == "blue")
                    {
                        blue++;
                    }
                }
                x++;
            }
            playerScore = blue;
            opponentScore = red;
        }
        */

        private void CheckMove(Slot placedSlot)
        {
            string color = "";

            if (checkMove == 1) { color = placedSlot.cardSlotted.currentColor == "red" ? "red" : "blue"; }

            if (placedSlot == gameBoard.slot[0] && checkMove == 1)
            {
                //check slots 1 and 3
                if (gameBoard.slot[1].isOccupied == true && placedSlot.cardSlotted.right > gameBoard.slot[1].cardSlotted.left)
                {
                    //gameBoard.slot[1].cardSlotted.texture = Content.Load<Texture2D>("deck/" + color + "/" + gameBoard.slot[1].cardSlotted.fileName);
                    gameBoard.slot[1].cardSlotted.currentColor = color;
                }
                if (gameBoard.slot[3].isOccupied == true && placedSlot.cardSlotted.bottom > gameBoard.slot[3].cardSlotted.top)
                {
                    //gameBoard.slot[3].cardSlotted.texture = Content.Load<Texture2D>("deck/" + color + "/" + gameBoard.slot[3].cardSlotted.fileName);
                    gameBoard.slot[3].cardSlotted.currentColor = color;
                }
            }
            if (placedSlot == gameBoard.slot[1] && checkMove == 1)
            {
                //check slots 0, 2, and 4
                if (gameBoard.slot[0].isOccupied == true && placedSlot.cardSlotted.left > gameBoard.slot[0].cardSlotted.right)
                {
                    //gameBoard.slot[0].cardSlotted.texture = Content.Load<Texture2D>("deck/" + color + "/" + gameBoard.slot[0].cardSlotted.fileName);
                    gameBoard.slot[0].cardSlotted.currentColor = color;
                }
                if (gameBoard.slot[2].isOccupied == true && placedSlot.cardSlotted.bottom > gameBoard.slot[2].cardSlotted.top)
                {
                    //gameBoard.slot[2].cardSlotted.texture = Content.Load<Texture2D>("deck/" + color + "/" + gameBoard.slot[2].cardSlotted.fileName);
                    gameBoard.slot[2].cardSlotted.currentColor = color;
                }
                if (gameBoard.slot[4].isOccupied == true && placedSlot.cardSlotted.right > gameBoard.slot[4].cardSlotted.left)
                {
                    //gameBoard.slot[4].cardSlotted.texture = Content.Load<Texture2D>("deck/" + color + "/" + gameBoard.slot[4].cardSlotted.fileName);
                    gameBoard.slot[4].cardSlotted.currentColor = color;
                }
            }
            else if (placedSlot == gameBoard.slot[2] && checkMove == 1)
            {
                //check slots 1 and 5
                if (gameBoard.slot[1].isOccupied == true && placedSlot.cardSlotted.left > gameBoard.slot[1].cardSlotted.right)
                {
                    //gameBoard.slot[1].cardSlotted.texture = Content.Load<Texture2D>("deck/" + color + "/" + gameBoard.slot[1].cardSlotted.fileName);
                    gameBoard.slot[1].cardSlotted.currentColor = color;
                }
                if (gameBoard.slot[5].isOccupied == true && placedSlot.cardSlotted.bottom > gameBoard.slot[5].cardSlotted.top)
                {
                    //gameBoard.slot[5].cardSlotted.texture = Content.Load<Texture2D>("deck/" + color + "/" + gameBoard.slot[5].cardSlotted.fileName);
                    gameBoard.slot[5].cardSlotted.currentColor = color;
                }
            }
            else if (placedSlot == gameBoard.slot[3] && checkMove == 1)
            {
                //check slots 0, 4, and 6
                if (gameBoard.slot[0].isOccupied == true && placedSlot.cardSlotted.top > gameBoard.slot[0].cardSlotted.bottom)
                {
                    //gameBoard.slot[0].cardSlotted.texture = Content.Load<Texture2D>("deck/" + color + "/" + gameBoard.slot[0].cardSlotted.fileName);
                    gameBoard.slot[0].cardSlotted.currentColor = color;
                }
                if (gameBoard.slot[4].isOccupied == true && placedSlot.cardSlotted.right > gameBoard.slot[4].cardSlotted.left)
                {
                    //gameBoard.slot[4].cardSlotted.texture = Content.Load<Texture2D>("deck/" + color + "/" + gameBoard.slot[4].cardSlotted.fileName);
                    gameBoard.slot[4].cardSlotted.currentColor = color;
                }
                if (gameBoard.slot[6].isOccupied == true && placedSlot.cardSlotted.bottom > gameBoard.slot[6].cardSlotted.top)
                {
                    //gameBoard.slot[6].cardSlotted.texture = Content.Load<Texture2D>("deck/" + color + "/" + gameBoard.slot[6].cardSlotted.fileName);
                    gameBoard.slot[6].cardSlotted.currentColor = color;
                }
            }
            else if (placedSlot == gameBoard.slot[4] && checkMove == 1)
            {
                //check slots 1, 3, 5, and 7
                if (gameBoard.slot[1].isOccupied == true && placedSlot.cardSlotted.top > gameBoard.slot[1].cardSlotted.bottom)
                {
                   // gameBoard.slot[1].cardSlotted.texture = Content.Load<Texture2D>("deck/" + color + "/" + gameBoard.slot[1].cardSlotted.fileName);
                    gameBoard.slot[1].cardSlotted.currentColor = color;
                }
                if (gameBoard.slot[3].isOccupied == true && placedSlot.cardSlotted.left > gameBoard.slot[3].cardSlotted.right)
                {
                    //gameBoard.slot[3].cardSlotted.texture = Content.Load<Texture2D>("deck/" + color + "/" + gameBoard.slot[3].cardSlotted.fileName);
                    gameBoard.slot[3].cardSlotted.currentColor = color;
                }
                if (gameBoard.slot[5].isOccupied == true && placedSlot.cardSlotted.right > gameBoard.slot[5].cardSlotted.left)
                {
                    //gameBoard.slot[5].cardSlotted.texture = Content.Load<Texture2D>("deck/" + color + "/" + gameBoard.slot[5].cardSlotted.fileName);
                    gameBoard.slot[5].cardSlotted.currentColor = color;
                }
                if (gameBoard.slot[7].isOccupied == true && placedSlot.cardSlotted.bottom > gameBoard.slot[7].cardSlotted.top)
                {
                    //gameBoard.slot[7].cardSlotted.texture = Content.Load<Texture2D>("deck/" + color + "/" + gameBoard.slot[7].cardSlotted.fileName);
                    gameBoard.slot[7].cardSlotted.currentColor = color;
                }
            }
            else if (placedSlot == gameBoard.slot[5] && checkMove == 1)
            {
                //check slots 2, 4, and 8
                if (gameBoard.slot[2].isOccupied == true && placedSlot.cardSlotted.top > gameBoard.slot[2].cardSlotted.bottom)
                {
                    //gameBoard.slot[2].cardSlotted.texture = Content.Load<Texture2D>("deck/" + color + "/" + gameBoard.slot[2].cardSlotted.fileName);
                    gameBoard.slot[2].cardSlotted.currentColor = color;
                }
                if (gameBoard.slot[4].isOccupied == true && placedSlot.cardSlotted.right > gameBoard.slot[4].cardSlotted.left)
                {
                    //gameBoard.slot[4].cardSlotted.texture = Content.Load<Texture2D>("deck/" + color + "/" + gameBoard.slot[4].cardSlotted.fileName);
                    gameBoard.slot[4].cardSlotted.currentColor = color;
                }
                if (gameBoard.slot[8].isOccupied == true && placedSlot.cardSlotted.bottom > gameBoard.slot[8].cardSlotted.top)
                {
                    //gameBoard.slot[8].cardSlotted.texture = Content.Load<Texture2D>("deck/" + color + "/" + gameBoard.slot[8].cardSlotted.fileName);
                    gameBoard.slot[8].cardSlotted.currentColor = color;
                }
            }
            else if (placedSlot == gameBoard.slot[6] && checkMove == 1)
            {
                //check slots 3 and 7
                if (gameBoard.slot[3].isOccupied == true && placedSlot.cardSlotted.top > gameBoard.slot[3].cardSlotted.bottom)
                {
                    //gameBoard.slot[3].cardSlotted.texture = Content.Load<Texture2D>("deck/" + color + "/" + gameBoard.slot[3].cardSlotted.fileName);
                    gameBoard.slot[3].cardSlotted.currentColor = color;
                }
                if (gameBoard.slot[7].isOccupied == true && placedSlot.cardSlotted.right > gameBoard.slot[7].cardSlotted.left)
                {
                    //gameBoard.slot[7].cardSlotted.texture = Content.Load<Texture2D>("deck/" + color + "/" + gameBoard.slot[7].cardSlotted.fileName);
                    gameBoard.slot[7].cardSlotted.currentColor = color;
                }
            }
            else if (placedSlot == gameBoard.slot[7] && checkMove == 1)
            {
                //check slots 4, 6, and 8
                if (gameBoard.slot[4].isOccupied == true && placedSlot.cardSlotted.top > gameBoard.slot[4].cardSlotted.bottom)
                {
                    //gameBoard.slot[4].cardSlotted.texture = Content.Load<Texture2D>("deck/" + color + "/" + gameBoard.slot[4].cardSlotted.fileName);
                    gameBoard.slot[4].cardSlotted.currentColor = color;
                }
                if (gameBoard.slot[6].isOccupied == true && placedSlot.cardSlotted.right > gameBoard.slot[6].cardSlotted.left)
                {
                    //gameBoard.slot[6].cardSlotted.texture = Content.Load<Texture2D>("deck/" + color + "/" + gameBoard.slot[6].cardSlotted.fileName);
                    gameBoard.slot[6].cardSlotted.currentColor = color;
                }
                if (gameBoard.slot[8].isOccupied == true && placedSlot.cardSlotted.left > gameBoard.slot[8].cardSlotted.right)
                {
                    //gameBoard.slot[8].cardSlotted.texture = Content.Load<Texture2D>("deck/" + color + "/" + gameBoard.slot[8].cardSlotted.fileName);
                    gameBoard.slot[8].cardSlotted.currentColor = color;
                }
            }
            else if (placedSlot == gameBoard.slot[8] && checkMove == 1)
            {
                //check slots 5 and 7
                if (gameBoard.slot[5].isOccupied == true && placedSlot.cardSlotted.top > gameBoard.slot[5].cardSlotted.bottom)
                {
                    //gameBoard.slot[5].cardSlotted.texture = Content.Load<Texture2D>("deck/" + color + "/" + gameBoard.slot[5].cardSlotted.fileName);
                    gameBoard.slot[5].cardSlotted.currentColor = color;
                }
                if (gameBoard.slot[7].isOccupied == true && placedSlot.cardSlotted.left > gameBoard.slot[7].cardSlotted.right)
                {
                    //gameBoard.slot[7].cardSlotted.texture = Content.Load<Texture2D>("deck/" + color + "/" + gameBoard.slot[7].cardSlotted.fileName);
                    gameBoard.slot[7].cardSlotted.currentColor = color;
                }
            }

            checkMove = 0;
        }


/*        private void SelectCard(Card card)
        {
            int x = 0;
            int col;
            int move;
            Card[] turnCard;

            if (turn ==1)
            {
                col = plcol;
                move = plmove;
                turnCard = playerCard;
            }
            else
            {
                col = orcol;
                move = ormove;
                turnCard = opponentCard;
            }
            /*
            if (card.Position.X == col && card.isUsed == false)
            {
                while (x < 5)
                {
                    if (turnCard[x].isUsed == false) { turnCard[x].position.X = col; }
                    x++;
                }
                card.position.X += move;
                selectedCard = card;
            }
            
        }*/
        
            /*
        private void PlayCard(Card card, Slot slot)
        {
            if (slot.isOccupied == false && card.isUsed == false)
            {
                //card.position.X = slot.rect.X;
                //card.position.Y = slot.rect.Y;
                slot.isOccupied = true;
                card.isUsed = true;
                placedSlot = slot;
                slot.cardSlotted = card;

                if (turn == 1)
                {
                    turn = 2;
                }
                else
                {
                    turn = 1;
                }
                checkMove = 1;
            }
        }
        */

        /*
        protected override void Draw(GameTime gameTime)
        {
            int x = 0;
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            spriteBatch.Draw(gameBoard.texture, mainFrame, Color.White);
            spriteBatch.End();

            spriteBatch.Begin();
            while (x<5)
            {
                spriteBatch.Draw(playerCard[x].Texture, playerCard[x].Position, Color.White);
                spriteBatch.Draw(opponentCard[x].Texture, opponentCard[x].Position, Color.White);
                x++;
            }
            x = 0;
            while(x<9)
            {
                if (gameBoard.slot[x].isOccupied == true)
                {
                    spriteBatch.Draw(gameBoard.slot[x].cardSlotted.Texture, gameBoard.slot[x].cardSlotted.Position, Color.White);
                }
                x++;
            }

            spriteBatch.DrawString(font, "" + playerScore, new Vector2(50, 350), Color.White);
            spriteBatch.DrawString(font, "" + opponentScore, new Vector2(435, 350), Color.White);
            spriteBatch.DrawString(resultFont, "" + gameResult, new Vector2(200, 350), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
        */
    }
}
