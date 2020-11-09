using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheoryOfAlthgorytms
{
    internal static class SortingTypes
    {
        static public Int32[] CountByLettersA(String[] strs)
        {
            int length = strs.Length;
            Int32[] sortedStrsByCount = new Int32[length];

            for (int index = 0; index < length; ++index)
            {
                for (int index2 = 0, lenghtCurWord = strs[index].Length; index2 < lenghtCurWord; ++index2)
                {
                    if (strs[index][index2] == 'A')
                        ++sortedStrsByCount[index];
                }
            }

            return sortedStrsByCount;
        }

        static public Int32[] CountByLength(String[] strs)
        {
            int length = strs.Length;
            Int32[] sortedStrsByCount = new Int32[length];

            for (int index = 0; index < length; ++index)
            {
                sortedStrsByCount[index] = strs[index].Length;
            }

            return sortedStrsByCount;
        }

        static public Int32[] CountByWords(String[] strs)
        {
            int length = strs.Length;
            Int32[] sortedStrsByCount = new Int32[length];

            bool isWord;
            for (int index = 0; index < length; ++index)
            {
                isWord = false;
                for (int index2 = 0, lenghtCurWord = strs[index].Length; index2 < lenghtCurWord; ++index2)
                {
                    //if (((strs[index][index2] == ' ' || strs[index][index2] == ',' || strs[index][index2] == '.' || strs[index][index2] == '–') && (index2 + 1 != lenghtCurWord || strs[index][index2 + 1] != ' ')))
                    //    ++sortedStrsByCount[index];
                    if (strs[index][index2] == ' ' && isWord)
                    {
                        ++sortedStrsByCount[index];
                        isWord = false;
                    }
                    if (!isWord && Char.IsLetterOrDigit(strs[index][index2]))
                    {
                        isWord = true;
                    }
                }
                if (isWord)
                    ++sortedStrsByCount[index];
            }

            return sortedStrsByCount;
        }
    }
}