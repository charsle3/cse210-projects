public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void NewProduct(Product product) //used to insert products
    {
        _products.Add(product);
    }

    public double GetTotal() //total up price of each product (as modified by quantity), and figure out shipping
    {
        double total = 0;

        foreach (Product product in _products) //accumulate total
        {
            total += product.GetTotal();
        }

        if (_customer.IsUSA()) //shipping fees logic
        {
            total += 5;
        }
        else
        {
            total += 35;
        }

        return total;
    }

    public string GetPacking() //stack up each product name
    {
        string packingLabel = "";

        foreach (Product product in _products)
        {
            packingLabel += product.GetPacking();    
        }

        return packingLabel;
    }

    public string GetShipping() //pull formatted address from member variable
    {
        return _customer.GetShipping();
    }
}