using System;
using System.Collections.Generic;

public class StartUp
{
    static void Main()
    {
        SortedSet<Person> personsByAge = new SortedSet<Person>(new PersonAgeComparator());
        SortedSet<Person> personsByName = new SortedSet<Person>(new PersonNameComparator());

        int numberOfPersons = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfPersons; i++)
        {
            string[] personData = Console.ReadLine().Split();
            Person newPerson = new Person()
            {
                Name = personData[0],
                Age = int.Parse(personData[1])
            };

            personsByAge.Add(newPerson);
            personsByName.Add(newPerson);
        }

        Console.ForegroundColor = ConsoleColor.Red;

        foreach (Person person in personsByName)
        {
            Console.WriteLine(person);
        }

        foreach (Person person in personsByAge)
        {
            Console.WriteLine(person);
        }
    }
}