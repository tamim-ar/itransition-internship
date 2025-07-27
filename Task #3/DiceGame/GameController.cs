using System;
using System.Collections.Generic;
using System.Linq;

namespace DiceGame
{
    public class GameController
    {
        private List<Dice> diceList;
        private RandomGenerator randomGen;
        private TableGenerator tableGen;
        
        public GameController(List<Dice> diceList)
        {
            this.diceList = diceList;
            this.randomGen = new RandomGenerator();
            this.tableGen = new TableGenerator();
        }
        
        public void StartGame()
        {
            Console.WriteLine("Let's determine who makes the first move.");
            
            int firstMoveResult = randomGen.DoFairRandom(1);
            bool userFirst = (firstMoveResult == 0);
            
            int computerDiceIndex;
            int userDiceIndex;
            
            if (userFirst)
            {
                Console.WriteLine("You make the first move!");
                userDiceIndex = GetUserDiceChoice(-1);
                computerDiceIndex = GetComputerDiceChoice(userDiceIndex);
                Console.WriteLine($"I choose the [{diceList[computerDiceIndex]}] dice.");
            }
            else
            {
                Console.WriteLine("I make the first move!");
                computerDiceIndex = GetComputerDiceChoice(-1);
                Console.WriteLine($"I choose the [{diceList[computerDiceIndex]}] dice.");
                userDiceIndex = GetUserDiceChoice(computerDiceIndex);
            }
            
            Console.WriteLine($"You choose the [{diceList[userDiceIndex]}] dice.");
            
            // Computer roll
            Console.WriteLine("It's time for my roll.");
            int computerRollIndex = randomGen.DoFairRandom(5);
            int computerRoll = diceList[computerDiceIndex].Roll(computerRollIndex);
            Console.WriteLine($"My roll result is {computerRoll}.");
            
            // User roll
            Console.WriteLine("It's time for your roll.");
            int userRollIndex = randomGen.DoFairRandom(5);
            int userRoll = diceList[userDiceIndex].Roll(userRollIndex);
            Console.WriteLine($"Your roll result is {userRoll}.");
            
            // Determine winner
            if (userRoll > computerRoll)
                Console.WriteLine($"You win ({userRoll} > {computerRoll})!");
            else if (computerRoll > userRoll)
                Console.WriteLine($"I win ({computerRoll} > {userRoll})!");
            else
                Console.WriteLine($"It's a tie ({userRoll} = {computerRoll})!");
        }
        
        private int GetUserDiceChoice(int excludeIndex)
        {
            while (true)
            {
                Console.WriteLine("Choose your dice:");
                
                for (int i = 0; i < diceList.Count; i++)
                {
                    if (i != excludeIndex)
                        Console.WriteLine($"{i} - {diceList[i]}");
                }
                Console.WriteLine("X - exit");
                Console.WriteLine("? - help");
                
                Console.Write("Your selection: ");
                string input = Console.ReadLine();
                
                if (input.ToUpper() == "X")
                    Environment.Exit(0);
                
                if (input == "?")
                {
                    tableGen.ShowProbabilityTable(diceList);
                    continue;
                }
                
                if (int.TryParse(input, out int choice) && 
                    choice >= 0 && choice < diceList.Count && choice != excludeIndex)
                {
                    return choice;
                }
                
                Console.WriteLine("Invalid choice. Try again.");
            }
        }
        
        private int GetComputerDiceChoice(int excludeIndex)
        {
            var availableIndices = new List<int>();
            for (int i = 0; i < diceList.Count; i++)
            {
                if (i != excludeIndex)
                    availableIndices.Add(i);
            }
            
            Random rand = new Random();
            return availableIndices[rand.Next(availableIndices.Count)];
        }
    }
}
