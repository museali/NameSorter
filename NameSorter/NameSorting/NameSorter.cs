using System;
using System.Collections.Generic;

/*
 * It acts as a wrapper around another INameSorter implementation,
 * allowing for easy swapping of sorting algorithms.
 */
namespace NameSorter
{
    public class NameSorter : INameSorter
    {
        private readonly INameSorter _nameSorter;

        public NameSorter(INameSorter nameSorter)
        {
            _nameSorter = nameSorter;
        }

        public IEnumerable<string> Sort(IEnumerable<string> unsortedNames)
        {
            return _nameSorter.Sort(unsortedNames);
        }
    }
}
