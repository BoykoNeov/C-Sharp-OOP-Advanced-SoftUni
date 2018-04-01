using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        HashSet<Person> personsHashSet = new HashSet<Person>();
        SortedSet<Person> personsSortedSet = new SortedSet<Person>();

        int inputCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < inputCount; i++)
        {
            string[] inputs = Console.ReadLine().Split();
            Person newPerson = new Person(inputs[0], int.Parse(inputs[1]));
            personsHashSet.Add(newPerson);
            personsSortedSet.Add(newPerson);
        }

        Console.WriteLine(personsHashSet.Count);
        Console.WriteLine(personsSortedSet.Count);
    }
}