using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace Lab_16
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int n = 5;
            string[] jsonString = new string[n];
            string path = "Products.json";
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            Product[] product = new Product[n];
            for (int i = 0; i < n; i++)
            {
                product[i] = new Product();
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write("Введите код товара - ");
                product[i].Code = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите наименование товара - ");
                product[i].Name = Console.ReadLine();
                Console.Write("Введите стоимость товара - ");
                product[i].Price = Convert.ToDouble(Console.ReadLine());
            }
            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < n; i++)
                {
                    string jsonstring = JsonSerializer.Serialize(product[i]);
                    sw.WriteLine(jsonstring);
                }
            }
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
