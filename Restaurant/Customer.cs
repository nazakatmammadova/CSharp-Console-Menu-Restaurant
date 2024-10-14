using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    internal class Customer
    {
        private static int idCounter = 0;
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }

        public Customer(string name,string surname, string phone)
        {
            Id = ++idCounter;
            Name = name;
            Surname = surname;
            Phone = phone;
        }

    }
}
