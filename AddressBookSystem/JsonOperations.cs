using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    public class JsonOperations
    {
        // method to write onto json file
        public static void WriteIntoJSONFile(Dictionary<string, AddressBookMain> contactList, string jsonFilePath)
        {
            Console.WriteLine("Writing Data into JSON File");
            //iterate over all address books
            foreach (KeyValuePair<string, AddressBookMain> kv in contactList)
            {
                string book = kv.Key;
                var contacts = kv.Value.getContacts();
                Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                using (StreamWriter stw = new StreamWriter(jsonFilePath))
                {
                    //write onto json file
                    using (JsonTextWriter writer = new JsonTextWriter(stw))
                    {
                        serializer.Serialize(writer, contacts);
                    }
                }
            }
        }
        //read from json file
        public static void ReadFromJSONFile( string jsonFilePath)
        {
            Console.WriteLine("Reading Data from JSON File");
            //deserialize objects 
            List<Contacts> records = JsonConvert.DeserializeObject<List<Contacts>>(File.ReadAllText(jsonFilePath));
            foreach (Contacts record in records)
            {
                Console.WriteLine(record);
            }
        }
    }
}