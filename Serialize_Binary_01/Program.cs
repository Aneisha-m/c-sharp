using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Serialize_Binary_01
{
    class Program
    {
        static void Main(string[] args)
        {

            Class01 instance01 = new Class01();          // create object
            instance01.n1 = 1111;                          // populate
            instance01.n2 = 4444;
            instance01.str = "Some Stringggg";
            instance01.setHidden(25);                      // hidden field : not serialized

            IFormatter formatter = new BinaryFormatter();  // create serialization object

            Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);  // create object ready to receive streaming data

            formatter.Serialize(stream, instance01);  // serialize object and output to the stream

            stream.Close();


            // deserialize now
            Console.WriteLine("==");
            Console.WriteLine("Beginning deserialization process");
            FileStream streamRead = File.OpenRead("MyFile.bin");
            Class01 instance02 = formatter.Deserialize(streamRead) as Class01;
            streamRead.Close();
            Console.WriteLine("Instance02 which has been DESERIALIAZED from the binary file");
            Console.WriteLine(instance02.n1);
            Console.WriteLine(instance02.n2);
            Console.WriteLine(instance02.str);
            Console.WriteLine("But hidden field was not serialized so is blank");
            Console.WriteLine(instance02.getHidden());

        }
    }

    // see https://docs.microsoft.com/en-us/dotnet/framework/serialization/basic-serialization

    [Serializable]
    public class Class01
    {
        [NonSerialized]
        private int _hidden_01;   // won't be included with serialization
        public int n1 = 0;
        public int n2 = 0;
        public String str = null;
        public void setHidden(int hidden)
        {
            this._hidden_01 = hidden;
        }
        public int getHidden()
        {
            return this._hidden_01;
        }
    }


}
