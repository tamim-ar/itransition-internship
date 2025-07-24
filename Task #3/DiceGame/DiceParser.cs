using System;
using System.Collections.Generic;
namespace DiceGame
{
    class dp
    {
        public List<d> p(string[] a)
        {
            var L = new List<d>();
            foreach (var s in a)
            {
                var p = s.Split(',');
                if (p.Length != 6) throw new Exception("bad dice");
                int[] v = new int[6];
                for (int i = 0; i < 6; i++)
                {
                    int x;
                    if (!int.TryParse(p[i], out x)) throw new Exception("not number");
                    v[i] = x;
                }
                L.Add(new d(v));
            }
            return L;
        }
    }
}
