using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest_01
{
    class Program
    {
        static void Main(string[] args)
        {
            x object01 = new x();
            object01.ChangeY();
            object01.ChangeY();
            object01.ChangeY();
            object01.ChangeY();
            object01.ChangeY();
            object01.ChangeY();
            object01.ChangeY();
            object01.ChangeY();
            object01.ChangeY();
            object01.ChangeY();
            object01.ChangeY();
            object01.ChangeY();
            object01.ChangeY();
            object01.ChangeY();
        }
    }


    public class x
    {
        public int y { get; set; }
        public int ChangeY()
        {
            if (y < 10)              // max 10
            {
                y++;
            }
            Console.WriteLine(y);
            return y;
        }
    }
}
