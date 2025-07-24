using System;
using System.Security.Cryptography;
using System.Text;
namespace DiceGame
{
    class rg
    {
        RandomNumberGenerator r;
        public rg() { r = RandomNumberGenerator.Create(); }
        public byte[] k()
        {
            var b = new byte[32];
            r.GetBytes(b);
            return b;
        }
        public int gi(int m)
        {
            var bb = new byte[4];
            int x;
            do
            {
                r.GetBytes(bb);
                x = Math.Abs(BitConverter.ToInt32(bb, 0));
            } while (x >= int.MaxValue - (int.MaxValue % (m + 1)));
            return x % (m + 1);
        }
        public string h(byte[] key, int n)
        {
            var hm = new HMACSHA256(key);
            var d = Encoding.UTF8.GetBytes(n.ToString());
            return BitConverter.ToString(hm.ComputeHash(d)).Replace("-", "");
        }
        public int fair(int m)
        {
            int c = gi(m);
            var key = k();
            Console.WriteLine("HMAC=" + h(key, c));
            int u = getU(m);
            int res = (c + u) % (m + 1);
            Console.WriteLine("my num=" + c + " key=" + BitConverter.ToString(key).Replace("-", ""));
            Console.WriteLine("result=" + c + "+" + u + "=" + res);
            return res;
        }
        int getU(int m)
        {
            while (true)
            {
                Console.WriteLine("pick 0 to " + m);
                for (int i = 0; i <= m; i++) Console.WriteLine(i + " - " + i);
                Console.WriteLine("X - exit");
                Console.WriteLine("? - help");
                var inp = Console.ReadLine();
                if (inp == "X") Environment.Exit(0);
                if (inp == "?") { Console.WriteLine("pick number"); continue; }
                int ch;
                if (int.TryParse(inp, out ch) && ch >= 0 && ch <= m) return ch;
                Console.WriteLine("bad");
            }
        }
    }
}
