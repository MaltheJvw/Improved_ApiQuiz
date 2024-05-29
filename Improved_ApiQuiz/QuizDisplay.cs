using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Improved_ApiQuiz
{
    internal class QuizDisplay
    {
        
        private Menu menu;

        
        public QuizDisplay(Menu menu) 
        {
            
            this.menu = menu;
        }

        public void StartQuiz()
        {
            

            QuizConfigurations configs = new QuizConfigurations(menu);
            string getCategory = configs.GetCategory().ToString();
            Console.Clear();
            string getLimit = configs.GetLimit().ToString();
            Console.Clear();
            string getDifficulty = configs.GetDifficulty().ToString();
            Console.Clear();
            ApiHandler handler = new ApiHandler();
            List<Format> api = handler.ConvertApi(getCategory, getLimit, getDifficulty);

            if (api.Count == 0)
            {
                Console.WriteLine("No questions found. Please try again later.");
                return;
            }

            foreach (var question in api)
            {
                DisplayQuestion(question);
                string userAnswer = DisplayQuestion(question);

                bool isCorrect = CheckAnswer(question, userAnswer);
                if (isCorrect)
                {
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine("Incorrect.");
                }

                Console.WriteLine();

            }
        }
        private string DisplayQuestion(Format question)
        {
            string[] customMenuItems = new string[question.answers.Count + 1];
            string[] keyMenuItem = new string[question.answers.Count + 1];
            int keyIndex = 1;
            int questionIndex = 0;
            customMenuItems[questionIndex] = question.question;


            foreach (var answer in question.answers)
            {
                if (!string.IsNullOrEmpty(answer.Value))
                {
                    questionIndex++;
                    customMenuItems[questionIndex] = answer.Value;
                    keyIndex++;
                    keyMenuItem[keyIndex] = answer.Key;
                }
            }
            

            menu.SetMenuItems(customMenuItems);
            string Choice = menu.DisplayMenu();

            return Choice;
            
        }
        private bool CheckAnswer(Format question, string userAnswer)
        {
            if (question.correct_answers.TryGetValue($"answer_{userAnswer}_correct", out string isCorrect))
            {
                return isCorrect == "true";
            }
            return false;
        }
    }
}
