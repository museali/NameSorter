using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/*
 * It handles the sorting of names by
 * using instances of INameSorter, IFileReader, and IFileWriter.
 */
namespace NameSorter
{
    public class NameSortingApplication
    {
        private readonly INameSorter _nameSorter;
        private readonly IFileReader _fileReader;
        private readonly IFileWriter _fileWriter;
        private readonly string _inputFile;
        private readonly string _outputFile;

        public NameSortingApplication(string inputFile, string outputFile)
        {
            _inputFile = inputFile;
            _outputFile = outputFile;
            _nameSorter = new NameSorter(new LastNameFirstNameSorter());
            _fileReader = new FileReader();
            _fileWriter = new FileWriter();
        }

        public void Run()
        {
            if (!System.IO.File.Exists(_inputFile))
            {
                Console.WriteLine($"Input file '{_inputFile}' does not exist.");
                return;
            }

            var unsortedNames = _fileReader.ReadLines(_inputFile);
            var sortedNames = _nameSorter.Sort(unsortedNames);

            // Format names before writing to file
            var formattedNames = FormatNames(sortedNames);

            _fileWriter.WriteLines(_outputFile, formattedNames);

            // Format names before printing to console
            var formattedNamesForConsole = FormatNames(sortedNames);
            ConsoleOutput.Print(formattedNamesForConsole);

            Console.WriteLine($"Names sorted successfully. Sorted list saved to '{_outputFile}'.");
        }

        private IEnumerable<string> FormatNames(IEnumerable<string> names)
        {
            List<string> formattedNames = new List<string>();
            foreach (var name in names)
            {
                string[] words = name.Split(' ');
                for (int i = 0; i < words.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(words[i]))
                    {
                        // Preserve the original case of the words
                        string originalWord = words[i];
                        string formattedWord = char.ToUpper(originalWord[0]) + originalWord.Substring(1).ToLower();
                        words[i] = formattedWord;
                    }
                }
                formattedNames.Add(string.Join(" ", words));
            }
            return formattedNames;
        }
    }
}