using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuizApplication
{
    internal class Quiz
    {
        private Question[] _questions;
        private int _score; 
        public Quiz(Question[] questions)
        {
            this._questions = questions;
            _score = 0;
        }
        public void StartQuiz()
        {
            Console.WriteLine("Welcome to the Quiz!");
            int questionNumber = 1; // To display question numbers
            // Iterate through each question
            foreach (Question question in _questions)
            {
                Console.WriteLine("");
                Console.WriteLine($"Question {questionNumber++}: ");
                DisplayQuestion(question);
                int userChoice = GetUserChoice();
                if (question.IsCorrectAnswer(userChoice))
                {
                    Console.WriteLine("Correct!");
                    _score ++;
                }
                else
                {
                    Console.WriteLine($"Incorrect!  The correct answer was:");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($"{question.CorrectAnswerIndex + 1}. ");
                    Console.ResetColor();
                    Console.WriteLine($"{question.Answers[question.CorrectAnswerIndex]}");
                }
            }
            DisplayResults();
        }
        private void DisplayResults()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔═════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                 Results                                 ║");
            Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();

            Console.WriteLine($"You scored: {_score} out of {_questions.Length}.");
            double percentage = (double)_score / _questions.Length;
            if (percentage > 0.8)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Excellent Work!");
                Console.ResetColor();
            }
            else if (percentage >= 0.5)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Good Work!");
                Console.ResetColor();
            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have some work to do!");
                Console.ResetColor();
            }
        }
        private void DisplayQuestion(Question question)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("╔═════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                 Question                                ║");
            Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine(question.QuestionText);
            Console.ResetColor();
            for (int i = 0; i < question.Answers.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("   ");
                Console.Write($"{i + 1}. ");
                Console.ResetColor();
                Console.WriteLine($"{question.Answers[i]}");
            }
        }
        private int GetUserChoice()
        {
            Console.Write("Your answer (number): ");
            string input = Console.ReadLine();
            int choice = 0;
            while (!int.TryParse(input, out choice) || choice < 1 || choice > 4)
            {
                Console.WriteLine("Invalid choice.  Please enter an answer that is between 1 and 4: ");
                input = Console.ReadLine();
            }

            return choice - 1;  // adjust for 0 indexed array
        }
    }
}
