using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment5_2
{
    public class Order : IComparable<Order>
    {
        public string OrderId { get; set; }
        public Customer Customer { get; set; }
        //添加属性方便数据绑定
        public string CustomerName => Customer?.Name;
        public DateTime OrderDate { get; set; }
        public List<OrderDetails> Details { get; set; } = new List<OrderDetails>();
        public decimal TotalAmount => Details.Sum(d => d.TotalAmount);

        public Order(string orderId, Customer customer, DateTime orderDate)
        {
            OrderId = orderId;
            Customer = customer;
            OrderDate = orderDate;
        }

        public void AddDetail(OrderDetails detail)
        {
            if (Details.Contains(detail))
            {
                throw new ArgumentException("This product already exists in the order.");
            }
            Details.Add(detail);
        }

        public void RemoveDetail(Product product)
        {
            var detail = Details.FirstOrDefault(d => d.Product.Equals(product));
            if (detail == null)
            {
                throw new ArgumentException("Product not found in order details.");
            }
            Details.Remove(detail);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Order other = (Order)obj;
            return OrderId == other.OrderId;
        }

        public override int GetHashCode()
        {
            return OrderId.GetHashCode();
        }

        public override string ToString()
        {
            var details = string.Join("\n  ", Details.Select(d => d.ToString()));
            return $"Order ID: {OrderId}\nCustomer: {Customer}\nOrder Date: {OrderDate:yyyy-MM-dd}\nTotal Amount: {TotalAmount:C}\nDetails:\n  {details}";
        }

        public int CompareTo(Order other)
        {
            return OrderId.CompareTo(other.OrderId);
        }
    }
}
