

namespace HotelManagementSoftware;

public class Reservation : HotelItem
{
    public int Id { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public int TotalCost { get; set; }
    public int CustomerId { get; set; }
    public int RoomId { get; set; }


    // Metod från ISearchable interfacet
    public override bool MyContains(int customerId)
    {
        if (CustomerId.Equals(customerId))
        {
            return true;
        }
        return false;
    }

    public override bool MyContains(string reservationId)
    {
        if (!int.TryParse(reservationId, out int result))
        {
            return false;
        }

        if (Id.Equals(result))
        {
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        return $"Bokning id: {Id}, Incheckning: {CheckIn}, Utcheckning: {CheckOut}, Total kostnad {TotalCost}, Kund id: {CustomerId}, Rum id: {RoomId}.";
    }

}

