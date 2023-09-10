using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section05
{
    public class Program
    {
        static void Main(string[] args)
        {
            // for loop
            for(int counter0 = 0; counter0 < 5; counter0++)
            {
                Console.WriteLine(counter0);
            }
            Console.WriteLine("\n");

            // do while loop
            int counter1 = 0;
            do
            {
                Console.WriteLine(counter1);
                counter1++;
            } 
            while (counter1 < 5);
            Console.WriteLine("\n");

            // while loop 
            int counter2 = 0;
            while (counter2 < 5)
            {
                Console.WriteLine(counter2);
                counter2++;
            }
            Console.WriteLine("\n");

            // The do while loop executes the statement first and then checks the condition
            // The while loop checkes the condition first and then executes the statement 

            // break
            for (int counter3 = 0; counter3 < 5; counter3++)
            {
                Console.WriteLine(counter3);
                if (counter3 == 3)
                {
                    Console.WriteLine("At 3 we stop because of our break statement!");
                    break;
                }
            }
            Console.WriteLine("\n");

            // continue
            for (int counter3 = 0; counter3 < 5; counter3++)
            {
                if (counter3 == 3)
                {
                    Console.WriteLine("We skip 3 and go to the next iteration because of our continue statement!");
                    continue;
                }
                Console.WriteLine(counter3);
            }

            // Get the average scores of students where the scores can be 0 to 20.
            // If the user inputs -1, stop and return the average scores.  
            int scoreInt = 0;
            int totalScores = 0;
            int totalSumOfScores = 0;
            while (scoreInt != -1)
            {
                Console.WriteLine("What was the student score?  Type -1 to break");
                string? scoreString = Console.ReadLine();
                bool isInt = int.TryParse(scoreString, out scoreInt);   // Convert string to int.  
                if (isInt == true)      // If the user passed in an integer, we proceed:
                {
                    if (scoreInt == -1)
                    {
                        break;
                    }
                    else if (scoreInt > 0 && scoreInt < 20)
                    {
                        totalScores++;
                        totalSumOfScores += scoreInt;
                    }
                    else
                    {
                        Console.WriteLine("Enter a valid number that is 0 to 20");
                    }
                }
                else
                {
                    Console.WriteLine("Enter a valid number that is 0 to 20");
                }
            }
            if (totalScores > 0)    // Handle cases where user immediately enters -1 and so we don't want to divide by 0. 
            {
                Console.WriteLine("The average is " + totalSumOfScores / totalScores);
            }
        }
    }
}
