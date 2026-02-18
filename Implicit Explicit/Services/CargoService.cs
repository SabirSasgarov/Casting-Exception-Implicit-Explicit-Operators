using Implicit_Explicit.Exceptions;
using Implicit_Explicit.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
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

        //public override string ToString()
        //{
        //    foreach (var item in couriers)
        //    {
        //        Console.WriteLine($"{item.Id} - {item.IsAvailable}");
        //    }
        //    return " ";
        //}


        public void CreateOreder(CargoOrder newOrder)
        {
            bool hasCustomerId = false;
            bool hasCourierId = false;
            Courier newCourier = null;
            foreach (var customer in customers)
            {
                if (newOrder.CustomerId == customer.Id)
                {
                    hasCustomerId = true;
                    break;
                }
            }
			foreach (var courier in couriers)
			{
				if (newOrder.CourierId == courier.Id)
				{
                    hasCourierId = true;
                    newCourier = courier;
					break;
				}
			}

            if (hasCourierId && hasCustomerId)
            {
                if (newCourier.IsAvailable)
                {
                    newCourier.IsAvailable = false;
                    Array.Resize(ref cargoOrders, cargoOrders.Length + 1);
                    cargoOrders[cargoOrders.Length - 1] = newOrder;
                }
                else
                {
                    throw new OrderExceptions("Courier is not available!");
                }
            }
            else if (hasCustomerId)
                throw new OrderExceptions("Courier was not found!");
            else if (hasCourierId)
                throw new OrderExceptions("Customer was not found!");
            else
                throw new OrderExceptions("Nor customer or courier was found!");
		}

	}
}