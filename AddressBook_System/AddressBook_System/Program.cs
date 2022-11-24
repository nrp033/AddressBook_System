namespace AddressBook_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---- WELCOME TO ADDRESSBOOK SYSTEM ----");
            AddressBook.AddContact();
            AddressBook.DisplayContact();

            Console.ReadKey();
        }
    }
}