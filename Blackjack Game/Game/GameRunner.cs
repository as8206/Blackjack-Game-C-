namespace Blackjack_Game.Game
{
    public class GameRunner
    {
        private static string input = "initialized";

        static void Main(string[] args)
        {
            Console.WriteLine("runner started"); //debug output
            World gameWorld = World.CreateWorld();
            Console.WriteLine("\n"); //create space between debugging output and normal output

            //while (input.equalsIgnoreCase("y") == false && input.equalsIgnoreCase("n") == false)
            //{
            //    System.out.println("Would you like to play? Y/N");
            //    input = in.next();
            //}

            //if (input.equalsIgnoreCase("y"))
            //{
            gameWorld.StartGame();
            //}

            Console.WriteLine("Game closing, goodbye!");
        }
    }
}
