using DbLibrary;
using System;
using System.Collections.Generic;

namespace OrdersApp
{
    public class Program
    {
        private static void ShowOrders(List<OrderEntity> orders)
        {
            Console.WriteLine("\n List of Orders: \n");
            foreach (var orderEntity in orders)
            {
                Console.WriteLine(orderEntity);
            }
        }

        private static void ShowProducts(List<ProductEntity> products)
        {
            Console.WriteLine("\n List of Products: \n");
            foreach (var entity in products)
            {
                Console.WriteLine(entity);
            }
        }

        static void Main(string[] args)
        {
            var productRepository = new ProductRepository<ProductEntity>();

            var product = new ProductEntity()
            {
                Name = "Green apple",
                Description = "Green apples",
                Weight = 50,
                Height = 1,
                Length = 0,
                Width = 0
            };

            productRepository.InsertItem(product);
            productRepository.UpdateItem(new ProductEntity()
            {
                ProductId = 8,
                Name = "All green apple",
                Description = "Green apples",
                Weight = 20,
                Height = 10,
                Length = 1,
                Width = 1
            });

            var searchedProduct = productRepository.SelectItemById(8);
            Console.WriteLine(searchedProduct);

            var fullProductsList = productRepository.SelectAll();
            ShowProducts(fullProductsList);

            productRepository.DeleteItem(8);


            var orderRepository = new OrderRepository<OrderEntity>();
            var order = new OrderEntity()
            {
                Status = Status.NotStarted,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                ProductId = 1
            };


            orderRepository.InsertItem(order);
            orderRepository.UpdateItem(new OrderEntity()
            {
                OrderId = 8,
                Status = Status.Loading,
                UpdatedDate = DateTime.Today,
                ProductId = 3
            });

            var searchedOrder = orderRepository.SelectItemById(8);
            Console.WriteLine(searchedOrder);

            var fullOrdersList = orderRepository.SelectAll();
            ShowOrders(fullOrdersList);

            orderRepository.DeleteItem(8);

            var ordersFiltered = orderRepository.SelectByFilter("Status", 1);
            ShowOrders(ordersFiltered);

            var ordersFiltered1 = orderRepository.SelectByFilter("Product", 2);
            ShowOrders(ordersFiltered1);

            var ordersFiltered2 = orderRepository.SelectByFilter("Month", 1);
            ShowOrders(ordersFiltered2);

            var ordersFiltered3 = orderRepository.SelectByFilter("Year", 2023);
            ShowOrders(ordersFiltered3);

            orderRepository.DeleteBulkByCriterion("Status", 0);
            orderRepository.DeleteBulkByCriterion("Product", 2);
            orderRepository.DeleteBulkByCriterion("Month", 1);
            orderRepository.DeleteBulkByCriterion("Year", 2023);

            var resultAfterDelete = orderRepository.SelectAll();
            ShowOrders(resultAfterDelete);
        }
    }
}
