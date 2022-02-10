using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    public class AddressBookMain
    {
        //Collection Class
        private List<Contacts> contactList;
        //Constructor.
        public AddressBookMain()
        {
            this.contactList = new List<Contacts>();
        }
        //Method to Add Contact
        public void AddContactDetails(string firstName, string lastName, string address, string city, string state, long zipCode, long phoneNumber, string email)
        {
            Contacts contactDetails = new Contacts(firstName, lastName, address, city, state, zipCode, phoneNumber, email);
            this.contactList.Add(contactDetails);
        }
        //Display Contact
        public void DisplayContact()
        {
            //cheks if ContactList is empty or not.
            if (this.contactList.Count != 0)
            {
                foreach (Contacts data in this.contactList)
                {
                    data.Display();
                }
            }
            else
                Console.WriteLine("No Contacts in AddressBook \n");
        }
        //Method to Edit Contact 
        public void EditContact(string name)
        {
            // checks for every object whether the name is equal the given name
            foreach (Contacts data in this.contactList)
            {
                if (data.firstName.Equals(name))
                {
                    Console.WriteLine("Enter your choice:");
                    Console.WriteLine("1. Last Name");
                    Console.WriteLine("2. Address");
                    Console.WriteLine("3. City");
                    Console.WriteLine("4. State");
                    Console.WriteLine("5. Zip");
                    Console.WriteLine("6. Phone Number");
                    Console.WriteLine("7. Email");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            data.lastName = Console.ReadLine();
                            Console.WriteLine("Data updated successfully \n");
                            break;
                        case 2:
                            data.address = Console.ReadLine();
                            Console.WriteLine("Data updated successfully \n");
                            break;
                        case 3:
                            data.city = Console.ReadLine();
                            Console.WriteLine("Data updated successfully \n");
                            break;
                        case 4:
                            data.state = Console.ReadLine();
                            Console.WriteLine("Data updated successfully \n");
                            break;
                        case 5:
                            data.zipCode = Convert.ToInt64(Console.ReadLine());
                            Console.WriteLine("Data updated successfully \n");
                            break;
                        case 6:
                            data.phoneNumber = Convert.ToInt64(Console.ReadLine());
                            Console.WriteLine("Data updated successfully \n");
                            break;
                        case 7:
                            data.email = Console.ReadLine();
                            Console.WriteLine("Data updated successfully \n");
                            break;
                        default:
                            Console.WriteLine("Enter Valid Choice! \n");
                            break;
                    }
                }
                else
                    Console.WriteLine("No Contact With this Name! \n");
            }
        }
        //Method to Delete a Person
        public void DeleteContact(string dName)
        {
            foreach (Contacts ct in this.contactList)
            {
                if (ct.firstName.Equals(dName))
                {
                    this.contactList.Remove(ct);
                    Console.WriteLine("Contact Deleted! \n");
                    break;
                }
            }
        }
    }
}