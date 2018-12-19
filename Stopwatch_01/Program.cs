using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Stopwatch_01
{
    class Program
    {
        static void Main(string[] args)
        {

    Stopwatch s = new Stopwatch();
    s.Start();

    var max = 100000000;

    for(int i = 0; i < max; i++)
    {

    }
    s.Stop();

    Console.WriteLine("took {0} milliseconds to count up to {1:0000.000}",s.ElapsedMilliseconds, max );    
            
        }
    }
}
