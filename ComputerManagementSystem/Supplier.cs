using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ComputerManagementSystem
{
    internal class Supplier
    {
        private int id;
        private string name;
        private string telephone;
        private string email;
        private string address;
        private List<IObserver> observers = new List<IObserver>();

        public Supplier(int id, string name, string telephone, string email, string address)
        {
            this.id = id;
            this.name = name;
            this.telephone = telephone;
            this.email = email;
            this.address = address;
        }
        public Supplier() { }

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }
        public void RemoveObserver(IObserver observer)
        {
            observers.Add(observer);
        }

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
                if (value.ToString().Length == 0)
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
                if (value.ToString().Length == 0)
                {
                    throw new ArgumentException("Address can not be empty");
                }
                this.address = value;
            }
        }

        public void AddSupplier(List<Supplier> suppliers)
        {
            /*Supplier supplier = new Supplier();

            Console.Write("Enter id: ");
            supplier.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter name: ");
            supplier.Name = Console.ReadLine();
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
            Console.Write("Enter address: ");
            supplier.Address = Console.ReadLine();

            suppliers.Add(supplier);*/

            suppliers.Add(new Supplier(1023, "Mobile World", "0922645516", "mobileworld@gmail.com", "Can Tho city"));
            suppliers.Add(new Supplier(1024, "Green Machine", "0323959498", "greenmachine@gmail.com", "Vinh Long city"));
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
                    /*foreach (IObserver observer in supplier.observers)
                    {
                        Computer computer = observer as Computer;
                        Console.WriteLine($"{computer.Name}");
                    }*/
                }
            }
            else
            {
                Console.WriteLine("Brand list is empty!");
            }
            Console.ReadKey();
        }

        public void UpdateSupplier(List<Supplier> suppliers)
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

        private string EditSupplier(string myValue, string nameValue)
        {
            Console.WriteLine($"{nameValue}: {myValue}");
            string updateValue = Console.ReadLine();
            if (updateValue.Length > 0)
            {
                myValue = updateValue;
            }
            return myValue;
        }

        public void DeleteSupplier(List<Supplier> suppliers)
        {
            Console.Write("Enter id: ");
            int searchValue = Convert.ToInt32(Console.ReadLine());
            bool flag = true;
            foreach (Supplier supplier in suppliers)
            {
                if (supplier.Id == searchValue)
                {
                    flag = false;
                    suppliers.Remove(supplier);
                    Console.WriteLine($"ID {supplier.Id} was deleted!");
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("ID does not exist!");
            }
            Console.ReadKey();
        }

        public void SearchSupplier(List<Supplier> suppliers)
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
                                      $"Address: {supplier.Address}");
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
