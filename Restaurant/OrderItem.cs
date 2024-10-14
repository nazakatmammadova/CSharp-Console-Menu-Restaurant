using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    internal class OrderItem
    {
        public MenuItem Item { get; set; }
        public int Quantity { get; set; }
        public float SubTotal { get; set; }
        public OrderItem(MenuItem item,int q)
        {
            Item = item;
            Quantity = q;
            SubTotal = item.Price*q;
        }
    }
}
