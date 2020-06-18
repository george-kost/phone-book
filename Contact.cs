using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneBooktest
{
    [Serializable]
    class Contact :IComparable
    {
        List<Contact> contacts = new List<Contact>();
        private String first_name, last_name, work_tel, cellphone, home_tel;

        public int CompareTo(object obj)
        {
            Contact contactToCompare = obj as Contact;
            if (string.Compare(First_name, contactToCompare.First_name) ==1)
            {
                return 1;
            }
            if (string.Compare(First_name, contactToCompare.First_name) ==-1)
            {
                return -1;
            }

            // The contacts are equivalent.
            return 0;
        }
        public Contact()
        {
            first_name = String.Empty;
            last_name = String.Empty;
            work_tel = String.Empty;
            cellphone = String.Empty;
            home_tel = String.Empty;
        }

        public String First_name
        {
            set { first_name = value; }
            get { return first_name; }
        }
        public String Last_name
        {
            set { last_name = value; }
            get { return last_name; }
        }
        public String Work_tel
        {
            set { work_tel = value; }
            get { return work_tel; }
        }
        public String Cellphone
        {
            set { cellphone = value; }
            get { return cellphone; }
        }
        public String Home_tell
        {
            set { home_tel = value; }
            get { return 
                    home_tel; }
        }

       

       
    }

    
}
