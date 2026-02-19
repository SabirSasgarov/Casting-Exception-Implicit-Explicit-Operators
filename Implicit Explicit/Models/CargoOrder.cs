using Implicit_Explicit.Enums;
using Implicit_Explicit.Exceptions;


namespace Implicit_Explicit.Models
{
    internal class CargoOrder
    {
        private static int ID;
        public int Id { get; }
        public int CustomerId { get; set; }
        public int CourierId { get; set; }
        public double TotalPrice { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public CargoOrder(int customerId, int curierId, double totalPrice, DateTime cratedAt, OrderStatus status = OrderStatus.Created)
        {
            CustomerId = customerId;
            CourierId = curierId;
            TotalPrice = totalPrice;
            Status = status;
            CreatedAt = cratedAt;
            ID++;
            Id = ID;
        }


        public OrderStatus UpdateStatus(OrderStatus status)
        {
            switch (status){
                case OrderStatus.Delivered:
					throw new OrderExceptions("Order has been delivered!");
                case OrderStatus.Cancelled:
					throw new OrderExceptions("Order has been cancelled!");
                default:
                    status = OrderStatus.Delivered;
					break;
			}
            return status;
        }
    }
}
