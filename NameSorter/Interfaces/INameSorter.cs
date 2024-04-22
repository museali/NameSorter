using System;
using System.Collections.Generic;

/*
 * This is an interface defining
 * the contract for sorting a collection of names.
 */
namespace NameSorter
{
    public interface INameSorter
    {
        IEnumerable<string> Sort(IEnumerable<string> unsortedNames);
    }
}
