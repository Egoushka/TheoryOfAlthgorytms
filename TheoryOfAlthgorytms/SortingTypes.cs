using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoryOfAlgorytms
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

            bool isWord;
            for (var index = 0; index < length; ++index)
            {
                isWord = false;
                for (int index2 = 0, lengthCurWord = strings[index].Length; index2 < lengthCurWord; ++index2)
                {
                    if (strings[index][index2] == ' ' && isWord)
                    {
                        ++sortedStringsByCount[index];
                        isWord = false;
                    }
                    if (!isWord && char.IsLetterOrDigit(strings[index][index2]))
                    {
                        isWord = true;
                    }
                }
                if (isWord)
                    ++sortedStringsByCount[index];
            }

            return sortedStringsByCount;
        }

        public static int[] CountByPunctSings(string[] strings)
        {
            var length = strings.Length;
            var sortedStringsByCount = new int[length];

            var sings = ",.:-;";
            var singsCount = sings.Length;
            for (var index = 0; index < length; ++index)
            {
                for (int index2 = 0, strLength = strings[index].Length; index2 < strLength; ++index2)
                {
                    for (var singIndex = 0; singIndex < singsCount; ++singIndex)
                    {
                        if (sings[singIndex] != strings[index][index2]) continue;

                        ++sortedStringsByCount[index];
                        break;
                    }
                }
            }
            return sortedStringsByCount;
        }
        public static int[] CountByWordsDigit(string[] strings)
        {
            var length = strings.Length;
            var sortedStringsByCount = new int[length];

            for (var index = 0; index < length; ++index)
            {
                for (int index2 = 0, lengthCurWord = strings[index].Length; index2 < lengthCurWord; ++index2)
                {

                    if (!char.IsDigit(strings[index][index2]) && strings[index][index2] != ' ')
                    {

                        do
                        {
                            ++index2;
                        } while (index2 != lengthCurWord && strings[index][index2] != ' ');
                        continue;
                    }

                    if (strings[index][index2] != ' ' && index2 + 1 != lengthCurWord) continue;

                    ++sortedStringsByCount[index];
                }
            }

            return sortedStringsByCount;
        }
    }
}