using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerManagementSystem
{
    internal class Brand : ISubject
    {
        private int id;
        private string name;
        private string description;
        private List<IObserver> observers = new List<IObserver>();

        public Brand(int id, string name, string description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
        }
        public Brand() { }

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

        public string Description
        {
            get => this.description;
            set
            {
                if (value.ToString().Length == 0)
                {
                    throw new ArgumentException("CPU can not be empty");
                }
                this.description = value;
            }
        }

        public void AddBrand(List<Brand> brands)
        {
            /*Brand brand = new Brand();

            Console.Write("Enter id: ");
            brand.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter name: ");
            brand.Name = Console.ReadLine();
            Console.Write("Enter description: ");
            brand.Description = Console.ReadLine();

            brands.Add(brand);*/

            brands.Add(new Brand(123, "Lenovo", "Lenovo product"));
            brands.Add(new Brand(124, "ASUS", "ASUS product"));
        }

        public void ViewBrand(List<Brand> brands)
        {
            if (brands.Count > 0)
            {
                foreach (Brand brand in brands)
                {
                    Console.WriteLine($"ID: {brand.Id}\n" +
                                      $"Name: {brand.Name}\n" +
                                      $"Description: {brand.Description}\n");
                    /*foreach (IObserver observer in brand.observers)
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

        public void UpdateBrand(List<Brand> brands)
        {
            Console.Write("Enter id: ");
            int searchValue = Convert.ToInt32(Console.ReadLine());
            bool flag = true;
            foreach (Brand brand in brands)
            {
                if (brand.Id == searchValue)
                {
                    flag = false;
                    brand.Name = this.EditBrand(brand.Name, "Name");
                    brand.Description = this.EditBrand(brand.Description, "Description");
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("ID does not exist!");
                Console.ReadKey();
            }
        }

        private string EditBrand(string myValue, string nameValue)
        {
            Console.WriteLine($"{nameValue}: {myValue}");
            string updateValue = Console.ReadLine();
            if (updateValue.Length > 0)
            {
                myValue = updateValue;
            }
            return myValue;
        }

        public void DeleteBrand(List<Brand> brands)
        {
            Console.Write("Enter id: ");
            int searchValue = Convert.ToInt32(Console.ReadLine());
            bool flag = true;
            foreach (Brand brand in brands)
            {
                if (brand.Id == searchValue)
                {
                    flag = false;
                    brands.Remove(brand);
                    Console.WriteLine($"ID {brand.Id} was deleted!");
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("ID does not exist!");
            }
            Console.ReadKey();
        }

        public void SearchBrand(List<Brand> brands)
        {
            Console.Write("Enter id: ");
            int searchValue = Convert.ToInt32(Console.ReadLine());
            bool flag = true;
            foreach (Brand brand in brands)
            {
                if (brand.Id == searchValue)
                {
                    flag = false;
                    Console.WriteLine($"ID: {brand.Id}\n" +
                                      $"Name: {brand.Name}\n" +
                                      $"Case: {brand.Description}\n");
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
