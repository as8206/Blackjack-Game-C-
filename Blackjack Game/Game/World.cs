using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack_Game.PlayingCards;

namespace Blackjack_Game.Game
{
    internal class World
    {
        private static World gameWorld;
        private Deck deck;
        private static String input = "initialized";

        public static int numOfCards = 52;

        private World()
        {
            Console.WriteLine("world called"); //debug output

            deck = new Deck();
        }

        public static World CreateWorld()
	    {
            if (gameWorld == null)
			{
				gameWorld = new World();
			}
		
		    return gameWorld;
	    }

        public void StartGame()
        {
            
        }

        //outputs a given deck to the console
        private void PrintDeck(Deck deck)
        {
            Card[] cards = deck.GetCards();

            foreach (Card current in cards)
            {
                Console.WriteLine(current.GetCardName());
            }
        }

        //outputs a random card from the given deck
        private void PrintRandomCard(Deck deck)
        {
            Random random = new Random();
            int selector = random.Next(0, deck.GetNumOfCards());

            Console.WriteLine("Card " + selector + " was selected: " + deck.GetCardName(selector));
        }
    }
}
