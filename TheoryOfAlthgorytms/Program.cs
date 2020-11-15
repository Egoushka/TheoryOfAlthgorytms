using System;
using System.Linq;

namespace TheoryOfAlthgorytms
{
    internal class Program
    {
        static public void Sort(String[] strs)
        {
            Console.WriteLine("Which method do you want to sort?\n1 - Bubble sort\n2 - Insertion\n3 - Selection\n4 - Shell");
            Int32.TryParse(Console.ReadLine(), out int choice);
            Console.WriteLine("Which exactly do you want to sort?\n1 - sort by count of letters 'A'\n2 - sort by length\n3 - sort by counts of words\n4 - sort by count of punc signs");
            Int32.TryParse(Console.ReadLine(), out int choice2);
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

                default:
                    break;
            }
            switch (choice)
            {
                case 1:
                    {
                        Sorting.BubbleSort(strs, sortedArrByIndexes);
                        break;
                    }
                case 2:
                    {
                        Sorting.InsertSort(strs, sortedArrByIndexes);

                        break;
                    }
                case 3:
                    {
                        Sorting.SelectionSort(strs, sortedArrByIndexes);

                        break;
                    }
                case 4:
                    {
                        Sorting.ShellSorting(strs, sortedArrByIndexes);

                        break;
                    }

                default:
                    break;
            }
            Console.WriteLine("Sort by descending order?(1 - yes, 2 - no)");
            if (Console.ReadLine() == "1")
                Array.Reverse(strs);
        }

        private static void Main(string[] args)
        {
            String[] strs = { "GAGA,, aa", "BABABABA,,,,, aaa a :     ", "BAB " };
            Sort(strs);

            for (int index = 0, length = strs.Length; index < length; ++index)
            {
                Console.WriteLine(strs[index]);
            }
            Console.ReadKey();
        }
    }
}