using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_System
{
    internal class FileReadORWrite
    {
        public static string path = @"C:\Users\NRP\Desktop\BATCH_207\GIT\AddressBook_System\AddressBook_System\AddressBook_System\DataFiles\Contacts.txt";

        // Writes the file.
        public static void WriteFile(List<Contact> contacts)
        {
            if (File.Exists(path))
            {
                using (StreamWriter streamWriter = File.AppendText(path))
                {
                    foreach (Contact contact in contacts)
                    {
                        streamWriter.WriteLine(contact.toString()); ;
                    }
                    streamWriter.Close();
                }
                Console.WriteLine("\nSucessFully write into txt file");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("\nFile Not Found !");
            }
        }

        // Reads the file.
        public static void readFile()
        {
            if (File.Exists(path))
            {
                using (StreamReader streamReader = File.OpenText(path))
                {
                    string data = String.Empty;
                    while ((data = streamReader.ReadLine()) != null)
                    {
                        Console.WriteLine(data);
                    }
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("\nFile Not Found !");
            }
        }
    }
}
