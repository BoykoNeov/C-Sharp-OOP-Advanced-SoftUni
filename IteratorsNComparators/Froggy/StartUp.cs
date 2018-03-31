using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        Lake lake = new Lake(Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(string.Join(", ", lake));
    }
}