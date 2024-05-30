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
                
                string selectedItem = DisplayQuestion(question);

                bool isCorrect = CheckAnswer(question, selectedItem);
                if (isCorrect)
                {
                    Console.WriteLine("Correct!");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Incorrect.");
                    Console.ReadKey();

                }
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
                    keyMenuItem[keyIndex] = answer.Key;
                    keyIndex++;
                }
            }
            menu.SetMenuItems(customMenuItems);
            int Choice = menu.DisplayMenu();
            string selectedItem = keyMenuItem[Choice];
            return selectedItem;
        }
        private bool CheckAnswer(Format question, string selectedItem)
        {
            if (question.correct_answers.TryGetValue($"{selectedItem}_correct", out string isCorrect))
            {
                return isCorrect == "true";
            }
            return false;
        }
    }
}
