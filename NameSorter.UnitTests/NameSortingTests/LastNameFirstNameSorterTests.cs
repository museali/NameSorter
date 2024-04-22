using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

/* 
 * This class tests the LastNameFirstNameSorter class,
 * which sorts names by last name and then by given names.
 */
namespace NameSorter.UnitTests
{
    [TestClass]
    public class LastNameFirstNameSorterTest
    {
        [TestMethod]
        public void LastNameFirstNameSorter_SortsNamesByLastNameAndGivenNames()
        {
            // Arrange
            var unsortedNames = new List<string>
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
            var expected = new List<string>
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

            // Act
            var sortedNames = new LastNameFirstNameSorter().Sort(unsortedNames);

            // Assert
            CollectionAssert.AreEqual(expected, sortedNames.ToList());
        }

        [TestMethod]
        public void LastNameFirstNameSorter_HandlesNamesWithDifferentNumberOfGivenNames()
        {
            // Arrange
            var unsortedNames = new List<string>
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
            var expected = new List<string>
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

            // Act
            var sortedNames = new LastNameFirstNameSorter().Sort(unsortedNames);

            // Assert
            CollectionAssert.AreEqual(expected, sortedNames.ToList());
        }

        [TestMethod]
        public void LastNameFirstNameSorter_ReturnsEmptyEnumerableForEmptyInput()
        {
            // Arrange
            var unsortedNames = new List<string>();

            // Act
            var sortedNames = new LastNameFirstNameSorter().Sort(unsortedNames);

            // Assert
            Assert.IsFalse(sortedNames.Any());
        }
    }
}
