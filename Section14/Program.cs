using System.IO;
using System.Text.RegularExpressions;

namespace Section14
{
    internal class Program
    {
        // ------------------------- Regex -------------------------
        static void Main(string[] args)
        {
            // Defining a regular expression with a pattern to search
            string pattern = @"i";
            Regex regex = new Regex(pattern);

            // Text to search
            //Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader("C:\\Users\\Laptop\\Desktop\\Coding\\CSharp\\Section14\\sample.txt");
            string txt_file = sr.ReadToEnd();

            string search_string = "Hi there 123";

            // Find matches
            // MatchCollection hits = regex.Matches(txt_file);
            MatchCollection hits = regex.Matches(search_string);

            // Match results
            Console.WriteLine($"{hits.Count} hits found:\n   {search_string}");

            // Amount of matches
            foreach (Match aHit in hits)
            {
                GroupCollection groups = aHit.Groups;
                Console.WriteLine("'{0}' found at {1}",
                                  groups["word"].Value,
                                  groups[0].Index
                                 );
            }
            Console.ReadLine();
        }
    }
}
