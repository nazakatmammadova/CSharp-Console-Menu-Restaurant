using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    internal class Order
    {

        private static int orderNumberCounter = 1000;
        public int OrderNumber { get;private set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public float TotalPrice { get; private set; } = 0;
        public DateTime OrderTime { get; private set; } = DateTime.Now;
        public Customer Customer { get; private set; }

        public Order(Customer customer)
        {

            OrderNumber = ++orderNumberCounter;
            Customer=customer;
        }
        public void AddOrder(OrderItem orderItem)
        {
                var existingItem = OrderItems.Find(o => o.Item == orderItem.Item);
                if (existingItem != null)
                {
                    existingItem.Quantity += orderItem.Quantity;
                    existingItem.SubTotal += orderItem.SubTotal;
                }
                else
                {
                    OrderItems.Add(orderItem);
                }
                TotalPrice += orderItem.SubTotal;
        }

        public void RemoveOrder(OrderItem orderItem)
        {
            var existingItem = OrderItems.Find(o => o.Item == orderItem.Item);
            if (existingItem != null)
            {
                if (existingItem.Quantity > orderItem.Quantity)
                {
                    existingItem.Quantity -= orderItem.Quantity;
                    existingItem.SubTotal -= orderItem.SubTotal;
                }
                else
                {
                    OrderItems.Remove(existingItem);
                }
                TotalPrice -= orderItem.SubTotal;
            }
        }


        public void DisplayOrder()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Order Time: {OrderTime}");
            Console.WriteLine($"Order Number: {OrderNumber}");
            Console.WriteLine($"Customer: {Customer.Name} {Customer.Surname} ({Customer.Phone})");
            foreach (var order in OrderItems)
            {
                Console.WriteLine($"{order.Item.Name} ------ {order.Quantity} x {order.Item.Price} AZN --------- Subtotal: {order.SubTotal} AZN");
            }
            Console.WriteLine($"Total Price: {TotalPrice} AZN");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("--------------------------------------------------------------------------------");
        }
    }
}
