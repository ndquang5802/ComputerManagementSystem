using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IMenu menu = null;
            string strMenu = "Menu";
            do
            {
                menu = MenuFactory.GetMenuFactory(strMenu);
                menu.ShowMenu();
                strMenu = menu.ChoiceMenu();
            } while (strMenu != "Close");

            Console.ReadKey();
        }
    }
}
