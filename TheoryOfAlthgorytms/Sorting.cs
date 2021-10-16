using System;

namespace TheoryOfAlgorithms
{
    internal static class Sorting
    {
        public static void BubbleSort(string[] strings, int[] sortedIndexes)
        {
            ulong transposition = 0, comparisons = 0;
            for (int index = strings.Length - 1, index2 = 0; index > 0; --index)
            {
                while (index2 < index)
                {
                    if (sortedIndexes[index2] > sortedIndexes[index2 + 1])
                    {
                        ++transposition;

                        (sortedIndexes[index2], sortedIndexes[index2 + 1]) = (sortedIndexes[index2 + 1], sortedIndexes[index2]);
                        (strings[index2], strings[index2 + 1]) = (strings[index2 + 1], strings[index2]);
                    }
                    ++comparisons;
                    ++index2;
                }
                index2 = 0;
            }
            Console.WriteLine($"Transposition -> {transposition}\nComparisons -> {comparisons}");
        }

        public static void SelectionSort(string[] strings, int[] sortedIndexes)
        {
            var length = strings.Length;
            ulong transposition = 0, comparisons = 0;

            for (int i = 0, j, k = 0; i < length - 1; ++i)
            {
                k = i;
                for (j = i + 1; j < length; ++j,++comparisons)
                {
                    if (sortedIndexes[k] > sortedIndexes[j])
                        k = j;
                }

                if (k == i) continue;

                ++transposition;

                (sortedIndexes[k], sortedIndexes[i]) = (sortedIndexes[i], sortedIndexes[k]);
                (strings[k], strings[i]) = (strings[i], strings[k]);
            }
            Console.WriteLine($"Transposition -> {transposition}\nComparisons -> {comparisons}");
        }

        public static void InsertSort(string[] strings, int[] sortedIndexes)
        {
            var length = strings.Length;
            ulong transposition = 0, comparisons = 0;

            for (int index = 1, index2; index < length; index++)
            {
                var tmpInt = sortedIndexes[index];
                var tmpStr = strings[index];
                for (index2 = index - 1; index2 >= 0;++comparisons)
                {
                    if (tmpInt < sortedIndexes[index2])
                    {
                        ++transposition;
                        sortedIndexes[index2 + 1] = sortedIndexes[index2];
                        strings[index2 + 1] = strings[index2];
                        index2--;
                        sortedIndexes[index2 + 1] = tmpInt;
                        strings[index2 + 1] = tmpStr;
                    }
                    else
                        break;
                }
            }
            Console.WriteLine($"Transposition -> {transposition}\nComparisons -> {comparisons}");
        }

        public static void ShellSorting(string[] strings, int[] sortedIndexes)
        {
            ulong transposition = 0, comparisons = 0;
            var length = strings.Length;
            for (var step = length / 2; step > 0; step /= 2)
            {
                for (var i = step; i < length; i++)
                {
                    for (var j = i - step; j >= 0 && sortedIndexes[j] > sortedIndexes[j + step]; j -= step, ++comparisons)
                    {
                        ++transposition;
                        (sortedIndexes[j], sortedIndexes[j + step]) = (sortedIndexes[j + step], sortedIndexes[j]);

                        (strings[j], strings[j + step]) = (strings[j + step], strings[j]);
                    }
                }
            }
            Console.WriteLine($"Transposition -> {transposition}\nComparisons -> {comparisons}");
        }
    }
}