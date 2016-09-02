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
        private int playerScore = 5;
        private int opponentScore = 5;
                
        private int checkMove = 0;

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
        /*
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
        */

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
    }
}
