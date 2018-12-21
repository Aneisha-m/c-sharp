using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Async_With_Callback
{
    class Program
    {

        static NorthwindEntities DBContext = new NorthwindEntities();
        static List<Customer> CustomerList01 = new List<Customer>();
        

        static void Main(string[] args)
        {
            GetCustomersSynchronous();
            Console.WriteLine("Total items were {0}", GetTotalAsynchronous().Result);

            // Now with async and await


            Console.WriteLine("Application has ended");
            Console.ReadLine();
        }

        static void GetCustomersSynchronous()
        {
            // Fully synchronous
            var customers = GetCustomers();

            var top10 = customers.Take<Customer>(10);

            CustomerList01 = top10.ToList<Customer>();

            CustomerList01.ForEach((customer) => {
                Console.WriteLine("{0} - {1}", customer.CustomerID, customer.ContactName);
            });
        }

        static IQueryable<Customer> GetCustomers()
        {
            // simulate long running
            Thread.Sleep(2000);
            Console.WriteLine("querying customers for a long time");
            return
               from customer in DBContext.Customers
               select customer;
        }

        async static Task<int> GetTotalAsynchronous()
        {
            int count = 0;
            var task01 = Task<int>.Run(()=> {
                
                for (int i = 0; i< 3; i++)
                {
                    Thread.Sleep(1000);
                    count++;
                }
                return count;
            });
            return await task01;
           
        }

            List<Customer> GetCustomersAsync()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Async query");
            var output = (from customer in DBContext.Customers
                          select customer).ToList<Customer>();
            return output;
        }


    }

    public class CustomerList : List<Customer>
    {

    }

}
