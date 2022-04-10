using System;
using Exercise.Entities;
using System.Globalization;
using System.Collections.Generic;

namespace Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());

            List<Product> list = new List<Product>();

            for (int i = 1; i <= n; i++)
            {
                System.Console.WriteLine($"Product #{i} data:");
                System.Console.Write("Comon, used or imported (c/u/i): ");
                char ch = char.Parse(Console.ReadLine());
                System.Console.Write("Name: ");
                string name = Console.ReadLine();
                System.Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (ch == 'i')
                {
                    System.Console.Write("Customs fee: ");
                    double customsFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new ImportedProduct(name, price, customsFee));
                }
                else if (ch == 'u')
                {
                    System.Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateTime manufactureDate = DateTime.Parse(Console.ReadLine());
                    list.Add(new UsedProduct(name, price, manufactureDate));
                }
                else
                {
                    list.Add(new Product(name, price));
                }
            }

            System.Console.WriteLine();
            System.Console.WriteLine("PRICE TAGS:");

            foreach (Product tags in list)
            {
                System.Console.WriteLine(tags.PriceTag().ToString());
            }
        }
    }
}
