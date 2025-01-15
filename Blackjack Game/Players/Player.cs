using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack_Game.Game;
using Blackjack_Game.PlayingCards;

namespace Blackjack_Game.Players
{
    internal abstract class Player
    {
        private List<Card> hand = [];

        internal Player()
        {

        }

        internal int GetScore()
        {
            int score = 0;
            int value = 0;
            int acesHeld = 0;

            //Calculates the score for all cards held, except for aces, which are counted to be scored later
            foreach (var card in hand)
            {
                value = card.value;
                
                if (value == 1)
                    acesHeld++;
                else if (value > 9)
                    score = score + 10;
                else
                    score = score + value;
            }

            //Scores the aces, checking whether each should be scored as an 11 or a 1
            int scoreTemp = score;
            bool solutionFound = false;
            int aceIsOne = 0;
            int aceIsEleven = acesHeld;
            while (!solutionFound)
            {
                scoreTemp = score + (aceIsEleven * 11) + aceIsOne;

                //if (scoreTemp <= World.goalScore)
                //{
                //    score = scoreTemp;
                //    solutionFound = true;
                //}
                //else if (scoreTemp > World.goalScore && aceIsEleven > 0)
                //{
                //    aceIsEleven--;
                //    aceIsOne++;
                //}
                //else
                //{
                //    score = scoreTemp;
                //    solutionFound = true;
                //}

                if (scoreTemp > World.goalScore && aceIsEleven > 0)
                {
                    aceIsEleven--;
                    aceIsOne++;
                }
                else
                {
                    score = scoreTemp;
                    solutionFound = true;
                }
            }

            return score;
        }
    }
}
