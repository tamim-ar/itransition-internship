using System;

namespace DiceGame
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Error: You need at least 3 dice!");
                Console.WriteLine("Example: dotnet run 2,2,4,4,9,9 6,8,1,1,8,6 7,5,3,7,5,3");
                return;
            }

            try
            {
                var parser = new DiceParser();
                var diceList = parser.ParseDice(args);
                
                var game = new GameController(diceList);
                game.StartGame();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("Example: dotnet run 2,2,4,4,9,9 6,8,1,1,8,6 7,5,3,7,5,3");
            }
        }
    }
}
