using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;


namespace WebAPIClient_01
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("" +
                    "http://philanderson888webapi01.cloudapp.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Console.WriteLine("GET");
                HttpResponseMessage response = await client.GetAsync("api/Person/25");
                if (response.IsSuccessStatusCode)
                {
                    Person person = await response.Content.ReadAsAsync<Person>();
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}",person.ID,person.FirstName,person.LastName,person.PayRate,person.StartDate,person.EndDate);
                }

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Console.WriteLine("GET ALL");
                response = await client.GetAsync("api/Person");
                if (response.IsSuccessStatusCode)
                {
                    List<Person> People = await response.Content.ReadAsAsync<List<Person>>();
                    foreach(Person person in People)
                    {
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", person.ID, person.FirstName, person.LastName, person.PayRate, person.StartDate, person.EndDate);
                    }
                }

                Console.WriteLine("POST");
                Person newPerson = new Person();
                newPerson.FirstName = "Paul";
                newPerson.LastName = "Jones";
                newPerson.PayRate = 212;
                newPerson.StartDate = DateTime.Parse("01/10/2018");
                newPerson.StartDate = DateTime.Parse("01/11/2018");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = await client.PostAsJsonAsync("api/Person",newPerson);
                Uri personUrl = null;
                if (response.IsSuccessStatusCode)
                {
                    personUrl = response.Headers.Location;
                    Console.WriteLine(personUrl);
                }

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Console.WriteLine("GET");
                Person personToUpdate = null;
                if (personUrl != null)
                {
                    response = await client.GetAsync(personUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        Person person = await response.Content.ReadAsAsync<Person>();
                        personToUpdate = person;
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", person.ID, person.FirstName, person.LastName, person.PayRate, person.StartDate, person.EndDate);
                    }

                }



                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                personToUpdate.LastName = "NotJonesAnyMore";
                personToUpdate.FirstName = "NotPaulAnyMore";
                Console.WriteLine("PUT");
                if (personUrl != null)
                {
                    response = await client.PutAsJsonAsync(personUrl,personToUpdate);
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Person updated successfully");
                    }

                }

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Console.WriteLine("GET");
                if (personUrl != null)
                {
                    response = await client.GetAsync(personUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        Person person = await response.Content.ReadAsAsync<Person>();
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", person.ID, person.FirstName, person.LastName, person.PayRate, person.StartDate, person.EndDate);
                    }

                }


             /*   client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Console.WriteLine("DELETE");
                if (personUrl != null)
                {
                    response = await client.DeleteAsync(personUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Person deleted successfully");
                    }

                }
                */

            }
        }
    }
}
