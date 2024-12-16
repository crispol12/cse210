using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product p)
    {
        _products.Add(p);
    }

    public double GetTotalCost()
    {
        double sum = 0;
        foreach (Product p in _products)
        {
            sum += p.GetTotalCost();
        }

        // Add shipping cost
        double shipping = _customer.LivesInUSA() ? 5.0 : 35.0;
        return sum + shipping;
    }

    public string GetPackingLabel()
    {
        // List product name and product id for each product
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Packing Label:");
        foreach (Product p in _products)
        {
            sb.AppendLine($"{p.GetName()} (ID: {p.GetProductId()})");
        }
        return sb.ToString();
    }

    public string GetShippingLabel()
    {
        // Show customer name and address
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Shipping Label:");
        sb.AppendLine(_customer.GetName());
        sb.AppendLine(_customer.GetAddress().GetFullAddress());
        return sb.ToString();
    }
}
