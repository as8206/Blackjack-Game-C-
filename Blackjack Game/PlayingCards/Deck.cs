﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack_Game.Game;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Blackjack_Game.PlayingCards
{
    internal class Deck
    {
        private int numOfCards = World.numOfCards;
        private Card[] cards;
        private bool[] usedCard;

        public Deck()
        {
            cards = new Card[numOfCards];
            usedCard = new bool[numOfCards];

            int cardTracker = 0;
            string? suit = null;
            for (int suits = 0; suits < 4; suits++)
            {
                for (int value = 1; value < 14; value++)
                {
                    if (cardTracker > (numOfCards - 1))
                    {
                        Console.WriteLine("Deck Creation Failed");
                        Environment.Exit(1); //not the best way to do this but whatever
                    }

                    //determines correct suit for card from for loop iterator
                    if (suits == 0)
                        suit = "Diamonds";
                    else if (suits == 1)
                        suit = "Hearts";
                    else if (suits == 2)
                        suit = "Spades";
                    else if (suits == 3)
                        suit = "Clubs";
                    else
                    {
                        Console.WriteLine("Unexpected Suit control integer");
                        Environment.Exit(1);
                    }

                    cards[cardTracker] = new Card(suit, value);
                    usedCard[cardTracker] = false;
                    //Console.WriteLine("Created card number " + cardTracker); //debug output
                    cardTracker++;
                }
            }
        }

        public Card[] GetCards()
        {
            return cards;
        }

        public int GetNumOfCards()
        {
            return numOfCards;
        }

        public string GetCardName(int card)
        {
            return cards[card].GetCardName();
        }

        //returns a random card that has not been used
        //if all cards have already been used, returns null
        public Card? DealCard()
        {
            if (AreAllCardsUsed())
                return null;
            bool checkUsed = true;
            Random random = new Random();
            int selector = random.Next(0, numOfCards);

            while (checkUsed == true)
            {
                selector = random.Next(0, numOfCards);
                checkUsed = usedCard[selector];
            }

            usedCard[selector] = true;
            return cards[selector];

        }

        //sets all values in usedCard to true, essentially "reshuffling" the deck
        public void ReShuffle()
        {
            for (int cardNumber = 0; cardNumber < numOfCards; cardNumber++)
            {
                usedCard[cardNumber] = false;
            }
        }

        //checks if there are still usable cards in the deck
        private bool AreAllCardsUsed()
        {
            //for (boolean check : usedCard)
            foreach (bool check in usedCard)
            {
                if (check == true)
                    continue;
                else
                    return false;
            }
            return true;
        }


        //	public static Deck createDeck()
        //	{
        //		if(deck == null)
        //		{
        //			deck = new Deck();
        //		}
        //		return deck;
        //	}
    }
}
