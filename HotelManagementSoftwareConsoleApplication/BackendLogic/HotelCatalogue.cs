

namespace HotelManagementSoftware;


public class HotelCatalogue : ILogicRepository
{
    ISQLRepository sqlRepository;
    public HotelCatalogue(ISQLRepository _sqlRepository)
    {
        sqlRepository = _sqlRepository;
    }


    public List<HotelItem> GetAllDataFromHotel()
    {
        return sqlRepository.GetData().ToList();
    }

    public int AddDataToHotel(HotelItem x)
    {

        int id = sqlRepository.AddData(x);
        return id;
    }

    public int UpdateHotelData(HotelItem x)
    {
        return sqlRepository.UpdateData(x);
    }

    public int DeleteDataFromHotel(HotelItem x)
    {
        return sqlRepository.DeleteData(x);
    }




    public List<HotelItem> GetAvailableRoomFRomHotel(DateTime checkIn)
    {
        return sqlRepository.GetAvailableRoom(checkIn).ToList();
    }
    public int AddReservation(Reservation reservation)
    {
        if (CheckRoomAvailability(reservation.RoomId, reservation.CheckIn, reservation.CheckOut))
        {
            return sqlRepository.AddData(reservation);
        }
        return 0;
    }
    public bool CheckRoomAvailability(int roomId, DateTime checkIn, DateTime checkOut)
    {
        foreach (HotelItem item in sqlRepository.GetReservationsOfOneRoom(roomId))
        {
            Reservation reservation = (Reservation)item;

            if (!(reservation.CheckIn > checkOut || reservation.CheckOut < checkIn))
            {
                return false;
            }
        }
        return true;
    }




    public List<HotelItem> SearchHotelItem(string stringValue)
    {
        List<HotelItem> foundData = new();
        foreach (HotelItem item in sqlRepository.GetData())
        {
            if (item.MyContains(stringValue)) foundData.Add(item);
        }
        return foundData;
    }
    public List<HotelItem> SearchHotelItem(int intValue)
    {
        List<HotelItem> foundData = new();
        foreach (HotelItem item in sqlRepository.GetData())
        {
            if (item.MyContains(intValue)) foundData.Add(item);
        }
        return foundData;
    }


}

