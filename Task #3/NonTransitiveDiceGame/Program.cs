using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace NonTransitiveDiceGame
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var game = new DiceGame(args);
                game.Play();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                ShowUsageExample();
            }
        }

        static void ShowUsageExample()
        {
            Console.WriteLine("Usage: dotnet run -- dice1 dice2 dice3 [dice4...]");
            Console.WriteLine("Example: dotnet run -- 2,2,4,4,9,9 6,8,1,1,8,6 7,5,3,7,5,3");
            Console.WriteLine("Each dice must have exactly 6 comma-separated integers.");
        }
    }
}
