using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace PhoneBooktest
{
    class Program
    {        
        static void Main(string[] args)
        {
            int con_number = 0;
            List<Contact> contacts = new List<Contact>();
            List<int> contact_index = new List<int>();
            contacts = ContactData.readContacts();
            int operation=0;
            while (operation!=7)
            {               
                operation = ContactData.Chose_function();
                if (operation == 1) //show contacts
                {
                    if (contacts.Count == 0)
                    {
                        Console.WriteLine("Contacts list is empty!");
                        Console.WriteLine("");
                    }
                    foreach (var item in contacts)
                    { ContactData.printContact(item); }
                }
                else if (operation == 2) //search contacts
                {
                    foreach (var index in ContactData.searchIndex(contacts))
                    {
                        ContactData.printContact(contacts[index]);
                    }
                }     
                else if (operation == 3) //edit contacts
                { String newInfo=" ";
                    int chose;
                    char stop;
                    //con_number = ContactData.searchIndex(contacts).Count;
                    contacts = ContactData.readContacts();
                    contact_index = ContactData.searchIndex(contacts);
                    while (contact_index.Count != 1)

                    {
                        Console.WriteLine("Your search criteria has more than one results.");
                        Console.WriteLine("Please use a unique search key like phone number");
                        Console.WriteLine("Do you want to keep searching? Type y or n");
                        stop = Char.Parse(Console.ReadLine());
                        if (stop.Equals('n')) break;
                        con_number = ContactData.searchIndex(contacts).Count;
                                          
                    }
                    //contact_index = ContactData.searchIndex(contacts);
                    if (contacts.Count == 0) Console.WriteLine("Contacts list is Empty!");
                    else
                    {
                        ContactData.printContact(contacts[contact_index[0]]);
                    }
                    Console.WriteLine("Type a number to chose the corresponding info you want to change");
                    Console.WriteLine("1 for firstname, 2 for lastname, 3 for work number, 4 for cellphone, 5 for home");
                    Console.WriteLine("");
                    chose = Int32.Parse(Console.ReadLine());
                   
                    if (chose == 1) {
                        Console.WriteLine("Give a new firstname");
                        newInfo = Console.ReadLine();
                        contacts[contact_index[0]].First_name=newInfo; }
                    else if (chose == 2) {
                        Console.WriteLine("Give a new lastname");
                        newInfo = Console.ReadLine();
                        contacts[contact_index[0]].Last_name = newInfo;
                    }
                    else if (chose == 3) {
                        Console.WriteLine("Give a new work number");
                        newInfo = Console.ReadLine();
                        contacts[contact_index[0]].Work_tel = newInfo;
                    }
                    else if (chose == 4) {
                        Console.WriteLine("Give a new cellphone number");
                        newInfo = Console.ReadLine();
                        contacts[contact_index[0]].Cellphone = newInfo;
                    }
                    else if (chose == 5) {
                        Console.WriteLine("Give a new home number");
                        newInfo = Console.ReadLine();
                        contacts[contact_index[0]].Home_tell = newInfo;
                    }
                    else {
                        Console.WriteLine("Wrong input");
                            }
                    ContactData.saveContacts(contacts);
                   
                }      
                else if (operation == 4) //delete contacts
                {
                    contact_index = ContactData.searchIndex(contacts);
                    //con_number = ContactData.searchIndex(contacts).Count;
                    con_number = contact_index.Count;
                    while (con_number != 1)
                    {
                        Console.WriteLine("Your search criteria has more than one results.");
                        Console.WriteLine("Please use a unique search key like phone number");
                        Console.WriteLine("");
                        con_number = ContactData.searchIndex(contacts).Count;

                    }
                    //contact_index = ContactData.searchIndex(contacts);
                    ContactData.printContact(contacts[contact_index[0]]);
                    contacts.RemoveAt(contact_index[0]);
                    ContactData.saveContacts(contacts);
                    Console.WriteLine("contact  deleted");
                    Console.WriteLine("");
                }
                
                else if (operation == 5) //insert new contact
                {
                    contacts = ContactData.readContacts();
                    contacts.Add(ContactData.insertContact());
                    ContactData.saveContacts(contacts);
                    Console.WriteLine("contact inserted");
                    Console.WriteLine("");
                }
                else if (operation == 6) //Sort contacts list in alphabetical order
                {
                    contacts = ContactData.readContacts();
                    contacts.Sort();
                    ContactData.saveContacts(contacts);
                    Console.WriteLine("List is sorted");
                    Console.WriteLine("");
                }


                else if (operation == 7)
                { Console.WriteLine("End of program"); break; }
                else { Console.WriteLine("Wrong input,please type a number between 1-5"); }
            }

        }

    }
}
