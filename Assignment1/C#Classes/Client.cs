using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Classes
{
    internal class Client : Person
    {
        
        private bool isInProgress;
        private double costEstimateOfProject;

        public Client(string firstName, string lastName, string address, bool isInProgress, double costEstimateOfProject) : base(firstName, lastName, address) {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.IsInProgress = isInProgress;
            this.CostEstimateOfProject = costEstimateOfProject;
        }

        public bool IsInProgress { get; set; }
        public double CostEstimateOfProject { get; set; }
    }
}
