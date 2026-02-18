using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implicit_Explicit.Models
{
    internal class Customer
    {
        private static int ID;
        public int Id { get; }
        public string Name { get; set; }
        public string City { get; set; }

        public Customer(string name, string city)
        {
            Name = name;
            City = city;
            ID++;
            Id = ID;
        }

    }
}
