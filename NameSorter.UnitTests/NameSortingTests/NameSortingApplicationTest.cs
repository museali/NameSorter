using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
/*
 * This class tests the NameSortingApplication class,
 * which handles the sorting of names from an input file.
 */
namespace NameSorter.UnitTests
{
    [TestClass]
    public class NameSortingApplicationTest
    {
        private string testInputFilePath;
        private string testOutputFilePath;

        [TestInitialize]
        public void Initialize()
        {
            // Set up the test input file
            testInputFilePath = "test-input.txt";
            string[] testNames = new string[]
            {
                "Janet Parsons",
                "Vaugh Lewis",
                "Adonis Julius Archer",
                "Shelby Nathan Yoder",
                "Marin Alvarez",
                "London Lindsey",
                "Beau Tristan Bentley",
                "Leo Gardner",
                "Hunter Uriah Mathew Clarke",
                "Mikayla Lopez",
                "Frankie Conner Ritter"
            };
            File.WriteAllLines(testInputFilePath, testNames);

            // Set up the test output file
            testOutputFilePath = "test-output.txt";
        }

        [TestMethod]
        public void NameSortingApplication_ExecutesSuccessfully()
        {
            // Arrange
            var application = new NameSortingApplication(testInputFilePath, testOutputFilePath);

            // Act
            application.Run();

            // Assert
            Assert.IsTrue(File.Exists(testOutputFilePath));
        }

        [TestMethod]
        public void NameSortingApplication_HandlesNonExistentInputFileCorrectly()
        {
            // Arrange
            var nonExistentFilePath = "non-existent-file.txt";
            var expectedMessage = $"Input file '{nonExistentFilePath}' does not exist.";
            var application = new NameSortingApplication(nonExistentFilePath, testOutputFilePath);
            string consoleOutput;

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                application.Run();
                consoleOutput = sw.ToString().Trim(); // Trim to remove any leading/trailing whitespace
            }

            // Assert
            Assert.AreEqual(expectedMessage, consoleOutput);
        }


        [TestCleanup]
        public void Cleanup()
        {
            // Clean up the test input file
            File.Delete(testInputFilePath);

            // Clean up the test output file if it exists
            if (File.Exists(testOutputFilePath))
            {
                File.Delete(testOutputFilePath);
            }
        }
    }
}
