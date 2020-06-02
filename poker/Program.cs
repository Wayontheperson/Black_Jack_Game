using System;
using System.Collections.Generic;

namespace poker
{
    class Program
    {
        static void Main(string[] args)
        {
            Player p1 = new Player(1000);
            Player p2 = new Player(1000);

            List<Player> players = new List<Player>();
            List<Card> Cards = new List<Card>();
            players.Add(p1);
            players.Add(p2);

            while (true)
            {
                if (p1.Money == 0 || p2.Money == 0)
                    break;

                // 카드를 나눠준다.
                Dealer dealer = new Dealer();
                dealer.Prepare();

                for (int i = 0; i < 2; i++)
                {
                    foreach (Player player in players)
                    {
                        Card card = dealer.Draw();
                        player.AddCard(card);
                    }
                }
                // 추가 카드를 받는다
                
                foreach (Player player in players)
                {
                    while (player.SumAllNumbers()<14)
                    {
                        Card card = dealer.Draw();
                        player.AddCard(card);
                    }
                }
                
                // 학교를 간다.
                int bettingMoney = 0;
                foreach (Player player in players)
                {
                    //player.SetMoney(player.GetMoney() - 100);
                    player.Money -= 100; // Money는 멤버 변수가 아님
                    bettingMoney += 100;
                }

                // 승자를 가린다.
                Player winner = FindWinner(players);

                winner.Money += bettingMoney;

                int playerNo = 1;
                foreach (Player player in players)
                {
                    Console.WriteLine($"Player {playerNo++} has {player.Money:C0} with ");
                    for (int i = 0; i < player.LengtOfCards(); i++)
                    {
                        Console.WriteLine(player[i]);
                    }
                    
                }
                    
                Console.WriteLine("\n");


                // 카드를 반환한다.
                foreach (Player player in players)
                    player.ClearCards();
            }

        // TODO: 승자 출력
        }

        private static Player FindWinner(List<Player> players)
        {
            int score0 = players[0].SumAllNumbers();
            int score1 = players[1].SumAllNumbers();

            if (score0==21)
                return players[0];
            else if(score1==21)
                return players[1];
            else if (score0 > score1 && score0<21 && score1<21)
            {
                return players[0];
            }

            else //(score0 < score1 && score0<21 && score1<21)
            {
                return players[1];
            }
        }
    }

    
}
