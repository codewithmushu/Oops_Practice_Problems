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
            deck.DistributeCards(4);
        }
    }
}
