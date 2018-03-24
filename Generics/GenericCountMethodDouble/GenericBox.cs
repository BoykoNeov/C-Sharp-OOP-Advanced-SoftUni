using System;

public class GenericBox<T> : IComparable<GenericBox<T>>, IComparable
    where T : IComparable<T>
{
    private T _value;

   public T Value { get => _value; set => _value = value; }

    public GenericBox(T value)
    {
        this.Value = value;
    }

    public override string ToString()
    {
        return $"{this.Value.GetType().FullName}: {this.Value}";
    }

    //public int CompareTo(T other)
    //{
    //    int result = this.Value.CompareTo(other);
    //    return result;
    //}

    public int CompareTo(object obj)
    {
        GenericBox<T> other = obj as GenericBox<T>;

        if (other == null)
        {
            return 1;
        }
        else
        {
            return this.Value.CompareTo(other.Value);
        }
    }

    public int CompareTo(GenericBox<T> other)
    {
        return this.Value.CompareTo(other.Value);
    }
}