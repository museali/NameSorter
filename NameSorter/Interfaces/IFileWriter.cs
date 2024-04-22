using System;
using System.Collections.Generic;

/*
 * This interface defines the contract
 * for writing lines of text to a file.
 */
namespace NameSorter
{
    public interface IFileWriter
    {
        void WriteLines(string path, IEnumerable<string> lines);
    }

}