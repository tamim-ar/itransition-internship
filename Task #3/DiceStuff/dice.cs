using System;
using System.Linq;

class dice
{
    public int[] nums { get; }
    public int num { get; }

    public dice(int[] n, int i)
    {
        if (n.Length != 6)
        {
            throw new Exception($"dice {i + 1} needs 6 numbers");
        }
        
        if (n.Any(x => x <= 0))
        {
            throw new Exception($"dice {i + 1} has bad numbers");
        }

        nums = n;
        num = i;
    }

    public int roll(byte[] r)
    {
        int i = r[0] % 6;
        return nums[i];
    }

    public override string ToString()
    {
        return $"dice {num + 1}: [{string.Join(",", nums)}]";
    }
}
