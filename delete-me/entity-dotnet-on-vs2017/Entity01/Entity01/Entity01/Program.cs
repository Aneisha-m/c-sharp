using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace Entity01
{
    class Program
    {
        static NorthwindEntities DBContext = new NorthwindEntities();

        static void Main(string[] args)
        {
            var categories =
                from c in DBContext.Categories
                select c;

            foreach(Category c in categories)
            {
                WriteLine($"{c.CategoryID} : {c.CategoryName} has {c.Products.Count} products");
            }
        }
    }
}
