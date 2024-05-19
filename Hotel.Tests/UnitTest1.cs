namespace Hotel.Tests;

using HotelManagementSoftware;


public class UnitTest1
{
    [Fact]
    public void CheckRoomAvailability_AvailableRoom_ReturnTrue()
    {
        // Arrange 
        HotelCatalogue ht = new(new TestRepositoryStub());

        // Act 
        bool actual = ht.CheckRoomAvailability(10, new DateTime(2023, 10, 21), new DateTime(2023, 10, 30));

        // Assert
        Assert.True(actual);
    }




    [Fact]
    public void CheckRoomAvailability_UnAvailableRoom_ReturnFalse()
    {
        // Arrange 
        HotelCatalogue ht = new(new TestRepositoryStub());

        // Act 
        bool actual = ht.CheckRoomAvailability(10, new DateTime(2023, 10, 10), new DateTime(2023, 10, 20));

        // Assert
        Assert.False(actual);
    }
}



public class TestRepositoryStub : ISQLRepository
{
    public IEnumerable<HotelItem> GetData()
    {
        throw new NotImplementedException();
    }
    public int AddData(HotelItem x)
    {
        {
            throw new NotImplementedException();
        }
    }
    public int UpdateData(HotelItem x)
    {
        {
            throw new NotImplementedException();
        }
    }
    public int DeleteData(HotelItem x)
    {
        {
            throw new NotImplementedException();
        }
    }
    public IEnumerable<HotelItem> GetAvailableRoom(DateTime checkIn)
    {
        throw new NotImplementedException();
    }



    public IEnumerable<HotelItem> GetReservationsOfOneRoom(int roomId)
    {
        List<Reservation> reservations = new();

        Reservation r = new()
        {
            Id = 1,
            CheckIn = new DateTime(2023, 10, 10),
            CheckOut = new DateTime(2023, 10, 20),
            RoomId = 10
        };
        reservations.Add(r);
        return reservations;
    }

}


