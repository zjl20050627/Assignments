using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new OrderService();

            // 添加订单示例
            service.AddOrder(new Order { OrderId = 1, Customer = "张三", Details = new List<OrderDetail> { new OrderDetail { ProductName = "商品A", Price = 100, Quantity = 2 } } });

            // 查询订单示例
            var queryResult = service.QueryOrders(o => o.Customer == "张三");

            foreach (var order in queryResult)
            {
                Console.WriteLine(order);
            }

            // 删除订单示例
            try
            {
                service.RemoveOrder(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // 修改订单示例
            service.ModifyOrder(new Order { OrderId = 2 }, new Order { OrderId = 2, Customer = "李四", Details = new List<OrderDetail> { new OrderDetail { ProductName = "商品B", Price = 50, Quantity = 3 } } });
        }
    }
}
