using System;
using System.Collections.Generic;
using System.IO;

/*
 * It provides the functionality
 * to read lines of text from a file.
 */
namespace NameSorter
{
    public class FileReader : IFileReader
    {
        public IEnumerable<string> ReadLines(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}
