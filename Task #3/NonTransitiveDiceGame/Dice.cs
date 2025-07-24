using System;
using System.Linq;

namespace NonTransitiveDiceGame
{
    public class Dice
    {
        public int[] Faces { get; private set; }
        public string Name { get; private set; }

        public Dice(string faceValues, int index)
        {
            Name = $"Dice {index + 1}";
            ParseFaces(faceValues);
        }

        private void ParseFaces(string faceValues)
        {
            try
            {
                Faces = faceValues.Split(',')
                                 .Select(s => int.Parse(s.Trim()))
                                 .ToArray();
                
                if (Faces.Length != 6)
                    throw new ArgumentException($"Each dice must have exactly 6 faces, got {Faces.Length}");
            }
            catch (FormatException)
            {
                throw new ArgumentException("All face values must be integers");
            }
        }

        public override string ToString()
        {
            return $"{Name}: [{string.Join(",", Faces)}]";
        }
    }
}
