using System;

class Program
{
    static void Main(string[] args)
    {
        //Order #1
        Address addr1 = new Address("268 E 100 S", "Blanding", "Utah", "USA");
        Customer cust1 = new Customer("Bob Jones", addr1);
        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("1909S VDB Lincoln Cent", "011909SAU95", 789.34, 1));
        order1.AddProduct(new Product("1950D Jefferson Nickel", "051950DMS63", 62.89, 1));

        //Order #2
        Address addr2 = new Address("Calle Reforma 123", "Colonia Roma Norte", "Ciudad de Mexico", "Mexico");
        Customer cust2 = new Customer("Juan Bautista", addr2);
        Order order2 = new Order(cust2);
        order2.AddProduct(new Product("1 Oz Libertad, 1992", "1IB1992", 56.45, 2));
        order2.AddProduct(new Product("1 Oz Silver Round, Generic", "AU1OZGEN", 36.59, 6));


        Console.WriteLine(order1.PackingLabel());  // print packing label
        Console.WriteLine(order1.ShippingLabel());   //printing shipping label
        Console.WriteLine($"Total Price: ${order1.GetTotalCost():F2}\n");   //printing total price
        Console.WriteLine("NEXT ORDER");
        Console.WriteLine(order2.PackingLabel());
        Console.WriteLine(order2.ShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalCost():F2}\n");



    }
}