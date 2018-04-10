using System;
using System.Collections.Generic;
using System.Linq;

namespace BubbleSorter
{
    public static class BubbleSorter<T> where T:IComparable<T>
    {
        public static IEnumerable<T> BubbleSort(IEnumerable<T> collectionToSort)
        {
            bool unorderedItemsPresent = true;
            List<T> listToWorkWith = collectionToSort.ToList();

            while (unorderedItemsPresent)
            {
                unorderedItemsPresent = false;

                for (int i = 0; i < listToWorkWith.Count - 1; i++)
                {
                    if (listToWorkWith[i].CompareTo(listToWorkWith[i + 1]) == 1)
                    {
                        unorderedItemsPresent = true;
                        T temp = listToWorkWith[i];
                        listToWorkWith[i] = listToWorkWith[i + 1];
                        listToWorkWith[i + 1] = temp;
                    }
                }
            }

            return listToWorkWith;
        }
    }
}