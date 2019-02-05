using System;
using System.Xml.Linq;
using static System.Console;

namespace XML_01
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("\n\nMost basic element possible\n");
            var xml = new XElement("test", 1);
            WriteLine(xml);

            WriteLine("\n\nNow add a sub-element\n");
            xml = new XElement("test", 
                new XElement("subelement",1)
                );
            WriteLine(xml);

            WriteLine("\n\nNow add several\n");
            xml = new XElement("test",
                new XElement("subelement", 1),
                new XElement("subelement", 2),
                new XElement("subelement", 3)
                );
            WriteLine(xml);

            WriteLine("\n\nNow add attributes\n");
            xml = new XElement("test",
                new XElement("subelement", 
                    new XAttribute("someattribute",11),1),
                new XElement("subelement",
                    new XAttribute("someattribute", 22), 1),
                new XElement("subelement",
                    new XAttribute("someattribute", 33), 3)
                );
            WriteLine(xml);
        }
    }
}
