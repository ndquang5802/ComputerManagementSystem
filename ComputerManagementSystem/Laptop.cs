using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerManagementSystem
{
    internal class Laptop : Computer
    {
        private float battery;

        public float Battery
        {
            get { return battery; }
            set { battery = value; }
        }

        public void AddLaptop(List<Laptop> laptops)
        {
            Laptop laptop = new Laptop();

            Console.Write("Enter id: ");
            laptop.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter name: ");
            laptop.Name = Console.ReadLine();
            Console.Write("Enter CPU: ");
            laptop.CPU = Console.ReadLine();
            Console.Write("Enter ROM: ");
            laptop.ROM = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter RAM: ");
            laptop.RAM = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter price: ");
            laptop.Price = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter quantity: ");
            laptop.Quantity = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter battery: ");
            laptop.Battery = Convert.ToSingle(Console.ReadLine());

            Console.Write("Enter brand id: ");
            int brandId = Convert.ToInt32(Console.ReadLine());
            foreach (Brand brand in BrandMenu.brands)
            {
                if (brand.Id == brandId)
                {
                    laptop.Brand = brand;
                    break;
                }
            }

            Console.Write("Enter supplier id: ");
            int supplierId = Convert.ToInt32(Console.ReadLine());
            foreach (Supplier supplier in SupplierMenu.suppliers)
            {
                if (supplier.Id == supplierId)
                {
                    laptop.Supplier = supplier;
                    break;
                }
            }

            laptops.Add(laptop);
        }

        public void ViewLaptop(List<Laptop> laptops)
        {
            if (laptops.Count > 0)
            {
                foreach (Laptop laptop in laptops)
                {
                    Console.WriteLine($"ID: {laptop.Id}\n" +
                                      $"Name: {laptop.Name}\n" +
                                      $"CPU: {laptop.CPU}\n" +
                                      $"ROM: {laptop.ROM}GB\n" +
                                      $"RAM: {laptop.RAM}GB\n" +
                                      $"Price: ${laptop.Price}\n" +
                                      $"Quantity: {laptop.Quantity}\n" +
                                      $"Battery: {laptop.Battery}\n" +
                                      $"Brand: {laptop.Brand.Name}\n" +
                                      $"Supplier: {laptop.Supplier.Name}\n");
                }
            }
            else
            {
                Console.WriteLine("Laptop list is empty!");
            }
            Console.ReadKey();
        }

        public void UpdateLaptop(List<Laptop> laptops)
        {
            Console.Write("Enter id: ");
            int searchValue = Convert.ToInt32(Console.ReadLine());
            bool flag = true;
            foreach (Laptop laptop in laptops)
            {
                if (laptop.Id == searchValue)
                {
                    flag = false;
                    laptop.Name = this.EditLaptop(laptop.Name, "Name");
                    laptop.CPU = this.EditLaptop(laptop.CPU, "CPU");
                    laptop.ROM = this.EditLaptop(laptop.ROM, "ROM");
                    laptop.RAM = this.EditLaptop(laptop.RAM, "RAM");
                    laptop.Price = this.EditLaptop(laptop.Price, "Price");
                    laptop.Quantity = this.EditLaptop(laptop.Quantity, "Quantity");
                    laptop.Battery = this.EditLaptop(laptop.Battery, "Battery");
                    laptop.Brand = this.EditLaptop(laptop.Brand, "Brand ID", "Brand Name");
                    laptop.Supplier = this.EditLaptop(laptop.Supplier, "Supplier ID", "Supplier Name");
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("ID does not exist!");
                Console.ReadKey();
            }
        }

        private Brand EditLaptop(Brand myValue, string IDValue, string nameValue)
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

        private Supplier EditLaptop(Supplier myValue, string IDValue, string nameValue)
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

        private string EditLaptop(string myValue, string nameValue)
        {
            Console.WriteLine($"{nameValue}: {myValue}");
            string updateValue = Console.ReadLine();
            if (updateValue.Length > 0)
            {
                myValue = updateValue;
            }
            return myValue;
        }

        private int EditLaptop(int myValue, string nameValue)
        {
            Console.WriteLine($"{nameValue}: {myValue}");
            string updateValue = Console.ReadLine();
            if (updateValue.Length > 0 && Convert.ToSingle(updateValue) != myValue)
            {
                myValue = Convert.ToInt32(updateValue);
            }
            return myValue;
        }

        private float EditLaptop(float myValue, string nameValue)
        {
            Console.WriteLine($"{nameValue}: {myValue}");
            string updateValue = Console.ReadLine();
            if (updateValue.Length > 0 && Convert.ToSingle(updateValue) != myValue)
            {
                myValue = Convert.ToSingle(updateValue);
            }
            return myValue;
        }

        public void DeleteLaptop(List<Laptop> laptops)
        {
            Console.Write("Enter id: ");
            int searchValue = Convert.ToInt32(Console.ReadLine());
            bool flag = true;
            foreach (Laptop laptop in laptops)
            {
                if (laptop.Id == searchValue)
                {
                    flag = false;
                    laptops.Remove(laptop);
                    Console.WriteLine($"ID {laptop.Id} was deleted!");
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("ID does not exist!");
            }
            Console.ReadKey();
        }

        public void SearchLaptop(List<Laptop> laptops)
        {
            Console.Write("Enter id: ");
            int searchValue = Convert.ToInt32(Console.ReadLine());
            bool flag = true;
            foreach (Laptop laptop in laptops)
            {
                if (laptop.Id == searchValue)
                {
                    flag = false;
                    Console.WriteLine($"ID: {laptop.Id}\n" +
                                      $"Name: {laptop.Name}\n" +
                                      $"CPU: {laptop.CPU}\n" +
                                      $"ROM: {laptop.ROM}GB\n" +
                                      $"RAM: {laptop.RAM}GB\n" +
                                      $"Price: ${laptop.Price}\n" +
                                      $"Quantity: {laptop.Quantity}\n" +
                                      $"Battery: {laptop.Battery}");
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
