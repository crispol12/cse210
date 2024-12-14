using System;

class Program
{
    static void Main(string[] args)
    {
        // Create Addresses
        Address address1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Address address2 = new Address("45 Queen St", "Toronto", "ON", "Canada");

        // Create Customers
        Customer customer1 = new Customer("John Smith", address1);
        Customer customer2 = new Customer("Alice Johnson", address2);

        // Create Products
        Product prodA = new Product("Book on C#", "B001", 15.99, 2);
        Product prodB = new Product("USB Flash Drive", "U100", 9.99, 5);
        Product prodC = new Product("Wireless Mouse", "M200", 19.99, 1);
        Product prodD = new Product("Laptop Stand", "L300", 29.99, 2);

        // Create first order (Customer in USA)
        Order order1 = new Order(customer1);
        order1.AddProduct(prodA);
        order1.AddProduct(prodB);

        // Create second order (Customer outside USA)
        Order order2 = new Order(customer2);
        order2.AddProduct(prodC);
        order2.AddProduct(prodD);

        // Display information for order1
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("Total Cost: $" + order1.GetTotalCost().ToString("F2"));
        Console.WriteLine();

        // Display information for order2
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("Total Cost: $" + order2.GetTotalCost().ToString("F2"));
    }
}
