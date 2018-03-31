using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        string input = string.Empty;
        Stack<int> stack = new Stack<int>();

        while((input = Console.ReadLine()) != "END")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string[] commands = input.Split(new char[] {' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                switch (commands[0])
                {
                    case "Pop":
                        stack.Pop();
                        break;

                    case "Push":
                        stack.Push(commands.Skip(1).Select(int.Parse).ToArray());
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

        Console.ForegroundColor = ConsoleColor.Red;
        for (int i = 0; i < 2; i++)
        {
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}