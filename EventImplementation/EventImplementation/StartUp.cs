using System;

public class StartUp
{
    public static void Main()
    {
        Dispatcher dispacher = new Dispatcher();
        Handler handler = new Handler();

        dispacher.NameChange += handler.OnDispatcherNameChange;

        string newName = string.Empty;
        while ((newName = Console.ReadLine()) != "End")
        {
            dispacher.Name = newName;
        }
    }
}