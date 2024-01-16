using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Classes
{
    internal abstract class Employee : Person
    {
        private double salary;
        private int performanceRating;

        protected Employee(string firstName, string lastName, string address, double salary, int performanceRating) : base(firstName, lastName, address)
        {
            this.Salary = salary;
            this.PerformanceRating = performanceRating;
        }

        public void ComputePayCheck() 
        {
            double paycheck = this.Salary / 52;
            decimal paycheckRounded = Math.Round((decimal)paycheck, 2, MidpointRounding.AwayFromZero);
            Console.WriteLine($"{this.FirstName} {this.LastName} is paid ${paycheckRounded} every two weeks");
        }

        public void ComputePayRaise()
        {
            if (this.PerformanceRating > 5)
            {
                double payRaise = this.Salary * 0.10;
                decimal payRaiseRounded = Math.Round((decimal)payRaise, 2, MidpointRounding.AwayFromZero);
                Console.WriteLine($"{this.FirstName} {this.LastName} is getting a pay raise of: ${payRaiseRounded}");
            }
            else
            {
                Console.WriteLine($"{this.FirstName} {this.LastName} is not getting a pay raise");
            }
        }

        public double Salary { get; set; }
        public int PerformanceRating { get; set; }
    }
}
