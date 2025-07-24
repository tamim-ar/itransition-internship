using System;

try
{
    if (args.Length < 3)
    {
        throw new Exception("need 3 dice. like: 2,2,4,4,9,9 6,8,1,1,8,6 7,5,3,7,5,3");
    }

    var g = new game(args);
    g.start();
}
catch (Exception e)
{
    Console.WriteLine($"oops: {e.Message}");
    Console.WriteLine("use it like: program.exe 2,2,4,4,9,9 6,8,1,1,8,6 7,5,3,7,5,3");
}
