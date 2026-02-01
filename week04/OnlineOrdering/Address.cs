public class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    public bool IsUSA() //used to check for shipping cost
    {
        if (_country == "USA")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public string GetShipping() //function for formatting the address
    {
        string shippingLabel = $"{_street}\n{_city}, {_state}";
        if (!IsUSA())
        {
            shippingLabel += $"{_country}";
        }

        shippingLabel += "\n";

        return shippingLabel;
    }
}