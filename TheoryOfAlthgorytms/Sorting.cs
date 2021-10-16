using System;

namespace TheoryOfAlgorytms
{
    internal static class Sorting
    {
        public static void BubbleSort(string[] strings, int[] sortedIndexs)
        {
            ulong transposition = 0, comparisons = 0;
            string str;
            for (int index = strings.Length - 1, index2 = 0, tmp; index > 0; --index)
            {
                while (index2 < index)
                {
                    if (sortedIndexs[index2] > sortedIndexs[index2 + 1])
                    {
                        ++transposition;
                        tmp = sortedIndexs[index2];
                        sortedIndexs[index2] = sortedIndexs[index2 + 1];
                        sortedIndexs[index2 + 1] = tmp;

                        str = strings[index2];
                        strings[index2] = strings[index2 + 1];
                        strings[index2 + 1] = str;
                    }
                    ++comparisons;
                    ++index2;
                }
                index2 = 0;
            }
            Console.WriteLine($"Transposition -> {transposition}\nComparisons -> {comparisons}");
        }

        public static void SelectionSort(string[] strings, int[] sortedIndexs)
        {
            int tmpInt;
            string tmpStr;
            var length = strings.Length;
            ulong transposition = 0, comparisons = 0;

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

                    tmpStr = strings[k];
                    strings[k] = strings[i];
                    strings[i] = tmpStr;
                }
            }
            Console.WriteLine($"Transposition -> {transposition}\nComparisons -> {comparisons}");
        }

        public static void InsertSort(string[] strings, int[] sortedIndexs)
        {
            var length = strings.Length;
            ulong transposition = 0, comparisons = 0;
            int tmpInt;
            string tmpStr;

            for (int index = 1, index2; index < length; index++)
            {
                tmpInt = sortedIndexs[index];
                tmpStr = strings[index];
                for (index2 = index - 1; index2 >= 0;++comparisons)
                {
                    if (tmpInt < sortedIndexs[index2])
                    {
                        ++transposition;
                        sortedIndexs[index2 + 1] = sortedIndexs[index2];
                        strings[index2 + 1] = strings[index2];
                        index2--;
                        sortedIndexs[index2 + 1] = tmpInt;
                        strings[index2 + 1] = tmpStr;
                    }
                    else
                        break;
                }
            }
            Console.WriteLine($"Transposition -> {transposition}\nComparisons -> {comparisons}");
        }

        public static void ShellSorting(string[] strings, int[] sortedIndexs)
        {
            ulong transposition = 0, comparisons = 0;
            var length = strings.Length;
            int tmpInt;
            string tmpStr;
            for (var step = length / 2; step > 0; step /= 2)
            {
                for (var i = step; i < length; i++)
                {
                    for (var j = i - step; j >= 0 && sortedIndexs[j] > sortedIndexs[j + step]; j -= step, ++comparisons)
                    {
                        ++transposition;
                        tmpInt = sortedIndexs[j];
                        sortedIndexs[j] = sortedIndexs[j + step];
                        sortedIndexs[j + step] = tmpInt;

                        tmpStr = strings[j];
                        strings[j] = strings[j + step];
                        strings[j + step] = tmpStr;
                    }
                }
            }
            Console.WriteLine($"Transposition -> {transposition}\nComparisons -> {comparisons}");
        }
    }
}