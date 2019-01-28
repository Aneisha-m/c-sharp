using System;
using System.Collections.Generic;
using System.Linq;

namespace EF_from_database
{
    class Program
    {
        static List<Customer> customers = new List<Customer>();

        static void Main(string[] args)
        {

            Console.WriteLine("\n\nSelecting a database table\n");
            using (var db = new NorthwindEntities())
            {
                var customers = db.Customers.ToList<Customer>();

                foreach (Customer c in customers)
                {
                    Console.WriteLine($"{c.ContactName} has username {c.CustomerID} and lives in {c.City}");
                }

            }



            Console.WriteLine("\n\nSelecting All Customers\n");
            using (var db = new NorthwindEntities())
            {
                var customerList =
                    (from customer in db.Customers
                     select customer).ToList<Customer>();

                foreach(Customer c in customerList)
                {
                    Console.WriteLine($"{c.ContactName} has username {c.CustomerID} and lives in {c.City}");
                }
            }

            Console.WriteLine("\n\nJust Customers In One City\n");
            using (var db = new NorthwindEntities())
            {
                customers =
                    (from customer in db.Customers
                     where customer.City == "London"
                     select customer).ToList<Customer>();
                foreach (Customer c in customers)
                {
                    Console.WriteLine($"{c.ContactName} has username {c.CustomerID} and lives in {c.City}");
                }

            }


            Console.WriteLine("\n\nOrdering Customers By City\n");
            using(var db = new NorthwindEntities())
            {
                customers =
                    (from customer in db.Customers
                     orderby customer.City
                     select customer).ToList<Customer>();
                foreach (Customer c in customers)
                {
                    Console.WriteLine($"{c.ContactName} has username {c.CustomerID} and lives in {c.City}");
                }      
            }

            Console.WriteLine("\n\nOutputting Custom Object\n");
            using (var db = new NorthwindEntities())
            {
                var ModifiedCustomerList =
                    (from c in db.Customers
                     orderby c.City
                     select new ModifiedCustomer { Name = c.ContactName, City = c.City, ID = c.CustomerID }).ToList();

                foreach (ModifiedCustomer c in ModifiedCustomerList)
                {
                    Console.WriteLine($"{c.Name} has username {c.ID} and lives in {c.City}" );
                }
            }




            Console.WriteLine("\n\nOutputting Custom Object\n");
            using (var db = new NorthwindEntities())
            {
                var ModifiedCustomerList =
                    (from c in db.Customers
                     orderby c.City
                     select new { Name = c.ContactName, City = c.City, ID = c.CustomerID }).ToList();

                foreach (var c in ModifiedCustomerList)
                {
                    Console.WriteLine($"{c.Name} has username {c.ID} and lives in {c.City}");
                }
            }





            Console.WriteLine("\n\nLINQ GroupBy\n");
            using (var db = new NorthwindEntities())
            {
                var CityCount =
                    (from c in db.Customers
                     group c by c.City into cities
                     orderby cities.Key descending
                     select new { City = cities.Key, Count = cities.Count() }).ToList();

                foreach (var c in CityCount)
                {
                    if (c.Count == 1)
                    {
                        Console.WriteLine($"There is {c.Count} person who lives in {c.City}");
                    }
                    else
                    {
                        Console.WriteLine($"There are {c.Count} people who live in {c.City}");
                    }
                    
                }
            }




            Console.WriteLine("\n\nLINQ Join Two Tables\n");
            using (var db = new NorthwindEntities())
            {
                var ordersByCustomer =
                    (from c in db.Customers
                     join order in db.Orders on c.CustomerID equals order.CustomerID
                     select new { id = c.CustomerID, name = c.ContactName,
                         orderid = order.OrderID, orderdate = order.OrderDate }).ToList();

                foreach (var c in ordersByCustomer)
                {
                    Console.WriteLine($"Customer {c.id} {c.name} has order {c.orderid} on {c.orderdate}");
                }
            }



            Console.WriteLine("\n\nLINQ Group Products By Category\n");
            using (var db = new NorthwindEntities())
            {
                var productsByCategory =
                    (from c in db.Categories
                     join product in db.Products on c.CategoryID equals product.CategoryID
                     select new
                     {
                         id = c.CategoryID,
                         category = c.CategoryName,
                         productID = product.ProductID,
                         name = product.ProductName
                     }).ToList();

                foreach (var p in productsByCategory)
                {
                    Console.WriteLine($"Category {p.name} with id {p.id} has product {p.name} with id {p.productID}");
                }
            }

            Console.WriteLine("\n\nNow try grouping\n\n");
            using (var db = new NorthwindEntities())
            {
                var productsByCategory =
                    (from c in db.Categories
                     join product in db.Products on c.CategoryID equals product.CategoryID
                     select new ModifiedProduct
                     {
                         id = c.CategoryID,
                         category = c.CategoryName,
                         productID = product.ProductID,
                         name = product.ProductName
                     }).GroupBy(category=>category.category)
                        .Select(category=> new {
                            name = category.Key, 
                            count = category.Count()
                        }).ToList();

                foreach (var p in productsByCategory)
                {
                    Console.WriteLine($"Category {p.name} has count {p.count}");
                }
            }



            Console.WriteLine("\n\nNumber of orders by customer\n\n");
            using (var db = new NorthwindEntities())
            {
                var customers =
                    (from c in db.Customers
                     select c).ToList<Customer>();

                Console.WriteLine("Customers");
                Console.WriteLine("==========");
                foreach (Customer c in customers)
                {
                    Console.WriteLine($"\tID {c.CustomerID} \tName\t{c.ContactName} has {c.Orders.Count} orders");
                }

                /*
                 
                 * */

            }




        }
    }

    public class ModifiedCustomer
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string ID { get; set; }
    }

    public class ModifiedProduct
    {
        public int id { get; set; }
        public string category { get; set; }
        public int productID {get;set;}
        public string name { get; set; }
    }
}
