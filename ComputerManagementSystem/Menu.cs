using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerManagementSystem
{
    internal class Menu : IMenu
    {
        public string GetType()
        {
            return "Menu";
        }
        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("===========Menu===========");
            Console.WriteLine("=    1. Manage PC        =");
            Console.WriteLine("=    2. Manage Laptop    =");
            Console.WriteLine("=    3. Supplier         =");
            Console.WriteLine("=    4. Brand            =");
            Console.WriteLine("=    5. Exit             =");
            Console.WriteLine("==========================");
        }
        public string ChoiceMenu()
        {
            Console.Write("Please choice: ");
            int n = Convert.ToInt32(Console.ReadLine());
            string strMenu = "";

            switch (n)
            {
                case 1:
                    strMenu = "PCMenu";
                    break;
                case 2:
                    strMenu = "LaptopMenu";
                    break;
                case 3:
                    strMenu = "SupplierMenu";
                    break;
                case 4:
                    strMenu = "BrandMenu";
                    break;
                case 5:
                    strMenu = "Close";
                    break;
                default:
                    strMenu = "Invalid choice";
                    break;
            }
            return strMenu;
        }
    }
}
