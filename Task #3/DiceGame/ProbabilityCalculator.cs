using System;
using System.Collections.Generic;
namespace DiceGame
{
    class pc
    {
        public double p(d a, d b)
        {
            int w = 0, t = 0;
            for (int i = 0; i < 6; i++) for (int j = 0; j < 6; j++)
                {
                    t++;
                    if (a.f[i] > b.f[j]) w++;
                }
            return (double)w / t;
        }
        public double[,] all(List<d> L)
        {
            int n = L.Count;
            double[,] pr = new double[n, n];
            for (int i = 0; i < n; i++) for (int j = 0; j < n; j++)
                {
                    if (i == j) pr[i, j] = 0.3333;
                    else pr[i, j] = p(L[i], L[j]);
                }
            return pr;
        }
    }
}
