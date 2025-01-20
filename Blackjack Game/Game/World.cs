using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack_Game.PlayingCards;
using Blackjack_Game.Players;

namespace Blackjack_Game.Game
{
    internal class World
    {
        private static World? gameWorld;
        private Deck deck;
        private static String input = "initialized";
        private String? message;

        UserPlayer pc;
        DealerPlayer dealer;

        public static int numOfCards = 52;
        public static int goalScore = 21;

        private World()
        {
            Console.WriteLine("world called"); //debug output

            message = null;
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
            Console.Clear();

            String input = "initialized";
            pc = new UserPlayer();
            dealer = new DealerPlayer();

            dealer.RecieveCard(deck.DealCard());
            dealer.RecieveCard(deck.DealCard());
            pc.RecieveCard(deck.DealCard());
            pc.RecieveCard(deck.DealCard());

            //PrintGameTable();

            //bool hitOrStay = pc.HitOrStay(deck);
            //while (hitOrStay)
            //{
            //    PrintGameTable();
            //    hitOrStay = pc.HitOrStay(deck);

            //}

            bool gameActive = true;
            //PrintGameTable(null);
            while (gameActive)
            {
                gameActive = PlayRound();
            }

            //Console.WriteLine();
        }

        public bool PlayRound()
        {
            int didAnyoneHit = 0;
            //String message = "";

            //takes the players turn, if already stayed or busted, they are informed and skipped
            //if able to play they are asked to hit or stay, and informed of the result
            message = "It's Your Turn";
            PrintGameTable();
            if (pc.GetBusted())
            {
                Thread.Sleep(1000);
                message += "\n\nYou are Busted";
            }
            else if (pc.GetStayed())
            {
                Thread.Sleep(1000);
                message += "\n\nYou already Stayed";
            }
            else if (pc.HitOrStay(deck))
            {
                didAnyoneHit++;
                message += "\n\nYou Hit and Recieved : INSERT CARD HERE";               
            }
            else
            {
                message += "\n\nYou Choose to Stay";
            }
            PrintGameTable();
            Thread.Sleep(1500);

            //takes the dealer's turn, with the same rules as the player
            message = "Dealer's Turn";
            PrintGameTable();
            if (dealer.GetBusted())
            {
                Thread.Sleep(1000);
                message += "\n\nDealer is Busted";
            }
            else if (dealer.GetStayed())
            {
                Thread.Sleep(1000);
                message += "\n\nDealer already Stayed";
            }
            else if (dealer.HitOrStay(deck))
            {
                didAnyoneHit++;
                message += "\n\nDealer Choose to Hit and Recieved : INSERT CARD HERE";
            }
            else
            {
                message += "\n\nDealer Choose to Stay";
            }
            PrintGameTable();
            Thread.Sleep(1500);
            
            if (didAnyoneHit > 0)
                return true;

            return false;
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

        private void PrintGameTable()
        {
            Console.Clear();

            dealer.PrintHand();
            pc.PrintHand();

            Console.WriteLine("_________________________________________________________________\n");

            if(message != null)
                Console.WriteLine(message + "\n");
        }
    }
}
