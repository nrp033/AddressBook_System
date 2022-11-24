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
        public static void MultiContacts()
        {
            AddContact();
            Console.Write("\nDo You Want To Add Another Contact (Y/N) : ");
            string check = Console.ReadLine();
            while (check == "Y" || check == "y")
            {
                AddContact();
                Console.Write("\nDo You Want To Add Another Contact (Y/N) : ");
                check = Console.ReadLine();
            }
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

        public static void EditContact()
        {

            Console.Write("\nEnter Name of Person to Edit    : ");
            string FirstName = Console.ReadLine();
            foreach (Contact contact in Details)
            {
                if (contact.FirstName == FirstName)
                {
                    editor:
                    Console.WriteLine("\nChoose From Following List");
                    Console.WriteLine("\n1) FirstName \n2) Last Name\n" +
                                        "3) Contact No\n4) E@mail\n" +
                                        "5) Address\n" +
                                        "6) City\n7) State\n8) ZipCode");
                    Console.Write("\nEnter Your Choice  :  ");
                    int choice = 0;
                    try { choice = Convert.ToInt32(Console.ReadLine()); }
                    catch (FormatException) { Console.WriteLine("Integer Expected !");goto editor; }
                    switch (choice)
                    {
                        case 1:

                            Console.Write("Enter New First Name : ");
                            contact.FirstName = Console.ReadLine();
                            break;
                        case 2:
                            Console.Write("New Last Name    : ");
                            contact.LastName = Console.ReadLine();
                            break;
                        case 3:
                            Console.Write("New Contact No   : ");
                            contact.MobNumber = Console.ReadLine();
                            break;
                        case 4:
                            Console.Write("New E@mail       : ");
                            contact.Email = Console.ReadLine();
                            break;
                        case 5:
                            Console.Write("New Address      : ");
                            contact.Address = Console.ReadLine();
                            break;
                        case 6:
                            Console.Write("New City Name    : ");
                            contact.City = Console.ReadLine();
                            break;
                        case 7:
                            Console.Write("New State Name   : ");
                            contact.State = Console.ReadLine();
                            break;
                        case 8:
                            Console.Write("New Zip Code     : ");
                            contact.Zip = Console.ReadLine();
                            break;

                        default:
                            Console.WriteLine("Wrong Input !");
                            break;
                    }
                    Console.WriteLine("\nContact Edited SucessFully  ! \n");
                }
                else
                    Console.WriteLine($"\nContact of {FirstName} Not Avalable !");
            }
        }
        public static void RemoveContact()
        {
            Console.Write("\nPlease Enter Name of Person to Edit  : ");
            string FirstName = Console.ReadLine();

            foreach (Contact contact in Details)
            {
                if (contact.FirstName.ToLower() == FirstName.ToLower())
                {
                    Details.Remove(contact);
                    Console.WriteLine($"\nContact of {FirstName} is Deleted !");
                    return;
                }
                else
                    Console.WriteLine($"Contact of {FirstName} Not Found ! ");

            }
        }


    }
    
}
