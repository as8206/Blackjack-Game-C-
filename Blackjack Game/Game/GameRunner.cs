namespace Blackjack_Game.Game
{
    public class GameRunner
    {
        private static string? input;

        static void Main(string[] args)
        {
            //Console.WriteLine("runner started"); //debug output
            //Console.WriteLine("\n"); //create space between debugging output and normal output

            World gameWorld = World.CreateWorld();
            input = "initialized";

            while (input.Equals("y", StringComparison.OrdinalIgnoreCase) == false
                && input.Equals("n", StringComparison.OrdinalIgnoreCase) == false)
            {
                Console.WriteLine("Would you like to play? Y/N");
                input = Console.ReadLine();
                if (input == null)
                    input = "temp";
            }

            if (input.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                gameWorld.StartGame();
            }

            Console.WriteLine("Game closing, goodbye!");
        }
    }
}
