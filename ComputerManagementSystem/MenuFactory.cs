using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerManagementSystem
{
    internal class MenuFactory
    {
        public static IMenu GetMenuFactory(string menuType)
        {
            IMenu menu = null;
            if (menuType == "Menu")
            {
                menu = new Menu();
            }
            else if (menuType == "PCMenu")
            {
                menu = new PCMenu();
            }
            else if (menuType == "LaptopMenu")
            {
                menu = new LaptopMenu();
            }
            else if (menuType == "SupplierMenu")
            {
                menu = new SupplierMenu();
            }
            else if (menuType == "BrandMenu")
            {
                menu = new BrandMenu();
            }
            return menu;
        }
    }
}
