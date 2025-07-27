using System;
using System.Collections.Generic;
using ConsoleTables;

namespace DiceGame
{
    public class TableGenerator
    {
        public void ShowProbabilityTable(List<Dice> diceList)
        {
            Console.WriteLine("\nThis is a non-transitive dice game.");
            Console.WriteLine("Each player picks a different dice and rolls it.");
            Console.WriteLine("The higher number wins!");
            Console.WriteLine("\nProbability of win for the user:\n");

            var calculator = new ProbabilityCalculator();
            double[,] probabilities = calculator.CalculateAllProbabilities(diceList);


            var headers = new List<string> { "User dice v" };
            for (int i = 0; i < diceList.Count; i++)
            {
                headers.Add(diceList[i].ToString());
            }


            var table = new ConsoleTable(headers.ToArray());

            for (int i = 0; i < diceList.Count; i++)
            {
                var row = new List<object> { diceList[i].ToString() };

                for (int j = 0; j < diceList.Count; j++)
                {
                    if (i == j)
                        row.Add(".3333");
                    else
                        row.Add(probabilities[i, j].ToString("F4"));
                }

                table.AddRow(row.ToArray());
            }

            table.Write();
            Console.WriteLine();
        }
    }
}
