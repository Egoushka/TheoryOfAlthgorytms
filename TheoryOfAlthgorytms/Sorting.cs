using System.Text.RegularExpressions;

namespace TheoryOfAlgorithms
{
    internal static class Sorting
    {
        public const int CountOfSortingMethods = 6;

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

        public static (ulong, ulong) MergeSortForStrings(ref string[] strings, ref int[] sortedIndexes, int lowIndex, int highIndex, ref ulong transposition, ref ulong comparisons)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                MergeSortForStrings(ref strings, ref sortedIndexes, lowIndex, middleIndex + 1, ref transposition, ref comparisons);
                MergeSortForStrings(ref strings, ref sortedIndexes, middleIndex + 1, highIndex, ref transposition, ref comparisons);

                MergeForStrings(ref strings, ref sortedIndexes, lowIndex, middleIndex, highIndex, ref transposition, ref comparisons);
            }

            return (transposition, comparisons);
        }

        private static void MergeForStrings(ref string[] strings, ref int[] sortedIndexes, int lowIndex, int middleIndex, int highIndex, ref ulong transposition, ref ulong comparisons)
        {
            var left = lowIndex;
            var right = middleIndex + 1;

            var tempArrayInts = new int[highIndex - lowIndex + 1];
            var tempArrayStrings = new string[highIndex - lowIndex + 1];

            var index = 0;

            while (left <= middleIndex && right <= highIndex)
            {
                if (sortedIndexes[left] < sortedIndexes[right])
                {
                    tempArrayInts[index] = sortedIndexes[left];
                    tempArrayStrings[index] = strings[left];
                    left++;
                }
                else
                {
                    tempArrayInts[index] = sortedIndexes[right];
                    tempArrayStrings[index] = strings[right];
                    right++;
                }

                comparisons++;
                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                tempArrayInts[index] = sortedIndexes[i];
                tempArrayStrings[index] = strings[i];
                transposition++;
                index++;
            }

            for (var i = right; i <= highIndex; i++)
            {
                tempArrayInts[index] = sortedIndexes[i];
                tempArrayStrings[index] = strings[i];
                transposition++;
                index++;
            }

            for (var i = 0; i < tempArrayInts.Length; i++)
            {
                sortedIndexes[lowIndex + i] = tempArrayInts[i];
                strings[lowIndex + i] = tempArrayStrings[i];
                transposition++;
            }
        }
        static void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new int[highIndex - lowIndex + 1];
            var index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (array[left] < array[right])
                {
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    right++;
                }

                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = right; i <= highIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                array[lowIndex + i] = tempArray[i];
            }
        }
        static int[] MergeSort(int[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                MergeSort(array, lowIndex, middleIndex);
                MergeSort(array, middleIndex + 1, highIndex);
                Merge(array, lowIndex, middleIndex, highIndex);
            }

            return array;
        }

    }
}