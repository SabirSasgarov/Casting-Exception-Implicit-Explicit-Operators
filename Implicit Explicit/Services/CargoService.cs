using Implicit_Explicit.Exceptions;
using Implicit_Explicit.Models;

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
			Console.WriteLine("Customer hass been added!");
        }

        public void AddCourier(Courier newCurier)
        {
            Array.Resize(ref couriers, couriers.Length + 1);
            couriers[couriers.Length - 1] = newCurier;
			Console.WriteLine("Courier has been added!");
        }

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
					Console.WriteLine("Order has been added to the queue!");
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

        public void CompleteOrder(int id)
        {
			foreach (var order in cargoOrders)
			{
                if (id == order.Id)
                {
                    order.Status = order.UpdateStatus(order.Status);
					foreach (var courier in couriers)
					{
						if(courier.Id==order.CourierId)
                        {
                            courier.IsAvailable = true;
							Console.WriteLine("Oreder hase been delivered!");
                            return;
						}
					}
                    return;
				}
				throw new OrderExceptions("Order was not found!");
			}
		}

	}
}