using System;
using System.IO;

namespace TheoryOfAlgorithms
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            
            Task.Start();

            int[] ints = new[]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 5, 43, 5435, 324, 53, 53246, 536, 526, 36, 436, 236, 3426, 346, 236, 234643,
                26, 34264, 32541, 5, 3416134, 64, 3631, 4134, 431, 6, 432
            };
            foreach (var item in Sorting.MergeSort(ints, 0, ints.Length - 1))
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}