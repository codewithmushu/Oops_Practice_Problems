using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfCards
{
    public class Player
    {
        public string Name { get; set; }
        private Queue<Card> cards;

        public Player(string name)
        {
            Name = name;
            cards = new Queue<Card>();
        }

        public void ReceiveCards(Queue<Card> receivedCards)
        {
            while (receivedCards.Count > 0)
            {
                cards.Enqueue(receivedCards.Dequeue());
            }
        }

        public void SortCards()
        {
            List<Card> sortedCards = new List<Card>(cards);
            sortedCards.Sort((a, b) => a.Rank.CompareTo(b.Rank));
            cards = new Queue<Card>(sortedCards);
        }

        public void PrintCards()
        {
            Console.WriteLine("{0}'s cards:", Name);
            foreach (Card card in cards)
            {
                Console.WriteLine("{0} of {1}", card.Rank, card.Suit);
            }
        }

    }
}
