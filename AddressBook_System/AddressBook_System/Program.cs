namespace AddressBook_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---- WELCOME TO ADDRESSBOOK SYSTEM ----");

        Home:
            Menu();

            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 0:
                    break;
                case 1:
                    AddressBook.AddContact();
                    goto Home;
                    return;
                case 2:
                    AddressBook.DisplayContact();
                    goto Home;
                    return;
                case 3:
                    AddressBook.EditContact();
                    goto Home;
                    return;

                default:
                    Console.WriteLine("\nWrong Input !");
                    return;

            }

            Console.ReadKey();
        }
        public static void Menu()
        {
            Console.WriteLine("\n1) Add Contact");
            Console.WriteLine("2) Display Contact");
            Console.WriteLine("2) Edit Contact");
            Console.WriteLine("\n\nPress 0 To Exit ! ");
            Console.Write("Enter Your Choice    : ");
        }
    }
}