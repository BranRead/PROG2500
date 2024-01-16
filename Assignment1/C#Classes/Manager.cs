using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Classes
{
    internal class Manager : Employee
    {
        public Manager(string firstName, string lastName, string address, double salary, int performanceRating) : base(firstName, lastName, address, salary, performanceRating) { }

        public void FirePerson() {
            Console.WriteLine("You're fired!");
        }
    }
}
