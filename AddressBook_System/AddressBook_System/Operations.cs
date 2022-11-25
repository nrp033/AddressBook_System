using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_System
{
    internal class Operations
    {
        public static Dictionary<string, AddressBook> Group = new Dictionary<string, AddressBook>();
        public static void AddAddressBooks()
        {
        Multi:
            Console.Write("\nEnter the Name For New AddressBook : ");
            string AdBookName = Console.ReadLine();
            if (Group.ContainsKey(AdBookName))
            {
                int i = 1;
                Console.WriteLine("\nName already exist");
                Console.Write("\nAvailable names are : ");
                foreach (KeyValuePair<string, AddressBook> check in Group)
                {
                    Console.Write(i + "." + check.Key + "  ");
                    i++;
                }
                Console.WriteLine("");
            }
            else
            {
                AddressBook adressBook = new AddressBook();
                Group.Add(AdBookName, adressBook);

                Console.Write("\nDo You Want To Another AddressBook (Y/N) : ");
                string choice = Console.ReadLine();
                while (choice == "Y" || choice == "y")
                {
                    goto Multi;
                }


            }


        }

        private static void listAddressBook()
        {
            foreach (KeyValuePair<string, AddressBook> check in Group)
            {
                Console.Write("* " + check.Key + "   ");

            }
        }
        public static void MultiContact()
        {
            if (Group.Count != 0)
            {

                listAddressBook();

            Choose:
                string choice;
                Console.Write("\n\nEnter Name of the address book you want to use : ");
                string AdBookName = Console.ReadLine();
                if (!Group.ContainsKey(AdBookName))
                {
                    Console.Write("\nAddress book " + AdBookName + " not found \n\nAvailable names are : \n");
                    foreach (KeyValuePair<string, AddressBook> check in Group)
                    {
                        Console.Write("* " + check.Key + "  ");

                    }
                    goto Choose;
                }
                else
                {
                    Group[AdBookName].AddContact();
                    Console.Write("\nDo You Want Add Another Contact (Y/N) : ");
                    choice = Console.ReadLine();
                    while (choice == "Y" || choice == "y")
                    {
                        Group[AdBookName].AddContact();
                        Console.Write("\nDo You Want Add Another Contact (Y/N) : ");
                        choice = Console.ReadLine();
                    }

                }
            }
            else
            {
                Console.WriteLine("\nAddressBook  Empty !" +
                    "\nFirst Create the AddressBook\n" +
                    "\nPress Any Key To Returnt Menu !\n");
                Console.ReadKey();
            }
        }
        public static void DisplayContacts()
        {
            if (Group.Count == 0)
            {
                Console.WriteLine("\nAddress book list is empty");
                Console.WriteLine("\nPress Any key To Exit");
                Console.ReadKey();
                return;
            }
            else
            {
                listAddressBook();
                Console.Write("\nEnter the Adress book name to display contact :  ");
                string AdBookName = Console.ReadLine();
                Group[AdBookName].displayContact();
            }
        }

        public static void EditContact()
        {
            if (Group.Count == 0)
            {
                Console.WriteLine("\nAddress book list is empty");
                Console.WriteLine("\nPress Any key To Exit");
                Console.ReadKey();
                return;
            }
            else
            {
                listAddressBook();
                Console.Write("\nEnter the Name of Address :  ");
                string AdBookName = Console.ReadLine();
                if (Group.ContainsKey(AdBookName))
                {
                    Group[AdBookName].show();

                    Console.Write("Enter first name to edit contact     :  ");
                    string name = Console.ReadLine();
                    Group[AdBookName].Edit(name);

                }
            }
        }

        public static void RemoveContact()
        {
            if (Group.Count != 0)
            {

            Choose:
                listAddressBook();
                string choice;
                Console.Write("\n\nEnter Name of the address book you want to use : ");
                string AdBookName = Console.ReadLine();
                if (!Group.ContainsKey(AdBookName))
                {
                    Console.Write("\nAddress book " + AdBookName + " not found \n\nAvailable names are : \n");
                    foreach (KeyValuePair<string, AddressBook> check in Group)
                    {
                        Console.Write("* " + check.Key + "  ");

                    }
                    goto Choose;
                }
                else
                {

                    Group[AdBookName].show();
                    Console.Write("\n\nPlease Enter Name of Person Remove : ");
                    string FirstName = Console.ReadLine();
                    Group[AdBookName].delete(FirstName);
                }
            }
            else
            {
                Console.WriteLine("\nAddressBook  Empty !" +
                    "\nFirst Create the AddressBook" +
                    "\nPress Any Key To Returnt Menu !\n");
                Console.ReadKey();

            }
        }
        public static void Search()
        {
            SearchByCityOrState(Group);
        }
        public static void SearchByCityOrState(Dictionary<string, AddressBook> Group)
        {
            if (Group.Count > 0) 
            {
                bool check = false;
            searchpoint:
                Console.Write("\n1) Serch By City" +
                    "\n2) Search By State" +
                    "\n\nEnter Your Choice      :");
                int option = 0;
                try { option = Convert.ToInt32(Console.ReadLine()); }
                catch (FormatException) { Console.WriteLine("\n Integer Expected !");goto searchpoint; }
                switch (option)
                {
                    case 1:
                        Console.Write("\nEnter the City Name     : ");
                        string cityname = Console.ReadLine();
                        foreach (var element in Group)
                        {
                            string name = element.Value.SearchByCity(cityname);
                            if (name != null)
                            {
                                Console.WriteLine(name);
                                check = true;
                            }
                        }
                        if (check == false)
                        {
                            Console.WriteLine($"\nNo Contact With the City Name Entered ! ");
                        }
                        goto searchpoint;
                        break;

                        case 2:
                        Console.Write("\nEnter the State Name    : ");
                        string stateName = Console.ReadLine();
                        foreach (var element in Group)
                        {
                            string name = element.Value.SearchByState(stateName);
                            if (name != null)
                            {
                                Console.WriteLine(name);
                                check = true;
                            }
                        }
                        if (check == false)
                        {
                            Console.WriteLine($"\nNo Contact With the State Name Entered ! ");
                        }
                        goto searchpoint;
                        break;

                    default:
                        Console.WriteLine("\nWrong Input !");
                        break;
                }
               
            }
            else
                Console.WriteLine("\n No AddressBook To Store Contact !");
            
        }
    }
}
