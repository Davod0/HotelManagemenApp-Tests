

namespace HotelManagementSoftware;

public class Room : HotelItem
{
    public int Id { get; set; }
    public int RoomNumber { get; set; }
    public string Type { get; set; }
    public int Price { get; set; }


    public override bool MyContains(int roomNumber)
    {
        if (RoomNumber.Equals(roomNumber))
        {
            return true;
        }
        return false;
    }

    public override bool MyContains(string typeOfRoom)
    {
        if (Type.Contains(typeOfRoom, StringComparison.InvariantCultureIgnoreCase))
        {
            return true;
        }
        return false;
    }


    public override string ToString()
    {
        return $"Rum id: {Id}, Nummer: {RoomNumber}, typ: {Type}, Pris: {Price}.";
    }
}

