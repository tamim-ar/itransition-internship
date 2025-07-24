using System;
using System.Collections.Generic;
using ConsoleTables;
namespace DiceGame
{
    class tg
    {
        public void show(List<d> L)
        {
            Console.WriteLine("prob table");
            var c = new pc();
            double[,] p = c.all(L);
            var h = new List<string> { "dice" };
            for (int i = 0; i < L.Count; i++) h.Add(L[i].ToString());
            var t = new ConsoleTable(h.ToArray());
            for (int i = 0; i < L.Count; i++)
            {
                var r = new List<object> { L[i].ToString() };
                for (int j = 0; j < L.Count; j++)
                {
                    if (i == j) r.Add("-");
                    else r.Add(p[i, j].ToString("F2"));
                }
                t.AddRow(r.ToArray());
            }
            t.Write();
        }
    }
}
