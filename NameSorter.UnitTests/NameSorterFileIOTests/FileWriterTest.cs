using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

/*
 * This class tests the FileWriter class,
 * which is responsible for writing lines to a file.
 */
namespace NameSorter.UnitTests
{
    [TestClass]
    public class FileWriterTest
    {
        private string testFilePath;

        [TestInitialize]
        public void Initialize()
        {
            // Set up the test output file
            testFilePath = "test-output.txt";
        }

        [TestMethod]
        public void FileWriter_WritesCorrectContentToOutputFile()
        {
            // Arrange
            var linesToWrite = new List<string>
            {
                "Marin Alvarez",
                "Adonis Julius Archer",
                "Beau Tristan Bentley",
                "Hunter Uriah Mathew Clarke",
                "Leo Gardner",
                "Vaugh Lewis",
                "London Lindsey",
                "Mikayla Lopez",
                "Janet Parsons",
                "Frankie Conner Ritter",
                "Shelby Nathan Yoder"
            };
            var fileWriter = new FileWriter();

            // Act
            fileWriter.WriteLines(testFilePath, linesToWrite);

            // Assert
            CollectionAssert.AreEqual(linesToWrite, File.ReadAllLines(testFilePath));
        }

        [TestMethod]
        public void FileWriter_OverwritesExistingOutputFile()
        {
            // Arrange
            File.WriteAllText(testFilePath, "Existing content");
            var linesToWrite = new List<string> { "New line 1", "New line 2" };
            var fileWriter = new FileWriter();

            // Act
            fileWriter.WriteLines(testFilePath, linesToWrite);

            // Assert
            CollectionAssert.AreEqual(linesToWrite, File.ReadAllLines(testFilePath));
        }
    }
}
