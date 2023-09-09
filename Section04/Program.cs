using System.Security.Cryptography.X509Certificates;

namespace Section04
{
    internal class Program
    {
        static string username;
        static string password;
        static int highscore = 300;
        static string highscorePlayer = "Daniel";
        static void Main(string[] args)
        {
            Console.WriteLine("What is the temperature in Celcius?");
            string temperature = Console.ReadLine();
            int numTemp;
            int number;
            bool userEnteredANumber = int.TryParse(temperature, out number);

            // If statements and TryParse()
            if (userEnteredANumber)
            {
                numTemp = number;    
            }
            else
            {
                numTemp = 0;
                Console.WriteLine("You did not enter a correct temperature value.  The temperature was set to a default of 0");
            }

            if (numTemp < 10)
            {
                Console.WriteLine("Take the coat");
            }
            else if (numTemp == 10)
            {
                Console.WriteLine("It's 10 degrees C");
            }
            else
            {
                Console.WriteLine("It's hot outside");
            }

            bool isAdmin = false;
            bool isRegistered = true;
            string userName = "";
            Console.WriteLine("What is your username?");
            userName = Console.ReadLine();

            // For string comparison, you have to use the .Equals() method
            // For integer comparison, you have to use operators 
            if (isRegistered && userName != "" && userName.Equals("admin"))
            {
                Console.WriteLine("Hi there, registered user");
                Console.WriteLine("Hi there, " + userName);
                Console.WriteLine("Hi there, Admin!");
            }

            // Or Comparison
            if (isAdmin || isRegistered)
            {
                Console.WriteLine("You are logged in");
            }

            Register();
            Login();
            
            // Nested If Statements
            static void Register()
            {
                Console.WriteLine("\nLet's register you a new username and password");
                Console.WriteLine("Please enter your username");
                username = Console.ReadLine();
                Console.WriteLine("Please enter your password");
                password = Console.ReadLine();
                Console.WriteLine("Registration completed");
                Console.WriteLine("--------------------------------------------");
            }

            static void Login()
            {
                Console.WriteLine("\nLet's login\n");
                Console.WriteLine("Please enter your username");
                if (username == Console.ReadLine())
                {
                    Console.WriteLine("Please enter your password");
                    if (password == Console.ReadLine())
                    {
                        Console.WriteLine("Login successful");
                    }
                    else
                    {
                        Console.WriteLine("Login failed.  Wrong password.  Restart Program");
                    }
                }
                else
                {
                    Console.WriteLine("Login failed, wrong username.  Restart program.");
                }
            }

            // Switch Statements (Integers)
            Console.WriteLine("\nSwitch Statements (Integers)!\n");
            int age = 25;
            switch (age)
            {
                case 15:
                    Console.WriteLine("Too youg to party in the club!");
                    break;
                case 25:
                    Console.WriteLine("Good to go!");
                    break;
                default:
                    Console.WriteLine("The other conditions are not true!");
                    break;
            }

            // Switch Statements (Strings)
            Console.WriteLine("\nSwitch Statements (Strings)!\n");
            string name1 = "Denis";
            switch (name1)
            {
                case "Denis":
                    Console.WriteLine("Hello Denis");
                    break;
                case "Frank":
                    Console.WriteLine("Hello Frank");
                    break;
                default:
                    Console.WriteLine("Hello!");
                    break;
            }

            static void CheckHighScore(int score, string playerName)
            {
                if (score > highscore)
                {
                    highscore = score;
                    highscorePlayer = playerName;
                    Console.WriteLine("New high score is " + score);
                    Console.WriteLine("New highscore holder is " + playerName);
                }
                else
                {
                    Console.WriteLine("You did not break the high score.  It is still " + highscore + " and held by " + highscorePlayer);
                }
            }

            Console.WriteLine("\nWhat is the player's name?");
            string? playerName = Console.ReadLine();
            Console.WriteLine("What was their score?");
            string? scoreString = Console.ReadLine();
            int scoreInt;
            int.TryParse(scoreString, out scoreInt);
            CheckHighScore(scoreInt, playerName);
        
            // Ternary Operator
            int temperature1 = -5;
            string stateOfMatter;

            stateOfMatter = temperature1 < 0 ? "liquid": "solid";
            Console.WriteLine("State of matter is {0}", stateOfMatter);

            int income = 65000;
            string wealth;
            wealth = income > 90000 ? "wealthy class" : income < 60000 ? "poor class": "middle class";
            Console.WriteLine("Your social class is {0}", wealth);

            int inputTemperature = 0;
            string temperatureMessage = string.Empty;
            string inputValue = string.Empty;
            Console.WriteLine("\nWhat is the temperature?");
            inputValue = Console.ReadLine();

            bool validInteger = int.TryParse(inputValue, out inputTemperature);

            if (validInteger)
            {
                temperatureMessage = inputTemperature <= 15 ?
                "it is too cold here" :
                inputTemperature >= 16 && inputTemperature <= 28 ?
                "it is cold here" :
                inputTemperature > 28 ? 
                "it is hot here": "";
                Console.WriteLine(temperatureMessage);
            }
            else
            {
                Console.WriteLine("Not a valid temperature");
            }
        }
    }
}