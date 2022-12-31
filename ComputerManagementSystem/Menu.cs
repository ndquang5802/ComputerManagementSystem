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
            Console.WriteLine("=   1. Manage PC         =");
            Console.WriteLine("=   2. Manage Laptop     =");
            Console.WriteLine("=   3. Manage Brand      =");
            Console.WriteLine("=   4. Manage Supplier   =");
            Console.WriteLine("=   5. Exit              =");
            Console.WriteLine("==========================");
        }
        public string ChoiceMenu()
        {
            string strMenu = "";
            try
            {
                Console.Write("Please choice: ");
                int n = Convert.ToInt32(Console.ReadLine());

                switch (n)
                {
                    case 1:
                        strMenu = "PCMenu";
                        break;
                    case 2:
                        strMenu = "LaptopMenu";
                        break;
                    case 3:
                        strMenu = "BrandMenu";
                        break;
                    case 4:
                        strMenu = "SupplierMenu";
                        break;
                    case 5:
                        strMenu = "Close";
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        strMenu = this.GetType();
                        Console.ReadKey();
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid choice!");
                strMenu = this.GetType();
                Console.ReadKey();
            }
            return strMenu;
        }
    }
}
