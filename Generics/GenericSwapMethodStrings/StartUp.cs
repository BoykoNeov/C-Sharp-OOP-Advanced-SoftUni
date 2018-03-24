using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        Dictionary<int, GenericBox<string>> boxes = new Dictionary<int, GenericBox<string>>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            GenericBox<string> box = new GenericBox<string>(Console.ReadLine());
            boxes[i] = box;
        }

        List<int> swap = Console.ReadLine().Split().Select(int.Parse).ToList();
        GenericBox<string> swapThis = null;
        swapThis = boxes[swap[0]];
        boxes[swap[0]] = boxes[swap[1]];
        boxes[swap[1]] = swapThis;

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(boxes[i].ToString());
        }
    }
}