using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Northwind_CRUD
{
    class Program
    {
        static void Main(string[] args)
        {       
            using (var db = new NorthwindEntities())
            {
                string customerid = "Phil3";

                Customer newCustomer = new Customer()
                {
                    CustomerID = customerid,
                    ContactName = "Fred",
                    City = "Berlin",
                    CompanyName = "NULL",
                    Address = "NULL",
                    ContactTitle = "NULL",
                    Region = "NULL",
                    PostalCode = "NULL",
                    Country = "NULL",
                    Phone = "NULL",
                    Fax = "NULL"
                };
                db.Customers.Add(newCustomer);
                db.SaveChanges();
            }

            Console.WriteLine("\n\nInsert : check new record is present\n\n");
            using (var db = new NorthwindEntities())
            {
                var customers = db.Customers.ToList();
                foreach (Customer c in customers)
                {
                    Console.WriteLine($"{c.CustomerID,-10}{c.ContactName,-40}{c.City,-20}");
                }
            }

            using (var db = new NorthwindEntities())
            {
                // obtain your selected customer
                var selectedCustomer = db.Customers.Where(c => c.CustomerID == "Phil1").FirstOrDefault();
                // now update
                selectedCustomer.City = "Paris";
                // save back to database
                db.SaveChanges();
            }

            Console.WriteLine("\n\nUpdate : Check record has been updated\n\n");
            using (var db = new NorthwindEntities())
            {
                var customers = db.Customers.ToList();
                foreach (Customer c in customers)
                {
                    Console.WriteLine($"{c.CustomerID,-10}{c.ContactName,-40}{c.City,-20}");
                }
            }

        }
    }
}
