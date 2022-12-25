using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerManagementSystem
{
    internal class Computer : IObserver
    {
        protected int id;
        protected string name;
        protected string cpu;
        protected int rom;
        protected int ram;
        protected float price;
        protected int quantity;
        protected Brand brand;
        protected Supplier supplier;

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

        public string CPU
        {
            get => this.cpu;
            set
            {
                if (value.ToString().Length == 0)
                {
                    throw new ArgumentException("CPU can not be empty");
                }
                this.cpu = value;
            }
        }

        public int ROM
        {
            get => this.rom;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("ROM must be a positive number!");
                }
                this.rom = value;
            }
        }

        public int RAM
        {
            get => this.ram;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("RAM must be a positive number!");
                }
                this.ram = value;
            }
        }

        public float Price
        {
            get => this.price;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price must be a positive number!");
                }
                this.price = value;
            }
        }

        public int Quantity
        {
            get => this.quantity;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Quantity must be a positive number!");
                }
                this.quantity = value;
            }
        }

        public Brand Brand
        {
            get => this.brand;
            set
            {
                this.brand = value;
                value.RegisterObserver(this);
            }
        }

        public Supplier Supplier
        {
            get => this.supplier;
            set
            {
                this.supplier = value;
                value.RegisterObserver(this);
            }
        }
    }
}
