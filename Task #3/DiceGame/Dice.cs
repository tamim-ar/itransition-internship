using System;
namespace DiceGame
{
    class d
    {
        public int[] f;
        public d(int[] x)
        {
            if (x.Length != 6) throw new Exception("bad");
            f = x;
        }
        public int r(int i)
        {
            if (i < 0 || i > 5) throw new Exception("bad idx");
            return f[i];
        }
        public override string ToString()
        {
            return f[0] + "," + f[1] + "," + f[2] + "," + f[3] + "," + f[4] + "," + f[5];
        }
    }
}
