using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    internal static class Restaurant
    {
        public static List<Order> Orders { get; set; } = new List<Order>();

        public static void TakeOrder(Order order)
        {
            Orders.Add(order);
        }

        public static void CompleteOrder(Order order)
        {
            Orders.Remove(order);
        }

        public static void DisplayOrders()
        {
            if(Orders.Count > 0)
            {
                foreach (var order in Orders)
                {
                    order.DisplayOrder();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sifaris yoxdur!".ToUpper());
            }
        }
    }
}
