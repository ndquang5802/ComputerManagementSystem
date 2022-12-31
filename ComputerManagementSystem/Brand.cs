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

        public string Description
        {
            get => this.description;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("CPU can not be empty");
                }
                this.description = value;
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

        public void AddBrand(List<Brand> brands)
        {
            Brand brand = new Brand();
            //Check valid ID
            Id:
            try
            {
                Console.Write("Enter id: ");
                int id = Convert.ToInt32(Console.ReadLine());
                foreach (Brand item in brands)
                {
                    if (item.Id == id)
                    {
                        Console.WriteLine("Brand ID already exists");
                        goto Id;
                    }
                }
                brand.Id = id;
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
                brand.Name = Console.ReadLine();
            }
            catch (ArgumentException err)
            {
                Console.WriteLine(err.Message);
                goto Name;
            }
            //Check valid description
            Description:
            try
            {
                Console.Write("Enter description: ");
                brand.Description = Console.ReadLine();
            }
            catch (ArgumentException err)
            {
                Console.WriteLine(err.Message);
                goto Description;
            }

            brands.Add(brand);
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
            Id:
            try
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
            catch (FormatException)
            {
                Console.WriteLine("ID must be a number and can not empty!");
                goto Id;
            }
        }

        private string EditBrand(string myValue, string nameValue)
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

        public void SearchBrand(List<Brand> brands)
        {
        Id:
            try
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
            catch (FormatException)
            {
                Console.WriteLine("ID must be a number and can not empty!");
                goto Id;
            }
        }

        public void DeleteBrand(List<Brand> brands)
        {
            Id:
            try
            {
                Console.Write("Enter id: ");
                int searchValue = Convert.ToInt32(Console.ReadLine());

                Brand deleteBrand = null;
                foreach (Brand brand in brands)
                {
                    if (brand.Id == searchValue)
                    {
                        deleteBrand = brand;
                        break;
                    }
                }

                if (deleteBrand == null)
                {
                    Console.WriteLine("ID does not exist!");
                }
                else
                {
                    NotifyRelevant(deleteBrand);
                    brands.Remove(deleteBrand);
                    Console.WriteLine($"Brand ID {deleteBrand.Id} was deleted!");
                }
                Console.ReadKey();
            }
            catch (FormatException)
            {
                Console.WriteLine("ID must be a number and can not empty!");
                goto Id;
            }
        }

        public void NotifyRelevant(ISubject subject)
        {
            Brand deleteBrand = subject as Brand;
            foreach (IObserver observer in deleteBrand.observers)
            {
                if (observer is PC pC)
                {
                    if (deleteBrand.Id == pC.Brand.Id)
                    {
                        observer.update(pC);
                        PCMenu.pCs.Remove(pC);
                    }
                }
                if (observer is Laptop laptop)
                {
                    if (deleteBrand.Id == laptop.Brand.Id)
                    {
                        observer.update(laptop);
                        LaptopMenu.laptops.Remove(laptop);
                    }
                }
            }
        }
    }
}
