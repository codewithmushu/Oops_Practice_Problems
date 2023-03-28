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

        public Queue<Card> DealCards(int numCards)
        {
            Queue<Card> dealtCards = new Queue<Card>();
            for (int i = 0; i < numCards; i++)
            {
                dealtCards.Enqueue(cards[i]);
                cards.RemoveAt(i);
            }
            return dealtCards;
        }

    }
}
