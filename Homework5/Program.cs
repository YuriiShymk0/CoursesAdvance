using System;
using System.IO;
using System.Text.Json;

namespace Homework5
{
    /*
     * Write a program that will serialize a simple object of class User (with fields string name, int age iEnum seniority) in Json string.
     * But!
     * 1) The received Json term needs to be encrypted that it was impossible to understand from the text what information contains
     * in the middle and to write down in a file (to think up own encryption algorithm);
     * 
     * 2) Implement deserialization together with decoding.
     */
    class Program
    {
        private const int _lvlEncrypt = 6;
        private static string _stringForDeserialize = "";

        static void Main(string[] args)
        {
            User user = new User()
            {
                Age = 23,
                Name = "John",
                Seniority = "3"
            };

            string jsonstrforserilialize = JsonSerializer.Serialize<User>(user);

            Console.WriteLine("Serialized user : " + jsonstrforserilialize);

            Console.WriteLine("\nEncrypted Json string : " + EncryptionJson(jsonstrforserilialize));

            Console.WriteLine("\nSerilalized Json file :" + Serilalizer("User.json", jsonstrforserilialize));

            Console.WriteLine("\nDeserilalized Json file :" + Deserilalizer("User.json"));
        }

        private static string Serilalizer(string roadtofile, string dataforserealize)
        {
            _stringForDeserialize = JsonSerializer.Serialize(EncryptionJson(dataforserealize));
            File.WriteAllText(roadtofile, _stringForDeserialize);
            return _stringForDeserialize;
        }

        private static string Deserilalizer(string roadtofile)
        {
            string jsonstr = File.ReadAllText(roadtofile);
            _stringForDeserialize = JsonSerializer.Deserialize<string>(jsonstr);
            return DecryptionJson(_stringForDeserialize);
        }

        private static string EncryptionJson(string jsonStrForEncrypt)
        {
            string EncryptedStr = "";
            foreach (var item in jsonStrForEncrypt)
            {
                EncryptedStr += (char)((short)item << _lvlEncrypt);
            }
            return EncryptedStr;
        }
        private static string DecryptionJson(string encryptedjsonStr)
        {
            string DecryptedStr = "";
            foreach (var item in encryptedjsonStr)
            {
                DecryptedStr += (char)((short)item >> _lvlEncrypt);
            }
            return DecryptedStr;
        }

    }
}
