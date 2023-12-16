using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace Section07

{
    public class Project
    {
        static void Main(string[] args)
        {
            // ------------------ Arrays Declaration (Method 1) ------------------
            int[] grades = new int[5];
            grades[0] = 20;
            grades[1] = 15;
            grades[2] = 12;
            grades[3] = 9;
            grades[4] = 7;

            // ------------------ Arrays Declaration (Method 2) ------------------
            int[] gradesOfMathStudentsA = { 20, 13, 12, 4, 4 };

            // ------------------ Arrays Declaration (Method 3) ------------------
            int[] gradesOfMathStudentB = new int[] { 15, 20, 3, 17, 18, 15 };

            // ------------------ Array Access ------------------
            Console.WriteLine("The grade at index [0] is: {0}", grades[0]);
            Console.WriteLine("The length of gradesOfMathStudentsA: {0}", gradesOfMathStudentsA.Length);

            // ------------------ Arrays Mutation ------------------
            /*          
                        Console.WriteLine("What grade do you want at index [0]? ");
                        string input = Console.ReadLine();
                        grades[0] = int.Parse(input);
                        Console.WriteLine("The grade at index [0] is: {0}", grades[0]);
            */

            // ------------------ Array Traversal (For Loop) ------------------
            int[] nums = new int[10];
            for (int i = 0; i < 10; i++)
            {
                nums[i] = i;
            }
            Console.WriteLine("\nnums array (for loop):");
            for (int j = 0; j < nums.Length; j++)
            {
                Console.WriteLine("Element {0} = {1}", j, nums[j]);
            }

            // ------------------ Array Traversal (Foreach Loop) ------------------
            int counter = 0;
            Console.WriteLine("\nnums array (foreach loop):");
            foreach (int k in nums)
            {
                Console.WriteLine("Element {0} = {1}", counter, k);
                counter++;
            }

            Console.WriteLine("\nmyFriends array (foreach loop):");
            string[] myFriends = { "Bianca", "Landon", "Harley", "Joe", "Sharnika" };
            foreach (string person in myFriends)
            {
                Console.WriteLine("Hello, {0}!", person);
            }

            // ------------------ Foreach Loops vs For Loops vs While Loops ------------------
            /*          for each
             *              *Great when you need to iterate through each element & 
             *              don't need to control the iteration process 
             *              
             *          for loops 
             *              *Give you more control over the iteration process
             *              *You can change the step size
             *              *You can change the start and stop
             *    
             *          while loops
             *              *Great for when you don't know how many elements there are
            */

            // ------------------ Multi-Dimensional Arrays Declaration ------------------
            int[,] twoDimensionalArray0 = new int[,]
            {
                {1, 2, 3},      // row 0
                {4, 5, 6},      // row 1
                {7, 8, 9}       // row 2
            };

            string[,,] threeDimensionalArray = new string[,,]
            {
                {
                    {"000", "001"},
                    {"010", "011"}
                 },
                {
                    {"100", "101"},
                    {"110", "111"}
                }
            };

            string[,] twoDimensionalArray1 = new string[3, 2] { { "one", "two" }, { "three", "four" }, { "five", "six" } };

            // ------------------ Multi-Dimensional Arrays Traversal ------------------
            Console.WriteLine("\n");
            Console.WriteLine("The middle element of twoDimensionalArray0 is: {0}", twoDimensionalArray0[1, 1]);
            Console.WriteLine("Element 7 of twoDimensionalArray0 is: {0}", twoDimensionalArray0[2, 0]);
            Console.WriteLine("Element at index [1,1,0] of threeDimensionalArray is: {0}", threeDimensionalArray[1, 1, 0]);
            Console.WriteLine("\nArray Traversal w/For Loop");
            foreach (int item in twoDimensionalArray0)
            {
                Console.Write(item + " ");
            }

            // ------------------ Multi-Dimensional Arrays Traversal (With Nested For Loop) ------------------
            Console.WriteLine("\n\nArray Traversal w/Nested For Loop");
            // outer loop --> iterate through rows
            for (int i = 0; i < twoDimensionalArray0.GetLength(0); i++)
            {
                // inner loop --> iterate through columns 
                for (int j = 0; j < twoDimensionalArray0.GetLength(1); j++)
                {
                    Console.Write(twoDimensionalArray0[i, j] + " ");
                }
            }
            // twoDimensionalArray0.GetLength(0) returns the length of the rows
            // twoDimensionalArray0.GetLength(1) returns the length of the columns
            Console.WriteLine("\n");

            // ------------------ Multi-Dimensional Arrays Mutation ------------------
            twoDimensionalArray1[1, 1] = "chicken";
            foreach (string i in twoDimensionalArray1)
            {
                Console.WriteLine(i);
            }

            // ------------------ Getting Dimensions of Array ------------------
            int dimensions = twoDimensionalArray1.Rank;
            Console.WriteLine("twoDimensionalArray1 has " + dimensions + " dimensions");

            // ------------------ Jagged Array Declaration (Method 1) ------------------
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[5];
            jaggedArray[1] = new int[3];
            jaggedArray[2] = new int[2];

            jaggedArray[0] = new int[] { 2, 3, 5, 7, 11 };
            jaggedArray[1] = new int[] { 1, 2, 3 };
            jaggedArray[2] = new int[] { 13, 21 };

            // ------------------ Jagged Array Declaration (Method 2) ------------------
            int[][] jaggedArray2 = new int[][]
            {
                new int[] { 2, 3, 5, 7, 11},
                new int[] { 1, 2, 3}
            };

            Console.WriteLine("The value in the middle of the first entry is {0}", jaggedArray2[0][2]);

            for (int i = 0; i < jaggedArray2.Length; i++)
            {
                Console.WriteLine("At element {0} we have:", i);
                for (int j = 0; j < jaggedArray2[i].Length; j++)
                    Console.WriteLine(jaggedArray2[i][j]);
            };

            // ------------------ Multidimensional Arrays vs Jagged Arrays ------------------
            // *Multidimensional Arrays - Each element has the same, fixed size as other elements
            //  in that dimension.
            // *Jagged Arrays - An array of arrays, each inner array can be a different size. 

            string[][] friendsAndFamily = new string[][]
            {
                new string[]{"Michael", "Sandy"},
                new string[]{"Frank", "Claudia"},
                new string[]{"Andrew", "Michelle"}
            };


            static double GetAverage(int[] gradesArray)
            {
                int size = gradesArray.Length;
                double average;
                int sum = 0;

                for (int i = 0; i < size;i++)
                {
                    sum += gradesArray[i];
                }
                average = (double)sum / size;
                return average;
            }

            int[] studentsGrades = new int[] { 15, 13, 2, 7, 11, 5, 6, 4, 3, 2, };

            Console.WriteLine("The average student grade is: {0}", GetAverage(studentsGrades));

            int[] happiness = new int[] { 10, 9, 5, 4, 7 };

            Console.WriteLine(happiness[0]);
            static void sunIsShining(int[] array)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] +=2;
                }
            }

            sunIsShining(happiness);

            foreach (int element in happiness)
            {
                Console.WriteLine(element);
            }
            

            static void ParamsMethod(params string[] sentence)
            {
                for(int i = 0; i < sentence.Length; i++)
                {
                    Console.Write(sentence[i] + " ");
                }
            }

            // ------------------ Params ------------------
            // By using the params keyword, you can specify a method parameter that takes a 
            // variable number of arguments.  The parameter type must be a single-dimensional
            // array.  
            ParamsMethod("I", "love", "pizza", "with", "pineapples", "on", "it");

            Console.WriteLine("\n");

            static void ParamsMethod2(params object[] stuff)
            {
                foreach (object obj in stuff)
                {
                    Console.WriteLine(obj + " ");
                }
            }

            int price = 50;
            float pi = 3.14f;
            char at = '@';
            string book = "The hobbit";
            ParamsMethod2(price, pi, at, book);
            Console.WriteLine("\n");

            static int MinV2(params int[] numbers)
            {
                int min = int.MaxValue;
                foreach (int number in numbers)
                {
                    if (number < min)
                        min = number;
                }
                return min;
            }

            Console.WriteLine(MinV2(1, -21, 13, 4));
        
            // ------------------ Collections ------------------
            // Collections are classes that we can use to store a collection of objects
            // Can store many types of objects
            // Can be any size
            // We use them to store, manage, and manipulate groups of objects more efficiently
            // A collection is a class and it requires an instance of the class before adding elements to that collection
            // Two types of collections: (1) Non-Generic and (2) Generic

            // Non-Generic
            //      *Can store any type of objects
            //      *Located in:    System.Collections namespace

            // Generic
            //      *Limited to one type of object
            //      *Located in:    System.Collections.Generic namespace

            // ------------------ ArrayLists ------------------
            ArrayList myArrayList1 = new ArrayList();
            ArrayList myArrayList2 = new ArrayList(100);    // Defined amount of 100 objects

            myArrayList1.Add(25);
            myArrayList1.Add("hello");
            myArrayList1.Add(13.37);
            myArrayList1.Add(13);
            myArrayList1.Add(13);
            myArrayList1.Add(128);
            myArrayList1.Add(25.3);
            
            // Delete element with specific value from ArrayList
            myArrayList1.Remove(13);    // Only removes one of the 13s

            // Delete element at specific index
            myArrayList1.RemoveAt(0);

            double sum1 = 0;
            foreach(object obj in myArrayList1)
            {
                if (obj is int)
                {
                    sum1 += Convert.ToDouble(obj);
                } else if (obj is double)
                {
                    sum1 += (double)obj;
                } else if (obj is string)
                {
                    Console.WriteLine(obj);
                }
            }

            Console.WriteLine(sum1);
            Console.WriteLine("\n");

            // ------------------ Lists ------------------
            // A type of collection
            var numbers = new List <int> ();
            numbers.Add(1);
            numbers.Add(2);
            numbers.Clear();

            // ------------------ Hashtables ------------------
            Hashtable studentsTable = new Hashtable();
            Student stud1 = new Student(1, "Maria", 98);
            Student stud2 = new Student(2, "Jason", 76);
            Student stud3 = new Student(3, "Clara", 43);
            Student stud4 = new Student(4, "Steve", 55);

            studentsTable.Add(stud1.Id, stud1);
            studentsTable.Add(stud2.Id, stud2);
            studentsTable.Add(stud3.Id, stud3);
            studentsTable.Add(stud4.Id, stud4);

            Student storedStudent1 = (Student)studentsTable[stud1.Id];

            foreach (DictionaryEntry entry in studentsTable)
            {
                Student temp = (Student)entry.Value;
                Console.WriteLine("Student ID:{0}, Name:{1}, GPA:{2}", temp.Id, temp.Name, temp.GPA);
            }

            Console.WriteLine("\n");

            foreach (Student value in studentsTable.Values)
            {
                Console.WriteLine("Student ID:{0}, Name:{1}, GPA:{2}", value.Id, value.Name, value.GPA);
            }

            Console.WriteLine("\n");

            Hashtable studentsTable1 = new Hashtable();
            Student[] students = new Student[5];
            students[0] = new Student(1, "Denis", 88);
            students[1] = new Student(2, "Olaf", 97);
            students[2] = new Student(6, "Ragner", 12);
            students[3] = new Student(1, "Luise", 47);
            students[4] = new Student(4, "Dawn", 17);
        
            foreach (Student s in students)
            {
                if(!studentsTable1.ContainsKey(s.Id))
                {
                    studentsTable1.Add(s.Id, s);
                    Console.WriteLine("Student with ID:{0} was added!.", s.Id);
                }
                else
                {
                    Console.WriteLine("Sorry, a student with the ID already exists:{0}", s.Id);
                }
            }

            // ------------------ Dictionary ------------------
            Dictionary<int, string> myDictionary1 = new Dictionary<int, string>()
            {
                {1, "one"},
                {2, "two"},
                {3, "three"}
            };

            Employee[] employees = {
                new Employee("CEO", "Gwynn", 95, 200),
                new Employee("Manager", "Joe", 35, 25),
                new Employee("HR", "Lora", 32, 21)
            };

            Dictionary <string, Employee> employeesDirectory = new Dictionary <string, Employee>();
            foreach (Employee emp in employees)
            {
                employeesDirectory.Add(emp.Role, emp);
            }

            Employee empl = employeesDirectory["CEO"];
            Console.WriteLine("Employee Name: {0}, Role: {1}, Salary: {2}", empl.Name, empl.Role, empl.Salary);

            for (int i = 0; i < employeesDirectory.Count; i++)
            {
                KeyValuePair <string, Employee> keyValuePair = employeesDirectory.ElementAt(i);
                Employee employeeValue = keyValuePair.Value;
                Console.WriteLine("Employee Name: {0}, Role: {1}, Age: {2}, Salary: {3}", employeeValue.Name, employeeValue.Role, employeeValue.Age, employeeValue.Salary);
            }

            // Update
            string keyToUpdate = "HR";
            if (employeesDirectory.ContainsKey(keyToUpdate))
            {
                employeesDirectory[keyToUpdate] = new Employee("HR", "Eleka", 26, 18);
            } 
            else
            {
                Console.WriteLine("No employee found at this key.");
            }
            
            // Remove
            string keyToRemove = "HR";
            if (employeesDirectory.Remove(keyToRemove))
            {
                Console.WriteLine("The employee was removed");
            } 
            else
            {
                Console.WriteLine("No employee found at this key.");
            }

            // ------------------ Stacks ------------------
            // Data can be added/removed from top 
            // Data cannot be added/removed from middle
            // LIFO 

            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Console.WriteLine("The top value of the stack is: {0}", stack.Peek());  // Returns 3
            int myStackItem = stack.Pop();
            Console.WriteLine("The popped item was: {0}", myStackItem); // Returns 3

            stack.Push(3);
            stack.Push(4);
            stack.Push(5);      

            while (stack.Count > 0)
            {
                Console.WriteLine("The top value of the stack, {0}, was removed.  The current stack count is {1}", stack.Pop(), stack.Count);
            }

            int[] numbers1 = new int[] {6, 5, 4, 3, 2, 1};

            Stack<int> stack1 = new Stack<int>();
            foreach (int number in numbers1)
            {
                stack1.Push(number);
            }
            
            while (stack1.Count > 0)
            {
                int number = stack1.Pop();
                Console.WriteLine(number + " ");
            }
            Console.WriteLine("\n");
            // ------------------ Queue ------------------
            // Data can be added/removed from back
            // Data cannot be added/removed from middle
            // FIFO

            Queue<int> queue1 = new Queue<int>();
            queue1.Enqueue(1);
            queue1.Enqueue(2);
            queue1.Enqueue(3);
            Console.WriteLine(queue1.Peek());   // Returns 1
            queue1.Dequeue();   // 1
            Console.WriteLine(queue1.Peek());   // Returns 2

            queue1.Enqueue(4);
            queue1.Enqueue(5);
            queue1.Enqueue(6);

            while (queue1.Count > 0)
            {
                Console.WriteLine("The front value {0} was removed from the queue.  The current queue count is {1}", queue1.Dequeue(), queue1.Count);
            }

            static Order[] ReceiveOrdersFromBranch1()
            {
                Order[] orders = new Order[] 
                {
                    new Order(1, 5),
                    new Order(2, 4),
                    new Order(6, 10)
                };
                return orders;
            }

            static Order[] ReceiveOrdersFromBranch2()
            {
                Order[] orders = new Order[] 
                {
                    new Order(3, 5),
                    new Order(4, 4),
                    new Order(5, 10)
                };
                return orders;
            }

            Queue<Order> ordersQueue = new Queue<Order>();
            
            foreach (Order o in ReceiveOrdersFromBranch1())
            {
                ordersQueue.Enqueue(o);
            }

            foreach (Order o in ReceiveOrdersFromBranch2())
            {
                ordersQueue.Enqueue(o);
            }

            while (ordersQueue.Count > 0)
            {
                Order currentOrder = ordersQueue.Dequeue();
                currentOrder.ProcessOrder();
            }
        }
    }
    class Student
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public float GPA {get; set;}
        public Student (int id, string name, float GPA)
        {
            this.Id = id;
            this.Name = name;
            this.GPA = GPA;
        }
    }

    class Employee
    {
        public string Role {get; set;}
        public string Name {get; set;}
        public int Age {get; set;}
        public float Rate {get; set;}
        public float Salary
        {
            get
            {
                return Rate * 8 * 5 * 4 * 12;
            }
        }

        public Employee(string role, string name, int age, float rate)
        {
            this.Role = role;
            this.Name = name;
            this.Age = age;
            this.Rate = rate;
        }
    }
    class Order
    {
        public int OrderId {get; set;}
        public int OrderQuantity {get; set;}
        public Order(int id, int orderQuantity)
        {
            this.OrderId = id;
            this.OrderQuantity = orderQuantity;
        }
        
        public void ProcessOrder()
        {
            Console.WriteLine($"Order {OrderId} processed!");
        }
    }
}
