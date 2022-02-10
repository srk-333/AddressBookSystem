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
        static AddressBookMain addressBookMain = new AddressBookMain();
        static Dictionary<string, AddressBookMain> addressBook = new Dictionary<string, AddressBookMain>();
        static Dictionary<string, List<Contacts>> cityDictionary = new Dictionary<string, List<Contacts>>();
        static Dictionary<string, List<Contacts>> stateDictionary = new Dictionary<string, List<Contacts>>();
        //created List of class Type.
        public void ReadInput()
        {
            bool CONTINUE = true;

            //the loop continues until the user exit from program.
            while (CONTINUE)
            {
                Console.WriteLine("Enter your choice:");
                Console.WriteLine("1.Add Address Book");
                Console.WriteLine("2.Add contacts");
                Console.WriteLine("3.Display");
                Console.WriteLine("4.Edit Details");
                Console.WriteLine("5.Delete Person");
                Console.WriteLine("6.Add Multiple Address Book");
                Console.WriteLine("7.Delete Any Address Book");
                Console.WriteLine("8.Display person by city or state name");
                Console.WriteLine("9.View person by city or state");
                Console.WriteLine("0.Exit");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        CreateAddressBook.AddBook();
                        break;
                    case 2:
                        AddDetails(CreateAddressBook.BookName(addressBook),cityDictionary, stateDictionary);
                        break;
                    case 3:
                        addressBookMain = CreateAddressBook.BookName(addressBook);
                        addressBookMain.DisplayContact();
                        break;
                    case 4:
                        addressBookMain = CreateAddressBook.BookName(addressBook);
                        Console.WriteLine("Enter the first name of person");
                        string name = Console.ReadLine();
                        addressBookMain.EditContact(name);
                        break;
                    case 5:
                        addressBookMain = CreateAddressBook.BookName(addressBook);
                        Console.WriteLine("Enter the first name of person");
                        string dName = Console.ReadLine();
                        addressBookMain.DeleteContact(dName);
                        break;
                    case 6:
                        AddMultipleAddressBook();
                        break;
                    case 7:
                        Console.WriteLine("Enter address book name to delete:");
                        string addressBookName = Console.ReadLine();
                        addressBook.Remove(addressBookName);
                        break;
                    case 8:
                        AddressBookMain.DisplayPerson(addressBook);
                        break;
                    case 9:
                        AddressBookMain.PrintList(cityDictionary);
                        AddressBookMain.PrintList(stateDictionary);
                        break;
                    case 0:
                        CONTINUE = false;
                        break;
                    default:
                        break;
                }
            }
        }
        //Method to create a AddressBook in Dictionary
        public static void AddBook()
        {
            Console.WriteLine("Enter address book name:");
            string addBookName = Console.ReadLine();
            addressBook.Add(addBookName, addressBookMain);
        }
        /// <summary>
        /// This method is used to add a new contact.
        /// </summary>
        /// <param name="addressBookMain"></param>
        public static void AddDetails(AddressBookMain addressMain, Dictionary<string, List<Contacts>> cityDictionary, Dictionary<string, List<Contacts>> stateDictionary)
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

            addressMain.AddContactDetails(firstName, lastName, address, city, state, zipCode, phoneNumber, email, stateDictionary, cityDictionary);
        }
        //Method to Add Multiple Contact
        public void AddMultipleAddressBook()
        {
            Console.WriteLine("How many AddressBook,you want to Add");
            int cNumber = int.Parse(Console.ReadLine());
            for (int i = 1; i <= cNumber; i++)
            {
                CreateAddressBook.AddBook();
            }
            Console.WriteLine("All Address Book Added successfully! \n");
        }
        /// <summary>
        /// method to find the address of particular address book.
        /// </summary>
        /// <param name="addBook"></param>
        /// <returns></returns>
        public static AddressBookMain BookName(Dictionary<string, AddressBookMain> addBook)
        {
            addressBook = addBook;
            Console.WriteLine("Enter address book name:");
            string name = Console.ReadLine();
            AddressBookMain address = addressBook[name];
            return address;
        }
    }  
}