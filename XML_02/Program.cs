using System;
using System.Linq;
using System.Xml.Linq;

namespace XML_02
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindEntities())
            {
                var products = db.Products.ToArray();

                var xml = new XElement
                ("products",
                    from p in products
                    select new XElement
                    ("product",
                        new XAttribute("id", p.ProductID),
                        new XAttribute("price", p.UnitPrice),
                        new XElement("name", p.ProductName)
                    )
                );

                Console.WriteLine(xml);
            }
        }
    }
}
