using System;
using System.Text;
using FestivalManager.Core.IO.Contracts;

public class ConsoleWriter : IWriter
{
    private StringBuilder stringBuilder;

    public ConsoleWriter()
    {
        stringBuilder = new StringBuilder();
    }

    private void AppendLine(string line)
    {
        stringBuilder.AppendLine(line);
    }

    private void WriteLineAll()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(stringBuilder.ToString().Trim());
        Console.ResetColor();
    }

    public void WriteLine(string contents)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(contents);
        Console.ResetColor();
    }

    public void Write(string contents)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(contents);
        Console.ResetColor();
    }
}