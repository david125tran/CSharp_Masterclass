using System.Security.Cryptography.X509Certificates;

namespace Section08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declaring a list and initializing
            List<string> colors1 = new List<string>();
            
            // Adding items to the list one by one
            colors1.Add("red");
            colors1.Add("blue");
            colors1.Add("green");
            colors1.Add("red");
            colors1.Add("red");

            // Iterating through the list
            Console.WriteLine("Current colors in the colors list:");
            foreach (string color in colors1)
            {
                Console.WriteLine(color);
            }

            // Removing items from the list
            bool isDeletingSuccessful = colors1.Remove("red");

            while (isDeletingSuccessful)
            {
                isDeletingSuccessful = colors1.Remove("red");
            }

            // Iterating through the list
            Console.WriteLine("Current colors in the colors list:");
            foreach (string color in colors1)
            {
                Console.WriteLine(color);
            }

            // Adding multiple items to a list
            List<string> colors2 =
                [
                    "red",
                    "blue",
                    "green",
                    "red",
                ];

            colors2.Add("yellow");

            // Sorting a list
            List<int> numbers = new List<int> {10, 5, 12, 84, 1, 8};
            numbers.Sort();
            
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }

            // Find items
            List<int> higherThan10 = numbers.FindAll(x => x >= 10);

            Console.WriteLine("Numbers >= 10 in the list:");
            foreach (int number in higherThan10)
            {
                Console.WriteLine(number);
            }

            // Lambda Expressions are composed of 2 parts
            // 1. Parameters
            // 2. Expression or statement block

            // Parameters are written on the left side of =>
            // This symbol, "=>", is read as "goes to" or "becomes".
            // The expression or action to perform is on the right side.

            // This is read as:
            // "Take an input x and turn it into x multiplied by x"
            // x => x * x;

            // Define a predicate to see if a number is greater than 10
            Predicate<int> isGreaterThan10 = x => x >= 10;

            List<int> higherThanTen = numbers.FindAll(isGreaterThan10);

            Console.WriteLine("Numbers >= 10 in the list:");
            foreach (int number in higherThan10)
            {
                Console.WriteLine(number);
            }

            /*
            In C#, a delegate is like a pointer or a reference to a method.
            It allows you to pass methods as arguments to other methods, store
            them in variables, and call them later. This is useful when you want 
            your code to be flexible and able to handle different behaviors
            that aren't predetermined.            
            */

            Predicate<int> isGreaterThan11 = IsGreaterThanEleven;

            // Find items
            List<int> higherThan11 = numbers.FindAll(isGreaterThan11);
            Console.WriteLine("Numbers >= 11 in the list:");
            foreach (int number in higherThan11)
            {
                Console.WriteLine(number);
            }


        }
        public static bool IsGreaterThanEleven(int x)
        {
            return x > 11;
        }
    }
}
