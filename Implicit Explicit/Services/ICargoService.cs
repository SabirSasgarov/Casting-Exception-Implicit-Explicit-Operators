using Implicit_Explicit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implicit_Explicit.Services
{
    internal interface ICargoService
    {
        public void AddCustomer(Customer newCustomer);

        public void AddCourier(Courier newCurier);

        public void CreateOreder(CargoOrder newOrder);

        public void CompleteOrder(int id);
    }
}
