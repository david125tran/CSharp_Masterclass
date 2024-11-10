using System.Diagnostics;

namespace Section09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // try, catch, finally 
            int result = 0;

            Debug.WriteLine("Main method is running");

            try
            {
                int num1 = 10;
                Console.WriteLine("Please enter a number that you want to divide 10 by.");
                string userInput = Console.ReadLine();
                result = num1 / Int32.Parse(userInput);
            }
            catch (DivideByZeroException ex)    // Catching division by zero exceptions
            {
                Console.WriteLine("Error: Don't divide by zero.");
            }
            catch (FormatException ex)          // Catching format exceptions
            {
                Console.WriteLine("Error: A number was not entered");
            }
            catch (OverflowException)           // Catching numbers being to large exceptions
            {
                Console.WriteLine("Error: A number that was too large was entered");
            }
            catch (Exception ex)                // Catching all exceptions
            {
                // Print error to console
                Console.WriteLine($"Error: {ex.ToString()}");
                // Print error to debugger
                Debug.WriteLine($"Error: {ex.ToString()}");
            }
            finally
            {
                Console.WriteLine("This always executes");
            }

            Console.WriteLine("Result: " + result);
 
            // throw
            Console.WriteLine("Enter you age:");
            GetUserAge(Console.ReadLine());
        }
        // throw
        static int GetUserAge(string input)
        {
            int age;
            if (!int.TryParse(input, out age))
            {
                throw new Exception("You didn't enter a valid age");
            }
            if (age < 0 || age > 120)
            {
                throw new Exception("Your age must be between 0 and 120.");
            }
            return age;
        }
    }
    
}
