using System.Collections.Generic;

public class PersonNameComparator : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        if (x.Name.Length == y.Name.Length)
        {
            return char.ToLower(x.Name[0]).CompareTo(char.ToLower(y.Name[0]));
        }
        else
        {
            return x.Name.Length.CompareTo(y.Name.Length);
        }
    }
}