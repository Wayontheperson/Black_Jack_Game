using System;
using System.Collections.Generic;
using System.Linq;

namespace poker
{
    internal class Dealer
    {
        private List<Card> cards = new List<Card>();

        internal void Prepare()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 2; j <= 14; j++) 
                {
                    Card card = new Card();
                    if (j<12)
                        card.No = j;
                    else
                    {
                        card.Letters = 10;
                    }
                    
                    cards.Add(card);
                }  
            }
            cards = cards.OrderBy(x => Guid.NewGuid()).ToList();

        }

        public Card Draw()
        {
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
    }
}