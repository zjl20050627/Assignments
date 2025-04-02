using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment5_2
{
    class Program
    {
        static OrderService orderService = new OrderService();

        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nOrder Management System");
                Console.WriteLine("1. Add Order");
                Console.WriteLine("2. Remove Order");
                Console.WriteLine("3. Update Order");
                Console.WriteLine("4. Query Orders");
                Console.WriteLine("5. List All Orders");
                Console.WriteLine("6. Sort Orders");
                Console.WriteLine("7. Export Orders");
                Console.WriteLine("8. Import Orders");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddOrder();
                        break;
                    case "2":
                        RemoveOrder();
                        break;
                    case "3":
                        UpdateOrder();
                        break;
                    case "4":
                        QueryOrders();
                        break;
                    case "5":
                        ListAllOrders();
                        break;
                    case "6":
                        SortOrders();
                        break; 
                    case "0":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AddOrder()
        {
            try
            {
                Console.Write("Enter Order ID: ");
                string orderId = Console.ReadLine();

                Console.Write("Enter Customer ID: ");
                string customerId = Console.ReadLine();
                Console.Write("Enter Customer Name: ");
                string customerName = Console.ReadLine();
                Console.Write("Enter Customer Contact: ");
                string contactInfo = Console.ReadLine();
                Customer customer = new Customer(customerId, customerName, contactInfo);

                Order order = new Order(orderId, customer, DateTime.Now);

                bool addingDetails = true;
                while (addingDetails)
                {
                    Console.Write("Enter Product ID (or 'done' to finish): ");
                    string productId = Console.ReadLine();
                    if (productId.ToLower() == "done")
                    {
                        addingDetails = false;
                        continue;
                    }

                    Console.Write("Enter Product Name: ");
                    string productName = Console.ReadLine();
                    Console.Write("Enter Product Price: ");
                    decimal price = decimal.Parse(Console.ReadLine());
                    Product product = new Product(productId, productName, price);

                    Console.Write("Enter Quantity: ");
                    int quantity = int.Parse(Console.ReadLine());

                    order.AddDetail(new OrderDetails(product, quantity));
                }

                orderService.AddOrder(order);
                Console.WriteLine("Order added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void RemoveOrder()
        {
            try
            {
                Console.Write("Enter Order ID to remove: ");
                string orderId = Console.ReadLine();
                orderService.RemoveOrder(orderId);
                Console.WriteLine("Order removed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void UpdateOrder()
        {
            try
            {
                Console.Write("Enter Order ID to update: ");
                string orderId = Console.ReadLine();

                Console.Write("Enter new Customer ID: ");
                string customerId = Console.ReadLine();
                Console.Write("Enter new Customer Name: ");
                string customerName = Console.ReadLine();
                Console.Write("Enter new Customer Contact: ");
                string contactInfo = Console.ReadLine();
                Customer customer = new Customer(customerId, customerName, contactInfo);

                Order order = new Order(orderId, customer, DateTime.Now);

                bool addingDetails = true;
                while (addingDetails)
                {
                    Console.Write("Enter Product ID (or 'done' to finish): ");
                    string productId = Console.ReadLine();
                    if (productId.ToLower() == "done")
                    {
                        addingDetails = false;
                        continue;
                    }

                    Console.Write("Enter Product Name: ");
                    string productName = Console.ReadLine();
                    Console.Write("Enter Product Price: ");
                    decimal price = decimal.Parse(Console.ReadLine());
                    Product product = new Product(productId, productName, price);

                    Console.Write("Enter Quantity: ");
                    int quantity = int.Parse(Console.ReadLine());

                    order.AddDetail(new OrderDetails(product, quantity));
                }

                orderService.UpdateOrder(order);
                Console.WriteLine("Order updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void QueryOrders()
        {
            Console.WriteLine("\nQuery Options:");
            Console.WriteLine("1. By Order ID");
            Console.WriteLine("2. By Product Name");
            Console.WriteLine("3. By Customer Name");
            Console.WriteLine("4. By Amount Range");
            Console.Write("Select query option: ");

            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.Write("Enter Order ID (or part of it): ");
                    string orderId = Console.ReadLine();
                    DisplayOrders(orderService.QueryByOrderId(orderId));
                    break;
                case "2":
                    Console.Write("Enter Product Name (or part of it): ");
                    string productName = Console.ReadLine();
                    DisplayOrders(orderService.QueryByProductName(productName));
                    break;
                case "3":
                    Console.Write("Enter Customer Name (or part of it): ");
                    string customerName = Console.ReadLine();
                    DisplayOrders(orderService.QueryByCustomer(customerName));
                    break;
                case "4":
                    Console.Write("Enter Minimum Amount: ");
                    decimal min = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter Maximum Amount: ");
                    decimal max = decimal.Parse(Console.ReadLine());
                    DisplayOrders(orderService.QueryByAmountRange(min, max));
                    break;
                default:
                    Console.WriteLine("Invalid query option.");
                    break;
            }
        }

        static void ListAllOrders()
        {
            DisplayOrders(orderService.GetAllOrders());
        }

        static void DisplayOrders(List<Order> orders)
        {
            if (orders.Count == 0)
            {
                Console.WriteLine("No orders found.");
                return;
            }

            foreach (var order in orders)
            {
                Console.WriteLine("\n" + order);
                Console.WriteLine("----------------------");
            }
        }

        static void SortOrders()
        {
            Console.WriteLine("\nSort Options:");
            Console.WriteLine("1. By Order ID (default)");
            Console.WriteLine("2. By Total Amount");
            Console.WriteLine("3. By Order Date");
            Console.Write("Select sort option: ");

            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    orderService.SortOrders();
                    Console.WriteLine("Orders sorted by Order ID.");
                    break;
                case "2":
                    orderService.SortOrders((x, y) => x.TotalAmount.CompareTo(y.TotalAmount));
                    Console.WriteLine("Orders sorted by Total Amount.");
                    break;
                case "3":
                    orderService.SortOrders((x, y) => x.OrderDate.CompareTo(y.OrderDate));
                    Console.WriteLine("Orders sorted by Order Date.");
                    break;
                default:
                    Console.WriteLine("Invalid sort option. Using default (Order ID).");
                    orderService.SortOrders();
                    break;
            }
        }
    }

}
