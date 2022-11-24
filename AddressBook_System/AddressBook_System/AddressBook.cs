using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_System
{
    internal class AddressBook
    {
        public List<Contact> Details;


        public AddressBook()
        {
            Details = new  List<Contact>() ;
        }

        public void AddContact()
        {
            Contact contact = new Contact();
            Console.WriteLine("\n\tEnter The Following Details\n");

            Console.Write("First Name       :  ");
            string firstName = Console.ReadLine();
            bool duplicate = equals(firstName);
            contact.FirstName = firstName;

            Console.Write("Last Name        :  ");
            contact.LastName = Console.ReadLine();

            Console.Write("Contact No       :  ");
            contact.MobNumber = Console.ReadLine();

            Console.Write("E@mail           :  ");
            contact.Email = Console.ReadLine();

            Console.Write("Address          :  ");
            contact.Address = Console.ReadLine();

            Console.Write("Enter City       :  ");
            contact.City = Console.ReadLine();

            Console.Write("Enter State      :  ");
            contact.State = Console.ReadLine();

            Console.Write("Enter Zip        :  ");
            contact.Zip = Console.ReadLine();

            if (!duplicate)
            {
                Details.Add(contact);
                Console.WriteLine("\n---- Contact Added SuccessFully ----");
            }
            else
            {
                Console.WriteLine("Contact Can't be Added !");
                Console.WriteLine("Cannot Add Contact With Duplicate First Name !");
            }
        }

        private bool equals(string name)
        {
            if (this.Details.Any(e => e.FirstName.ToLower() == name.ToLower()))
                return true;
            else
                return false;
        }

        public void Edit(string firstName)
        {
            //Contact contact = null;

            foreach (Contact contact in Details)
            {


                if (firstName.Equals(contact.FirstName))
                {

                editor:
                    Console.WriteLine("\nChoose From Following List");
                    Console.WriteLine("\n1) FirstName \n2) Last Name\n" +
                                        "3) Contact No\n4) E@mail\n" +
                                        "5) City\n6) State\n7) ZipCode");
                    Console.Write("\nEnter Your Choice  :  ");
                    int choice = 0;
                    try { choice = Convert.ToInt32(Console.ReadLine()); }
                    catch (FormatException e) { Console.WriteLine(e.Message); }
                    switch (choice)
                    {
                        case 1:

                            Console.Write("Enter New First Name : ");
                            string FirstName = Console.ReadLine();
                            bool duplicate = equals(FirstName);
                            if (duplicate)
                            {
                                Console.WriteLine($"Contact {FirstName} Already Present !");
                                goto editor;
                            }
                            else
                            contact.FirstName = FirstName;
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
                            Console.Write("New City Name    : ");
                            contact.City = Console.ReadLine();
                            break;
                        case 6:
                            Console.Write("New State Name   : ");
                            contact.State = Console.ReadLine();
                            break;
                        case 7:
                            Console.Write("New Zip Code     : ");
                            contact.Zip = Console.ReadLine();
                            break;

                        default:
                            Console.WriteLine("Wrong Input !");
                            break;
                    }
                    Console.WriteLine("\nContact Edited SucessFully  ! \n");

                    //Details.Add(contact);

                    Console.WriteLine($"\nContact of {firstName} has been edited");

                    string option;
                    Console.Write("\n\nDo You Want to Edit Another Detail (Y/N) : ");
                    option = Console.ReadLine();
                    if (option == "y" || option == "Y") { goto editor; }

                    else if (option == "N" || option == "n")
                        Console.WriteLine("Back To Main Menu ! ");

                    else { Console.WriteLine("\n\nWrong Input !"); }

                }
                else
                    Console.WriteLine($"No Contact With {firstName} Name ");
            }

        }

        public void delete(string name)
        {
            bool status = false;
            Contact RemoveContact = null;
            foreach (Contact contact in Details)
            {
                if (contact.FirstName.Contains(name))
                {
                    RemoveContact = contact;
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            Details.Remove(RemoveContact);
            if (status == true)
            {
                Console.WriteLine($"Contact of {name} has been deleted");
            }
            else
                Console.WriteLine($"No Contact with Name {name}");

        }

        public void displayContact()
        {
            if (Details.Count > 0)
            {
                int count = 1;
                foreach (Contact contact in Details)
                {
                    Console.WriteLine("Contact No : " + count);
                    Console.WriteLine("\nFirst Name       : " + contact.FirstName);
                    Console.WriteLine("Last Name        : " + contact.LastName);
                    Console.WriteLine("Contact No       : " + contact.MobNumber);
                    Console.WriteLine("E-Mail           : " + contact.Email);
                    Console.WriteLine("City             : " + contact.City);
                    Console.WriteLine("State            : " + contact.State);
                    Console.WriteLine("Zip Code         : " + contact.Zip);

                    Console.WriteLine("\n--------------------------------");
                    count++;
                }
            }
            else { Console.WriteLine("\nNo Contact To Display !"); }
        }

        public void show()
        {
            foreach (Contact contact in Details)
            {
                Console.WriteLine("\n" + contact.FirstName + "   " + contact.LastName);

            }
        }








    }

}
