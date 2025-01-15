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

            //		printDeck(deck);

            //		printRandomCard(deck);
        }

        public static World createWorld()
	    {
            if (gameWorld == null)
			{
				gameWorld = new World();
			}
		
		    return gameWorld;
	    }

        public void startGame()
        {
            Card card;
            int test = 1;
            int looper = 0;
            while (true && looper == 0)
            {
                card = deck.dealCard();
                if (card != null)
                {
                    Console.WriteLine(test + " Card Dealt was: " + card.getCardName());
                    test++;
                }
                else
                    looper++;
            }

            Console.WriteLine("reshuffle");
            deck.reShuffle();

            while (true && looper == 1)
            {
                card = deck.dealCard();
                if (card != null)
                {
                    Console.WriteLine(test + " Card Dealt was: " + card.getCardName());
                    test++;
                }
                else
                    looper++;
            }
        }

        //outputs a given deck to the console
        private void printDeck(Deck deck)
        {
            Card[] cards = deck.getCards();
            //		String value = " value not pulled, an error has occured";

            foreach (Card current in cards)
            {
                //			if(current.value == 1)
                //				value = "Ace";
                //			else if(current.value == 11)
                //				value = "Jack";
                //			else if (current.value == 12)
                //				value = "Queen";
                //			else if (current.value == 13)
                //				value = "King";
                //			else
                //				value = Integer.toString(current.value);
                //			
                //			System.out.println(value + " of " + current.suit);

                Console.WriteLine(current.getCardName());
            }
        }

        //outputs a random card from the given deck
        private void printRandomCard(Deck deck)
        {
            //int selector = (int)(Math.random() * deck.getNumOfCards());
            Random random = new Random();
            int selector = random.Next(0, deck.getNumOfCards());

            Console.WriteLine("Card " + selector + " was selected: " + deck.getCardName(selector));
        }
    }
}
