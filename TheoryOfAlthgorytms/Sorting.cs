namespace TheoryOfAlgorithms
{
    internal static class Sorting
    {
        public const int CountOfSortingMethods = 5;

        public static (ulong, ulong) BubbleSort(string[] strings, int[] sortedIndexes)
        {
            ulong transposition = 0, comparisons = 0;

            for (int index = strings.Length - 1, index2 = 0; index > 0; --index)
            {
                while (index2 < index)
                {
                    if (sortedIndexes[index2] > sortedIndexes[index2 + 1])
                    {
                        ++transposition;

                        (sortedIndexes[index2], sortedIndexes[index2 + 1]) =
                            (sortedIndexes[index2 + 1], sortedIndexes[index2]);
                        (strings[index2], strings[index2 + 1]) = (strings[index2 + 1], strings[index2]);
                    }

                    ++comparisons;
                    ++index2;
                }

                index2 = 0;
            }
            return (transposition, comparisons);
        }

        public static (ulong, ulong) SelectionSort(string[] strings, int[] sortedIndexes)
        {
            var length = strings.Length;
            ulong transposition = 0, comparisons = 0;
            for (var i = 0; i < length - 1; ++i)
            {
                var k = i;
                for (var j = i + 1; j < length; ++j, ++comparisons)
                {
                    if (sortedIndexes[k] > sortedIndexes[j])
                        k = j;
                }

                if (k == i) continue;

                ++transposition;

                (sortedIndexes[k], sortedIndexes[i]) = (sortedIndexes[i], sortedIndexes[k]);
                (strings[k], strings[i]) = (strings[i], strings[k]);
            }
            return (transposition, comparisons);
        }

        public static (ulong, ulong) InsertSort(string[] strings, int[] sortedIndexes)
        {
            var length = strings.Length;
            ulong transposition = 0, comparisons = 0;

            for (var index = 1; index < length; index++)
            {
                var tmpInt = sortedIndexes[index];
                var tmpStr = strings[index];
                for (var index2 = index - 1; index2 >= 0; ++comparisons)
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
            return (transposition, comparisons);
        }

        public static (ulong, ulong) ShellSorting(string[] strings, int[] sortedIndexes)
        {
            ulong transposition = 0, comparisons = 0;
            var length = strings.Length;
            for (var step = length / 2; step > 0; step /= 2)
            {
                for (var i = step; i < length; i++)
                {
                    for (var j = i - step;
                        j >= 0 && sortedIndexes[j] > sortedIndexes[j + step];
                        j -= step, ++comparisons)
                    {
                        ++transposition;

                        (sortedIndexes[j], sortedIndexes[j + step]) = (sortedIndexes[j + step], sortedIndexes[j]);
                        (strings[j], strings[j + step]) = (strings[j + step], strings[j]);
                    }
                }
            }

            return (transposition, comparisons);
        }
    }
}