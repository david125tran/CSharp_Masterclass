namespace Section02
{
    internal class Program
    {
        // Constants as Fields
        // Constants are immutable values which are known at compile time & do not chang for the life of the program
        const double PI = 3.1415929;
        const int weeks = 52;

        static void Main(string[] args)
        {
            // Declaring a variable
            int num1;   // We assign a default value to 0 if we don't specify a value

            // Variable reassignment
            num1 = 13;

            // Declaring an initializing a variable at the same time
            int num2 = 23;
            int sum = num1 + num2;

            // String concatenation 
            Console.WriteLine("num1: " + num1 + " + num2: " + num2 + " is: \n" + sum);

            // Multiple variable declaration
            int num3, num4, num5;

            // Doubles
            double d1 = 3.1415;
            double d2 = 5.1;
            double dDiv = d1 / d2;
            Console.WriteLine("d1/d2 is " + dDiv);

            // Floats
            float f1 = 3.1415f;
            float f2 = 5.1f;
            float fDiv = f1 / f2;
            Console.WriteLine("f1 / f2 is " + fDiv);

            // Longs
            long myLongNum = 1230819231208;
            Console.WriteLine(myLongNum);

            // Double and Integer
            double dIDiv = d1 / num1;
            Console.WriteLine(dIDiv);

            // Strings
            string myname = "David";                    // By convention, we reserve lowercase "string" for variables.  "String" refers to the String() class
            string message = "My name is " + myname;
            message = message.ToUpper();                // Convert to uppercase
            Console.WriteLine(message.ToLower());       // Print out in lowercase 

            // Single Line Comments
            // Comment(s)

            //Multiline Comments
            /*
             Comment(s)
             */

            // Console Methods
            Console.WriteLine("Prints the text and jumps the cursor to a new line");
            Console.Write("Prints the text and leaves the cursor at the end of the text");
            Console.ReadKey();  // Waits for us to enter in a key
            Console.WriteLine("\nOkay");

            Console.Write("Enter a string and press enter:");
            string input = Console.ReadLine();
            Console.WriteLine("You have entered {0}", input);   // The {0} ASCII value gives us the argument passed in at index 0, which would be our input

            // Naming Conventions
            /*
             * Class Names - PascalCase
             * Method Names - camelCase
             * Local Variables Names - camelCase
             * 
             */

            // Casting an Integer to a Long [Implicit Conversion]
            // Implicit Conversion - Converting smaller data type --> bigger data type
            int num = 123498;
            long bigNum = num;
            Console.WriteLine(bigNum);

            // Casting a Double to an Integer [Explicit Conversion]
            // Explicit Conversion - Converting bigger data type --> smaller data type
            double myDouble = 13.337;
            int myInt;
            myInt = (int) myDouble;
            Console.WriteLine(myInt);

            // Type Conversion
            string myString = myDouble.ToString();
            Console.WriteLine(myString.GetType());

            // Parsing a String to Integer
            string myString2 = "123";
            int num7 = Int32.Parse(myString2);
            Console.WriteLine(num7.GetType());

            // String Manipulation
            string name = "David";
            int age = 31;
            string job = "Scientist";
            Console.WriteLine("Hello my name is {0} & I'm {1} years old.  I'm a {2}", name, age, job);

            // String Interpolation
            Console.WriteLine($"Hello my name is {name} & I'm {age} years old.  I'm a {job}");

            // String Verbatim
            Console.WriteLine(@"Hello, \n I'm David."); // String verbatim will write the string verbatim.  For example, ignoring escape characters

            // String Escape Character: "\"
            string string3 = "This is a string with a slash, \"\" and a colon, \":\"";
            Console.WriteLine(string3);

            // The Var Keyword
            // The var keyword uses the compiler to figure out the type of the variable at the compliation time
            var number = 0;
            var string4 = "Hello.";
            var isTrue = false;
            Console.WriteLine(number);  
            Console.WriteLine(string4);
            Console.WriteLine(isTrue);

            Console.Read();





        }
    }
}