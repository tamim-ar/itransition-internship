using System;
using System.Collections.Generic;
using System.Linq;

namespace DiceGame
{
    public class DiceParser
    {
        public List<Dice> ParseDice(string[] args)
        {
            var diceList = new List<Dice>();

            foreach (string arg in args)
            {
                try
                {
                    string[] parts = arg.Split(',');

                    if (parts.Length != 6)
                        throw new ArgumentException($"Each dice must have 6 values, but got {parts.Length}");

                    int[] faces = new int[6];
                    for (int i = 0; i < 6; i++)
                    {
                        if (!int.TryParse(parts[i], out faces[i]))
                            throw new ArgumentException($"'{parts[i]}' is not a valid number");
                    }

                    diceList.Add(new Dice(faces));
                }
                catch (Exception ex)
                {
                    throw new ArgumentException($"Error parsing dice '{arg}': {ex.Message}");
                }
            }

            return diceList;
        }
    }
}
