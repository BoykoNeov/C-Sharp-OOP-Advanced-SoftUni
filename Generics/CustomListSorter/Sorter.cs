using System;

public class Sorter<T> where T : IComparable<T>
{
    public static void Sort(ref CustomList<T> customList)
    {
        CustomList<T> sortedList = new CustomList<T>();

        // This is intentionally done in such naive way
        int customListCount = customList.Count;

        for (int i = 0; i < customListCount; i++)
        {
            T minElement = customList.Min();
            int indexOfMin = customList.FirstIndexOf(minElement);
            customList.Remove(indexOfMin);
            sortedList.Add(minElement);
        }

        customList = sortedList;
    }
}