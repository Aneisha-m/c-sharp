using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace asp_net_password_hash
{
    class Program
    {
        static void Main(string[] args)
        {
            var base64string = "AQAAAAEAACcQAAAAELZyWXHYmPNCQb8Ah5iXYHEsxh84uzoQS8/Nb1lkQ7bXPCJtdG3Wk4g/B9dgI0KzNQ==";

            var decodedbase64 = Convert.FromBase64String(base64string);

            

            foreach(var b in decodedbase64)
            {
                Console.WriteLine(b);
                File.AppendAllText("output.txt", b.ToString()+"\r\n");
                
            }

            System.Diagnostics.Process.Start("notepad.exe", "output.txt");
        }
    }
}
