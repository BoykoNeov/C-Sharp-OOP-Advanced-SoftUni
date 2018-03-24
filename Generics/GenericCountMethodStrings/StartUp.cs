using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        List<GenericBox<string>> boxes = new List<GenericBox<string>>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            GenericBox<string> box = new GenericBox<string>(Console.ReadLine());
            boxes.Add(box);
        }

        string comparator = Console.ReadLine();
        int biggerCounter = 0;

        for (int i = 0; i < n; i++)
        {
            if (boxes[i].Value.CompareTo(comparator) > 0)
            {
                biggerCounter++;
            }
        }

        Console.WriteLine(biggerCounter);
    }
}