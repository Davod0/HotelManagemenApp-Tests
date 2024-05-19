

namespace HotelManagementSoftware;
public class UI
{
    ILogicRepository logicRepository;

    public UI(ILogicRepository _logicRepository)
    {
        logicRepository = _logicRepository;
    }

    public List<HotelItem> GetAllDataFromLogic()
    {
        return logicRepository.GetAllDataFromHotel();
    }

    public int AddDataToLogic(HotelItem x)
    {
        return logicRepository.AddDataToHotel(x);
    }

    public int UpdateLogicData(HotelItem x)
    {
        return logicRepository.UpdateHotelData(x);
    }

    public int DeleteDataFromLogic(HotelItem x)
    {
        return logicRepository.DeleteDataFromHotel(x);
    }

    public List<HotelItem> GetAvailableRoomFromLogic(DateTime x)
    {
        return logicRepository.GetAvailableRoomFRomHotel(x);
    }
    public int AddReservationToLogic(Reservation reservation)
    {
        return logicRepository.AddReservation(reservation);
    }

    public List<HotelItem> SearchItem(string stringValue)
    {
        return logicRepository.SearchHotelItem(stringValue);
    }

    public List<HotelItem> SearchItem(int intValue)
    {
        return logicRepository.SearchHotelItem(intValue);
    }

}
