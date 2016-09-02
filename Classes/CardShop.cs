using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleTriadOffline.Classes;

namespace TripleTriadOffline
{
    class CardShop
    {
        private static Deck masterDeck = Game.GetMasterDeck();
        private static Deck playerDeck = Game.GetPlayerDeck();

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

    }
}
