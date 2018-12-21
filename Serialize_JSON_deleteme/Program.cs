using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;  // have to add reference to System.Runtime.Serialization first
using System.IO;

namespace Serialize_DataContractJSON
{
    class Program
    {
        static void Main(string[] args)
        {

            BlogSite bsObj = new BlogSite()
            {
                Name = "C-sharpcorner",
                Description = "Share Knowledge"
            };

            Console.WriteLine("==Serializing JSON using DataContractSerializer==\n");
            // Create serialization object
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(BlogSite));
            // Stream serialized object to Memory
            MemoryStream msObj = new MemoryStream();
            js.WriteObject(msObj, bsObj);

            // Read object back
            msObj.Position = 0;
            StreamReader sr = new StreamReader(msObj);
            // "{\"Description\":\"Share Knowledge\",\"Name\":\"C-sharpcorner\"}"  
            string json = sr.ReadToEnd();
            Console.WriteLine(json);
            sr.Close();
            msObj.Close();



            // Deserialize

            // string json = "{\"Description\":\"Share Knowledge\",\"Name\":\"C-sharpcorner\"}";

            Console.WriteLine("\n\n==DeSerializing JSON using DataContractSerializer==\n");
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                // Deserialization from JSON  
                DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(BlogSite));
                BlogSite bsObj2 = (BlogSite)deserializer.ReadObject(ms);
                Console.WriteLine("Name: " + bsObj2.Name); // Name: C-sharpcorner
                Console.WriteLine("Description: " + bsObj2.Description); // Description: Share Knowledge  
            }



        }
    }

    [DataContract]
    class BlogSite
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }
    }


}
