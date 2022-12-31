using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerManagementSystem
{
    internal class LaptopMenu : IMenu
    {
        public static List<Laptop> laptops = new List<Laptop>();
        public string GetType()
        {
            return "LaptopMenu";
        }
        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("========Manage Laptop=======");
            Console.WriteLine("=     1. Add Laptop        =");
            Console.WriteLine("=     2. Update Laptop     =");
            Console.WriteLine("=     3. Delete Laptop     =");
            Console.WriteLine("=     4. Search Laptop     =");
            Console.WriteLine("=     5. View Laptop       =");
            Console.WriteLine("=     6. Back              =");
            Console.WriteLine("============================");
        }
        public string ChoiceMenu()
        {
            string strMenu = "";
            try
            {
                Console.Write("Please choice: ");
                int n = Convert.ToInt32(Console.ReadLine());
                Laptop laptop = new Laptop();

                switch (n)
                {
                    case 1:
                        laptop.AddLaptop(laptops);
                        strMenu = this.GetType();
                        break;
                    case 2:
                        laptop.UpdateLaptop(laptops);
                        strMenu = this.GetType();
                        break;
                    case 3:
                        laptop.DeleteLaptop(laptops);
                        strMenu = this.GetType();
                        break;
                    case 4:
                        laptop.SearchLaptop(laptops);
                        strMenu = this.GetType();
                        break;
                    case 5:
                        laptop.ViewLaptop(laptops);
                        strMenu = this.GetType();
                        break;
                    case 6:
                        strMenu = "Menu";
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
