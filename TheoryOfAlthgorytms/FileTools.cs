using System.IO;

namespace TheoryOfAlgorithms
{
    static class FileTools
    {
        public static string[] ReadInfoFromFile(string parth)
        {
            return File.ReadAllLines(parth);
        }
    }
}
