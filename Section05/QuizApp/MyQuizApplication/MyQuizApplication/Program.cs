namespace MyQuizApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Question[] questions = new Question[]
            {
                new Question("Which nut is used to make marzipan?", 
                new string[] {"Walnut", "Pine Nut", "Brazil Nut", "Almond"},
                3),
                new Question("What's the most stolen grocery item?",
                new string[] {"Beer", "Meat", "Cheese", "Candy" },
                2),
                new Question("Which two spices are the most popular in the world??",
                new string[] {"Pepper & Mustard", "Cardamom & Anise", "Pepper & Oregeno", "Bayleaf & Pepper"},
                0),

            };

            Quiz myQuiz = new Quiz(questions);
            myQuiz.StartQuiz();
            Console.ReadLine();
        }
    }
}
