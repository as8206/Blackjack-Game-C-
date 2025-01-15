using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blackjack_Game.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack_Game.PlayingCards;

namespace Blackjack_Game.Players.Tests
{
    [TestClass()]
    public class PlayerTests
    {
        //tests that the GetScore() method in player is able to correctly value aces
        [TestMethod()]
        public void GetScoreTest()
        {
            Card jackOfHearts = new Card("Hearts", 11);
            Card jackOfSpades = new Card("Spades", 11);
            Card aceOfHearts = new Card("Hearts", 1);
            Card aceOfSpades = new Card("Spades", 1);
            Card fiveOfHearts = new Card("Hearts", 5);
            Card nineOfHearts = new Card("Hearts", 9);

            //player1's aces should all be 1, and the score should be 17
            Player player1 = new Player();

            player1.RecieveCard(fiveOfHearts);
            player1.RecieveCard(aceOfSpades);
            player1.RecieveCard(aceOfHearts);
            player1.RecieveCard(jackOfHearts);

            Console.WriteLine("Player1: " + player1.GetScore());
            Assert.AreEqual(17, player1.GetScore());

            //player2's ace should be 11, and the score should be 21
            Player player2 = new Player();

            player2.RecieveCard(jackOfHearts);
            player2.RecieveCard(aceOfHearts);

            Console.WriteLine("Player2: " + player2.GetScore());
            Assert.AreEqual(21, player2.GetScore());

            //Player3's aces should be 1, and the score should be 22
            Player player3 = new Player();

            player3.RecieveCard(jackOfHearts);
            player3.RecieveCard(jackOfSpades);
            player3.RecieveCard(aceOfSpades);
            player3.RecieveCard(aceOfHearts);

            Console.WriteLine("Player3: " + player3.GetScore());
            Assert.AreEqual(22, player3.GetScore());

            //Player4's one ace should be 11 and the other ace should be 1, and the score should be 21
            Player player4 = new Player();

            player4.RecieveCard(aceOfHearts);
            player4.RecieveCard(aceOfSpades);
            player4.RecieveCard(nineOfHearts);

            Console.WriteLine("Player4: " + player4.GetScore());
            Assert.AreEqual (21, player4.GetScore());

            //Player5's one ace should be 11 and the other ace should be 1, and the score should be 17
            Player player5 = new Player();

            player5.RecieveCard(aceOfSpades);
            player5.RecieveCard(aceOfHearts);
            player5.RecieveCard(fiveOfHearts);
            
            Console.WriteLine("Player5: " + player5.GetScore());    
            Assert.AreEqual(17, player5.GetScore());
        }
    }
}