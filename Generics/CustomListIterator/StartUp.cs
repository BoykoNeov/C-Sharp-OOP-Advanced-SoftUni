using System;
using System.Collections.Generic;

public class StartUp
{
    static void Main()
    {
        CustomList<string> customList = new CustomList<string>();

        string input = string.Empty;

        while((input = Console.ReadLine()) != "END")
        {
            string[] inputs = input.Split();
            Console.ForegroundColor = ConsoleColor.Red;

            switch (inputs[0])
            {
                case "Add":
                    customList.Add(inputs[1]);
                    break;

                case "Remove":
                    customList.Remove(int.Parse(inputs[1]));
                    break;

                case "Contains":
                     Console.WriteLine(customList.Contains(inputs[1]));
                    break;

                case "Swap":
                    customList.Swap(int.Parse(inputs[1]), int.Parse(inputs[2]));
                    break;

                case "Greater":
                    Console.WriteLine(customList.CountGreaterThan(inputs[1]));
                    break;

                case "Max":
                    Console.WriteLine(customList.Max());
                    break;

                case "Min":
                    Console.WriteLine(customList.Min());
                    break;

                case "Print":
                    foreach (string item in customList)
                    {
                        Console.WriteLine(item);
                    }

                    break;
            }

            Console.ResetColor();
        }
    }
}