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
            get => this.battery;
            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Battery must be a positive number!");
                }
                this.battery = value; 
            }
        }

        public void AddLaptop(List<Laptop> laptops)
        {
            Laptop laptop = new Laptop();

            //Check valid ID
            Id:
            try
            {
                Console.Write("Enter id: ");
                int id = Convert.ToInt32(Console.ReadLine());
                foreach (Laptop item in laptops)
                {
                    if (item.Id == id)
                    {
                        Console.WriteLine("Laptop ID already exists");
                        goto Id;
                    }
                }
                laptop.Id = id;
            }
            catch (ArgumentException err)
            {
                Console.WriteLine(err.Message);
                goto Id;
            }
            catch (FormatException)
            {
                Console.WriteLine("ID must be a number and can not empty!");
                goto Id;
            }
            //Check valid name
            Name:
            try
            {
                Console.Write("Enter name: ");
                laptop.Name = Console.ReadLine();
            }
            catch (ArgumentException err)
            {
                Console.WriteLine(err.Message);
                goto Name;
            }
            //Check valid CPU
            CPU:
            try
            {
                Console.Write("Enter CPU: ");
                laptop.CPU = Console.ReadLine();
            }
            catch (ArgumentException err)
            {
                Console.WriteLine(err.Message);
                goto CPU;
            }
            //Check valid ROM
            ROM:
            try
            {
                Console.Write("Enter ROM: ");
                laptop.ROM = Convert.ToInt32(Console.ReadLine());
            }
            catch (ArgumentException err)
            {
                Console.WriteLine(err.Message);
                goto ROM;
            }
            catch (FormatException)
            {
                Console.WriteLine("ROM must be the number and can not empty!");
                goto ROM;
            }
            //Check valid RAM
            RAM:
            try
            {
                Console.Write("Enter RAM: ");
                laptop.RAM = Convert.ToInt32(Console.ReadLine());
            }
            catch (ArgumentException err)
            {
                Console.WriteLine(err.Message);
                goto RAM;
            }
            catch (FormatException)
            {
                Console.WriteLine("RAM must be the number and can not empty!");
                goto RAM;
            }
            //Check valid price
            Price:
            try
            {
                Console.Write("Enter price: ");
                laptop.Price = Convert.ToSingle(Console.ReadLine());
            }
            catch (ArgumentException err)
            {
                Console.WriteLine(err.Message);
                goto Price;
            }
            catch (FormatException)
            {
                Console.WriteLine("Price must be the number and can not empty!");
                goto Price;
            }
            //Check valid quantity
            Quantity:
            try
            {
                Console.Write("Enter quantity: ");
                laptop.Quantity = Convert.ToInt32(Console.ReadLine());
            }
            catch (ArgumentException err)
            {
                Console.WriteLine(err.Message);
                goto Quantity;
            }
            catch (FormatException)
            {
                Console.WriteLine("Quantity must be the number and can not empty!");
                goto Quantity;
            }
            //Check valid battery
            Battery:
            try
            {
                Console.Write("Enter battery: ");
                laptop.Battery = Convert.ToSingle(Console.ReadLine());
            }
            catch (ArgumentException err)
            {
                Console.WriteLine(err.Message);
                goto Battery;
            }
            catch (FormatException)
            {
                Console.WriteLine("Battery must be the number and can not empty!");
                goto Battery;
            }
            //Check valid brand
            Brand:
            bool flagBrand = true;
            try
            {
                Console.Write("Enter brand id: ");
                int brandId = Convert.ToInt32(Console.ReadLine());

                foreach (Brand brand in BrandMenu.brands)
                {
                    if (brand.Id == brandId)
                    {
                        flagBrand = false;
                        laptop.Brand = brand;
                        break;
                    }
                }
                if (flagBrand)
                {
                    Console.WriteLine("Brand ID does not exist!");
                    goto Brand;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Brand can not empty!");
                goto Brand;
            }
            
            //Check valid supplier
            Supplier:
            bool flagSupplier = true;
            try
            {
                Console.Write("Enter supplier id: ");
                int supplierId = Convert.ToInt32(Console.ReadLine());
                foreach (Supplier supplier in SupplierMenu.suppliers)
                {
                    if (supplier.Id == supplierId)
                    {
                        flagSupplier = false;
                        laptop.Supplier = supplier;
                        break;
                    }
                }
                if (flagSupplier)
                {
                    Console.WriteLine("Supplier ID does not exist!");
                    goto Supplier;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Supplier can not empty!");
                goto Supplier;
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
                                      $"Battery: {laptop.Battery}V\n" +
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
            Id:
            try
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
                        //Check valid update ROM
                        UpdateRom:
                        try
                        {
                            laptop.ROM = this.EditLaptop(laptop.ROM, "ROM");
                        }
                        catch (ArgumentException err)
                        {
                            Console.WriteLine(err.Message);
                            goto UpdateRom;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("ROM must be the number!");
                            goto UpdateRom;
                        }
                        //Check valid update RAM:
                        UpdateRam:
                        try
                        {
                            laptop.RAM = this.EditLaptop(laptop.RAM, "RAM");
                        }
                        catch (ArgumentException err)
                        {
                            Console.WriteLine(err.Message);
                            goto UpdateRam;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("RAM must be the number!");
                            goto UpdateRam;
                        }
                        //Check valid update price
                        UpdatePrice:
                        try
                        {
                            laptop.Price = this.EditLaptop(laptop.Price, "Price");
                        }
                        catch (ArgumentException err)
                        {
                            Console.WriteLine(err.Message);
                            goto UpdatePrice;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Price must be the number!");
                            goto UpdatePrice;
                        }
                        //Check valid update quantity
                        updateQuantity:
                        try
                        {
                            laptop.Quantity = this.EditLaptop(laptop.Quantity, "Quantity");
                        }
                        catch (ArgumentException err)
                        {
                            Console.WriteLine(err.Message);
                            goto updateQuantity;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Quantity must be the number!");
                            goto updateQuantity;
                        }
                        //Check valid update battery
                        UpdateBattery:
                        try
                        {
                            laptop.Battery = this.EditLaptop(laptop.Battery, "Battery");
                        }
                        catch (ArgumentException err)
                        {
                            Console.WriteLine(err.Message);
                            goto UpdateBattery;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Battery must be the number!");
                            goto UpdateBattery;
                        }

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
            catch (FormatException)
            {
                Console.WriteLine("ID must be a number and can not empty!");
                goto Id;
            }
        }

        private Brand EditLaptop(Brand myValue, string IDValue, string nameValue)
        {
            UpdateBrand:
            Console.WriteLine();
            bool flagUpdateBrand = true;
            Console.WriteLine($"{IDValue}: {myValue.Id} - {nameValue}: {myValue.Name}");
            Console.Write($"Enter new {IDValue}: ");
            string updateValue = Console.ReadLine();
            if (updateValue.Length > 0)
            {
                int id = Convert.ToInt32(updateValue);
                foreach (Brand brand in BrandMenu.brands)
                {
                    if (brand.Id == id)
                    {
                        flagUpdateBrand = false;
                        myValue = brand;
                        break;
                    }
                }
                if (flagUpdateBrand)
                {
                    Console.WriteLine("Brand ID does not exist!");
                    goto UpdateBrand;
                }
            }
            return myValue;
        }

        private Supplier EditLaptop(Supplier myValue, string IDValue, string nameValue)
        {
            UpdateSupplier:
            Console.WriteLine();
            bool flagUpdateSupplier = true;
            Console.WriteLine($"{IDValue}: {myValue.Id} - {nameValue}: {myValue.Name}");
            Console.Write($"Enter new {IDValue}: ");
            string updateValue = Console.ReadLine();
            if (updateValue.Length > 0)
            {
                int id = Convert.ToInt32(updateValue);
                foreach (Supplier supplier in SupplierMenu.suppliers)
                {
                    if (supplier.Id == id)
                    {
                        flagUpdateSupplier = false;
                        myValue = supplier;
                        break;
                    }
                }
                if (flagUpdateSupplier)
                {
                    Console.WriteLine("Brand ID does not exist!");
                    goto UpdateSupplier;
                }
            }
            return myValue;
        }

        private string EditLaptop(string myValue, string nameValue)
        {
            Console.WriteLine();
            Console.WriteLine($"{nameValue}: {myValue}");
            Console.Write($"Enter new {nameValue}: ");
            string updateValue = Console.ReadLine();
            if (updateValue.Length > 0)
            {
                myValue = updateValue;
            }
            return myValue;
        }

        private int EditLaptop(int myValue, string nameValue)
        {
            Console.WriteLine();
            Console.WriteLine($"{nameValue}: {myValue}");
            Console.Write($"Enter new {nameValue}: ");
            string updateValue = Console.ReadLine();
            if (updateValue.Length > 0 && Convert.ToSingle(updateValue) != myValue)
            {
                myValue = Convert.ToInt32(updateValue);
            }
            return myValue;
        }

        private float EditLaptop(float myValue, string nameValue)
        {
            Console.WriteLine();
            Console.WriteLine($"{nameValue}: {myValue}");
            Console.Write($"Enter new {nameValue}: ");
            string updateValue = Console.ReadLine();
            if (updateValue.Length > 0 && Convert.ToSingle(updateValue) != myValue)
            {
                myValue = Convert.ToSingle(updateValue);
            }
            return myValue;
        }

        public void SearchLaptop(List<Laptop> laptops)
        {
            Id:
            try
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
                                          $"Battery: {laptop.Battery}V\n");
                        break;
                    }
                }
                if (flag)
                {
                    Console.WriteLine("ID does not exist!");
                }
                Console.ReadKey();
            }
            catch (FormatException)
            {
                Console.WriteLine("ID must be a number and can not empty!");
                goto Id;
            }
        }

        public void DeleteLaptop(List<Laptop> laptops)
        {
            Id:
            try
            {
                Console.Write("Enter id: ");
                int searchValue = Convert.ToInt32(Console.ReadLine());
                bool flag = true;
                foreach (Laptop laptop in laptops)
                {
                    if (laptop.Id == searchValue)
                    {
                        flag = false;
                        laptop.Brand.RemoveObserver(laptop);
                        laptop.Supplier.RemoveObserver(laptop);
                        laptops.Remove(laptop);
                        Console.WriteLine($"Laptop ID {laptop.Id} was deleted!");
                        break;
                    }
                }
                if (flag)
                {
                    Console.WriteLine("ID does not exist!");
                }
                Console.ReadKey();
            }
            catch (FormatException)
            {
                Console.WriteLine("ID must be a number and can not empty!");
                goto Id;
            }
        }
    }
}
