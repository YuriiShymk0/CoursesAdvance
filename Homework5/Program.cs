using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Homework5
{
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

            Console.WriteLine("\nDecrypted Json string : " + DecryptionJson(_stringForDeserialize));

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
            return _stringForDeserialize;
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
