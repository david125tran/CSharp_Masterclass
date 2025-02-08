namespace Section22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // --------------------- Part 1 ---------------------
            //Box<int> boxInt = new Box<int>();
            //boxInt.Content = 1;

            //Console.WriteLine(boxInt.Log());

            //Box<string> boxStr = new Box<string>();
            //boxStr.Content = "Hello World";
            //Console.WriteLine(boxStr.Log());

            // --------------------- Part 2 ---------------------
            //Box<string> boxStr = new Box<string>("Hello World!");
            //Console.WriteLine(boxStr.GetContent());
            //boxStr.UpdateContent("Good morning World!");
            //Console.WriteLine(boxStr.GetContent());

            //Box<int> boxInt = new Box<int>(1);

            // --------------------- Part 3 ---------------------
            //Box<int, string> box = new Box<int, string>(100, "One Hundred");
            //box.Display();

            // --------------------- Part 4 ---------------------
            //Logger logger = new Logger();
            //logger.Log<int>(10);
            //logger.Log("Hello from Logger");
            //logger.Log(new { Name = "John", Age = 30 });

            // --------------------- Part 5 ---------------------
            //Box<int> boxInt = new Box<int>();
            //Box<Book> boxBook = new Box<Book>();

            // --------------------- Part 6 ---------------------
            //Repository<Product> repository = new Repository<Product>();
            //var product = new Product();
            //repository.Add(product);

            // --------------------- Part 7 ---------------------
            //var productOne = new Product();
            //var productTwo = new Product();
            //var result = Comparer.AreEqual(productOne, productTwo);  
            //Console.WriteLine(result);

            Console.ReadKey();
        }

        // --------------------- Part 5 ---------------------
        class Book
        {

        }
        // --------------------- Part 6 ---------------------
        //class Product : IEntity
        //{
        //    public int Id { get; set; }
        //}
        // --------------------- Part 8 ---------------------
        internal interface IRepository<T>
        {
            void Add(T entity);
            void Remove(T entity);
        }
        internal class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        internal class  ProductRepository : IRepository<Product>
        {
            public void Add(Product entity)
            {

            }
            public void Remove(Product entity)
            {

            }
        }
    }
}
