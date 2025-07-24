using System;
using System.Security.Cryptography;

namespace NonTransitiveDiceGame
{
    public class ProvablyFairRandom
    {
        private readonly RandomNumberGenerator rng;
        
        public ProvablyFairRandom()
        {
            rng = RandomNumberGenerator.Create();
        }

        public (int result, string proof) GenerateWithProof(int min, int max)
        {
            byte[] randomBytes = new byte[4];
            rng.GetBytes(randomBytes);
            
            // Convert to hex for proof
            string proof = BitConverter.ToString(randomBytes).Replace("-", "");
            
            // Convert to number in range
            int randomInt = BitConverter.ToInt32(randomBytes, 0);
            int result = Math.Abs(randomInt % (max - min + 1)) + min;
            
            return (result, proof);
        }

        public (bool userFirst, string proof) DetermineFirstPlayer()
        {
            var (randomValue, proof) = GenerateWithProof(0, 1);
            bool userFirst = randomValue == 1;
            
            Console.WriteLine($"Determining first player...");
            Console.WriteLine($"Random bytes generated: {proof}");
            Console.WriteLine($"Result: {(userFirst ? "User" : "Computer")} goes first");
            Console.WriteLine($"(0 = Computer first, 1 = User first)");
            
            return (userFirst, proof);
        }
    }
}
