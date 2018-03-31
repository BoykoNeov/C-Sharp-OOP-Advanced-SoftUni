using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Lake : IEnumerable<int>
{
    public List<int> stones = new List<int>();

    public Lake(IEnumerable<int> stones)
    {
        this.stones = stones.ToList();
    }

    public Lake() { }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < this.stones.Count; i+= 2)
        {
            yield return stones[i];
        }

        for (int i = this.stones.Count % 2 == 0 ? this.stones.Count - 1 : this.stones.Count - 2; i >= 1; i -= 2)
        {
            yield return stones[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}