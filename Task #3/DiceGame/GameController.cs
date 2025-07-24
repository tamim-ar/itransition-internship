using System;
using System.Collections.Generic;
namespace DiceGame
{
    class gc
    {
        List<d> L; rg R = new rg(); tg T = new tg();
        public gc(List<d> x) { L = x; }
        public void s()
        {
            Console.WriteLine("who first");
            int f = R.fair(1);
            bool u = (f == 0);
            int c, usr;
            if (u)
            {
                Console.WriteLine("you first");
                usr = getU(-1);
                c = getC(usr);
                Console.WriteLine("computer pick " + L[c]);
            }
            else
            {
                Console.WriteLine("computer first");
                c = getC(-1);
                Console.WriteLine("computer pick " + L[c]);
                usr = getU(c);
            }
            Console.WriteLine("you pick " + L[usr]);
            Console.WriteLine("computer roll");
            int cr = R.fair(5);
            int croll = L[c].r(cr);
            Console.WriteLine("computer got " + croll);
            Console.WriteLine("you roll");
            int ur = R.fair(5);
            int uroll = L[usr].r(ur);
            Console.WriteLine("you got " + uroll);
            if (uroll > croll) Console.WriteLine("u win");
            else if (croll > uroll) Console.WriteLine("computer win");
            else Console.WriteLine("tie");
        }
        int getU(int ex)
        {
            while (true)
            {
                Console.WriteLine("pick dice");
                for (int i = 0; i < L.Count; i++) if (i != ex) Console.WriteLine(i + " - " + L[i]);
                Console.WriteLine("X - exit");
                Console.WriteLine("? - help");
                var inp = Console.ReadLine();
                if (inp == "X") Environment.Exit(0);
                if (inp == "?") { T.show(L); continue; }
                int ch;
                if (int.TryParse(inp, out ch) && ch >= 0 && ch < L.Count && ch != ex) return ch;
                Console.WriteLine("bad");
            }
        }
        int getC(int ex)
        {
            var a = new List<int>();
            for (int i = 0; i < L.Count; i++) if (i != ex) a.Add(i);
            return a[new Random().Next(a.Count)];
        }
    }
}
