using System;

class Program
{
    static void Main(string[] args)
    {
        // Create Addresses
        Address address1 = new Address("1504 North Main Street", "Meridian", "ID", "USA");
        Address address2 = new Address("10459 Reynolds Street", "Bonita Springs", "Florida", "USA");

        // Create Customers
        Customer customer1 = new Customer("Ava Walcott", address1);
        Customer customer2 = new Customer("Remor Pavel", address2);

        // Create Products
        Product prodA = new Product("Book on Python and Relation with AI", "B001", 15.99, 2);
        Product prodB = new Product("USB Flash Drive 100 GB", "U100", 9.99, 5);
        Product prodC = new Product("Wireless Mouse Alien Ware", "M200", 80.99, 1);
        Product prodD = new Product("Laptop Dell", "L300", 500.99, 2);

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
