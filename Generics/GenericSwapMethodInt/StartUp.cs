using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<GenericBox<int>> boxes = new List<GenericBox<int>>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            GenericBox<int> box = new GenericBox<int>(int.Parse(Console.ReadLine()));
            boxes.Add(box);
        }

        List<int> swap = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        GenericBox<int> swapThis = null;
        swapThis = boxes[swap[0]];
        boxes[swap[0]] = boxes[swap[1]];
        boxes[swap[1]] = swapThis;

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(boxes[i].ToString());
        }
    }
}