using System;
namespace Singleton_DesignPattern
{
    //'Creator' abstract class
    abstract class ElectronicProduct
    {
        //Common property
        public string Name { get; set; }
        public string Memory { get; set; }
        public string Description { get; set; }

        //Common Method / Function / Behaviour
        public abstract string GetMemory();
        public abstract void SetMemory(int value);
    }

    //'ConcreteProduct' Class
    class MobilePhone : ElectronicProduct
    {
        public MobilePhone()
        {
            Name = "Nokia";
            Memory = "8 GB";
            Description = "It's famous mobile phone in india";
        }
        //GSM or CDMA
        public string PhoneType { get; set; }

        public override string GetMemory()
        {
            return Memory;
        }

        public override void SetMemory(int value)
        {
            Memory = string.Format("{0} {1}", value, "GB");
        }
    }

    //'ConcreteProduct' Class
    class Laptop : ElectronicProduct
    {
        public Laptop()
        {
            Name = "Lenovo";
            Memory = "500 GB";
            Description = "It's famous labtop in india";
        }
        //DualCore or MultiCore
        public string ProcessorType { get; set; }

        public override string GetMemory()
        {
            return Memory;
        }

        public override void SetMemory(int value)
        {
            Memory = string.Format("{0} {1}", value, "GB");
        }
    }

    //'ConcreteProduct' Class
    class ExternalHardDrive : ElectronicProduct
    {
        public ExternalHardDrive()
        {
            Name = "Dell";
            Memory = "1 TB";
            Description = "It's famous External Hard Drive in india";
        }
        //SSD or HDD (Solid State Drive OR Hard Disk Drive)
        public string Type { get; set; }

        public override string GetMemory()
        {
            return Memory;
        }

        public override void SetMemory(int value)
        {
            Memory = string.Format("{0} {1}", value, "TB");
        }
    }

    //'ConcreteProduct' Class
    class GenericProduct : ElectronicProduct
    {
        //TODO
        public override string GetMemory()
        {
            throw new NotImplementedException();
        }

        public override void SetMemory(int value)
        {
            throw new NotImplementedException();
        }
    }

    //'IProduct' Interface
    interface IProductFactory
    {
        ElectronicProduct CreateProduct(ProductDetails productDetails);
    }

    //'Concrete Creator' Class
    class ProductFactory : IProductFactory
    {
        public ProductFactory()
        {
            Console.WriteLine("Creating Product Factory");
        }

        //'Factory Method' to decide which class instantiate
        public ElectronicProduct CreateProduct(ProductDetails productDetails)
        {
            switch (productDetails)
            {
                case ProductDetails.MobilePhone:
                    return new MobilePhone();
                case ProductDetails.Laptop:
                    return new Laptop();
                case ProductDetails.ExternalHardDrive:
                    return new ExternalHardDrive();

                default:
                    return new GenericProduct();
            }
        }

    }

    //Different product that can be created by the factory
    enum ProductDetails
    {
        MobilePhone,
        Laptop,
        ExternalHardDrive
    }

    //main class act as 'Client'
    class Program
    {
        static void Main(string[] args)
        {
            ProductFactory factory = new ProductFactory();
            ElectronicProduct product;
            foreach (ProductDetails prodDetail in Enum.GetValues(typeof(ProductDetails)))
            {
                product = factory.CreateProduct(prodDetail);
                Console.WriteLine("Name: {0}, Memory: {1}, Description: {2}, Available Memory: {3}", product.Name, product.Memory, product.Description, product.GetMemory());
                Console.WriteLine("Do you want to reset {0} memory?", product.Name);
                Console.Write("Press 1 to reset memory: ");
                if (Convert.ToInt32(Console.ReadLine()) == 1)
                {
                    Console.Write("Enter Memory Capacity: ");
                    product.SetMemory(Convert.ToInt32(Console.ReadLine()));
                }
                Console.WriteLine("Current Reset Memory Value: {0}", product.GetMemory());
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
}
