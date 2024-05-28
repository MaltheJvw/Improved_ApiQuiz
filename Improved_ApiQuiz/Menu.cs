using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Improved_ApiQuiz
{
    internal class Menu
    {
        private string[] _menuitems;
        private int _selectedIndex;
        
        public Menu()
        {

        }

        public Menu(string[] menuitems, int selectedIndex)
        {
            _menuitems = menuitems;
            _selectedIndex = selectedIndex;
        }
        
        public int SelectedIndex {  get { return _selectedIndex; } }
           
        public string[] Menuitems { get { return _menuitems; } }

        public string GetDifficultyMenu()
        {
            string[] _menuitems = { "5", "10", "15", "20", "25", "30" };
            int _selectedIndex = 0;

            ConsoleKey key;

            Console.CursorVisible = false;

            Console.SetCursorPosition(0, 0);
            Console.Write("Difficulty: ");

            DisplayMenu(_menuitems, _selectedIndex);

            string difficulty = Menuitems[SelectedIndex];

            Console.Clear();

            return difficulty;

            return SelectedIndex.ToString();

        }

        public void DisplayMenu(string[] _menuitems, int _selectedIndex)
        {
            Console.SetCursorPosition(0, 1);
            for (int i = 0; i < _menuitems.Length; i++)
            {
                if (i == _selectedIndex)
                {
                    Console.Write("-> ");
                }
                else
                {
                    Console.Write("   ");
                }
                Console.WriteLine(_menuitems[i]);
            }
        }
        public void UpdateMenu()
        {
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                {
                    _selectedIndex = (_selectedIndex == 0) ? _menuitems.Length - 1 : _selectedIndex - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    _selectedIndex = (_selectedIndex == _menuitems.Length - 1) ? 0 : _selectedIndex + 1;
                }

                // Redraw the menu with the new selected index
                DisplayMenu(_menuitems, _selectedIndex);
            } while (key != ConsoleKey.Enter);
        }
    }
}
