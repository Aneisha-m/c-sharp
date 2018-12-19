using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AsyncAndAwait_01
{
    class Program
    {
        static void Main(string[] args)
        {

            // Note : also see Dispatcher_02

            Console.WriteLine("Control in main thread BEFORE ASYNC CALLED");
            ReadFileAsync();
            Console.WriteLine("Control in main thread AFTER ASYNC CALLED");
        }

        private async static void ReadFileAsync()
        {
            char[] buffer;

            Console.WriteLine("Control in Method BEFORE ASYNC CALLED");

            using (var reader = new StreamReader("abc.txt"))
            {
                buffer = new char[(int)reader.BaseStream.Length];
                await reader.ReadAsync(buffer, 0, (int)reader.BaseStream.Length);
            }
            Console.WriteLine(new String(buffer));

            Console.WriteLine("Control in Method AFTER ASYNC CALLED");
        }
    }


}
