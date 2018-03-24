public class GenericBox<T>
{
    private T _value;

    T Value { get => _value; set => _value = value; }

    public GenericBox(T value)
    {
        this.Value = value;
    }

    public override string ToString()
    {
        return $"{this.GetType().FullName}: {this.Value}";
    }
}