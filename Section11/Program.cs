namespace Section11
{
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
    internal class Program
    {
        static void Main(string[] args)
        {
            // Interfaces

            Dog dog = new Dog();
            dog.MakeSound();
            dog.Eat("slice of pizza");

            Cat cat = new Cat();
            cat.MakeSound();
            cat.Eat("fish");

            // Polymorphism
            Restaurant restaurant = new Restaurant();
            restaurant.MakeFood();

            PizzaShop iLoveNYPizza = new PizzaShop();
            iLoveNYPizza.MakeFood();

            RamenShop IppudoRamen = new RamenShop();
            IppudoRamen.MakeFood();

            // Interfaces and Polymorphism
            IPaymentProcessor creditCardProcessor = new CreditCardProcessor();
            PaymentService paymentService = new PaymentService(creditCardProcessor);
            paymentService.ProcessorOrderPayment(100.00m);

            IPaymentProcessor payPalProcessor = new PaypalProcessor();
            paymentService = new PaymentService(payPalProcessor);
            paymentService.ProcessorOrderPayment(200.0m);

            Console.ReadKey();
        }
    }
}
