﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_System
{
    internal class Operations
    {
        public static Dictionary<string, AddressBook> Group = new Dictionary<string, AddressBook>();

        public static Dictionary<string, List<string>> cityDisc = new Dictionary<string, List<string>>();
        public static Dictionary<string, List<string>> StateDisc = new Dictionary<string, List<string>>();
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
            Search:
            Console.WriteLine("\n1) Search By City\n2) Search By State ");
            Console.Write("\n\n Enter Your choice       : ");
            int area = 0;
            try { area = Convert.ToInt32(Console.ReadLine()); }
            catch (FormatException e) { Console.WriteLine(e.Message); }

            switch (area)
            {
                case 1:
                    Console.Write("\nEnter City Name      :  ");
                    string cityname = Console.ReadLine();

                    cityDisc = FindByCityOrState(Group, cityDisc,cityname);
                    displayPersonDisc(cityDisc,cityname);
                    goto Search;
                    break;
                case 2:
                    Console.Write("\nEnter State Name      :  ");
                    string statename = Console.ReadLine();

                    StateDisc = FindByCityOrState(Group, StateDisc,statename);
                    displayPersonDisc(StateDisc,statename);
                    goto Search;
                    break;

                default:
                    Console.WriteLine("Wrong Input ! ");
                    break;
            }

        }

        private static Dictionary<string, List<string>> FindByCityOrState(Dictionary<string, AddressBook> group, Dictionary<string, List<string>> areaDisc,string findPlace)
        {
            foreach (var element in group)
            {
                List<string> listOfPersonsInPlace = element.Value.findPersons(findPlace);
                foreach (var name in listOfPersonsInPlace)
                {
                    if (!areaDisc.ContainsKey(findPlace))
                    {
                        List<string> personList = new List<string>();
                        personList.Add(name);
                        areaDisc.Add(findPlace, personList);
                    }
                    else
                    {

                        areaDisc[findPlace].Add(name);
                    }
                }
            }
            return areaDisc;
        }

        public static void displayPersonDisc(Dictionary<string, List<string>> areaDisc,string areaname)
        {
            int count = 0;
            foreach (var index in areaDisc)
            {

                foreach (var personName in index.Value)
                {
                    if (index.Key == areaname)
                    {
                        Console.WriteLine("\nName : " + personName + "\tArea : " + index.Key);
                        count++;
                    }
                    
                }
            }
            Console.WriteLine("\nTotal Count Of Person  : "+count);
        }
        public static void Sort()
        {
            if (Group.Count != 0)
            {
                Choose:
                listAddressBook();
                string choice;
                Console.WriteLine("\nEnter AddressBook To Sort Contacts     : ");
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
                    Group[AdBookName].SortByName();
                }
            }
            else
            {
                Console.WriteLine("\nNo AddressBook Available !");

                Console.ReadKey();
            }
          
        }

    }
}
