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
            get => this.cases;
            set 
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Case can not be empty");
                }
                this.cases = value;
            }
        }

        public void AddPC(List<PC> pCs)
        {
            PC pC = new PC();

            //Check valid ID
            Id:
            try
            {
                Console.Write("Enter id: ");
                int id = Convert.ToInt32(Console.ReadLine());
                foreach (PC item in pCs)
                {
                    if (item.Id == id)
                    {
                        Console.WriteLine("PC ID already exists");
                        goto Id;
                    }
                }
                pC.Id = id;
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
                pC.Name = Console.ReadLine();
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
                pC.CPU = Console.ReadLine();
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
                pC.ROM = Convert.ToInt32(Console.ReadLine());
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
                pC.RAM = Convert.ToInt32(Console.ReadLine());
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
                pC.Price = Convert.ToSingle(Console.ReadLine());
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
                pC.Quantity = Convert.ToInt32(Console.ReadLine());
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
            //Check valid case
            Case:
            try
            {
                Console.Write("Enter case name: ");
                pC.Cases = Console.ReadLine();
            }
            catch (ArgumentException err)
            {
                Console.WriteLine(err.Message);
                goto Case;
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
                        pC.Brand = brand;
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
                        pC.Supplier = supplier;
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
            Id:
            try
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
                        //Check valid update ROM
                        UpdateRom:
                        try
                        {
                            pC.ROM = this.EditPC(pC.ROM, "ROM");
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
                        //Check valid update RAM
                        UpdateRam:
                        try
                        {
                            pC.RAM = this.EditPC(pC.RAM, "RAM");
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
                        //Check valid price
                        UpdatePrice:
                        try
                        {
                            pC.Price = this.EditPC(pC.Price, "Price");
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
                        //Check valid quantity
                        updateQuantity:
                        try
                        {
                            pC.Quantity = this.EditPC(pC.Quantity, "Quantity");
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
                        pC.Cases = this.EditPC(pC.Cases, "Case name");
                        pC.Brand.RemoveObserver(pC);
                        pC.Brand = this.EditPC(pC.Brand, "Brand ID", "Brand Name");
                        pC.Supplier.RemoveObserver(pC);
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
            catch (FormatException)
            {
                Console.WriteLine("ID must be a number and can not empty!");
                goto Id;
            }
        }

        private Brand EditPC(Brand myValue, string IDValue, string nameValue)
        {
            UpdateBrand:
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

        private Supplier EditPC(Supplier myValue, string IDValue, string nameValue)
        {
            UpdateSupplier:
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
                    Console.WriteLine("Supplier ID does not exist!");
                    goto UpdateSupplier;
                }
            }
            return myValue;
        }

        private string EditPC(string myValue, string nameValue)
        {
            Console.WriteLine($"{nameValue}: {myValue}");
            Console.Write($"Enter new {nameValue}: ");
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
            Console.Write($"Enter new {nameValue}: ");
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
            Console.Write($"Enter new {nameValue}: ");
            string updateValue = Console.ReadLine();
            if (updateValue.Length > 0 && Convert.ToSingle(updateValue) != myValue)
            {
                myValue = Convert.ToSingle(updateValue);
            }
            return myValue;
        }

        public void SearchPC(List<PC> pCs)
        {
            Id:
            try
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
            catch (FormatException)
            {
                Console.WriteLine("ID must be a number and can not empty!");
                goto Id;
            }
        }

        public void DeletePC(List<PC> pCs)
        {
            Id:
            try
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
                        Console.WriteLine($"PC ID {pC.Id} was deleted!");
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
