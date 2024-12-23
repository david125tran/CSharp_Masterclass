using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Section12
{
    // ------------------------------- Structs -------------------------------
    /* Structs (Short for "structures") are value types that are typically
     * used to encapsulate small groups of related variables.  
     * 
     * They are best for small data structures that have value semantics and
     * will not be modified after creation.   
     */

    /* Structs vs. Classes:
     * Structs:
     * - Are value types, which means they are stored on the stack.
     * - More efficient in terms of memory allocation and speed.  
     * - No inheritance.
     * 
     * Classes:
     * - Are stored on the heap.  
     */



    public struct Point
    {
        /* It's common practice to make structs immutable by declaring
         * all fields as readonly and providing get accessors for 
         * properties.
         */

        public double X { get; }
        public double Y { get; }

        // Here, we will go against convention
        //public int X;
        //public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public double DistanceTo(Point other)
        {
            double dx = other.X - X;
            double dy = other.Y - Y;    
            return Math.Sqrt(dx * dx + dy * dy);
        }
        public void Display()
        {
            Console.WriteLine($"Point: ({X}, {Y})");
        }
    }

    // ------------------------------- Enums -------------------------------
    enum Day { Mo, Tu, We, Th, Fr, S, Su };
    // Initialize Jan to index 1
    enum Month { Jan = 1, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec };
    internal class Program
    {

        static void Main(string[] args)
        {
            // ------------------------------- Structs -------------------------------
            Point p1 = new Point(10, 20);
            p1.Display();

            Point p2 = new Point(11, 22); 
            p2.Display();

            Point p3 = p1;
            p3.Display();

            double distance = p1.DistanceTo(p2);
            Console.WriteLine($"Distance between points:" +
                $"{distance:F2}"); // Floating point # of 2 values

            // ------------------------------- Enums -------------------------------
            Day fr = Day.Fr;
            Day su = Day.Su;

            Day a = Day.Fr;
            Console.WriteLine(fr == a);     // Returns True

            Console.WriteLine(Day.Mo);      // Returns "Mo"

            Console.WriteLine((int) Month.Jan);  // Returns 1
            Console.WriteLine((int) Month.Feb);  // Returns 2

            // ------------------------------- Datetime -------------------------------
            DateTime dateTime = DateTime.Now;
            Console.WriteLine(dateTime);
            DateTime today = DateTime.Today;
            Console.WriteLine(today);
            DateTime tomorrow = DateTime.Today.AddDays(1);
            Console.WriteLine(tomorrow);

            // ------------------------------- MathClass -------------------------------
            Console.WriteLine("Ceiling: " + Math.Ceiling(15.333));  // Returns 16

            int num1 = 13;
            int num2 = 9;

            Console.WriteLine(Math.Min(num1, num2));

            // ------------------------------- Garbage Collection -------------------------------
            
            Console.ReadKey();
        }
    }
}
