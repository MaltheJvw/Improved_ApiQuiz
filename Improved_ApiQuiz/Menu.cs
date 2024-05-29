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
            _menuitems = new string[] { "Option1", "Option2", "Option3" };
            _selectedIndex = 0;
        }

        public Menu(string[] menuitems, int selectedIndex)
        {
            _menuitems = menuitems;
            _selectedIndex = selectedIndex;
        }
        
        public int SelectedIndex {  get { return _selectedIndex; } }
           
        public string[] Menuitems { get { return _menuitems; } }

        public void SetMenuItems(string[] menuItems)
        {
            _menuitems = menuItems;
            _selectedIndex = 1; 
        }


        public string DisplayMenu()
        {
            Console.Clear();
            

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

            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;

                int previousIndex = _selectedIndex;

                if (key == ConsoleKey.UpArrow)
                {
                    _selectedIndex = (_selectedIndex == 1) ? _menuitems.Length - 1 : _selectedIndex - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    _selectedIndex = (_selectedIndex == _menuitems.Length - 1) ? 1 : _selectedIndex + 1;
                }

                if (_selectedIndex != previousIndex)
                {

                    Console.SetCursorPosition(0, previousIndex);
                    Console.Write("   " + _menuitems[previousIndex]);


                    Console.SetCursorPosition(0, _selectedIndex);
                    Console.Write("-> " + _menuitems[_selectedIndex]);
                }

            } while (key != ConsoleKey.Enter);

            return _menuitems[_selectedIndex];
        }
    }
}
