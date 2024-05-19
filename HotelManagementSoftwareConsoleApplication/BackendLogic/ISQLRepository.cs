

namespace HotelManagementSoftware;

public interface ISQLRepository
{
    IEnumerable<HotelItem> GetData();
    int AddData(HotelItem x);
    int UpdateData(HotelItem x);
    int DeleteData(HotelItem x);
    public IEnumerable<HotelItem> GetAvailableRoom(DateTime checkIn);
    IEnumerable<HotelItem> GetReservationsOfOneRoom(int roomId);
}

