using System;
using DataAccess;


namespace ConsoleApp;
public static class Program
{
    private static void ShowOrders(List<OrderModel> orders)
    {
        Console.WriteLine("\n List of Orders: \n");

        foreach (var orderEntity in orders)
        {
            Console.WriteLine(orderEntity);
        }
    }

    private static void ShowProducts(List<ProductModel> products)
    {
        Console.WriteLine("\n List of Products: \n");

        foreach (var entity in products)
        {
            Console.WriteLine(entity);
        }
    }

    public static void Main(string[] args)
    {

        var productRepo = new ProductRepository();
        var orderRepository = new OrderRepository();

        productRepo.Create(new ProductModel()
        {
            Description = "Description",
            Height = 1,
            Length = 1,
            Name = "Some name",
            Weight = 1,
            Width = 1,
        });

        var product = productRepo.Get(9);
        Console.WriteLine(product);

        product.Description = "OOOOp";
        product.Height = 1;
        product.Length = 1;
        product.Name = "Name";
        product.Weight = 1;
        product.Width = 1;

        productRepo.Update(product);
        var productList = productRepo.GetItems();
        ShowProducts(productList);

        productRepo.Delete(9);

        var productModelsAfterDeletion = productRepo.GetItems();
        ShowProducts(productModelsAfterDeletion);

        orderRepository.Create(new OrderModel()
        {
            Status = 0,
            CreatedDate = DateTime.Now,
            UpdatedDate = DateTime.Now,
            ProductId = 2
        });

        var order = orderRepository.Get(8);
        Console.WriteLine(order);

        order.Status = 0;
        order.UpdatedDate = DateTime.Now;
        order.ProductId = 3;

        orderRepository.Update(order);
        var orderList = orderRepository.GetItems();
        ShowOrders(orderList);

        orderRepository.Delete(8);

        var ordersModelsAfterDeletion = orderRepository.GetItems();
        ShowOrders(ordersModelsAfterDeletion);

        var t = orderRepository.SelectByFilter("status", 0);
        ShowOrders(t);

        orderRepository.DeleteBulkByCriterion("status", 2);
        ShowOrders(orderRepository.GetItems());
    }
}
