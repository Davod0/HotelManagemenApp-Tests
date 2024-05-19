

namespace HotelManagementSoftware;

public interface ILogicRepository
{
    List<HotelItem> GetAllDataFromHotel();
    int AddDataToHotel(HotelItem x);
    int UpdateHotelData(HotelItem x);
    int DeleteDataFromHotel(HotelItem x);
    List<HotelItem> GetAvailableRoomFRomHotel(DateTime checkIn);
    List<HotelItem> SearchHotelItem(string stringValue);
    List<HotelItem> SearchHotelItem(int intValue);
    int AddReservation(Reservation reservation);
    bool CheckRoomAvailability(int roomId, DateTime checkIn, DateTime checkOut);
}
