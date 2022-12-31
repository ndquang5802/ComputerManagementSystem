using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ComputerManagementSystem
{
    internal class Supplier : ISubject
    {
        private int id;
        private string name;
        private string telephone;
        private string email;
        private string address;
        private List<IObserver> observers = new List<IObserver>();

        public int Id
        {
            get => this.id;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("ID must be a positive number!");
                }
                this.id = value;
            }
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Name can not be empty");
                }
                this.name = value;
            }
        }

        public string Telephone
        {
            get => this.telephone;
            set
            {
                if (!IsTelephone(value) || value.ToString().Length == 0)
                {
                    throw new ArgumentException("Invalid telephone!");
                }
                this.telephone = value;
            }
        }

        public static bool IsTelephone(string number)
        {
            string motif = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
            return Regex.IsMatch(number, motif);
        }

        public string Email
        {
            get => this.email;
            set
            {
                if (!IsValidEmail(value))
                {
                    throw new ArgumentException("Invalid email!");
                }
                this.email = value;
            }
        }

        bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        public string Address
        {
            get => this.address;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Address can not be empty");
                }
                this.address = value;
            }
        }

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }
        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void AddSupplier(List<Supplier> suppliers)
        {
            Supplier supplier = new Supplier();

            //Check valid ID
            Id:
            try
            {
                Console.Write("Enter id: ");
                int id = Convert.ToInt32(Console.ReadLine());
                foreach (Supplier item in suppliers)
                {
                    if(item.Id == id)
                    {
                        Console.WriteLine("Supplier ID already exists");
                        goto Id;
                    }
                }
                supplier.Id = id;
            }
            catch (ArgumentException err)
            {
                Console.WriteLine(err.Message);
                goto Id;
            }
            catch (FormatException)
            {
                Console.WriteLine("ID must be a number can not empty!");
                goto Id;
            }
            //Check valid name
            Name:
            try
            {
                Console.Write("Enter name: ");
                supplier.Name = Console.ReadLine();
            }
            catch (ArgumentException err)
            {
                Console.WriteLine(err.Message);
                goto Name;
            }
            //Check valid telephone
            Telephone:
            try
            {
                Console.Write("Enter telephone: ");
                supplier.Telephone = Console.ReadLine();
            }
            catch (ArgumentException err)
            {
                Console.WriteLine(err.Message);
                goto Telephone;
            }
            //Check valid email
            Email:
            try
            {
                Console.Write("Enter email: ");
                supplier.Email = Console.ReadLine();
            }
            catch (ArgumentException err)
            {
                Console.WriteLine(err.Message);
                goto Email;
            }
            //Check valid address
            Address:
            try
            {
                Console.Write("Enter address: ");
                supplier.Address = Console.ReadLine();
            }
            catch (ArgumentException err)
            {
                Console.WriteLine(err.Message);
                goto Address;
            }

            suppliers.Add(supplier);
        }

        public void ViewSupplier(List<Supplier> suppliers)
        {
            if (suppliers.Count > 0)
            {
                foreach (Supplier supplier in suppliers)
                {
                    Console.WriteLine($"ID: {supplier.Id}\n" +
                                      $"Name: {supplier.Name}\n" +
                                      $"Telephone: {supplier.Telephone}\n" +
                                      $"Email: {supplier.Email}\n" +
                                      $"Address: {supplier.Address}\n");
                }
            }
            else
            {
                Console.WriteLine("Supplier list is empty!");
            }
            Console.ReadKey();
        }

        public void UpdateSupplier(List<Supplier> suppliers)
        {
            Id:
            try
            {
                Console.Write("Enter id: ");
                int searchValue = Convert.ToInt32(Console.ReadLine());
                bool flag = true;
                foreach (Supplier supplier in suppliers)
                {
                    if (supplier.Id == searchValue)
                    {
                        flag = false;
                        supplier.Name = this.EditSupplier(supplier.Name, "Name");
                        supplier.Telephone = this.EditSupplier(supplier.Telephone, "Telephone");
                        supplier.Email = this.EditSupplier(supplier.Email, "Email");
                        supplier.Address = this.EditSupplier(supplier.Address, "Address");
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
                Console.WriteLine("ID must be a number can not empty!");
                goto Id;
            }
        }
            
        private string EditSupplier(string myValue, string nameValue)
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

        public void SearchSupplier(List<Supplier> suppliers)
        {
            Id:
            try
            {
                Console.Write("Enter id: ");
                int searchValue = Convert.ToInt32(Console.ReadLine());
                bool flag = true;
                foreach (Supplier supplier in suppliers)
                {
                    if (supplier.Id == searchValue)
                    {
                        flag = false;
                        Console.WriteLine($"ID: {supplier.Id}\n" +
                                          $"Name: {supplier.Name}\n" +
                                          $"Telephone: {supplier.Telephone}\n" +
                                          $"Email: {supplier.Email}\n" +
                                          $"Address: {supplier.Address}\n");
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
                Console.WriteLine("ID must be a number can not empty!");
                goto Id;
            }
        }

        public void DeleteSupplier(List<Supplier> suppliers)
        {
            Id:
            try
            {
                Console.Write("Enter id: ");
                int searchValue = Convert.ToInt32(Console.ReadLine());

                Supplier deleteSupplier = null;
                foreach (Supplier supplier in suppliers)
                {
                    if (supplier.Id == searchValue)
                    {
                        deleteSupplier = supplier;
                        break;
                    }
                }

                if (deleteSupplier == null)
                {
                    Console.WriteLine("ID does not exist!");
                }
                else
                {
                    NotifyRelevant(deleteSupplier);
                    suppliers.Remove(deleteSupplier);
                    Console.WriteLine($"Supplier ID {deleteSupplier.Id} was deleted!");
                }
                Console.ReadKey();
            }
            catch (FormatException)
            {
                Console.WriteLine("ID must be a number can not empty!");
                goto Id;
            }
        }

        public void NotifyRelevant(ISubject subject)
        {
            Supplier deleteSupplier = subject as Supplier;
            foreach (IObserver observer in deleteSupplier.observers)
            {
                if (observer is PC pC)
                {
                    if (deleteSupplier.Id == pC.Supplier.Id)
                    {
                        observer.update(pC);
                        PCMenu.pCs.Remove(pC);
                    }
                }
                if (observer is Laptop laptop)
                {
                    if (deleteSupplier.Id == laptop.Supplier.Id)
                    {
                        observer.update(laptop);
                        LaptopMenu.laptops.Remove(laptop);
                    }
                }
            }
        }
    }
}
