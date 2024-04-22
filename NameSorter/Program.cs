using System;

/*
 * It parses command-line arguments to obtain the
 * input file path and runs the NameSortingApplication.
 */
namespace NameSorter
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: name-sorter <input-file>");
                return;
            }

            string inputFile = args[0];
            string outputFile = "sorted-names-list.txt";

            try
            {
                var application = new NameSortingApplication(inputFile, outputFile);
                application.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
