using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Classes
{
    internal abstract class Person
    {
        private string firstName;
        private string lastName;
        private string address;
       

        protected Person(string firstName, string lastName, string address)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}
