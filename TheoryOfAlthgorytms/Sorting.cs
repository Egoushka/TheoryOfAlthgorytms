using System;

namespace TheoryOfAlthgorytms
{
    internal static class Sorting
    {
        static public void BubbleSort(String[] strs, int[] sortedIndexs)
        {
            UInt64 transposition = 0, comparisons = 0;
            String str;
            for (int index = strs.Length - 1, index2 = 0, tmp; index > 0; --index)
            {
                while (index2 < index)
                {
                    if (sortedIndexs[index2] > sortedIndexs[index2 + 1])
                    {
                        ++transposition;
                        tmp = sortedIndexs[index2];
                        sortedIndexs[index2] = sortedIndexs[index2 + 1];
                        sortedIndexs[index2 + 1] = tmp;

                        str = strs[index2];
                        strs[index2] = strs[index2 + 1];
                        strs[index2 + 1] = str;
                    }
                    ++comparisons;
                    ++index2;
                }
                index2 = 0;
            }
            Console.WriteLine($"Transposition -> {transposition}\nComparisons -> {comparisons}");
        }

        static public void SelectionSort(String[] strs, int[] sortedIndexs)
        {
            int tmpInt;
            string tmpStr;
            int length = strs.Length;
            UInt64 transposition = 0, comparisons = 0;

            for (int i = 0, j, k = 0; i < length - 1; ++i)
            {
                k = i;
                for (j = i + 1; j < length; ++j,++comparisons)
                {
                    if (sortedIndexs[k] > sortedIndexs[j])
                        k = j;
                }
                if (k != i)
                {
                    ++transposition;
                    tmpInt = sortedIndexs[k];
                    sortedIndexs[k] = sortedIndexs[i];
                    sortedIndexs[i] = tmpInt;

                    tmpStr = strs[k];
                    strs[k] = strs[i];
                    strs[i] = tmpStr;
                }
            }
            Console.WriteLine($"Transposition -> {transposition}\nComparisons -> {comparisons}");
        }

        static public void InsertSort(String[] strs, int[] sortedIndexs)
        {
            int length = strs.Length;
            UInt64 transposition = 0, comparisons = 0;
            int tmpInt;
            string tmpStr;

            for (int index = 1, index2; index < length; index++)
            {
                tmpInt = sortedIndexs[index];
                tmpStr = strs[index];
                for (index2 = index - 1; index2 >= 0;++comparisons)
                {
                    if (tmpInt < sortedIndexs[index2])
                    {
                        ++transposition;
                        sortedIndexs[index2 + 1] = sortedIndexs[index2];
                        strs[index2 + 1] = strs[index2];
                        index2--;
                        sortedIndexs[index2 + 1] = tmpInt;
                        strs[index2 + 1] = tmpStr;
                    }
                    else
                        break;
                }
            }
            Console.WriteLine($"Transposition -> {transposition}\nComparisons -> {comparisons}");
        }

        static public void ShellSorting(String[] strs, int[] sortedIndexs)
        {
            UInt64 transposition = 0, comparisons = 0;
            int length = strs.Length;
            int tmpInt;
            string tmpStr;
            for (int step = length / 2; step > 0; step /= 2)
            {
                for (int i = step; i < length; i++)
                {
                    for (int j = i - step; j >= 0 && sortedIndexs[j] > sortedIndexs[j + step]; j -= step, ++comparisons)
                    {
                        ++transposition;
                        tmpInt = sortedIndexs[j];
                        sortedIndexs[j] = sortedIndexs[j + step];
                        sortedIndexs[j + step] = tmpInt;

                        tmpStr = strs[j];
                        strs[j] = strs[j + step];
                        strs[j + step] = tmpStr;
                    }
                }
            }
            Console.WriteLine($"Transposition -> {transposition}\nComparisons -> {comparisons}");
        }
    }
}