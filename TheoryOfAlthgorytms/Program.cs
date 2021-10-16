using System;
using System.Diagnostics;
using System.Linq;

namespace TheoryOfAlgorithms
{
    internal class Program
    {
        public static void Sort(string[] strings)
        {
          
            Console.WriteLine("Which exactly do you want to sort?\n1 - sort by count of letters 'A'\n2 - sort by length\n3 - sort by counts of words\n4 - sort by number of punc signs\n5 - sort by the number of words that consist of numbers");
            int.TryParse(Console.ReadLine(), out var choice2);
            Console.WriteLine("Sort by descending order?(1 - yes, 2 - no)");
            if (Console.ReadLine() == "1")
                Array.Reverse(strings); 
            var sortedArrByIndexes = new int[strings.Length];
            switch (choice2)
            {
                case 1:
                    {
                        sortedArrByIndexes = SortingTypes.CountByLettersA(strings);
                        break;
                    }
                case 2:
                    {
                        sortedArrByIndexes = SortingTypes.CountByLength(strings);
                        break;
                    }
                case 3:
                    {
                        sortedArrByIndexes = SortingTypes.CountByWords(strings);
                        break;
                    }
                case 4:
                    {
                        sortedArrByIndexes = SortingTypes.CountByPunctSings(strings);
                        break;
                    }
                case 5:
                    {
                        sortedArrByIndexes = SortingTypes.CountByWordsDigit(strings);
                        break;
                    }
                    

                default:
                    break;
            }
            var stopWatch = new Stopwatch();


            TimeSpan elapsedTime;

            var tmp = (string[])strings.Clone();
            var tmpInts = (int[])sortedArrByIndexes.Clone();
            Console.WriteLine("BubbleSort");
            stopWatch.Start();
            Sorting.BubbleSort(strings, sortedArrByIndexes);
            stopWatch.Stop();

            Console.WriteLine($"Time spent on sorting -> {elapsedTime = stopWatch.Elapsed}\n");
            stopWatch.Reset();

            strings = tmp.Clone() as string[];
            sortedArrByIndexes = tmpInts.Clone() as int[];

            Console.WriteLine("InsertSort");
            stopWatch.Start();
            Sorting.InsertSort(strings, sortedArrByIndexes);
            stopWatch.Stop();
            Console.WriteLine($"Time spent on sorting -> {elapsedTime = stopWatch.Elapsed}\n");
            stopWatch.Reset();

            strings = (string[])tmp.Clone();
            sortedArrByIndexes = tmpInts.Clone() as int[];


            Console.WriteLine("SelectionSort");
            stopWatch.Start();
            Sorting.SelectionSort(strings, sortedArrByIndexes);
            stopWatch.Stop();

            Console.WriteLine($"Time spent on sorting -> {elapsedTime = stopWatch.Elapsed}\n");
            stopWatch.Reset();

            strings = (string[])tmp.Clone();
            sortedArrByIndexes = tmpInts.Clone() as int[];


            Console.WriteLine("ShellSorting");
            stopWatch.Start();
            Sorting.ShellSorting(strings, sortedArrByIndexes);
            stopWatch.Stop();

            Console.WriteLine($"Time spent on sorting -> {elapsedTime}\n");
            stopWatch.Reset();
 
        }

        private static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines("1.txt");
            Sort(lines);
            Console.ReadKey();
        }
    }
}