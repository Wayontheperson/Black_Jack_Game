using System.Collections.Generic;

namespace poker
{
    internal class Player
    {
        public Player(int seedMoney)
        {
            Money = seedMoney;
        }
        
        private List<Card> cards= new List<Card>();
        
        public int Money { get; set; }

        internal void AddCard(Card card)
        {
            cards.Add(card);
        }

        internal void ClearCards()
        {
            cards.Clear();
        }

        public int this[int index]
        {
            get
            {
                if (cards[index].No == 0)
                    return cards[index].Letters;
                else
                    return cards[index].No;
            }
        }

        public int LengtOfCards()
        {
            return cards.Count;
        }
        internal int SumAllNumbers()
        {
            int sum = 0;
            for (int i = 0; i < cards.Count; i++)
            {
                
                if (cards[i].Letters == 10)
                    sum += 10;
                else
                {
                    sum += cards[i].No;
                }
            }
            return sum;
        }
        
    }
}