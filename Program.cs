namespace QuizApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Question[] questions = new Question[]
            {
                new Question(
                    "What is the capital of Germany?",  // Question Text
                    new string[] {"Paris", "Berlin", "London", "Madrid"},  // Answers Array
                    1  // CorrectAnswerIndex
                ),

                new Question(
                    "What color do you get if you Mix blue and yellow?",
                    new string[] {"purple", "orange", "brown", "green" },
                    3
                ),

                new Question(
                    "What is the scientific name of the wolf?",
                    new string[] {"Canis lupus", "Vulpes", "Canis latrans", "Hyaenidae" },
                    0
                ),

                new Question(
                    "Who wrote 'Hamlet'?",
                    new string[] {"Goethe", "Austen", "Shakespeare", "Dickens" },
                    2
                )
            };
            
            Quiz myQuiz = new Quiz(questions);
            myQuiz.StartQuiz();

            Console.ReadLine();
        }
    }
}
