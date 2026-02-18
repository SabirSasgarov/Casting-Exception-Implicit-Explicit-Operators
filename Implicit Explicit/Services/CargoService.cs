using Implicit_Explicit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implicit_Explicit.Services
{
    internal class CargoService : ICargoService
    {
        Customer[] customers = new Customer[0];
        Courier[] couriers = new Courier[0];
        CargoOrder[] cargoOrders = new CargoOrder[0];


        public void AddCustomer(Customer newCustomer)
        {
            Array.Resize(ref customers, customers.Length + 1);
            customers[customers.Length - 1] = newCustomer;
        }

        public void AddCourier(Courier newCurier)
        {
            Array.Resize(ref couriers, couriers.Length + 1);
            couriers[couriers.Length - 1] = newCurier;
        }

        public void CreateOreder(CargoOrder newOrder)
        {
            




        }
    }
}
