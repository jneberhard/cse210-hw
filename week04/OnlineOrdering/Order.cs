using System.Reflection;

public class Order
{
    private List<Product> products = new List<Product>();

    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;
        foreach (var product in products)
        {
            total += product.GetTotal();
        }
        double shipping = customer.InUSA() ? 5.0 : 35.0;
        return total + shipping;
    }

    public string PackingLabel()
    {
        string label = "Packing Label: \n";
        foreach (var product in products) 
        {
            label += $"Product: {product.Name}, ID: {product.ProductId}\n";
        }
        return label;
    }

    public string ShippingLabel()
    {
        return $"Shipping Label: \n{customer.Name}\n{customer.Address.FullAddress()}";
    }
    


}