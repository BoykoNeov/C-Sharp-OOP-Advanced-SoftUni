public class Tuple<T1, T2>
{
    T1 item1;
    T2 item2;

    public Tuple() { }

    public Tuple(T1 item1, T2 item2)
    {
        this.Item1 = item1;
        this.Item2 = item2;
    }

    public T2 Item2 { get => item2; set => item2 = value; }
    public T1 Item1 { get => item1; set => item1 = value; }

    public override string ToString()
    {
        return $"{Item1.ToString()} -> {Item2.ToString()}";
    }
}