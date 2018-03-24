using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        List<GenericBox<double>> boxes = new List<GenericBox<double>>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            GenericBox<double> box = new GenericBox<double>(double.Parse(Console.ReadLine()));
            boxes.Add(box);
        }

        double comparator = double.Parse(Console.ReadLine());
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