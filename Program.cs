using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfCards
{
    public class Program
    {
        static void Main(string[] args)
        {
            DeckofCards deck = new DeckofCards();
            deck.Shuffle();

            Queue<Player> players = new Queue<Player>();
            players.Enqueue(new Player("Player 1"));
            players.Enqueue(new Player("Player 2"));
            players.Enqueue(new Player("Player 3"));
            players.Enqueue(new Player("Player 4"));

            for (int i = 0; i < 9; i++)
            {
                foreach (Player player in players)
                {
                    Queue<Card> dealtCards = deck.DealCards(1);
                    player.ReceiveCards(dealtCards);
                }
            }

            foreach (Player player in players)
            {
                player.SortCards();
                player.PrintCards();
            }

        }
    }
}
