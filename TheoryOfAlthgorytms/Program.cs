using System;
using System.Linq;

namespace TheoryOfAlthgorytms
{
    internal class Program
    {
        static public void Sort(String[] strs)
        {
            Console.WriteLine("Which method do you want to sort?\n1 - Bubble sort\n");
            Int32.TryParse(Console.ReadLine(), out int choice);
            Console.WriteLine("Which exactly do you want to sort?\n1 - sort by count of letters 'A'\n2 - sort by length");
            Int32.TryParse(Console.ReadLine(), out int choice2);
            int[] sortedArrByIndexes;
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
                default:
                    break;
            }

            Console.WriteLine("Sort by descending order?(1 - yes, 2 - no)");
            if (Console.ReadLine() == "1")
                strs.Reverse();
        }

        private static void Main(string[] args)
        {
            String[] strs = { "GAGA aa", "BABABABA aaa a      ", "BAB" };
            Sorting.BubbleSort(strs, SortingTypes.CountByWords(strs));
        }
    }
}