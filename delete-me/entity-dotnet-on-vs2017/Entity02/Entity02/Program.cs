using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Entity02
{
    class Program
    {
        static NorthwindEntities DBContext = new NorthwindEntities();
        static void Main(string[] args)
        {
            var categories =
                from c in DBContext.Categories
                select c;
            Console.WriteLine("=========Categories=========");
            foreach (Category c in categories)
            {
                
                WriteLine($"\t{c.CategoryID} : {c.CategoryName} has {c.Products.Count} products");

                Console.WriteLine("\t\t=======Products======");

                foreach (Product p in c.Products)
                {
                    WriteLine($"\t\t{p.ProductID} has name {p.ProductName}");
                }
            }
        }
    }
}




