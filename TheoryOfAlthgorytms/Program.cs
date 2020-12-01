using System;
using System.Diagnostics;
using System.Linq;

namespace TheoryOfAlthgorytms
{
    internal class Program
    {
        static public void Sort(String[] strs)
        {
          
            Console.WriteLine("Which exactly do you want to sort?\n1 - sort by count of letters 'A'\n2 - sort by length\n3 - sort by counts of words\n4 - sort by number of punc signs\n5 - sort by the number of words that consist of numbers");
            Int32.TryParse(Console.ReadLine(), out int choice2);
            Console.WriteLine("Sort by descending order?(1 - yes, 2 - no)");
            if (Console.ReadLine() == "1")
                Array.Reverse(strs); 
            int[] sortedArrByIndexes = new int[strs.Length];
            switch (choice2)
            {
                case 1:
                    {
                        sortedArrByIndexes = SortingTypes.CountByLettersA(strs);
                        break;
                    }
                case 2:
                    {
                        sortedArrByIndexes = SortingTypes.CountByLength(strs);
                        break;
                    }
                case 3:
                    {
                        sortedArrByIndexes = SortingTypes.CountByWords(strs);
                        break;
                    }
                case 4:
                    {
                        sortedArrByIndexes = SortingTypes.CountByPunctSings(strs);
                        break;
                    }
                case 5:
                    {
                        sortedArrByIndexes = SortingTypes.CountByWordsDigit(strs);
                        break;
                    }
                    

                default:
                    break;
            }
            Stopwatch stopWatch = new Stopwatch();


            TimeSpan elapsedTime;

            String[] tmp = (string[])strs.Clone();
            int[] tmpInts = (int[])sortedArrByIndexes.Clone();
            Console.WriteLine("BubbleSort");
            stopWatch.Start();
            Sorting.BubbleSort(strs, sortedArrByIndexes);
            stopWatch.Stop();

            Console.WriteLine($"Time spent on sorting -> {elapsedTime = stopWatch.Elapsed}\n");
            stopWatch.Reset();

            strs = tmp.Clone() as string[];
            sortedArrByIndexes = tmpInts.Clone() as int[];

            Console.WriteLine("InsertSort");
            stopWatch.Start();
            Sorting.InsertSort(strs, sortedArrByIndexes);
            stopWatch.Stop();
            Console.WriteLine($"Time spent on sorting -> {elapsedTime = stopWatch.Elapsed}\n");
            stopWatch.Reset();

            strs = (string[])tmp.Clone();
            sortedArrByIndexes = tmpInts.Clone() as int[];


            Console.WriteLine("SelectionSort");
            stopWatch.Start();
            Sorting.SelectionSort(strs, sortedArrByIndexes);
            stopWatch.Stop();

            Console.WriteLine($"Time spent on sorting -> {elapsedTime = stopWatch.Elapsed}\n");
            stopWatch.Reset();

            strs = (string[])tmp.Clone();
            sortedArrByIndexes = tmpInts.Clone() as int[];


            Console.WriteLine("ShellSorting");
            stopWatch.Start();
            Sorting.ShellSorting(strs, sortedArrByIndexes);
            stopWatch.Stop();

            Console.WriteLine($"Time spent on sorting -> {elapsedTime}\n");
            stopWatch.Reset();
 
        }

        private static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines("1.txt");

            Sort(lines);
            Console.ReadKey();
        }
    }
}