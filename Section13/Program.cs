namespace Section13
{
    internal class Program
    {
        // --------------------------------- Delegates --------------------------------- 
        /* Delegates - A type that represents references to methods with
         * a specific parameter list and return type.  They provide a way to
         * pass methods as parameters, enabling flexible and extensible
         * code designs.  You use delegates when you need a way to encapsulate
         * a method and pass it as an argument.  
         * 
         * Delegates vs. Parameters
         * Delegates - Used to send behavior (methods) that might change dynamically
         * Parameters - Used to send data to a fixed method.
         */

        // 1. Delegate - Declaration
        public delegate void Notify(string message);
        static void ShowMessage(string message)
        {
            Console.WriteLine($"{message}");
        }
        // --------------------------------- Delegate Sorting Algorithm --------------------------------- 
        public delegate void LogHandler(string message);
        public class Logger
        {
            public void LogToConsole(string message)
            {
                Console.WriteLine("Console Log: " + message);
            }
            public void LogToFile(string message)
            {
                Console.WriteLine("File Log: " + message);
            }
        }

        // --------------------------------- Multicast Delegates ---------------------------------
        /* Multicast Delegates - A delegate that holds references to and can invoke multiple
         * methods.  
         */
        static void InvokeSafely(LogHandler logHandler, string message)
        {
            // This method handles possible null references for logHandler
            LogHandler tempLogHandler = logHandler;
            if (tempLogHandler != null)
            {
                tempLogHandler(message);
            }
        }

        static bool IsMethodInDelegate(LogHandler logHandler, LogHandler method)
        {
            if (logHandler == null)
            {
                return false;
            }

            foreach (var d in logHandler.GetInvocationList())
            {
                if (d == (Delegate)method)
                {
                    return true;
                }
            }

            return false;
        }
        // --------------------------------- Generics ---------------------------------
        /* Generics - A way to make your code flexible & reusable by allowing it to work with
         * any data type.  They are templates that you ccan fill with different types when 
         * you use them.  
         */

        public static void PrintArray<T>(T[] array)
        {
            foreach (T item in array)
            {
                Console.WriteLine(item);
            }
        }

        // --------------------------------- Delegates & Generics Combined (Age/Name Sorting Algorithm) ---------------------------------
        public delegate int Comparison<T>(T x, T y);
        public class Person
        {
            public int Age { get; set; }
            public string Name { get; set; }
        }
        public class PersonSorter
        {
            public void Sort(Person[] people, Comparison<Person> comparison)
            {
                for (int i = 0; i < people.Length - 1; i++)
                {
                    for (int j = i + 1; j < people.Length; j++)
                    {
                        if (comparison(people[i], people[j]) > 0)
                        {
                            Person temp = people[i];
                            people[i] = people[j];
                            people[j] = temp;

                        }
                    }
                }
            }
        }
        static int CompareByAge(Person x, Person y)
        {
            return x.Age.CompareTo(y.Age);
        }

        static int CompareByName(Person x, Person y)
        {
            return x.Name.CompareTo(y.Name);
        }

        // --------------------------------- Events - Publishers & Subscribers ---------------------------------
        /* Event - Let's one class tell others when something important happens.
         * It uses a special method called a delegate.  This means one part of 
         * the program can alert others without needing direct connections. 
         */

        public delegate void NotifyOfEvent(string message);
        public class EventPublisher
        {
            public event NotifyOfEvent OnNotify;
            public void RaiseEvent(string message)
            {
                OnNotify?.Invoke(message);      // Invoke the event if there are subscribers
            }
        }
        public class EventSubscriber
        {
            public void OnEventRaised(string message)
            {
                Console.WriteLine("Event received: " + message);
            }
        }

        // --------------------------------- Events - Temperature Monitor  ---------------------------------
        // Define the delegate that will be used for the event
        // public delegate void TemperatureChangeHandler(string message);


        // Define the TemperatureMonitor class which includes the event system
        public class TemperatureMonitor
        {
            // Declare the event using the delegate
            // public event TemperatureChangeHandler OnTemperatureChanged;
            public EventHandler<TemperatureChangedEventArgs> TemperatureChanged;

            // Private field to store the temperature
            private int _temperature;
            // Property to get and set the temperature
            public int Temperature
            {
                get { return _temperature; }

                set
                {
                    
                    if (_temperature != value)
                    {
                        _temperature = value;
                        // Raise event!!!
                        OnTemperatureChanged(new TemperatureChangedEventArgs(value));
                    }

                }
            }

            protected virtual void OnTemperatureChanged(TemperatureChangedEventArgs e)
            {
                // Letting every subscriber know.
                TemperatureChanged?.Invoke(this, e);
            }
        }

        // Subscriber
        public class TemperatureAlert
        {
            public void OnTemperatureChanged(object sender, TemperatureChangedEventArgs e)
            {
                Console.WriteLine($"Alert: temperature is {e.Temperature} sender is: {sender}");
            }
        }

        public class TempCoolingAlert
        {
            public void OnTemperatureChanged(object sender, TemperatureChangedEventArgs e)
            {
                Console.WriteLine($"Alert: temperature is cooling {e.Temperature} sender is: {sender}");
            }
        }
        // --------------------------------- EventArgs & EventHandler  ---------------------------------
        public class TemperatureChangedEventArgs : EventArgs
        {
            // Property holding temperature
            public int Temperature { get; }
            // Constructor
            public TemperatureChangedEventArgs(int temperature)
            {
                Temperature = temperature;
            }
        }

        static void Main(string[] args)
        {
            // --------------------------------- Delegates ---------------------------------
            // 2. Delegate - Instantiation
            Notify notifyDelegate = ShowMessage;
            //Notify notifyDelegate = new Notify(notifyDelegate);   // Old convention of instantitation

            // 3. Delegate - Invocation
            notifyDelegate("Hello Delegates.");

            // --------------------------------- Delegate Sorting Algorithm --------------------------------- 
            // Send behavior to method.
            Logger logger = new Logger();
            LogHandler logHandler = logger.LogToConsole;
            logHandler("Logging to console...");
            // Change method dynamically.
            logHandler = logger.LogToFile;
            logHandler("Logging to file...");

            // --------------------------------- Multicast Delegates ---------------------------------
            // Add a method.
            logHandler += logger.LogToConsole;
            // Invoking the multicast delegate.
            logHandler("Logging to both console and file...");

            foreach (LogHandler handler in logHandler.GetInvocationList())
            {
                try
                {
                    handler("Event occured with error handling");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception caught: " + ex.Message);
                }
            }
            // Delete a method from the multicast delegate.
            if (IsMethodInDelegate(logHandler, logger.LogToFile))
            {
                logHandler -= logger.LogToFile;
                Console.WriteLine("Log to file method removed");
            }
            else
            {
                Console.WriteLine("Log to file method not found");
            }

            if (logHandler != null)
            {
                InvokeSafely(logHandler, "After removing LogToFile");
            }

            // --------------------------------- Generics ---------------------------------
            int[] intArray = { 1, 2, 3, 4 };
            string[] stringArray = { "One", "Two", "Three", "Four" };
            PrintArray(intArray);
            PrintArray(stringArray);

            // --------------------------------- Delegates & Generics Combined (Age/Name Sorting Algorithm) ---------------------------------
            Person[] people =
            {
                new Person { Name = "Aaron", Age = 30},
                new Person { Name = "Suzy", Age = 12},
                new Person { Name = "Alex", Age = 31},
                new Person { Name = "Alicia", Age = 22},
                new Person { Name = "Moose", Age = 68},
                new Person { Name = "Hannah", Age = 58},
            };

            PersonSorter sorter = new PersonSorter();
            sorter.Sort(people, CompareByAge);

            foreach (Person person in people)
            {
                Console.WriteLine(person.Name);
            }

            // Returns:
            // Suzy
            // Alicia
            // Aaron
            // Alex
            // Hannah
            // Moose

            sorter.Sort(people, CompareByName);
            foreach (Person person in people)
            {
                Console.WriteLine(person.Name);
            }
            // Returns:
            // Aaron
            // Alex
            // Alicia
            // Hannah
            // Moose
            // Suzy

            // --------------------------------- Events - Publishers & Subscribers ---------------------------------
            EventPublisher publisher = new EventPublisher();
            EventSubscriber subscriber = new EventSubscriber();
            publisher.OnNotify += subscriber.OnEventRaised;
            publisher.RaiseEvent("Test");

            // --------------------------------- Events - Temperature Monitor  ---------------------------------
            TemperatureMonitor monitor = new TemperatureMonitor();
            TemperatureAlert alert = new TemperatureAlert();
            TempCoolingAlert tempCoolingAlert = new TempCoolingAlert();

            monitor.TemperatureChanged += alert.OnTemperatureChanged;
            monitor.TemperatureChanged += tempCoolingAlert.OnTemperatureChanged;
            monitor.Temperature = 20;

            while (true)
            {
                Console.WriteLine("Enter a temperature, or type '999' to exit");
                int userInput = int.Parse(Console.ReadLine());
                monitor.Temperature = userInput;
                if (userInput == 999)
                {
                    break;   
                }
            }

            Console.WriteLine("Exited");

            // --------------------------------- EventArgs & EventHandler  ---------------------------------

            Console.ReadKey();

        }
    }
}
