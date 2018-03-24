using System;

public class StartUp
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            GenericBox<int> box = new GenericBox<int>(int.Parse(Console.ReadLine()));
            Console.WriteLine(box.ToString());
        }
    }
}