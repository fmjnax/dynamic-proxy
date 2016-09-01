using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleTriadOffline.Classes;

namespace TripleTriadOffline
{
    public class Deck : IEnumerable<Card>
    {
        List<Card> deck = new List<Card>();

        public Deck()
        {
            
        }

        internal void AddCard(Card card)
        {
            deck.Add(card);
        }

        internal int GetCount()
        {
            int count = 0;

            count = deck.Count;
            return count;
        }

        internal Card GetCardById(int id)
        {
            Card returnCard = null;
 
            foreach (var card in deck)
            {
                if (card.id == id)
                {
                    returnCard = card;
                }
            }

            return returnCard;
        }

        internal Card GetCardByName(string displayName)
        {
            Card returnCard = null;

            foreach (var card in deck)
            {
                if (card.displayName == displayName)
                {
                    returnCard = card;
                    break;
                }
            }

            return returnCard;
        }

        internal int GetCountById(int id)
        {
            int count = 0;

            foreach (var card in deck)
            {
                if (card.id == id)
                {
                    count++;
                }
            }

            return count;
        }

        internal void RemoveCardById(int id)
        {
            foreach (var card in deck)
            {
                if (card.id == id)
                {
                    deck.Remove(card);
                }
            }
        }

        internal void RemoveCardByName(string displayName)
        {
            foreach (var card in deck.ToList())
            {
                if (card.displayName == displayName)
                {
                    deck.Remove(card);
                    break;
                }
            }
        }

        internal void Clear()
        {
            deck.Clear();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return deck.GetEnumerator();
        }

        IEnumerator<Card> IEnumerable<Card>.GetEnumerator()
        {
            return deck.GetEnumerator();
        }
    }
}
