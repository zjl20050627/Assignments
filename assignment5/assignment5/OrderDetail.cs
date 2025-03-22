using System.Collections.Generic;

namespace assignment5
{
    public class OrderDetail
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is OrderDetail details)
            {
                return this.ProductName == details.ProductName && this.Price == details.Price;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hashCode = -2083043575;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ProductName);
            hashCode = hashCode * -1521134295 + Price.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"{ProductName} - {Price} * {Quantity}";
        }
    }
}