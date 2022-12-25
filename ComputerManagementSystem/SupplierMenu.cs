using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerManagementSystem
{
    internal class SupplierMenu : IMenu
    {
        public static List<Supplier> suppliers = new List<Supplier>();
        public string GetType()
        {
            return "SupplierMenu";
        }
        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("========Manage Supplier=======");
            Console.WriteLine("=     1. Add Supplier        =");
            Console.WriteLine("=     2. Update Supplier     =");
            Console.WriteLine("=     3. Delete Supplier     =");
            Console.WriteLine("=     4. Search Supplier     =");
            Console.WriteLine("=     5. View Supplier       =");
            Console.WriteLine("=     6. Back                =");
            Console.WriteLine("==============================");
        }
        public string ChoiceMenu()
        {
            Console.Write("Please choice: ");
            int n = Convert.ToInt32(Console.ReadLine());
            string strMenu = "";
            Supplier supplier = new Supplier();
            switch (n)
            {
                case 1:
                    supplier.AddSupplier(suppliers);
                    strMenu = this.GetType();
                    break;
                case 2:
                    supplier.UpdateSupplier(suppliers);
                    strMenu = this.GetType();
                    break;
                case 3:
                    supplier.DeleteSupplier(suppliers);
                    strMenu = this.GetType();
                    break;
                case 4:
                    supplier.SearchSupplier(suppliers);
                    strMenu = this.GetType();
                    break;
                case 5:
                    supplier.ViewSupplier(suppliers);
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
