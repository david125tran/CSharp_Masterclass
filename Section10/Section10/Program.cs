using System.Threading.Tasks.Dataflow;

namespace Section10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog myDog = new Dog();
            myDog.Bark();
            myDog.Eat();
            myDog.MakeSound();

            BorderCollie myDogHannah = new BorderCollie();
            myDogHannah.Eat();  
            myDogHannah.GoingNuts();

            Console.WriteLine("");
            BaseClass baseClass = new BaseClass();
            baseClass.ShowFields();

            DerivedClass derivedClass = new DerivedClass();
            derivedClass.AccessFields();
            derivedClass.ShowFields();

            Employee joe = new Employee("David Tran", 33, "502 Hudson Ave. Raleigh, NC 27615","Automation Engineer", 103);
            joe.DisplayPersonInfo();
            joe.DisplayEmployeeInfo();

            Manager carl = new Manager("Carl Black", 35, "172 Rigsbee Ave Unit B. Durham, NC 27705", "Sr. Automation Engineer", 104, 4);
            carl.DisplayManagerInfo();
            carl.BecomeOlder(4);
            carl.DisplayManagerInfo();
            Console.ReadKey();
        }
    }

    // Every class inherits from the Object() class.  When you
    // create a class, you will see other methods.  This is 
    // coming from the Object() class. 
    
    // Base Class (Parent Class or Superclass) - The class
    // whose members are inherited
    class Animal
    {
        public void Eat()
        {
            Console.WriteLine("Eating...");
        }
        public virtual void MakeSound() 
            // Virtual allows us to override the method
            // when called in child classes
        {
            Console.WriteLine("Animal making noise...");
        }
    }

    // Derived Class (Child Class or Subclass) - The class
    // inherits the members of the base class
    class Dog: Animal
    {
        public void Bark()
        {
            Console.WriteLine("Barking...");
        }
        public override void MakeSound()
        {
            // Call the parent class's MakeSound() method
            base.MakeSound();
            // Add extra implementation for MakeSound() for the 
            // Dog() child class
            Console.WriteLine("Bark, bark, bark!");
        }

    }

    class BorderCollie: Dog
    {
        public void GoingNuts()
        {
            Console.WriteLine("Border Collie going nuts...");
        }
        public override void MakeSound()
        {
            Console.WriteLine("Bark, bark, bark!");
        }
    }

    class Cat: Animal
    {
        public void Meow()
        {
            Console.WriteLine("Meowing...");
        }
        public override void MakeSound()
        {
            Console.WriteLine("Meow, meow, meow!");
        }
    }
    class BaseClass
    {
        // Access Modifiers
        public int publicField;         // Accessible anywhere in the program
        protected int protectedField;   // Accessible in the class it's declared in & in subclasses
        private int privateField;       // Accesible only within the same class
        internal int internalField;     // Accessible anywhere within the same project
    
        public void ShowFields()
        {
            Console.WriteLine($"" +
                $"Public:       {publicField}\n" +
                $"Protected:    {protectedField}\n" +
                $"Private:      {privateField}\n"
                );
        }
    }

    class DerivedClass: BaseClass
    {
        public void AccessFields()
        {
            publicField = 1;
            protectedField = 2;
            //privateField = 2;         // Doesn't work because it is private to the BaseClass
        }
    }

    /* Constructors - Special methods in a class that are called when
     * an instance of the class is created.  In the context of inheritance,
     * constructors of the base class are called before the constructors of
     * the derived class.  This ensures that the base class is properly
     * initialized before any additional initialization in the derived
     * class takes place.  
     * 
     * Consistent State - Maintains a consistent and valid state across
     * the object hierarchy.  This ensures that both the base class and the
     * derived class remain in a valid state throughout the object's
     * lifetime.  By running the base class constructor first, we ensure 
     * that any dependencies or required initial states are established. 
     * 
     * Reuse of Initialization Code - Avoids duplication of initialization
     * code by reusing the base class constructor.  This means that common
     * setup tasks needed by both the base and derived classes are handled
     * once in the base class constructor.  The derived class does not
     * need to repeat this setup, making the code cleaner and reducing errors.
     */

    public class Person
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Address {  get; private set; }

        public Person(string name, int age, string address)
        {
            Name = name;
            Age = age;
            Address = address;
            Console.WriteLine("Person (parent class) constructor called");
        }
        public void DisplayPersonInfo()
        {
            Console.WriteLine($"Hi, my name is {Name} and I'm {Age} year(s) old!" +
                $"I live at {Address}");
        }

        /// <summary>Makes our object older.</summary>
        /// <param age="years">The parameter that indiates the amount of years the object should age.</param>
        /// <returns>The new age after aging.</returns>
        public int BecomeOlder(int years)
        {
            Age = Age + years;
            return Age;
        }
    }

    /* "Sealing" a class makes it so that any child classes derived from
     * the Employee() class are prevented from overriding the classes, 
     * methods, and properties.  
     * 
     * Security: Preventing further inheritance can enhance security
     * by avoiding unintended behavior or misuse.  
     * 
     * Performance: Sealed classes can sometimes lead to performance 
     * optimizations.  The runtime doesn't need to check for method
     * overrides in derived classes, leading to slightly faster performance.
     */

    //public sealed class Employee: Person
    public class Employee : Person
    {
        public string JobTitle { get; private set; }
        public int EmployeeID { get; private set; }
        // Pass constructor parameters into the child class to be passed 
        // into the parent class
        public Employee(string name, int age, string address, string jobTitle, int employeeID) 
            : base(name, age, address) // Calling the base class constructor
        {
            JobTitle = jobTitle;
            EmployeeID = employeeID;    
            Console.WriteLine("Person (child class) constructor called");
        }
        public void DisplayEmployeeInfo()
        {
            DisplayPersonInfo(); // Call method from base class
            Console.WriteLine($"Job Title: {JobTitle}, EmployeeID: {EmployeeID}");
        }
    }
    public class Manager: Employee
    {
        public int TeamSize { get; private set; }
        public Manager(string name, 
            int age, 
            string address,
            string jobTitle, 
            int employeeID,
            int teamSize)
            : base(name, age, address, jobTitle, employeeID)
        {
            TeamSize = teamSize;    
        }
        public void DisplayManagerInfo()
        { 
            DisplayPersonInfo(); 
            Console.WriteLine($"Team Size: {TeamSize}"); 
        }
    }
}
