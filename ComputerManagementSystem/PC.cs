using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerManagementSystem
{
    internal class PC : Computer
    {
        private string cases;

        public string Cases
        {
            get { return cases; }
            set { cases = value; }
        }

        public void AddPC(List<PC> pCs)
        {
            PC pC = new PC();

            Console.Write("Enter id: ");
            pC.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter name: ");
            pC.Name = Console.ReadLine();
            Console.Write("Enter CPU: ");
            pC.CPU = Console.ReadLine();
            Console.Write("Enter ROM: ");
            pC.ROM = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter RAM: ");
            pC.RAM = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter price: ");
            pC.Price = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter quantity: ");
            pC.Quantity = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter case name: ");
            pC.Cases = Console.ReadLine();

            Console.Write("Enter brand id: ");
            int brandId = Convert.ToInt32(Console.ReadLine());
            foreach (Brand brand in BrandMenu.brands)
            {
                if (brand.Id == brandId)
                {
                    pC.Brand = brand;
                    break;
                }
            }

            Console.Write("Enter supplier id: ");
            int supplierId = Convert.ToInt32(Console.ReadLine());
            foreach (Supplier supplier in SupplierMenu.suppliers)
            {
                if (supplier.Id == supplierId)
                {
                    pC.Supplier = supplier;
                    break;
                }
            }

            pCs.Add(pC);
        }

        public void ViewPC(List<PC> pCs)
        {
            if (pCs.Count > 0)
            {
                foreach (PC pC in pCs)
                {
                    Console.WriteLine($"ID: {pC.Id}\n" +
                                      $"Name: {pC.Name}\n" +
                                      $"CPU: {pC.CPU}\n" +
                                      $"ROM: {pC.ROM}GB\n" +
                                      $"RAM: {pC.RAM}GB\n" +
                                      $"Price: ${pC.Price}\n" +
                                      $"Quantity: {pC.Quantity}\n" +
                                      $"Case: {pC.Cases}\n" +
                                      $"Brand: {pC.Brand.Name}\n" +
                                      $"Supplier: {pC.Supplier.Name}\n");
                }
            }
            else
            {
                Console.WriteLine("PC list is empty!");
            }
            Console.ReadKey();
        }

        public void UpdatePC(List<PC> pCs)
        {
            Console.Write("Enter id: ");
            int searchValue = Convert.ToInt32(Console.ReadLine());
            bool flag = true;
            foreach (PC pC in pCs)
            {
                if (pC.Id == searchValue)
                {
                    flag = false;
                    pC.Name = this.EditPC(pC.Name, "Name");
                    pC.CPU = this.EditPC(pC.CPU, "CPU");
                    pC.ROM = this.EditPC(pC.ROM, "ROM");
                    pC.RAM = this.EditPC(pC.RAM, "RAM");
                    pC.Price = this.EditPC(pC.Price, "Price");
                    pC.Quantity = this.EditPC(pC.Quantity, "Quantity");
                    pC.Cases = this.EditPC(pC.Cases, "Case name");
                    pC.Brand = this.EditPC(pC.Brand, "Brand ID", "Brand Name");
                    pC.Supplier = this.EditPC(pC.Supplier, "Supplier ID", "Supplier Name");
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("ID does not exist!");
                Console.ReadKey();
            }
        }

        private Brand EditPC(Brand myValue, string IDValue, string nameValue)
        {
            Console.WriteLine($"{IDValue}: {myValue.Id}");
            Console.WriteLine($"{nameValue}: {myValue.Name}");
            string updateValue = Console.ReadLine();
            if (updateValue.Length > 0)
            {
                int id = Convert.ToInt32(updateValue);
                foreach (Brand brand in BrandMenu.brands)
                {
                    if (brand.Id == id)
                    {
                        myValue = brand;
                        break;
                    }
                }
            }
            return myValue;
        }

        private Supplier EditPC(Supplier myValue, string IDValue, string nameValue)
        {
            Console.WriteLine($"{IDValue}: {myValue.Id}");
            Console.WriteLine($"{nameValue}: {myValue.Name}");
            string updateValue = Console.ReadLine();
            if (updateValue.Length > 0)
            {
                int id = Convert.ToInt32(updateValue);
                foreach (Supplier supplier in SupplierMenu.suppliers)
                {
                    if (supplier.Id == id)
                    {
                        myValue = supplier;
                        break;
                    }
                }
            }
            return myValue;
        }

        private string EditPC(string myValue, string nameValue)
        {
            Console.WriteLine($"{nameValue}: {myValue}");
            string updateValue = Console.ReadLine();
            if (updateValue.Length > 0)
            {
                myValue = updateValue;
            }
            return myValue;
        }

        private int EditPC(int myValue, string nameValue)
        {
            Console.WriteLine($"{nameValue}: {myValue}");
            string updateValue = Console.ReadLine();
            if (updateValue.Length > 0 && Convert.ToInt32(updateValue) != myValue)
            {
                myValue = Convert.ToInt32(updateValue);
            }
            return myValue;
        }

        private float EditPC(float myValue, string nameValue)
        {
            Console.WriteLine($"{nameValue}: {myValue}");
            string updateValue = Console.ReadLine();
            if (updateValue.Length > 0 && Convert.ToSingle(updateValue) != myValue)
            {
                myValue = Convert.ToSingle(updateValue);
            }
            return myValue;
        }

        public void DeletePC(List<PC> pCs)
        {
            Console.Write("Enter id: ");
            int searchValue = Convert.ToInt32(Console.ReadLine());
            bool flag = true;
            foreach (PC pC in pCs)
            {
                if (pC.Id == searchValue)
                {
                    flag = false;
                    pC.Brand.RemoveObserver(pC);
                    pC.Supplier.RemoveObserver(pC);
                    pCs.Remove(pC);
                    Console.WriteLine($"ID {pC.Id} was deleted!");
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("ID does not exist!");
            }
            Console.ReadKey();
        }

        public void SearchPC(List<PC> pCs)
        {
            Console.Write("Enter id: ");
            int searchValue = Convert.ToInt32(Console.ReadLine());
            bool flag = true;
            foreach (PC pC in pCs)
            {
                if (pC.Id == searchValue)
                {
                    flag = false;
                    Console.WriteLine($"ID: {pC.Id}\n" +
                                      $"Name: {pC.Name}\n" +
                                      $"CPU: {pC.CPU}\n" +
                                      $"ROM: {pC.ROM}GB\n" +
                                      $"RAM: {pC.RAM}GB\n" +
                                      $"Price: ${pC.Price}\n" +
                                      $"Quantity: {pC.Quantity}\n" +
                                      $"Case: {pC.Cases}");
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("ID does not exist!");
            }
            Console.ReadKey();
        }
    }
}
