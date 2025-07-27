using System;
using System.Linq;

namespace DiceGame
{
    public class Dice
    {
        public int[] Faces { get; private set; }

        public Dice(int[] faces)
        {
            if (faces.Length != 6)
                throw new ArgumentException("Dice must have exactly 6 faces");

            Faces = faces;
        }

        public int Roll(int faceIndex)
        {
            if (faceIndex < 0 || faceIndex >= 6)
                throw new ArgumentException("Face index must be 0-5");

            return Faces[faceIndex];
        }

        public override string ToString()
        {
            return string.Join(",", Faces);
        }
    }
}
