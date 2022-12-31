using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerManagementSystem
{
    internal class PCMenu : IMenu
    {
        public static List<PC> pCs = new List<PC>();
        public string GetType()
        {
            return "PCMenu";
        }
        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("==========Manage PC=========");
            Console.WriteLine("=       1. Add PC          =");
            Console.WriteLine("=       2. Update PC       =");
            Console.WriteLine("=       3. Delete PC       =");
            Console.WriteLine("=       4. Search PC       =");
            Console.WriteLine("=       5. View PC         =");
            Console.WriteLine("=       6. Back            =");
            Console.WriteLine("============================");
        }
        public string ChoiceMenu()
        {
            string strMenu = "";
            try
            {
                Console.Write("Please choice: ");
                int n = Convert.ToInt32(Console.ReadLine());
                PC pC = new PC();

                switch (n)
                {
                    case 1:
                        pC.AddPC(pCs);
                        strMenu = this.GetType();
                        break;
                    case 2:
                        pC.UpdatePC(pCs);
                        strMenu = this.GetType();
                        break;
                    case 3:
                        pC.DeletePC(pCs);
                        strMenu = this.GetType();
                        break;
                    case 4:
                        pC.SearchPC(pCs);
                        strMenu = this.GetType();
                        break;
                    case 5:
                        pC.ViewPC(pCs);
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
