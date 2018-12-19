using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LINQ_with_XML
{
    class Program
    {
        static void Main(string[] args)
        {
            // unfinished

            XDocument xmlDoc01 = XDocument.Load("XMLdata.xml");
            Console.WriteLine(xmlDoc01);

            var movies = from m in xmlDoc01.Descendants("movie")
                         where m.Attribute("release").Value == ""
                         select m;
            movies.ToList().ForEach(m => m.Attribute("release").Value = "2013");

            int counter = 0;
            Console.WriteLine("counting");
            movies.ToList().ForEach(m => { counter++;  Console.WriteLine(counter); } );
            foreach (var movie in movies)
            {

            }
        }
    }
}
