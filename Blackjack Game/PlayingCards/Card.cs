using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_Game.PlayingCards
{

    public class Card
    {
        public String suit;
        public int value;

        public Card(String suit, int value)
        {
            this.suit = suit;
            this.value = value;
        }

        public String getCardName()
        {
            String cardName;
            String value = " value not pulled, an error has occured";

            if (this.value == 1)
                value = "Ace";
            else if (this.value == 11)
                value = "Jack";
            else if (this.value == 12)
                value = "Queen";
            else if (this.value == 13)
                value = "King";
            else
                value = Convert.ToString(this.value);

            cardName = (value + " of " + suit);

            return cardName;
        }
    }
}
