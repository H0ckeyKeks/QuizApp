using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication
{
    internal class Quiz
    {
        // When creating a quiz option, we want our questions passed to our quiz directly 
        private Question[] _questions;

        private int _score;

        public Quiz(Question[] questions)
        {
            /* The "this" keyword refers to the current instance of the class
            it is used in. It is used to acces members (properties & methods)
            of the same object */
            this._questions = questions;

            _score = 0;
        }

        public void StartQuiz()
        {
            Console.WriteLine("Welcome to the Quiz!");
            
            // Display question number
            int questionNumber = 1;

            foreach (Question question in _questions)
            {
                Console.WriteLine($"Question {questionNumber++}:");
                DisplayQuestion(question);
                int userChoice = GetUserChoice();

                if (question.IsCorrectAnswer(userChoice))
                {
                    Console.WriteLine("Correct!\n");
                    _score++;
                }
                else
                {
                    Console.WriteLine($"Incorrect! The correct answer was: {question.Answers[question.CorrectAnswerIndex]}\n");
                }
            }

            DisplayResults();
        }

        private void DisplayResults()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╔══════════════════════════════╗");
            Console.WriteLine("║           Results            ║");
            Console.WriteLine("╚══════════════════════════════╝");
            Console.ResetColor();
 

            Console.WriteLine($"Quiz finished. Your score is {_score} out of {_questions.Length}");

            double percentage = (double)_score / _questions.Length;
            if (percentage >= 0.8)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Excellent work!");
            }
            else if (percentage >= 0.5)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Good effort!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Keep practicing!");
            }
            Console.ResetColor();
        }

        private void DisplayQuestion(Question question)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("╔══════════════════════════════╗");
            Console.WriteLine("║           Question           ║");
            Console.WriteLine("╚══════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine(question.QuestionText);

            // Going through all answers and displaying them
            for (int i = 0; i < question.Answers.Length; i++)
            {
                // Changes text color
                Console.ForegroundColor = ConsoleColor.Cyan;
                // Write = Output something without line break
                Console.Write("    ");
                // Writes the enumeration and starts with 1 (0 + 1)
                Console.Write(i + 1);
                // Resetting foreground (text) color
                Console.ResetColor();

                Console.WriteLine($". {question.Answers[i]}");
            }
        }

        private int GetUserChoice()
        {
            Console.Write("Your answer (number): ");
            string input = Console.ReadLine();
            int choice = 0;

            /* As long as whatever user entered is a number
             we're going to keep going with the code after,
             otherwise we try again */
            while (!int.TryParse(input, out choice) || choice <1 || choice > 4)
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 4: ");
                input = Console.ReadLine();
            }

            // adjust to zero-indexed array (index starts with 0,
            // the numbers of the answeres start with 1)
            return choice -1;  
        }
    }
}
