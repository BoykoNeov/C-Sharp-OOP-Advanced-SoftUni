﻿using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        string input = string.Empty;
        Collection<string> listyIterator = null;

        while((input = Console.ReadLine()) != "END")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string[] commands = input.Split();

            try
            {
                switch (commands[0])
                {
                    case "Create":
                        listyIterator = new Collection<string>(commands.Skip(1).ToList());
                        break;

                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;

                    case "Print":
                        Console.WriteLine(listyIterator.Print());
                        break;

                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;

                    case "PrintAll":
                        Console.WriteLine(string.Join(" ", listyIterator.PrintAll()));

                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ResetColor();
            }
        }
    }
}