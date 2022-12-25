using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerManagementSystem
{
    internal class BrandMenu : IMenu
    {
        public static List<Brand> brands = new List<Brand>();
        public string GetType()
        {
            return "BrandMenu";
        }
        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("========Manage Brand=======");
            Console.WriteLine("=     1. Add Brand        =");
            Console.WriteLine("=     2. Update Brand     =");
            Console.WriteLine("=     3. Delete Brand     =");
            Console.WriteLine("=     4. Search Brand     =");
            Console.WriteLine("=     5. View Brand       =");
            Console.WriteLine("=     6. Back             =");
            Console.WriteLine("===========================");
        }
        public string ChoiceMenu()
        {
            Console.Write("Please choice: ");
            int n = Convert.ToInt32(Console.ReadLine());
            string strMenu = "";
            Brand brand = new Brand();
            switch (n)
            {
                case 1:
                    brand.AddBrand(brands);
                    strMenu = this.GetType();
                    break;
                case 2:
                    brand.UpdateBrand(brands);
                    strMenu = this.GetType();
                    break;
                case 3:
                    brand.DeleteBrand(brands);
                    strMenu = this.GetType();
                    break;
                case 4:
                    brand.SearchBrand(brands);
                    strMenu = this.GetType();
                    break;
                case 5:
                    brand.ViewBrand(brands);
                    strMenu = this.GetType();
                    break;
                case 6:
                    strMenu = "Menu";
                    break;
                default:
                    strMenu = "Invalid choice";
                    break;
            }
            return strMenu;
        }
    }
}
