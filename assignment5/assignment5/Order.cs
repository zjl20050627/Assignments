using System.Collections.Generic;
namespace assignment5
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Customer { get; set; }
        public List<OrderDetail> Details { get; set; } = new List<OrderDetail>();

        public override bool Equals(object obj)
        {
            if (obj is Order order)
            {
                return this.OrderId == order.OrderId;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return 755918762 + OrderId.GetHashCode();
        }

        public override string ToString()
        {
            return $"OrderId: {OrderId}, Customer: {Customer}, Details: [{string.Join(", ", Details)}]";
        }
    }
}