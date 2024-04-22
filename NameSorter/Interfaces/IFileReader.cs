using System;
using System.Collections.Generic;

/*
 * This interface defines the contract
 * for reading lines of text from a file.
 */
namespace NameSorter
{
    public interface IFileReader
    {
        IEnumerable<string> ReadLines(string path);
    }
}