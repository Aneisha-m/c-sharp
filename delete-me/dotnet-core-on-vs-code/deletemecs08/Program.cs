using System;
using static System.Console;
using System.Diagnostics;

namespace deletemecs08
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            for (int i = 1; i <= 100; i++)
            {
                if ((i % 3 == 0) && (i % 5 == 0))
                {
                    Write(" fizzbuzz ");
                    continue;
                }
                else if (i % 3 == 0)
                {
                    Write(" fizz ");
                    continue;
                }
                else if (i % 5 == 0)
                {
                    Write(" buzz ");
                    continue;
                }
                Write($" {i} ");
            }

            Trace.WriteLine("hello");
            Debug.WriteLine("world");
            Trace.WriteLine("hello");
            
        }
    }
}
