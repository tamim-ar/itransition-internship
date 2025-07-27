using System;
using System.Collections.Generic;

namespace DiceGame
{
    public class ProbabilityCalculator
    {
        public double CalculateWinProbability(Dice dice1, Dice dice2)
        {
            int wins = 0;
            int total = 0;

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    total++;
                    if (dice1.Faces[i] > dice2.Faces[j])
                        wins++;
                }
            }

            return (double)wins / total;
        }

        public double[,] CalculateAllProbabilities(List<Dice> diceList)
        {
            int count = diceList.Count;
            double[,] probabilities = new double[count, count];

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if (i == j)
                        probabilities[i, j] = 0.3333; // Same dice
                    else
                        probabilities[i, j] = CalculateWinProbability(diceList[i], diceList[j]);
                }
            }

            return probabilities;
        }
    }
}
