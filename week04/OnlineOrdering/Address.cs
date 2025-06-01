public class Address
{
    private string _streetAddress;
    private string _city;
    private string _state;
    private string _country;

    public string StreetAddress
    {
        get { return _streetAddress; }
        set { _streetAddress = value; }
    }
    public string City
    {
        get { return _city; }
        set { _city = value; }
    }
    public string State
    {
        get { return _state; }
        set { _state = value; }
    }
    public string Country
    {
        get { return _country; }
        set { _country = value; }
    }

    public Address(string streetAddress, string city, string state, string country)
    {
        StreetAddress = streetAddress;
        City = city;
        State = state;
        Country = country;
    }

    public bool IsUSA()
    {
        return Country.ToLower() == "usa";
    }

    public string FullAddress()
    {
        return $"{StreetAddress}\n{City}, {State}\n{Country}";
    }

}