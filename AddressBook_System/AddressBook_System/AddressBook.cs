using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_System
{
    internal class AddressBook
    {
        public static List<Contact> Details = new List<Contact>();
        public static void AddContact()
        {
            Contact contact = new Contact();

            Console.WriteLine("\n\tEnter The Following Details\n");

            Console.Write("First Name       :  ");
            contact.FirstName = Console.ReadLine();

            Console.Write("Last Name        :  ");
            contact.LastName = Console.ReadLine();

            Console.Write("E@mail           :  ");
            contact. Email = Console.ReadLine();

            Console.Write("Contact No       :  ");
            contact.MobNumber = Console.ReadLine();

            Console.Write("Address          :  ");
            contact.Address = Console.ReadLine();

            Console.Write("Enter City       :  ");
            contact.City  = Console.ReadLine();

            Console.Write("Enter State      :  ");
            contact.State = Console.ReadLine();

            Console.Write("Enter Zip        :  ");
            contact.Zip = Console.ReadLine();

                Details.Add(contact);
                Console.WriteLine("\n---- Contact Added SuccessFully ----");
        }
        public static void DisplayContact()
        {
            foreach (Contact contact in Details)
            {



                Console.WriteLine("\nFirst Name       : " + contact.FirstName);
                Console.WriteLine("Last Name        : " + contact.LastName);
                Console.WriteLine("Contact No       : " + contact.MobNumber);
                Console.WriteLine("E-Mail           : " + contact.Email);
                Console.WriteLine("Address          : " + contact.Address);
                Console.WriteLine("City             : " + contact.City);
                Console.WriteLine("State            : " + contact.State);
                Console.WriteLine("Zip Code         : " + contact.Zip);
            }


        }
            

    }
    
}
