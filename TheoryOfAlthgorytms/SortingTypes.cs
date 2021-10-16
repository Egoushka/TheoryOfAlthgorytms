using System.Linq;

namespace TheoryOfAlgorithms
{
    internal static class SortingTypes
    {
        public static int[] CountByLettersA(string[] strings) =>
            strings.Select(item => item.Count(character => character.Equals(SortingTypesConstants.SymbolToFindInSortingType))).ToArray();
        public static int[] CountByLength(string[] strings) => 
            strings.Select(item => item.Length).ToArray();
        public static int[] CountByWords(string[] strings) => 
            strings.Select(item => item.Split(SortingTypesConstants.Separators).Length).ToArray();
        public static int[] CountByDottedSigns(string[] strings) =>
            strings.Select(item => item.Count(character => SortingTypesConstants.Separators.Any(character.Equals))).ToArray();
        public static int[] CountByWordsDigit(string[] strings) => 
            strings.Select(item=>item.Split(SortingTypesConstants.Separators).Count(str => str.All(char.IsDigit))).ToArray();
    }
}