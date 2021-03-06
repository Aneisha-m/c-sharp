﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASPCoreEntity_03_Data;

namespace ASPCoreEntiry_03_VS_SQL.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        public IEnumerable<Customer> Customers { get; set; }
        public List<string> CustomerNames { get; set; }


        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            CustomerNames = new List<string>();
            Customer SelectedCustomer;

            using (var db = new Northwind())
            {
                Customers = (from c in db.Customers select c).ToList<Customer>();
                SelectedCustomer = db.Customers.FirstOrDefault(c => c.CustomerID == "WOLZA");
                SelectedCustomer.ContactName = "Phil";
                CustomerNames.Add(SelectedCustomer.ContactName);
                CustomerNames.Add("");
                db.SaveChanges();
            }
            foreach(Customer c in Customers)
            {                
                CustomerNames.Add(c.CustomerID);
                CustomerNames.Add(c.ContactName);
                CustomerNames.Add(c.CompanyName);
            }
            return CustomerNames;
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            CustomerNames = new List<string>();
            Customer SelectedCustomer;

            using (var db = new Northwind())
            {
                Customers = (from c in db.Customers select c).ToList<Customer>();

                
                    SelectedCustomer = db.Customers.FirstOrDefault(c => c.CustomerID == "WOLZA");
                    SelectedCustomer.ContactName = "Phil";
                CustomerNames.Add(SelectedCustomer.ContactName);
                    db.SaveChanges();
                
            }
            foreach (Customer c in Customers)
            {  
                CustomerNames.Add(c.CustomerID);
                CustomerNames.Add(c.ContactName);
                CustomerNames.Add(c.CompanyName);
                CustomerNames.Add("");
            }
            return SelectedCustomer.ContactName;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            value = value ?? "WOLZA";
            CustomerNames = new List<string>();
            Customer SelectedCustomer;
            using (var db = new Northwind())
            {
                SelectedCustomer = db.Customers.FirstOrDefault(c=>c.CustomerID==value);
                SelectedCustomer.ContactName = "Phil";
                db.SaveChanges();
            }
          
            
        }
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
