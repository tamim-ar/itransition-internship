using System;
using System.Collections.Generic;
using System.Linq;

class game
{
    List<dice> mydice;
    Random rnd;

    public game(string[] stuff)
    {
        mydice = new List<dice>();
        rnd = new Random();

        for (int i = 0; i < stuff.Length; i++)
        {
            var nums = stuff[i].Split(',')
                              .Select(s => int.TryParse(s, out int n) ? n : 0)
                              .ToArray();
            mydice.Add(new dice(nums, i));
        }
    }

    public void start()
    {
        Console.WriteLine("dice game starting!");
        
        bool playerGoesFirst = whoGoesFirst();
        Console.WriteLine(playerGoesFirst ? "u go first!" : "computer goes first!");

        while (true)
        {
            if (playerGoesFirst)
            {
                if (!playerMove()) break;
                if (!computerMove()) break;
            }
            else
            {
                if (!computerMove()) break;
                if (!playerMove()) break;
            }
        }
    }

    bool playerMove()
    {
        while (true)
        {
            Console.WriteLine("\nwhat u wanna do:");
            for (int i = 0; i < mydice.Count; i++)
            {
                Console.WriteLine($"{i + 1}: pick dice {i + 1}");
            }
            Console.WriteLine("h: help stuff");
            Console.WriteLine("x: quit");

            var pick = Console.ReadLine()?.ToLower();

            if (pick == "x") return false;
            if (pick == "h")
            {
                showHelp();
                continue;
            }

            if (int.TryParse(pick, out int num) && num >= 1 && num <= mydice.Count)
            {
                rollDice(mydice[num - 1], "u");
                return true;
            }

            Console.WriteLine("wrong pick try again");
        }
    }

    bool computerMove()
    {
        var compDice = mydice[rnd.Next(mydice.Count)];
        rollDice(compDice, "computer");
        return true;
    }

    void rollDice(dice d, string who)
    {
        var num = new byte[1];
        rnd.NextBytes(num);

        int result = d.roll(num);
        Console.WriteLine($"{who} picked {d} and got: {result}");
        Console.WriteLine($"random num was: {num[0]}");
    }

    bool whoGoesFirst()
    {
        var num = new byte[1];
        rnd.NextBytes(num);
        Console.WriteLine($"random num for first player: {num[0]}");
        return (num[0] % 2) == 0;
    }

    void showHelp()
    {
        Console.WriteLine("\nrules:");
        Console.WriteLine("1. pick a dice");
        Console.WriteLine("2. bigger number wins");
        Console.WriteLine("3. play till u quit");
        Console.WriteLine("4. its fair promise");
    }
}
