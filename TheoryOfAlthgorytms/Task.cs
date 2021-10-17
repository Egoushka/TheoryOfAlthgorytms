using System;
using System.Diagnostics;

namespace TheoryOfAlgorithms
{
    internal static class Task
    {
        public static void Start()
        {
            var strings = FileTools.ReadInfoFromFile(FileConstants.FileNameWithData);

            var selectedTypeOfSort = SelectSortType();

            if (SelectOrderOfSorting()) Array.Reverse(strings);

            var sortedIndexes = selectedTypeOfSort switch
            {
                1 => SortingTypes.CountByLettersA(strings),
                2 => SortingTypes.CountByLength(strings),
                3 => SortingTypes.CountByWords(strings),
                4 => SortingTypes.CountByDottedSigns(strings),
                5 => SortingTypes.CountByWordsDigit(strings),
                _ => throw new ArgumentOutOfRangeException()
            };
            Process(strings, sortedIndexes);
        }

        private static int SelectSortType()
        {
            while (true)
            {
                Console.WriteLine("Which exactly do you want to sort?\n\n" + "1 - sort by count of letters 'A'\n" +
                                  "2 - sort by length\n" + "3 - sort by counts of words\n" +
                                  "4 - sort by number of dotted signs\n" +
                                  "5 - sort by the number of words that consist of numbers\n");
                var userInput = Console.ReadLine();

                if (int.TryParse(userInput, out var selectedTypeOfSort)) return selectedTypeOfSort;

                Console.Clear();

                Console.WriteLine("Try again");
            }
        }

        private static bool SelectOrderOfSorting()
        {
            while (true)
            {
                Console.WriteLine("Sort by descending order?(1 - yes, 2 - no)\n");
                var userInput = Console.ReadLine();

                if (int.TryParse(userInput, out var orderOfSorting) && orderOfSorting is 0 or 1)
                    return orderOfSorting == 1;
                Console.Clear();
                ;
                Console.WriteLine("Try again");
            }
        }

        private static void Process(string[] strings, int[] sortedIndexes)
        {
            var tmp = (string[]) strings.Clone();
            var tmpIntegers = (int[]) sortedIndexes.Clone();
            var stopWatch = new Stopwatch();
            for (var i = 1; i <= Sorting.CountOfSortingMethods; i++)
            {
                stopWatch.Start();
                SelectSort((string[]) tmp.Clone(), (int[]) tmpIntegers.Clone(), i);
                stopWatch.Stop();

                Console.WriteLine($"Time spent on sorting -> {stopWatch.Elapsed}\n");

                stopWatch.Reset();
            }
        }

        private static void SelectSort(string[] strings, int[] sortedIndexes, int choice)
        {
            ulong transposition = 0;
            ulong comparisons = 0;
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Bubble");
                    (transposition, comparisons) = Sorting.BubbleSort(strings, sortedIndexes);
                    break;
                case 2:
                    Console.WriteLine("Insert");
                    (transposition, comparisons) = Sorting.InsertSort(strings, sortedIndexes);
                    break;
                case 3:
                    Console.WriteLine("Selection");
                    (transposition, comparisons) = Sorting.SelectionSort(strings, sortedIndexes);
                    break;
                case 4:
                    Console.WriteLine("Shell");
                    (transposition, comparisons) = Sorting.ShellSorting(strings, sortedIndexes);
                    break;
                case 5:
                    Console.WriteLine("Merge");
                    (transposition, comparisons) = Sorting.MergeSortForStrings(ref strings, ref sortedIndexes, 0, strings.Length, ref transposition, ref comparisons);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(choice), choice, null);
            }

            Console.WriteLine($"Transposition -> {transposition}\nComparisons -> {comparisons}");
        }
    }
}
