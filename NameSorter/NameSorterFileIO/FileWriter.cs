using System;
using System.Collections.Generic;
using System.IO;

/*
 * This class provides the functionality
 * to write lines of text to a file.
 */
namespace NameSorter
{
    public class FileWriter : IFileWriter
    {
        public void WriteLines(string path, IEnumerable<string> lines)
        {
            File.WriteAllLines(path, lines);
        }
    }
}
