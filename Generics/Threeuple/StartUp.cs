﻿using System;

public class StartUp
{
    public static void Main()
    {
        string[] firstInput = Console.ReadLine().Split();

        Threeuple<string, string, string> firstTuple = new Threeuple<string, string, string>((firstInput[0] + " " + firstInput[1]), firstInput[2], firstInput[3]);
        Console.WriteLine(firstTuple.ToString());

        string[] secondInput = Console.ReadLine().Split();
        Threeuple<string, int, string> secondTuple = new Threeuple<string, int, string>(secondInput[0], int.Parse(secondInput[1]), secondInput[2]);
        Console.WriteLine(secondTuple.ToString());

        string[] thirdInput = Console.ReadLine().Split();
        Threeuple<int, double, string> thirdTuple = new Threeuple<int, double, string>(int.Parse(thirdInput[0]), double.Parse(thirdInput[1]), thirdInput[2]);
        Console.WriteLine(thirdTuple.ToString());
    }
}