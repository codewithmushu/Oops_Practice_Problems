using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfCards
{
    public class DeckofCards
    {
        private List<Card> cards;

        public DeckofCards()
        {
            cards = new List<Card>();
            string[] suits = { "Clubs", "Diamonds", "Hearts", "Spades" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
            foreach (string suit in suits)
            {
                foreach (string rank in ranks)
                {
                    cards.Add(new Card(suit, rank));
                }
            }
        }

        public void Shuffle()
        {
            Random random = new Random();
            for (int i = cards.Count - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                Card temp = cards[j];
                cards[j] = cards[i];
                cards[i] = temp;
            }
        }

        public void DistributeCards(int numPlayers)
        {
            Card[,] playerCards = new Card[numPlayers, 9];
            int cardIndex = 0;
            for (int i = 0; i < numPlayers; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    playerCards[i, j] = cards[cardIndex++];
                }
            }
            PrintPlayerCards(playerCards);
        }

        private void PrintPlayerCards(Card[,] playerCards)
        {
            for (int i = 0; i < playerCards.GetLength(0); i++)
            {
                Console.WriteLine("Player {0}:", i + 1);
                for (int j = 0; j < playerCards.GetLength(1); j++)
                {
                    Console.WriteLine("{0} of {1}", playerCards[i, j].Rank, playerCards[i, j].Suit);
                }
                Console.WriteLine();
            }
        }









    }
}
