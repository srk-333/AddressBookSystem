using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    public class CreateAddressBook
    {
        AddressBookMain addressMain = new AddressBookMain();
        //created List of class Type.
        public void ReadInput()
        {
            bool CONTINUE = true;

            //the loop continues until the user exit from program.
            while (CONTINUE)
            {
                Console.WriteLine("Enter your choice:");
                Console.WriteLine("1.Add contacts");
                Console.WriteLine("2.Display");
                Console.WriteLine("3.Edit Details");
                Console.WriteLine("4.Delete Person");
                Console.WriteLine("0.Exit");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddDetails(addressMain);
                        break;
                    case 2:
                        addressMain.DisplayContact();
                        break;
                    case 3:
                        Console.WriteLine("Enter the first name of person");
                        string name = Console.ReadLine();
                        addressMain.EditContact(name);
                        break;
                    case 4:
                        Console.WriteLine("Enter the first name of person");
                        string dName = Console.ReadLine();
                        addressMain.DeleteContact(dName);
                        break;
                    case 0:
                        CONTINUE = false;
                        break;
                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// This method is used to add a new contact.
        /// </summary>
        /// <param name="addressBookMain"></param>
        public static void AddDetails(AddressBookMain addressMain)
        {
            Console.WriteLine("Enter first Name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Address");
            string address = Console.ReadLine();
            Console.WriteLine("Enter City");
            string city = Console.ReadLine();
            Console.WriteLine("Enter State");
            string state = Console.ReadLine();
            Console.WriteLine("Enter Zipcode");
            long zipCode = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter Phone Number");
            long phoneNumber = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter Email");
            string email = Console.ReadLine();
            addressMain.AddContactDetails(firstName, lastName, address, city, state, zipCode, phoneNumber, email);
        }
    }  
}