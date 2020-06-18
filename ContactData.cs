using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace PhoneBooktest
{
    class ContactData
    {
       
        public List<Contact> createContacts() //read,return user input for contacts
        {
            Boolean stop = false;
            List<Contact> contacts = new List<Contact>();
            while (!stop)
            {

                Contact conLoading = new Contact();

                Console.WriteLine("Give first name :");
                conLoading.First_name = Console.ReadLine();

                Console.WriteLine("Give last name :");
                conLoading.Last_name = Console.ReadLine();

                Console.WriteLine("Give work number:");
                conLoading.Work_tel = Console.ReadLine();

                Console.WriteLine("Give cellphone number:");
                conLoading.Cellphone = Console.ReadLine();

                Console.WriteLine("Give home number:");
                conLoading.Home_tell = Console.ReadLine();

                contacts.Add(conLoading); //load contacts to list

                Console.WriteLine("Do you want to add another contact? (type y or n)");
                String answer = Console.ReadLine();

                if (answer.Equals("n")) stop = true;

            }
            return contacts; //returns contact list input from user

        }
        public static void saveContacts(List<Contact> contacts) //Serialize
        {
            FileStream fs = new FileStream("DataFile.dat", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();// Construct a BinaryFormatter and use it to serialize the data to the stream.
            try
            {              
                formatter.Serialize(fs, contacts);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally { fs.Close(); }
        }

        public static List<Contact> readContacts() //Deserialize
        {
            List<Contact> contacts_load = new List<Contact>();
            // Open the file containing the data that you want to deserialize.
            if (!File.Exists("DataFile.dat")|| new FileInfo("DataFile.dat").Length == 0)
            {
                saveContacts(contacts_load);
                Console.WriteLine("File created");
            }

            FileStream fs = new FileStream("DataFile.dat", FileMode.Open);                     
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                contacts_load = (List<Contact>)formatter.Deserialize(fs);
                //contacts_load = (List<Contact>)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
                     
            return contacts_load; //returns contact list from file
        }
        public static int Chose_function()
        {
            int function_choice = 0;
            Console.WriteLine("Program functions: ");
            Console.WriteLine("Type 1 to show file contacts:");
            Console.WriteLine("Type 2 to search a contact:");
            Console.WriteLine("Type 3 to edit a contact:");
            Console.WriteLine("Type 4 to delete a contact:");
            Console.WriteLine("Type 5 to insert new contact:");
            Console.WriteLine("Type 6 to Sort contacts list in alphabetical order");
            Console.WriteLine("Type 7 to exit:");
            try
            {
                function_choice = Int32.Parse(Console.ReadLine());
            }
            catch (ArgumentNullException e)
            {
                do
                {
                    Console.WriteLine("Invalid input, please type a number between 1-5");
                } while (int.TryParse(Console.ReadLine(), out function_choice));
            }
            return function_choice;
        }
        public static void printSearchMethod()
        {
            Console.WriteLine("Program functions: ");
            Console.WriteLine("Type 1 to show file contacts:");
            Console.WriteLine("Type 2 to search a contact:");
            Console.WriteLine("Type 3 to edit a contact:");
            Console.WriteLine("Type 4 to delete a contact:");
            Console.WriteLine("Type 5 to insert new contact:");
            Console.WriteLine("Type 6 to exit:");
        }
       
        public static Contact insertContact()
        {
            Contact new_contact = new Contact();
            List<Contact> contacts = new List<Contact>();

                Console.WriteLine("Give first name :");
                new_contact.First_name = Console.ReadLine();

                Console.WriteLine("Give last name :");
                new_contact.Last_name = Console.ReadLine();

                Console.WriteLine("Give work number:");
                new_contact.Work_tel = Console.ReadLine();

                Console.WriteLine("Give cellphone number:");
                new_contact.Cellphone = Console.ReadLine();

                Console.WriteLine("Give home number:");
                new_contact.Home_tell = Console.ReadLine();                       
            return new_contact;
        }
            public static void printContact(Contact person)
        {
            Console.WriteLine("First name: " + person.First_name);
            Console.WriteLine("Last name: " + person.Last_name);
            Console.WriteLine("Work number: " + person.Work_tel);
            Console.WriteLine("Cellphone number : " + person.Cellphone);
            Console.WriteLine("Home number: " + person.Home_tell);
            Console.WriteLine("------------------------------- ");

        }
        public static List<int> searchIndex(List<Contact> contacts) //returns searched contacts index
        {
            int contact_index, choice;
            String temp;          
            List<int> contacts_indexes = new List<int>();

            Console.WriteLine("Choose a method to search a contact");
            Console.WriteLine("type 1 to search by contact first name");
            Console.WriteLine("type 2 to search by contact last name");
            Console.WriteLine("type 3 to search by contact work number");
            Console.WriteLine("type 4 to search by contact cellphone number");
            Console.WriteLine("type 5 to search by contact home number");
            choice = Int32.Parse(Console.ReadLine());


            if (choice == 1) //choice 1 search by contact first name
            {
                contact_index = 0;
                Console.WriteLine("Give first name of contact");
                temp = Console.ReadLine();

                foreach (var item in contacts)
                {

                    if (item.First_name.Equals(temp))
                    {
                        contacts_indexes.Add(contact_index);
                    }
                    contact_index++;
                }
            }
            else if (choice == 2) //choice 2 search by contact last name
            {
                contact_index = 0;
                Console.WriteLine("Give last name of contact");
                temp = Console.ReadLine();
                foreach (var item in contacts)
                {
                    if (item.Last_name.Equals(temp))
                    {
                        contacts_indexes.Add(contact_index);
                    }
                    contact_index++;
                }


            }
            else if (choice == 3) //choice 3 search by contact work number
            {
                contact_index = 0;
                Console.WriteLine("Give contact work numbe");
                temp = Console.ReadLine();
                foreach (var item in contacts)
                {
                    if (item.Work_tel.Equals(temp))
                    {
                        contacts_indexes.Add(contact_index);
                    }
                    contact_index++;
                }


            }
            else if (choice == 4) //choice 4 search by contact cellphone number
            {
                contact_index = 0;
                Console.WriteLine("Give cellphone number");
                temp = Console.ReadLine();
                foreach (var item in contacts)
                {
                    if (item.Cellphone.Equals(temp))
                    {
                        contacts_indexes.Add(contact_index);
                    }
                    contact_index++;
                }


            }
            else if (choice == 5) //choice 5 search by contact home number
            {
                contact_index = 0;
                Console.WriteLine("Give contact home number ");
                temp = Console.ReadLine();
                foreach (var item in contacts)
                {
                    if (item.Home_tell.Equals(temp))
                    {
                        contacts_indexes.Add(contact_index);
                    }
                    contact_index++;
                }


            }


            return contacts_indexes;
            }


    }
}
