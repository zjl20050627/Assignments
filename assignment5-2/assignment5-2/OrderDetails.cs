using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment5_2
{
    public class OrderDetails
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount => Product.Price * Quantity;
        //添加属性方便数据绑定
        public string ProductName => Product?.Name;
        public decimal ProductPrice => Product?.Price ?? 0;


        public OrderDetails(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            OrderDetails other = (OrderDetails)obj;
            return Product.Equals(other.Product);
        }

        public override int GetHashCode()
        {
            return Product.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Product}, Quantity: {Quantity}, Subtotal: {TotalAmount:C}";
        }
    }
}
