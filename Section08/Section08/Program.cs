using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Section08
{
    // By convention in C#, it is better to have a separate
    // file for each class.  
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public Employee(string name, int age, int salary)
        {
            Name = name;
            Age = age;
            Salary = salary;
        }
    }
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

            // Any method
            bool hasNumberGreaterThan20 = numbers.Any(x => x > 20);
            if (hasNumberGreaterThan20)
            {
                Console.WriteLine("There are numbers > 20 in the list");
            } else
            {
                Console.WriteLine("There are no numbers > 20 in the list");
            }

            // Initializing a list object of our class (Product) with values
            List<Product> products1 = new List<Product>
            {
                new Product { Name = "Apples", Price = 1.99},
                new Product { Name = "Bananas", Price = 2.04},
                new Product { Name = "Cherries", Price = 1.03},
                new Product { Name = "Walnuts", Price = 0.73},
            };

            // Initializing a list object of our class (Product) with out
            // values.  And then manually adding values.  
            List<Product> products2 = new List<Product>();
            products2.Add(new Product { Name = "Berries", Price = 2.99});

            // Iterating through products1
            Console.WriteLine("Available products:");
            foreach (Product product in products1)
            {
                Console.WriteLine($"Product name: {product.Name} for ${product.Price}");
            }

            // Finding where conditions are met in the list by converting
            // an ienumerable to a list.
            List<Product> cheapProducts = products1.Where(p => p.Price < 1.50).ToList();
            foreach (Product product in cheapProducts)
            {
                Console.WriteLine($"Cheap Product: {product.Name} for ${product.Price}");
            }

            // ArrayList - A legacy data type that is no longer recommended.
            // Declaring an ArrayList with a dynamic amount of values
            ArrayList myArrayList1 = new ArrayList();
            // Declaring an ArrayList with a static amount of values
            ArrayList myArrayList2 = new ArrayList(50);

            // Different functions of ArrayList
            myArrayList1.Add(25);
            myArrayList1.Add("Pizza");
            myArrayList1.Remove(25);
            int myArrayList1Count = myArrayList1.Count;
            // Delete element at specific index
            myArrayList1.RemoveAt(0);

            // Nullables
            int? age = null;
            if (age.HasValue)
            {
                Console.WriteLine($"The age has a value: {age.Value}");
            } else
            {
                Console.WriteLine($"The age does not have a value");
            }

            // Dictionaries
            Dictionary<int, string> myEmployees = new Dictionary<int, string>();
            myEmployees.Add(1, "John Doe");
            myEmployees.Add(2, "Bob Smith");
            myEmployees.Add(3, "Jane Lin");
            // Updating dictionary values
            myEmployees[1] = "Roxy Smith";
            // Accessing dictionary values
            string employee1 = myEmployees[1];
            Console.WriteLine($"Employee at index 1 is: {employee1}");
            // Removing dictionary items
            myEmployees.Remove(1);
            // Iterating through dictionary
            foreach (KeyValuePair<int, string> keyValuePair in myEmployees)
            {
                Console.WriteLine($"Employee ID: {keyValuePair.Key}, Employee: {keyValuePair.Value}");
            }
            // Gracefully adding & updating dictionaries if you aren't sure
            // if an id is already taken.
            if (myEmployees.ContainsKey(1))
            {
                myEmployees[1] = "Lexi Thompson";
            } else
            {
                myEmployees.Add(1, "Lexi Thompson");
            }

            // Using a complex object as the value of a dictionary
            Dictionary<int, Employee> employees = new Dictionary<int, Employee>();
            employees.Add(1, new Employee("David Tran", 33, 98000));
            employees.Add(2, new Employee("Hannah Tran", 23, 101000));
            employees.Add(3, new Employee("Rex Brown", 54, 46000));
            // Iterating through dictionary - Method 1
            Console.WriteLine("Method 1:");
            foreach (KeyValuePair<int , Employee> keyValuePair in employees)
            {
                Console.WriteLine($"Employee ID: {keyValuePair.Key}\n" +
                    $"Name: {keyValuePair.Value.Name}\n" +
                    $"Age: {keyValuePair.Value.Age}\n" +
                    $"Salary: {keyValuePair.Value.Salary}\n");
            }
            // Iterating through dictionary - Method 2
            Console.WriteLine("Method 2:");
            foreach (var item in employees)
            {
                Console.WriteLine($"Employee ID: {item.Key}\n" +
                    $"Name: {item.Value.Name}\n" +
                    $"Age: {item.Value.Age}\n" +
                    $"Salary: {item.Value.Salary}\n");
            }

            // Dictionaries vs. Arrays
            //
            // Dictionaries:
            //      *Key-based access
            //      *Doesn't require sequential keys
            //      *Each key must be unique
            //      *Flexibility in adding or removing entries
            //      *For large datasets, dictionaries offer better performance in lookup, add, delete operations
            //
            // Arrays:
            //      *Does require sequential keys
            //      *Keys don't have to be unique

            // Dictionaries - Alternative way to initialize a dictionary
            var codes = new Dictionary<string, string>
            {
                ["NY"] = "New York",
                ["CA"] = "California",
                ["TX"] = "Texas",
            };

            if (codes.TryGetValue("NC", out string? state)) 
            {
                Console.WriteLine(state);
            } else
            {
                Console.WriteLine($"The state code does not exist in the dictionary.");
            }
        }

        public static bool IsGreaterThanEleven(int x)
        {
            return x > 11;
        }
    }
}
