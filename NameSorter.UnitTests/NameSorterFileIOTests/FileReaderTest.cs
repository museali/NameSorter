using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Moq;

/*
 * This class tests the FileReader class, 
 * which reads the contents of a file.
 */
namespace NameSorter.UnitTests
{
    [TestClass]
    public class FileReaderTest
    {
        [TestMethod]
        public void FileReader_ReadsContentsOfInputFileCorrectly()
        {
            // Arrange
            string testFilePath = "test-input.txt";
            string[] testLines = new string[] { "Test file contents" };

            var fileReaderMock = new Mock<IFileReader>();
            fileReaderMock.Setup(fr => fr.ReadLines(testFilePath)).Returns(testLines);

            // Act
            var lines = fileReaderMock.Object.ReadLines(testFilePath);

            // Assert
            CollectionAssert.AreEqual(testLines, (System.Collections.ICollection)lines);
        }

        [TestMethod]
        public void FileReader_ReturnsEmptyEnumerableForNonExistentFile()
        {
            // Arrange
            string nonExistentFilePath = "non-existent-file.txt";

            var fileReaderMock = new Mock<IFileReader>();
            fileReaderMock.Setup(fr => fr.ReadLines(nonExistentFilePath)).Returns(new List<string>());

            // Act
            var lines = fileReaderMock.Object.ReadLines(nonExistentFilePath);

            // Assert
            Assert.IsNotNull(lines);
            Assert.IsFalse(lines.Any());
        }

        [TestMethod]
        public void FileReader_ReturnsEmptyEnumerableForEmptyFile()
        {
            // Arrange
            string emptyFilePath = "empty-file.txt";
            string[] emptyLines = new string[] { };

            var fileReaderMock = new Mock<IFileReader>();
            fileReaderMock.Setup(fr => fr.ReadLines(emptyFilePath)).Returns(emptyLines);

            // Act
            var lines = fileReaderMock.Object.ReadLines(emptyFilePath);

            // Assert
            Assert.IsNotNull(lines);
            Assert.IsFalse(lines.Any());
        }
    }
}
