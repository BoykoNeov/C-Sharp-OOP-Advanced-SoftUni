using System;
using System.Collections.Generic;

public class Person : IComparable<Person>
{
    private string name;
    private int age;
    private string town;

    public string Town
    {
        get { return town; }
        set { town = value; }
    }


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

    public int CompareTo(Person other)
    {
        int nameCompare = this.Name.CompareTo(other.Name);

        if (nameCompare != 0)
        {
            return nameCompare;
        }

        int ageCompare = this.Age.CompareTo(other.Age);

        if (ageCompare != 0)
        {
            return ageCompare;
        }

        return this.Town.CompareTo(other.Town);
    }

    public override bool Equals(object obj)
    {
        Person otherPerson = obj as Person;

        if (otherPerson == null)
        {
            return false;
        }

        if (this.CompareTo(otherPerson) == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override int GetHashCode()
    {
        var hashCode = 1014320599;
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Town);
        hashCode = hashCode * -1521134295 + Age.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
        return hashCode;
    }
}