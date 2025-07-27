using System;
using System.Security.Cryptography;
using System.Text;

namespace DiceGame
{
    public class RandomGenerator
    {
        private RandomNumberGenerator rng;

        public RandomGenerator()
        {
            rng = RandomNumberGenerator.Create();
        }

        public byte[] GenerateKey()
        {
            byte[] key = new byte[32];
            rng.GetBytes(key);
            return key;
        }

        public int GenerateSecureInt(int maxValue)
        {
            byte[] bytes = new byte[4];
            int result;

            do
            {
                rng.GetBytes(bytes);
                result = Math.Abs(BitConverter.ToInt32(bytes, 0));
            } while (result >= int.MaxValue - (int.MaxValue % (maxValue + 1)));

            return result % (maxValue + 1);
        }

        public string CalculateHMAC(byte[] key, int number)
        {
            using (var hmac = new HMACSHA256(key))
            {
                byte[] data = Encoding.UTF8.GetBytes(number.ToString());
                byte[] hash = hmac.ComputeHash(data);
                return BitConverter.ToString(hash).Replace("-", "");
            }
        }

        public int DoFairRandom(int maxValue)
        {

            int computerNumber = GenerateSecureInt(maxValue);

            byte[] key = GenerateKey();

            string hmac = CalculateHMAC(key, computerNumber);
            Console.WriteLine($"I selected a random value in the range 0..{maxValue} (HMAC={hmac}).");


            int userNumber = GetUserChoice(maxValue);


            int result = (computerNumber + userNumber) % (maxValue + 1);

            string keyString = BitConverter.ToString(key).Replace("-", "");
            Console.WriteLine($"My number is {computerNumber} (KEY={keyString}).");
            Console.WriteLine($"The fair number generation result is {computerNumber} + {userNumber} = {result} (mod {maxValue + 1}).");

            return result;
        }

        private int GetUserChoice(int maxValue)
        {
            while (true)
            {
                Console.WriteLine("Add your number modulo " + (maxValue + 1) + ".");

                for (int i = 0; i <= maxValue; i++)
                {
                    Console.WriteLine($"{i} - {i}");
                }
                Console.WriteLine("X - exit");
                Console.WriteLine("? - help");

                Console.Write("Your selection: ");
                string input = Console.ReadLine();

                if (input.ToUpper() == "X")
                    Environment.Exit(0);

                if (input == "?")
                {
                    Console.WriteLine("Select a number to add to my secret number.");
                    continue;
                }

                if (int.TryParse(input, out int choice) && choice >= 0 && choice <= maxValue)
                {
                    return choice;
                }

                Console.WriteLine("Invalid choice. Try again.");
            }
        }
    }
}
