using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaAgenda
{
    internal class Contact
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public TelephoneList Telephones { get; set; }
        public Contact Next { get; set; }

        public Contact(string name, string email, TelephoneList telephones)
        {
            ID = -1;
            Name = name;
            Email = email;
            Telephones = telephones;
            Next = null;
        }

        public override string ToString()
        {
            return " ..:: DADOS DO CONTATO ::.."
                + "\n Nome:\t\t " + Name
                + "\n E-mail:\t " + Email
                + "\n Telefones:\n " + Telephones.PrintList()
                + "\n ---------------------------------------";
        }

        
        
    }
}
