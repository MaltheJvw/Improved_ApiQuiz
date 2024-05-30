using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Improved_ApiQuiz
{
    internal class QuizConfigurations
    {
        private Menu menu;

        public QuizConfigurations(Menu menu) 
        {
            this.menu = menu;
        }

        public Menu Menu { get { return menu; } }

        public string GetDifficulty()
        {
            string[] customMenuItems = { "Difficulty: ", "Easy", "Medium", "Hard" };
            menu.SetMenuItems(customMenuItems);

            Console.CursorVisible = false;

            Console.SetCursorPosition(0, 0);
            

            int Choice = menu.DisplayMenu();
            string difficulty = customMenuItems[Choice];
            return difficulty;
        }

        public string GetLimit()
        {
            string[] customMenuItems = { "Number of questions:", "5", "10", "15", "20", "25", "30" };
            menu.SetMenuItems(customMenuItems);

            Console.CursorVisible = false;



            int Choice = menu.DisplayMenu();
            string limit = customMenuItems[Choice];

            return limit;
        }

        public string GetCategory()
        {
            string[] customMenuItems = { "Category: ", "Code", "Linux", "DevOps", "Networking", "SQL", "(f)Cloud", "Docker", "Kubernetes", "CMS" };
            menu.SetMenuItems(customMenuItems);

            Console.CursorVisible = false;

            int Choice = menu.DisplayMenu();
            string category = customMenuItems[Choice];

            return category;
        }
    }
}
