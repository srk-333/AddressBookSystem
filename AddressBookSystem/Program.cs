using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    public class Program
    {
        //Main  Method / program Entry Point
        static void Main(string[] args)
        {
            //Showing Welcome Message On console.
            Console.WriteLine("Welcome to Address Book Progam \n");

            Console.Write("Enter First Name, Last Name, Address, City, State, Zip, Phone Number, Email \n");
            CreateAddressBook addressBook = new CreateAddressBook()  //Initializing elements using collection-initializer syntax
            {
                FirstName = Console.ReadLine(),
                LastName = Console.ReadLine(),
                Address = Console.ReadLine(),
                City = Console.ReadLine(),
                State = Console.ReadLine(),
                Zip = Convert.ToDouble(Console.ReadLine()),
                PhoneNumber = Convert.ToDouble(Console.ReadLine()),
                Email = Console.ReadLine(),
            };
            addressBook.displayContact();
            Console.ReadLine();
        }
    }
}
