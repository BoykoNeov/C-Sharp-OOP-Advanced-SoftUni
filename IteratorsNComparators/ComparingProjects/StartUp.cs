using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        string input = string.Empty;
        List<Person> persons = new List<Person>();

        while ((input = Console.ReadLine()) != "END")
        {
            string[] args = input.Split();

            Person newPerson = new Person() { Name = args[0], Age = int.Parse(args[1]), Town = args[2] };
            persons.Add(newPerson);
        }

        int personNumber = int.Parse(Console.ReadLine()) - 1;

        int equalPeople = 0;

        foreach (Person person in persons)
        {
            if (persons[personNumber].Equals(person))
            {
                equalPeople++;
            }
        }

        if (equalPeople == 1)
        {
            Console.WriteLine("No matches");
            return;
        }

        Console.WriteLine($"{equalPeople} {persons.Count - equalPeople} {persons.Count}");
    }
}