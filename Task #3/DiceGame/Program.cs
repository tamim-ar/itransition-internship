using System;
namespace DiceGame
{
    class m
    {
        static void Main(string[] a)
        {
            if (a.Length < 3)
            {
                Console.WriteLine("need 3+ dice");
                Console.WriteLine("eg: dotnet run 1,2,3,4,5,6 1,2,3,4,5,6 1,2,3,4,5,6");
                return;
            }
            try
            {
                var p = new dp();
                var L = p.p(a);
                var g = new gc(L);
                g.s();
            }
            catch
            {
                Console.WriteLine("bad input try again");
            }
        }
    }
}
