using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management.Order
{
    public class Customer
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }

        public Customer(string customerName, string address)
        {
            CustomerName = customerName;
            Address = address;
        }
    }
}
