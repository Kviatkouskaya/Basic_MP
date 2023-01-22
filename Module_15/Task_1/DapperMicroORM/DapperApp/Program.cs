using System;
using System.Data;
using DapperLibrary;
using System.Configuration;
using System.Collections.Generic;

namespace DapperApp
{
    public class Program
    {
        private static IRepository<Order> _orderRepository;

        private static IRepository<Product> _productRepository;

        private static void ShowOrders(List<Order> orders)
        {
            Console.WriteLine("\n List of Orders: \n");
            foreach (var orderEntity in orders)
            {
                Console.WriteLine(orderEntity);
            }
        }

        private static void ShowProducts(List<Product> products)
        {
            Console.WriteLine("\n List of Products: \n");
            foreach (var entity in products)
            {
                Console.WriteLine(entity);
            }
        }

        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["OrderConnectionString"].ToString();

            _orderRepository = new OrderRepository<Order>(connectionString);

            /*
            var order = new Order()
            {
                Status = (int)OrderStatus.NotStarted,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                ProductId = 1
            };
            

            orderRepository.Create(order);
            orderRepository.Update(new Order()
            {
                OrderId = 29,
                Status = (int)OrderStatus.Loading,
                UpdatedDate = DateTime.Now,
                ProductId = 3
            });
            */
            var searchedOrder = _orderRepository.Get(7);
            Console.WriteLine(searchedOrder);
            /*
            var fullOrdersList = orderRepository.GetItems();
            ShowOrders(fullOrdersList);

            orderRepository.Delete(8);
            */

            _productRepository = new ProductRepository<Product>(connectionString);

            var product = new Product()
            {
                Name = "Green apple",
                Description = "Green apples",
                Weight = 50,
                Height = 1,
                Length = 0,
                Width = 0
            };

            //   productRepository.Create(product);
            /*
               productRepository.Update(new Product()
               {
                   ProductId = 8,
                   Name = "All green apple",
                   Description = "Green apples",
                   Weight = 20,
                   Height = 10,
                   Length = 1,
                   Width = 1
               });
            */
            var searchedProduct = _productRepository.Get(7);
            Console.WriteLine(searchedProduct);

            var fullProductsList = _productRepository.GetItems();
            ShowProducts(fullProductsList);

            _productRepository.Delete(8);
        }
    }
}