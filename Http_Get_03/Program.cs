using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Http_Get_03
{
    class Program
    {
        static void Main(string[] args)
        {
            // Async version of http get
            GetPage();  // have to call the method which is decorated with the async keyword
            Console.WriteLine("Control has returned to the main thread even though page has not yet arrived");
            System.Threading.Thread.Sleep(10);
            Console.WriteLine("Still no page - waiting . . . ");
            Console.ReadLine();
            Console.WriteLine(File.ReadAllText("page01.html"));


        }

        async static void GetPage()
        {
            
            var pageRequest01 = WebRequest.Create("http://www.albahari.com/nutshell/code.html");
            pageRequest01.Proxy = null;
            using (var response01 = await pageRequest01.GetResponseAsync())
            {

                
                using (var stream01 = response01.GetResponseStream())
                {
                    using (var fileStream01 = File.Create("page01.html"))
                    {
                        await stream01.CopyToAsync(fileStream01);
                        Console.WriteLine("file has arrived");
                        Console.WriteLine();
                        Console.WriteLine("===================");
                        Console.WriteLine("Request information");
                        Console.WriteLine(pageRequest01.AuthenticationLevel);
                        Console.WriteLine(pageRequest01.ContentLength);
                        Console.WriteLine(pageRequest01.ContentType);
                        Console.WriteLine(pageRequest01.Credentials);
                        foreach(var item in pageRequest01.Headers)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        Console.WriteLine(pageRequest01.Headers);

                        Console.WriteLine();
                        Console.WriteLine("Getting Request Header Keys And Values");
                        foreach (var item in pageRequest01.Headers)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        string[] requestHeaderInfo = pageRequest01.Headers.AllKeys;
                        foreach (string key in requestHeaderInfo)
                        {
                            Console.WriteLine();
                            Console.WriteLine(key);
                            foreach (string value in pageRequest01.Headers.GetValues(key))
                            {
                                Console.WriteLine(value);
                            }
                        }
                        Console.WriteLine(pageRequest01.ImpersonationLevel);
                        Console.WriteLine(pageRequest01.Method);
                        Console.WriteLine(pageRequest01.RequestUri);
                        Console.WriteLine(pageRequest01.Timeout);
                        Console.WriteLine(pageRequest01.UseDefaultCredentials);
                        Console.WriteLine(pageRequest01.ToString());
                        Console.WriteLine();
                        Console.WriteLine("===================");
                        Console.WriteLine("Response information");
                        Console.WriteLine(response01.ContentLength);
                        Console.WriteLine(response01.ContentType);
                        Console.WriteLine(response01.Headers.Count);
                        Console.WriteLine();
                        Console.WriteLine("Getting Header Keys And Values");
                        foreach (var item in response01.Headers)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        string[] headerInfo = response01.Headers.AllKeys;
                        foreach (string key in headerInfo){
                            Console.WriteLine();
                            Console.WriteLine(key);
                            foreach (string value in response01.Headers.GetValues(key))
                            {
                                Console.WriteLine(value);
                            }
                        }
                        Console.WriteLine();
                        Console.WriteLine(response01.IsFromCache);
                        Console.WriteLine(response01.IsMutuallyAuthenticated);
                        Console.WriteLine(response01.ResponseUri);
                        Console.WriteLine(response01.SupportsHeaders);
                        Console.WriteLine(response01.ToString());
                        Console.WriteLine();


                    }
                }


            }
        }
    }
}
