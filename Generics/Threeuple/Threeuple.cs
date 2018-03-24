public class Threeuple<T1, T2, T3> : Tuple<T1, T2>
{
    T3 item3;

    public Threeuple() { }

    public Threeuple(T1 item1, T2 item2, T3 item3) : base(item1, item2)
    {
        this.item3 = item3;
    }

    public T3 Item3 { get => item3; set => item3 = value; }

    public override string ToString()
    {
        return $"{Item1.ToString()} -> {Item2.ToString()} -> {Item3.ToString()}";
    }
}