namespace Section03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // User input
            {
                string? input = Console.ReadLine();
                Console.WriteLine(input);

                // Exceptions
                // Try - Catch - Finally
                try
                {
                    Console.WriteLine(Calculate());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter the correct format next time");
                }
                catch (OverflowException) 
                {
                    Console.WriteLine("Overflow exception.  The number was too large or too short for an int32");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Argument null exception.  Please enter a number");
                }
                finally
                {
                    Console.WriteLine("An error occured");
                }
            }

            WriteSomething();
            WriteSomethingSpecific("I love pizza");
            Console.WriteLine(Add(1, 2));
            Console.WriteLine(Multiply(2, 3));
            Console.WriteLine(Divide(2, 3));
            GreetFriend("Frank");
            Console.Read();

            Console.WriteLine("\nOperators:\n");

            // Operators
            int num1 = 5;
            int num2 = 3;
            int num3;

            num3 = -num1;
            Console.WriteLine("num3 is {0}", num3); //0 is replaced by the 1st object after the comma

            bool isSunny = true;
            Console.WriteLine("Is it sunny? {0}", !isSunny);    //the exclamation returns the opposite value

            // Increment operator
            num2 = 0;
            num2++;
            Console.WriteLine("num2 is {0}", num2);             // returns 1
            Console.WriteLine("num2 is {0}", num2++);           // returns 1.  the number is affected aftwards
            Console.WriteLine("num2 is {0}", num2);             // returns 2
            Console.WriteLine("num2 is {0}", ++num2);           // returns 3.  the number is affected immediately 

            // Decrement operator
            num2--;
            Console.WriteLine("num2 is {0}", num2);             // returns 2

            // Addition operator
            int result1;
            result1 = num1 + num2;
            Console.WriteLine("result of num1 + num2 is {0}", result1);

            // Subtraction operator
            int result2;
            result2 = num1 - num2;
            Console.WriteLine("result of num1 - num2 is {0}", result2);

            // Division operator
            double result3;
            result3 = Convert.ToDouble(num1) / Convert.ToDouble(num2);
            Console.WriteLine("result of num1 / num2 is {0}", result3);

            // Multiplication operator
            int result4;
            result4 = num1 * num2;
            Console.WriteLine("result of num1 * num2 is {0}", result4);

            // Modulus operator
            int result5;
            result5 = num1 % num2;
            Console.WriteLine("result of num1 % num2 is {0}", result5);

            // Is lower condition
            bool isLower;
            isLower = num1 < num2;
            Console.WriteLine("Is num1 < num2? {0}", isLower);

            // Equal condition
            bool isEqual;
            isEqual = num1 == num2;
            Console.WriteLine("Is num1 == num2? {0}", isEqual);

            // Not equal condition
            bool isNotEqual;
            isNotEqual = num1 != num2;
            Console.WriteLine("Is num1 != num2? {0}", isNotEqual);

            // And condition
            bool isLowerAndSunny;
            isLowerAndSunny = isLower && isSunny;
            Console.WriteLine("IsLower && isSunny? {0}", isLowerAndSunny);
            
            // Or condition
            bool isLowerOrSunny;
            isLowerOrSunny = isLower || isSunny;
            Console.WriteLine("IsLower || isSunny? {0}", isLowerOrSunny);

            
        }
        
        // Writing Methods
        public static void WriteSomething()
        {
            Console.WriteLine("I am called from a method");
        }

        public static void WriteSomethingSpecific(string myText)
        {
            Console.WriteLine(myText);
        }

        public static int Add(int num1, int num2)
        {
            return num1 + num2;
        }

        public static int Multiply(int num1, int num2)
        {
            return num1 * num2;
        }

        public static double Divide(double num1, double num2)
        {
            return num1 / num2; 
        }

        public static void GreetFriend(string name)     // We make the method void because it doesn't return anything
        {
            Console.WriteLine($"Hi {name}, my friend!");
        }

        public static int Calculate()
        {
            Console.WriteLine("Please enter the first number");
            string? number1Input = Console.ReadLine();
            Console.WriteLine("Please enter the second number");
            string? number2Input = Console.ReadLine();

            // Convert string to integer
            int num1 = int.Parse(number1Input);
            int num2 = int.Parse(number2Input);

            int result = num1 + num2;
            
            return result;
        }


    }
}