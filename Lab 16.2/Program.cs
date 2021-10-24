using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace Lab_16._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int n = 5;
            string[] jsonString = new string[n];
            string path = @"C:\Users\misyu\OneDrive\C#\Задания\16\Lab 16\Lab 16\bin\Debug\Products.json";
            double maxPrice = 0;
            string maxName = "";
            Product[] product = new Product[n];
            using (StreamReader streamReader = new StreamReader(path))
            {
                for (int i = 0; i < n; i++)
                {
                    jsonString[i] = streamReader.ReadLine();
                    product [i] = JsonSerializer.Deserialize<Product>(jsonString[i]);
                }
            }
            foreach (Product a in product)
            {
                if (maxPrice < a.Price)
                {
                    maxPrice = a.Price;
                    maxName = a.Name;
                }
            }
            Console.WriteLine($"Самый дорогой товар - {maxName}");
            Console.ReadKey();
        }
    }
    public class Product
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
