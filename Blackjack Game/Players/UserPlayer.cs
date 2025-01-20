using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack_Game.PlayingCards;

namespace Blackjack_Game.Players
{
    internal class UserPlayer : Player
    {

        public UserPlayer() { }

        public override void PrintHand()
        {
            Console.WriteLine("Your hand is: ");

            foreach (PlayingCards.Card card in hand)
            {
                Console.WriteLine(card.GetCardName());
            }

            if(busted)
            {
                Console.WriteLine();
                Console.WriteLine("Busted!");
            }

            if(stayed)
            {
                Console.WriteLine();
                Console.WriteLine("Stayed!");
            }

            Console.WriteLine();
        }

        //questions whether the user's player would like to hit and gain a card or stay
        //when the player has busted or already stayed this round, automatically stays
        //if the players chooses to hit, they are deal another card
        //returns 1 if the player hit, or 0 if the player stayed
        public override bool HitOrStay(Deck deck)
        {
            string input = "initialized";

            if (busted || stayed)
            {
                //Console.WriteLine("Bust!");
                //input = "stay";
                return false;
            }

            while (!input.Equals("hit", StringComparison.OrdinalIgnoreCase) && !input.Equals("stay", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Hit or Stay?");
                input = Console.ReadLine();
            }

            if (input.Equals("hit", StringComparison.OrdinalIgnoreCase))
            {
                this.RecieveCard(deck.DealCard());
                if (this.GetScore() > 21)
                    busted = true;
                return true;
            }
            else
            {
                stayed = true;
                return false;
            }
        }

    }
}
