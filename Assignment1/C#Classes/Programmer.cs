using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Classes
{
    internal class Programmer : Employee
    {

        public Programmer(string firstName, string lastName, string address, double salary, int performanceRating) : base(firstName, lastName, address, salary, performanceRating) { }
        public void Work()
        {
            Console.WriteLine("Drink coffee, code, repeat");
        }
    }
}
