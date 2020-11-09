using System;

namespace TheoryOfAlthgorytms
{
    internal static class Sorting
    {
        static public void BubbleSort(String[] strs, int[] sortedIndexs)
        {
            String str;
            for (int index = strs.Length - 1, index2 = 0, tmp; index > 0; --index)
            {
                while (index2 < index)
                {
                    if (sortedIndexs[index2] > sortedIndexs[index2 + 1])
                    {
                        tmp = sortedIndexs[index2];
                        sortedIndexs[index2] = sortedIndexs[index2 + 1];
                        sortedIndexs[index2 + 1] = tmp;

                        str = strs[index2];
                        strs[index2] = strs[index2 + 1];
                        strs[index2 + 1] = str;
                    }
                    ++index2;
                }
                index2 = 0;
            }
        }
    }
}