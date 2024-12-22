namespace Section11
{
    // ---------------------------------- Interfaces ----------------------------------
    /* Interface - An interface is like a blueprint
     * that defines methods and properties a class must
     * have, but it doesn't provide the actual code for
     * them.  It's used to ensure different classes follow
     * the same rules.  
     * 
     * Why use an interface?
     * 1) Abstraction - Defines what methods a class should
     *    implement without specifying how.
     * 2) Polymorphism - Allows different classes to be treated
     *    as instances of the interface type.  
     * 3) Decoupling - Reduces dependencies between classes,
     *    making the code more modular and easier to maintain.
     * 4) Reusability - Ensure that different classes can use
     *    common methods, enhancing code reusability.  
     * 5) Testability - Facilitates unit testing by allowing
     *    mock implementations of interfaces.  
    */
    public interface IAnimal // Start with a capital "I"
    {
        void MakeSound();
        void Eat(string food);
    }

    public class Dog : IAnimal
    {
        public void MakeSound()
        {
            Console.WriteLine("Bark");
        }
        public void Eat(string food)
        {
            Console.WriteLine($"Dog ate {food}");
        }
    }

    public class Cat : IAnimal
    {
        public void MakeSound()
        {
            Console.WriteLine("Meow");
        }
        public void Eat(string food)
        {
            Console.WriteLine($"Cat ate {food}");
        }
    }
    // By convention, interfaces should be in their own separate files.
    public interface IPaymentProcessor

    {
        void ProcessPayment(decimal amount);
    }

    public class CreditCardProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing credit card purchase for {amount}");
            // Implement credit card payment logic.
        }
    }

    public class PaypalProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing paypal purchase for: {amount}");
            // Implement paypal payment logic.
        }
    }

    public class PaymentService
    {
        private readonly IPaymentProcessor _processor;
        public PaymentService(IPaymentProcessor processor)
        {
            _processor = processor;
        }

        public void ProcessorOrderPayment (decimal amount)
        {
            _processor.ProcessPayment(amount);
        }
    }

    // ---------------------------------- Polymorphism ----------------------------------
    /* Polymorphism - The ability in programming where a single
     * interface or method can operate in multiple ways based on
     * the object it interacts with.
     *
     * Why polymorphism?
     * 1) One interface, many implementations
     * 2) Code maintenance
     * 3) Flexibility 
     */

    public class Restaurant
    {
        public virtual void MakeFood()
        {
            Console.WriteLine("Some food is being cooked.");
        }
    }
    public class PizzaShop : Restaurant
    {
        public override void MakeFood()
        {
            Console.WriteLine("Some pizza is being cooked.");
        }
    }
    public class RamenShop: Restaurant
    {
        public override void MakeFood()
        {
            Console.WriteLine("Some ramen is being cooked.");
        }
    }

    // ---------------------------------- Decoupling ----------------------------------
    /* Decoupling - When two parts of a program work together, but don't 
     * depend on each other directly.
     */
    public interface ILogger
    {
        void Log(string message);
    }

    public class FileLogger: ILogger
    {
        public void Log(string message)
        {
            // Storing a log text file on your local pc
            try
            {
                // The "@" (string literal) makes the string be taken literally so that you don't need escape characters
                File.AppendAllText(@"C:\Users\Laptop\Desktop\Coding\CSharp\Section11\log.txt", message + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
    public class DatabaseLogger : ILogger
    {
        public void Log(string message)
        {
            // Iplement the logic to log a message to a database
            Console.WriteLine($"Logging to database. {message}");
        }
    }
    public class Application
    {
        private readonly ILogger _logger;
        public Application(ILogger logger)
        {
            _logger = logger;
        }

        public void DoWork()
        {
            _logger.Log("Work started");
            // Do all the work
            _logger.Log("Work done");
        }
    }

    // ---------------------------------- Dependencies with a Dependency Injection ----------------------------------
    /* Dependency Injection - Dependencies are provided through a class constructor, ensuring
     * that the class receives all its dependencies at the time of instantiation. 
     */
    public class Hammer
    {
        public void Use()
        {
            Console.WriteLine("Hammering Nails!");
        }
    }
    public class Saw
    {
        public void Use()
        {
            Console.WriteLine("Sawing wood");
        }
    }
    public class Builder
    {
        // Dependencies
        private Hammer _hammer;
        private Saw _saw;
        public Builder(Hammer hammer, Saw saw)  // The builder class does a Dependency Injection of Hammer and Saw
        {
            // The builder is responsible for bringing their own hammer
            _hammer = hammer;
            _saw = saw;
        }

        public void BuildHouse()
        {
            _hammer.Use();
            _saw.Use();
            Console.WriteLine("House built");
        }
    }

    // ---------------------------------- Dependencies with a Setter Injection ----------------------------------
    /* Setter Injection - Dependencies are assigned to public setter methods, allowing for the
     * injection of dependencies after the object is created.  
     */
    public class Screwdriver
    {
        public void Use()
        {
            Console.WriteLine("Screwing Nails!");
        }
    }
    public class Glue
    {
        public void Use()
        {
            Console.WriteLine("Glueing wood");
        }
    }
    public class Woodworker
    {
        // Dependencies
        public Screwdriver Screwdriver { get; set; }
        public Glue Glue { get; set; }
        
        // Setter Injection
        public void BuildProject()
        {
            Screwdriver.Use();
            Glue.Use();
            Console.WriteLine("Wood working complete");
        }
    }

    // ---------------------------------- Dependencies with an Interface Dependency Injection ----------------------------------
    public interface IToolUser
    {
        void SetPaintballGun(PaintballGun paintballGun);
    }
    
    public class PaintballGun
    {
        public void Use()
        {
            Console.WriteLine("Shooting paintballs!");
        }
    }

    public class Player: IToolUser
    {
        // Dependencies
        private PaintballGun _paintballGun;

        // Setter Injection
        public void PlayPaintball()
        {
            _paintballGun.Use();
            Console.WriteLine("Game complete!");
        }
        public void SetPaintballGun(PaintballGun paintballGun)
        {
            _paintballGun = paintballGun;
        }

    }

    // ---------------------------------- Multiple Inheritance ----------------------------------
    public interface IPrintable
    {
        void Print();
    }

    public interface IScannable
    {
        void Scan();
    }
    public class MultiFunctionPrinter: IPrintable, IScannable
    {
        public void Print()
        {
            Console.WriteLine("Printing document");
        }
        public void Scan()
        {
            Console.WriteLine("Scanning document");
        }
    }

    // ---------------------------------- Program ----------------------------------
    internal class Program
    {
        static void Main(string[] args)
        {
            // ---------------------------------- Interfaces ----------------------------------
            Dog dog = new Dog();
            dog.MakeSound();
            dog.Eat("slice of pizza");

            Cat cat = new Cat();
            cat.MakeSound();
            cat.Eat("fish");

            // ---------------------------------- Polymorphism ----------------------------------
            Restaurant restaurant = new Restaurant();
            restaurant.MakeFood();

            PizzaShop iLoveNYPizza = new PizzaShop();
            iLoveNYPizza.MakeFood();

            RamenShop IppudoRamen = new RamenShop();
            IppudoRamen.MakeFood();

            // ---------------------------------- Interfaces and Polymorphism ----------------------------------
            /* Interfacess are like rules for what methods and properties of a class
             * must do.  Polymorphism is about letting different methods and properties
             * of a class do different things. 
             */
            IPaymentProcessor creditCardProcessor = new CreditCardProcessor();
            PaymentService paymentService = new PaymentService(creditCardProcessor);
            paymentService.ProcessorOrderPayment(100.00m);

            IPaymentProcessor payPalProcessor = new PaypalProcessor();
            paymentService = new PaymentService(payPalProcessor);
            paymentService.ProcessorOrderPayment(200.0m);

            // ---------------------------------- Decoupling ----------------------------------
            /* Decoupling - The Application class depends on the ILogger interface
             * rather than specific implementations like FileLogger or DatabaseLogger.  
             */
            ILogger fileLogger = new FileLogger();
            Application fl_app = new Application(fileLogger);
            fl_app.DoWork();

            ILogger databaseLogger = new DatabaseLogger();
            Application db_app = new Application(databaseLogger);
            db_app.DoWork();

            // ---------------------------------- Dependencies with a Dependency Injection ----------------------------------
            Hammer hammer = new Hammer();
            Saw saw = new Saw();
            Builder builder = new Builder(hammer, saw);
            builder.BuildHouse();

            // ---------------------------------- Dependencies with a Setter Injection ----------------------------------
            Woodworker woodworker = new Woodworker();
            Screwdriver screwdriver = new Screwdriver();
            Glue glue = new Glue();
            woodworker.Screwdriver = screwdriver;
            woodworker.Glue = glue;
            woodworker.BuildProject();

            // ---------------------------------- Dependencies with an Interface Dependency Injection ----------------------------------
            Player player = new Player();
            PaintballGun paintballGun = new PaintballGun();
            player.SetPaintballGun(paintballGun);
            player.PlayPaintball();

            // ---------------------------------- Multiple Inheritance ----------------------------------
            MultiFunctionPrinter printer = new MultiFunctionPrinter();
            printer.Print();
            printer.Scan();


            Console.ReadKey();
        }
    }


}
