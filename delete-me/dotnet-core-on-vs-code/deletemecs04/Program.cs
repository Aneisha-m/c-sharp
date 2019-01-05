using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace deletemecs04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Custom c = new Custom
            {
                name = "fred"
            };

            c.name = "bob";

            var xx = GetPerson1();
            var yy = GetPerson2();

            WriteLine(xx.Item1);
            WriteLine(xx.Item2);
            WriteLine(xx.ToString());
            WriteLine(yy.Item1);
            WriteLine(yy.Item2);
            WriteLine(yy.ToString());

            Tuple<string, int> GetPerson1()
            {
                return Tuple.Create("Bob", 22);
            }

            // C#7 tuple declaration
            (string, int) GetPerson2()
            {
                return ("Bob", 22);
            }

            (string name, int age) GetPerson3()
            {
                return ("Jill", 33);
            }

            WriteLine($"{GetPerson3().name} is {GetPerson3().age}");

            string x = default;
            WriteLine($"x is {x}");

            // assign tuples to variables

            var tuple01 = GetPerson3();

            WriteLine($"{tuple01.name} has age {tuple01.age}");

            // deconstruct

            (string name, int age) = tuple01;

            WriteLine($"{name} has age {age}");

            var c1 = new Complex(1, 2);
            var c2 = new Complex(3, 4);
            var c3 = c1 + c2;
            WriteLine($"{c1} plus {c2} is {c3}");



        }
    }

    public class Custom
    {
        public string name { get; set; }
    }
}
