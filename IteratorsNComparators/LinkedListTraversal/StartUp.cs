using System;

public class StartUp
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        DoublyLinkedList<int> linkedList = new DoublyLinkedList<int>();

        for (int i = 0; i < n; i++)
        {
            string[] args = Console.ReadLine().Split();

            switch (args[0])
            {
                case "Add":
                    linkedList.Add(int.Parse(args[1]));
                    break;

                case "Remove":
                    linkedList.Remove(int.Parse(args[1]));
                    break;
            }
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(linkedList.Count);
        Console.WriteLine(string.Join(" ", linkedList));
    }
}