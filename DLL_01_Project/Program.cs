using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL_01;


namespace DLL_01_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassDLL_01 x = new ClassDLL_01();
            x.DLL_01_field_01 = 10;

            Console.ReadLine();
        }
    }
}
