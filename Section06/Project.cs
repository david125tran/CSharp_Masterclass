using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Section06

{
    public class Project
    {
        static void Main(string[] args)
        {
            Car myCar = new Car();
            myCar.Name = "BatMobile";           // Using the setter method to set the name (private member variable) from outside of the class
            Console.WriteLine(myCar.Name);      // Using the getter method to get the name (private member variable) from outside of the class
            myCar.MaxSpeed = 180;
            Console.WriteLine("The max speed of the " + myCar.Name + " is " + myCar.MaxSpeed);  
            myCar.Details();

            Car audi = new Car("Audi A4", 250, "blue");
            //audi.Drive();
            audi.Details();
            Car bmw = new Car("BMW M5", 350, "red");
            //bmw.Drive();
            bmw.Details();

            Console.WriteLine("Press 1 to stop the car!");
            string userInput = Console.ReadLine();
            if (userInput == "1")
            {
                audi.Stop();
            }
            else
            {
                Console.WriteLine("Car drives indefinetly!");
            }

            Members member1 = new Members();
            member1.Introducing(true);
        }
    }
}
