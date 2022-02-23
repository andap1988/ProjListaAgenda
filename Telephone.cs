using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaAgenda
{
    internal class Telephone
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string DDD { get; set; }
        public string Phone { get; set; }
        public Telephone Next { get; set; }

        public Telephone(string type, string dDD, string phone)
        {
            ID = -1;
            Type = type;
            DDD = dDD;
            Phone = phone;
            Next = null;
        }

        public override string ToString()
        {
            return "\n\n ..:: Telefone ::..\n"
                + "\n Tipo: " + Type
                + "\n DDD: " + DDD
                + "\n Num.: " + Phone
                + "\n";
        }
    }
}
