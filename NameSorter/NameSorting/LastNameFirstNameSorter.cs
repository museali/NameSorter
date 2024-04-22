using System;
using System.Collections.Generic;
using System.Linq;

/*
 * It sorts a collection of names by splitting each name into parts
 * (assuming the last part is the last name) and 
 * then sorting first by last name and then by first names.
 */
namespace NameSorter
{
    public class LastNameFirstNameSorter : INameSorter
    {
        public IEnumerable<string> Sort(IEnumerable<string> unsortedNames)
        {
            return unsortedNames
                .OrderBy(name => name, StringComparer.OrdinalIgnoreCase) // Sort by entire name case-insensitively
                .OrderBy(name => name.Split().Last(), StringComparer.OrdinalIgnoreCase); // Then sort by last name case-insensitively
        }
    }
}