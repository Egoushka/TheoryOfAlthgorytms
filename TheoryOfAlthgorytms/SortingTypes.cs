using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoryOfAlgorithms
{
    internal static class SortingTypes
    {
        public static int[] CountByLettersA(string[] strings)
        {
            var length = strings.Length;
            var sortedStringsByCount = new int[length];

            for (var index = 0; index < length; ++index)
            {
                for (int index2 = 0, lengthCurWord = strings[index].Length; index2 < lengthCurWord; ++index2)
                {
                    if (strings[index][index2] == 'A')
                        ++sortedStringsByCount[index];
                }
            }

            return sortedStringsByCount;
        }
        public static int[] CountByLength(string[] strings)
        {
            var length = strings.Length;
            var sortedStringsByCount = new int[length];

            for (var index = 0; index < length; ++index)
            {
                sortedStringsByCount[index] = strings[index].Length;
            }

            return sortedStringsByCount;
        }

        public static int[] CountByWords(string[] strings)
        {
            var length = strings.Length;
            var sortedStringsByCount = new int[length];

            for (var index = 0; index < length; ++index)
            {
                sortedStringsByCount[index] = strings[index].Split(' ').Length;
            }

            return sortedStringsByCount;
        }

        public static int[] CountByPunctSings(string[] strings)
        {
            var length = strings.Length;
            var sortedStringsByCount = new int[length];
            var sings = new []
            {
                ',',
                '.',
                ':',
                '-',
                ';'
            };
            for (var index = 0; index < length; ++index)
            {
                sortedStringsByCount[index] = strings[index].Count(item => sings.Any(item1 => item1.Equals(item)));
            }
            return sortedStringsByCount;
        } 
        public static int[] CountByWordsDigit(string[] strings)
        {
            var length = strings.Length;
            var sortedStringsByCount = new int[length];

            for (var index = 0; index < length; ++index)
            {
               sortedStringsByCount[index] = 
                   strings[index].Split(' ').Count(item => item.All(char.IsDigit));
            }

            return sortedStringsByCount;
        }
    }
}