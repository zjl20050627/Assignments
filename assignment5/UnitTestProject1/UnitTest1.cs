using System;
using assignment5;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddOrder()
        {
            var service = new OrderService();
            var order = new Order { OrderId = 1,Customer = "张三" ,Details = new List<OrderDetail> { new OrderDetail { ProductName="商品A",Price = 100,Quantity =2 } } };
            service.AddOrder(order);
            //利用LINQ查询订单是否被正确添加
            var addedOrder = service.QueryOrders(o => o.OrderId == 1).FirstOrDefault();
            Assert.IsNotNull(addedOrder, "订单未被成功添加");
            Assert.AreEqual(order.Customer, addedOrder.Customer, "客户名称不匹配");
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "订单已存在")]
        public void TestAddDuplicateOrder()
        {
            var service = new OrderService();
            var order = new Order { OrderId = 1, Customer = "张三" };

            service.AddOrder(order);
            service.AddOrder(order); // 应该抛出异常
        }

        [TestMethod]
        public void TestRemoveOrder()
        {
            var service = new OrderService();
            var order = new Order { OrderId = 1, Customer = "李四" };
            service.AddOrder(order);

            service.RemoveOrder(1);

            // 确认订单已被移除
            var removedOrder = service.QueryOrders(o => o.OrderId == 1).FirstOrDefault();
            Assert.IsNull(removedOrder, "订单未被成功移除");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "未找到指定订单")]
        public void TestRemoveNonExistingOrder()
        {
            var service = new OrderService();
            service.RemoveOrder(999); // 尝试删除不存在的订单
        }

        [TestMethod]
        public void TestModifyOrder()
        {
            var service = new OrderService();
            var originalOrder = new Order { OrderId = 1, Customer = "王五", Details = new List<OrderDetail> { new OrderDetail { ProductName = "商品B", Price = 50, Quantity = 3 } } };
            service.AddOrder(originalOrder);

            var modifiedOrder = new Order { OrderId = 1, Customer = "赵六", Details = new List<OrderDetail> { new OrderDetail { ProductName = "商品C", Price = 60, Quantity = 4 } } };
            service.ModifyOrder(originalOrder, modifiedOrder);

            var updatedOrder = service.QueryOrders(o => o.OrderId == 1).FirstOrDefault();
            Assert.IsNotNull(updatedOrder, "修改后的订单不存在");
            Assert.AreEqual(modifiedOrder.Customer, updatedOrder.Customer, "客户名称未正确更新");
            Assert.IsTrue(modifiedOrder.Details.SequenceEqual(updatedOrder.Details), "订单明细未正确更新");
        }
    }
}
