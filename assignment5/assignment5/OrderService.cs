using System;
using System.Collections.Generic;
using System.Linq;

namespace assignment5
{
    public class OrderService
    {
        private List<Order> orders = new List<Order>();

        public void AddOrder(Order order)
        {
            try
            {
                if (!orders.Contains(order))
                    orders.Add(order);
                else throw new Exception("订单已存在");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"添加订单失败: {ex.Message}");
            }
        }

        public void RemoveOrder(int orderId)
        {
            var order = orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order != null)
                orders.Remove(order);
            else throw new Exception("未找到指定订单");
        }

        public void ModifyOrder(Order oldOrder, Order newOrder)
        {
            try
            {
                var index = orders.IndexOf(oldOrder);
                if (index >= 0)
                    orders[index] = newOrder;
                else throw new Exception("未找到要修改的订单");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"修改订单失败: {ex.Message}");
            }
        }

        public IEnumerable<Order> QueryOrders(Func<Order, bool> predicate)
        {
            try
            {
                return orders.Where(predicate).OrderBy(o => o.Details.Sum(d => d.Price * d.Quantity));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"查询订单失败: {ex.Message}");
                return Enumerable.Empty<Order>();
            }
        }

        public void SortOrders(Func<Order, object> keySelector)
        {
            try
            {
                orders = orders.OrderBy(keySelector).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"排序订单失败: {ex.Message}");
            }
        }
    }
}