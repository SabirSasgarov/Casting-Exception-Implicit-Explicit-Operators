using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Implicit_Explicit.Enums;


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


        public OrderStatus UpdateStatus()
        {
            if (Status == OrderStatus.Cancelled)
                return Status;
            if (Status == OrderStatus.Delivered)
                return Status;
            if (Status == OrderStatus.Created)
                Status = OrderStatus.OnTheWay;
            else if (Status == OrderStatus.OnTheWay)
                Status = OrderStatus.Delivered;
            return Status;
        }
    }
}
