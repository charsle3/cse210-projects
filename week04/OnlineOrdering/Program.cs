using System;

class Program
{
    static void Main(string[] args)
    {
        List<Order> orders = new List<Order>(); //empty list

        Address utah = new Address("4 bland st.", "Provo", "UT", "USA"); //first order
        Customer john = new Customer("John Smith", utah);
        Order fish = new Order(john);

        Product herring = new Product("Pickled Herring", "JX-Herring-5", 2.5, 12);
        fish.NewProduct(herring);

        Product tuna = new Product("Chicken of the Sea", "JX-tuna-33", .99, 4);
        fish.NewProduct(tuna);


        Address moscow = new Address("32 cherenkov", "Moscow", "", "Russia"); //second order
        Customer vlad = new Customer("Vladimir Petrov", moscow);
        Order longJohns = new Order(vlad);

        Product boxers = new Product("Wool Boxers", "T-44", 5.99, 7);
        longJohns.NewProduct(boxers);

        Product underArmor = new Product("Underarmor Shirt", "F-34s", 7.99, 7);
        longJohns.NewProduct(underArmor);

        Product onesie = new Product("Penguin Onsie", "P-111", 22, 7);
        longJohns.NewProduct(onesie);

        orders.Add(fish); //add orders to empty list
        orders.Add(longJohns);

        string display = "";

        foreach (Order order in orders)//format packing and shipping labels
        {
            display += $"Products:\n{order.GetPacking()}Total: ${order.GetTotal()}\n\n{order.GetShipping()}\n";
        }

        Console.WriteLine(display); //output display
    }
}