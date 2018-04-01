using System;
using System.Collections.Generic;

public class Person : IComparable<Person>, IEquatable<Person>
{
    private string name;
    private int age;

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Person() { }

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public int CompareTo(Person other)
    {
        int nameCompare = this.Name.CompareTo(other.Name);

        if (nameCompare != 0)
        {
            return nameCompare;
        }

        int ageCompare = this.Age.CompareTo(other.Age);
        return ageCompare;
    }

    public override bool Equals(object obj)
    {
        Person otherPerson = obj as Person;

        if (otherPerson == null)
        {
            return false;
        }
        else
        {
            return this.Equals(otherPerson);
        }

    }

    public override int GetHashCode()
    {
        var hashCode = 1014320599;
        hashCode = hashCode * -1521134295 + Age.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
        return hashCode;
    }

    public bool Equals(Person other)
    {
        if (this.CompareTo(other) == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}