using System;

public class StartUp
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            GenericBox<string> box = new GenericBox<string>(Console.ReadLine());
            Console.WriteLine(box.ToString());
        }
    }
}