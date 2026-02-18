using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implicit_Explicit.Models
{
    internal class Courier
    {
        private static int ID;
        public int Id { get; }

        public string Name { get; set; }

        public bool IsAvailable { get; set; }





        public Courier(string name, bool availability)
        {
            Name = name;
            IsAvailable = availability;
            ID++;
            Id = ID;
        }

    }
}
