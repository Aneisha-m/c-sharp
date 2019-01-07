using System;
using deletemecs02;

namespace deletemecs01
{
    class Program
    {
        static void Main(string[] args)
        {
            var instance02 = new Phil();
            instance02.someNumber = 22;	    
            Console.WriteLine("Hello World! " + instance02.someNumber);
        }
    }
}
