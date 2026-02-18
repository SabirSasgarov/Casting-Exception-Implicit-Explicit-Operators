using Implicit_Explicit.Models;
using Implicit_Explicit.Services;
using Implicit_Explicit.Enums;
using Implicit_Explicit.Exceptions;
namespace Implicit_Explicit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICargoService service = new CargoService();

            Customer customer1 = new Customer("Sabir","Sumqayit");
            Customer customer2 = new Customer("Arzu", "Baki");
            service.AddCustomer(customer1);
            service.AddCustomer(customer2);


            Courier courier1 = new Courier("Ali", true);
			Courier courier2 = new Courier("Ferid", true);
            service.AddCourier(courier1);
            service.AddCourier(courier2);

			CargoOrder newOrder1 = new CargoOrder(3,1,200,DateTime.Now);
            try
            {
                service.CreateOreder(newOrder1);
            }
            catch (OrderExceptions ex)
            {
				Console.WriteLine(ex.Message);
            }

		}
	}
}
