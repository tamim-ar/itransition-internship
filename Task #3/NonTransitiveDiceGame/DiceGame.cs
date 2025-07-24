using System;
using System.Collections.Generic;
using System.Linq;

namespace NonTransitiveDiceGame
{
    public class DiceGame
    {
        private readonly List<Dice> diceList;
        private readonly ProvablyFairRandom random;
        
        public DiceGame(string[] args)
        {
            ValidateArguments(args);
            diceList = ParseDice(args);
            random = new ProvablyFairRandom();
        }

        private void ValidateArguments(string[] args)
        {
            if (args.Length < 3)
                throw new ArgumentException("At least 3 dice are required for a non-transitive game");
            
            if (args.Length > 10)
                throw new ArgumentException("Too many dice specified (maximum 10)");
        }

        private List<Dice> ParseDice(string[] args)
        {
            var dice = new List<Dice>();
            for (int i = 0; i < args.Length; i++)
            {
                try
                {
                    dice.Add(new Dice(args[i], i));
                }
                catch (Exception ex)
                {
                    throw new ArgumentException($"Error in dice {i + 1}: {ex.Message}");
                }
            }
            return dice;
        }

        public void Play()
        {
            Console.WriteLine("=== Non-Transitive Dice Game ===");
            Console.WriteLine($"Loaded {diceList.Count} dice:");
            
            for (int i = 0; i < diceList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {diceList[i]}");
            }
            Console.WriteLine();
            
            // Determine first player with proof
            var (userFirst, _) = random.DetermineFirstPlayer();
            Console.WriteLine();
            
            GameLoop(userFirst);
        }

        private void GameLoop(bool userTurn)
        {
            while (true)
            {
                Console.WriteLine(new string('=', 50));
                
                if (userTurn)
                {
                    var userChoice = ShowPlayerMenu();
                    if (userChoice == -1) break; // Exit
                    if (userChoice == -2) continue; // Help, continue loop
                    
                    var computerChoice = SelectComputerDice(userChoice);
                    PlayRound(userChoice, computerChoice, true);
                }
                else
                {
                    var computerChoice = SelectComputerDice(-1); // -1 means first pick
                    var userChoice = ShowPlayerMenu();
                    if (userChoice == -1) break;
                    if (userChoice == -2) continue;
                    
                    PlayRound(userChoice, computerChoice, false);
                }
                
                userTurn = !userTurn; // Alternate turns
            }
            
            Console.WriteLine("Thanks for playing!");
        }

        private int ShowPlayerMenu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Your Turn ---");
                Console.WriteLine("Available dice:");
                
                for (int i = 0; i < diceList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {diceList[i]}");
                }
                
                Console.WriteLine($"{diceList.Count + 1}. Help");
                Console.WriteLine($"{diceList.Count + 2}. Exit");
                Console.Write("Choose your dice (enter number): ");
                
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice >= 1 && choice <= diceList.Count)
                        return choice - 1; // Convert to 0-based index
                    else if (choice == diceList.Count + 1)
                    {
                        ShowHelp();
                        return -2; // Help
                    }
                    else if (choice == diceList.Count + 2)
                        return -1; // Exit
                }
                
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }

        private void ShowHelp()
        {
            Console.WriteLine("\n=== HELP ===");
            Console.WriteLine("This is a non-transitive dice game.");
            Console.WriteLine("- Each player chooses a different dice");
            Console.WriteLine("- Both roll their dice");
            Console.WriteLine("- Higher roll wins the round");
            Console.WriteLine("- Non-transitive means no dice is always best!");
            Console.WriteLine("- All randomness is cryptographically secure and provable");
        }

        private int SelectComputerDice(int excludeIndex)
        {
            // Simple AI: randomly select from available dice
            var availableDice = Enumerable.Range(0, diceList.Count)
                                         .Where(i => i != excludeIndex)
                                         .ToList();
            
            var (choice, proof) = random.GenerateWithProof(0, availableDice.Count - 1);
            int selectedIndex = availableDice[choice];
            
            Console.WriteLine($"Computer selecting dice...");
            Console.WriteLine($"Random proof: {proof}");
            Console.WriteLine($"Computer chose: {diceList[selectedIndex]}");
            
            return selectedIndex;
        }

        private void PlayRound(int userDiceIndex, int computerDiceIndex, bool userWentFirst)
        {
            var userDice = diceList[userDiceIndex];
            var computerDice = diceList[computerDiceIndex];
            
            Console.WriteLine($"\n--- ROUND ---");
            Console.WriteLine($"User: {userDice}");
            Console.WriteLine($"Computer: {computerDice}");
            
            // Roll user dice
            var (userRoll, userProof) = random.GenerateWithProof(0, 5);
            int userResult = userDice.Faces[userRoll];
            Console.WriteLine($"User roll proof: {userProof}");
            Console.WriteLine($"User rolled: {userResult}");
            
            // Roll computer dice
            var (computerRoll, computerProof) = random.GenerateWithProof(0, 5);
            int computerResult = computerDice.Faces[computerRoll];
            Console.WriteLine($"Computer roll proof: {computerProof}");
            Console.WriteLine($"Computer rolled: {computerResult}");
            
            // Determine winner
            if (userResult > computerResult)
                Console.WriteLine("🎉 User wins this round!");
            else if (computerResult > userResult)
                Console.WriteLine("💻 Computer wins this round!");
            else
                Console.WriteLine("🤝 It's a tie!");
        }
    }
}
