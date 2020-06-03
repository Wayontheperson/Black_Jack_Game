using System.Collections.Generic;

namespace poker
{
    internal class Player
    {
        public Player(int seedMoney)
        {
            Money = seedMoney;
        }
        
        private List<Card> cards= new List<Card>(); //인덱서를 이용해서 접근하면 cards[index]를
                                                    //Player player[index]로 접근 가능하다.
        
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
            // 인덱서로 표현 안할거면 Player player.cards[index]가 된다.
            // 하지만 위에 cards를 정의한것이 private이므로 다른 곳에서 사용 불가 즉 public으로 바뀌야 된다
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