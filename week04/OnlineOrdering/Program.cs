using System;

class Program
{
    static void Main(string[] args)
    {
       //order one - c in usa
        Address address1 = new Address("123 Maple Street", "Rexburg", "ID", "USA");
        Customer customer1 = new Customer("Rachel Simmons", address1);
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Wireless Mouse", "A100", 24.99, 2));
        order1.AddProduct(new Product("Mechanical Keyboard", "A101", 79.99, 1));
        order1.AddProduct(new Product("USB-C Hub", "A102", 34.50, 1));

        // order two - c in peru
        Address address2 = new Address("Calle Ayacucho 245", "Arequipa", "Arequipa", "Peru");
        Customer customer2 = new Customer("Mariana Flores", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Standing Desk Mat", "B200", 45.00, 1));
        order2.AddProduct(new Product("Desk Lamp", "B201", 22.75, 2));

        Console.WriteLine("order 1");
        Console.WriteLine("packing :");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine("shipping label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice():0.00}");
        Console.WriteLine(new string('-', 50));

        Console.WriteLine("order 2");
        Console.WriteLine("packing :");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine("shipping label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice():0.00}");
        Console.WriteLine(new string('-', 50));
    }
}
