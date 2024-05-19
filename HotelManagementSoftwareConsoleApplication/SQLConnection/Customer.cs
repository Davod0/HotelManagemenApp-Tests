

namespace HotelManagementSoftware;

public class Customer : HotelItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }


    // Metod från ISearchable interfacet
    public override bool MyContains(int customerId)
    {
        if (Id.Equals(customerId))
        {
            return true;
        }
        return false;
    }

    public override bool MyContains(string customerName)
    {
        if (Name.Contains(customerName, StringComparison.InvariantCultureIgnoreCase))
        {
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        return $"Kund id: {Id}, Namn: {Name},  Email: {Email}, Telefon nummer: {PhoneNumber}.";
    }

}

