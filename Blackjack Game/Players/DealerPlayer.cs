using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack_Game.PlayingCards;

namespace Blackjack_Game.Players
{
    internal class DealerPlayer : Player
    {
        public DealerPlayer() { }

        public override void PrintHand()
        {
            Console.WriteLine("Dealer hand is: ");

            foreach (PlayingCards.Card card in hand)
            {
                Console.WriteLine(card.GetCardName());
            }

            if (busted)
            {
                Console.WriteLine();
                Console.WriteLine("Busted!");
            }

            if (stayed)
            {
                Console.WriteLine();
                Console.WriteLine("Stayed!");
            }

            Console.WriteLine();
        }

        public override bool HitOrStay(Deck deck)
        {
            bool willHit;

            if (busted || stayed)
            {
                //Console.WriteLine("Bust!");
                willHit = false;
            }

            Thread.Sleep(1000);

            if (this.GetScore() < 21)
            {
                this.RecieveCard(deck.DealCard());
                if (this.GetScore() > 21)
                    busted = true;
                return true;
            }
            else
            {
                busted = true;
                return false;
            }

        }
    }
}
