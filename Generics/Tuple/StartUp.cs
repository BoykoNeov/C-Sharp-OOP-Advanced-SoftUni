using System;

public class StartUp
{
    public static void Main()
    {
        string[] firstInput = Console.ReadLine().Split();

        Tuple<string, string> firstTuple = new Tuple<string, string>((firstInput[0] + " " + firstInput[1]), firstInput[2]);
        Console.WriteLine(firstTuple.ToString());

        string[] secondInput = Console.ReadLine().Split();
        Tuple<string, int> secondTuple = new Tuple<string, int>(secondInput[0], int.Parse(secondInput[1]));
        Console.WriteLine(secondTuple.ToString());

        string[] thirdInput = Console.ReadLine().Split();
        Tuple<int, double> thirdTuple = new Tuple<int, double>(int.Parse(thirdInput[0]), double.Parse(thirdInput[1]));
        Console.WriteLine(thirdTuple.ToString());
    }
}