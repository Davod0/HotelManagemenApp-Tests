namespace HotelManagementSoftware;


using System.Data;
using System.Data.SqlClient;
using Dapper;



public class DBContext : ISQLRepository
{
    public static IDbConnection connection = new SqlConnection("Server=localhost,1433;User=sa;Password=apA123!#!;Database=HotellManagementSoftware;");

    public static string sql;

    private void OpenDBConnection()
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();
    }


    public IEnumerable<HotelItem> GetData()
    {
        List<HotelItem> hotelItems = new List<HotelItem>();

        OpenDBConnection();

        sql = "SELECT id, roomNumber, type, price FROM Room;";
        IEnumerable<Room> rooms = connection.Query<Room>(sql);
        hotelItems.AddRange(rooms);

        sql = "SELECT id, name, email, phoneNumber FROM Customer;";
        IEnumerable<Customer> customers = connection.Query<Customer>(sql);
        hotelItems.AddRange(customers);

        sql = "SELECT id, checkIn, checkOut, totalCost, customerId, roomId FROM Reservation;";
        IEnumerable<Reservation> reservations = connection.Query<Reservation>(sql);
        hotelItems.AddRange(reservations);

        connection.Close();
        return hotelItems;
    }


    public int AddData(HotelItem x)
    {
        OpenDBConnection();
        var transaction = connection.BeginTransaction();
        try
        {
            if (x is Customer _customer)
            {
                // Customer _customer = (Customer)x;
                sql = "INSERT INTO Customer(name, email, phoneNumber) VALUES (@Name, @Email, @PhoneNumber);SELECT SCOPE_IDENTITY();";
                int customerId = connection.QuerySingle<int>(sql, _customer, transaction);
                transaction.Commit();
                return customerId;
            }
            else if (x is Room _room)
            {
                // Room _room = (Room)x;
                sql = "INSERT INTO Room(roomNumber, type, price) VALUES(@RoomNumber, @Type, @Price); SELECT SCOPE_IDENTITY(); ";
                int roomId = connection.QuerySingle<int>(sql, _room, transaction);
                transaction.Commit();
                return roomId;
            }
            else if (x is Reservation _reservation)
            {
                // Reservation _reservation = (Reservation)x;
                sql = "INSERT INTO Reservation(checkIn, checkOut, totalCost, customerId, roomId) OUTPUT INSERTED.id VALUES( @CheckIn, @CheckOut, @TotalCost, @CustomerId, @RoomId)";
                int reservationId = connection.QuerySingle<int>(sql, _reservation, transaction);
                transaction.Commit();
                return reservationId;
            }
        }
        catch (Exception e)
        {
            transaction.Rollback();
            Console.WriteLine($"Transaktions fel: {e.Message}");
        }
        finally
        {
            connection.Close();
        }
        return 0;
    }


    public int UpdateData(HotelItem x)
    {
        OpenDBConnection();
        var transaction = connection.BeginTransaction();
        try
        {
            if (x is Customer _customer)
            {
                // Customer _customer = (Customer)x;
                sql = "UPDATE Customer SET name = @Name, email = @Email, phoneNumber = @PhoneNumber OUTPUT INSERTED.id WHERE id = @Id;";
                int customerId = connection.QuerySingle<int>(sql, _customer, transaction);
                transaction.Commit();
                return customerId;
            }
            else if (x is Room _room)
            {
                // Room _room = (Room)x;
                sql = "UPDATE Room SET roomNumber = @RoomNumber, type = @Type, price = @Price OUTPUT INSERTED.id WHERE id = @Id; ";
                int roomId = connection.QuerySingle<int>(sql, _room, transaction);
                transaction.Commit();
                return roomId;
            }
            else if (x is Reservation _reservation)
            {
                // Reservation _reservation = (Reservation)x;
                sql = "UPDATE Reservation SET checkIn = @CheckIn, checkOut = @CheckOut, totalCost = @TotalCost, customerId = @CustomerId, roomId = @RoomId OUTPUT INSERTED.id WHERE id = @Id;";
                int reservationId = connection.QuerySingle<int>(sql, _reservation, transaction);
                transaction.Commit();
                return reservationId;
            }
        }
        catch (Exception e)
        {
            transaction.Rollback();
            Console.WriteLine($"Transaktions fel: {e.Message}");
        }
        finally
        {
            connection.Close();
        }
        return 0;
    }


    public int DeleteData(HotelItem x)
    {
        OpenDBConnection();
        var transaction = connection.BeginTransaction();
        try
        {
            if (x is Customer _customer)
            {
                // Customer _customer = (Customer)x;
                sql = "DELETE FROM Customer OUTPUT DELETED.id WHERE id = @Id;";
                int customerId = connection.QuerySingle<int>(sql, _customer, transaction);
                transaction.Commit();
                return customerId;
            }
            else if (x is Room _room)
            {
                // Room _room = (Room)x;
                sql = "DELETE FROM Room OUTPUT DELETED.id WHERE id = @Id;";
                int roomId = connection.QuerySingle<int>(sql, _room, transaction);
                transaction.Commit();
                return roomId;
            }
            else if (x is Reservation _reservation)
            {
                // Reservation _reservation = (Reservation)x;
                sql = "DELETE FROM Reservation OUTPUT DELETED.id WHERE id = @Id;";
                int reservationId = connection.QuerySingle<int>(sql, _reservation, transaction);
                transaction.Commit();
                return reservationId;
            }
        }
        catch (Exception e)
        {
            transaction.Rollback();
            Console.WriteLine($"Transaktions fel: {e.Message}");
        }
        finally
        {
            connection.Close();
        }
        return 0;
    }


    public IEnumerable<HotelItem> GetAvailableRoom(DateTime checkIn)
    {
        OpenDBConnection();

        sql = "SELECT roomId FROM Reservation WHERE checkOut >= @checkIn";
        List<int> reservedRoomId = connection.Query<int>(sql, new { checkIn }).ToList();

        sql = $"SELECT id FROM Room;";
        List<int> allRoomId = connection.Query<int>(sql).ToList();

        List<int> availableRoomId = allRoomId.Except(reservedRoomId).ToList();

        sql = "SELECT * FROM Room WHERE id IN @availableRoomId";
        List<Room> availableRooms = connection.Query<Room>(sql, new { availableRoomId }).ToList();

        if (availableRooms.Count > 0) // Om det finns någon bokning i systemet returneras denna listan
        {
            return availableRooms;
        }

        sql = "SELECT id, roomNumber, type, price FROM Room;";  // Annars returneras listan med alla rum
        IEnumerable<Room> allRooms = connection.Query<Room>(sql);
        connection.Close();
        return allRooms;
    }


    public IEnumerable<HotelItem> GetReservationsOfOneRoom(int roomId)
    {
        OpenDBConnection();
        var transaction = connection.BeginTransaction();
        try
        {
            string sql = "SELECT * FROM Reservation WHERE roomId=@RoomID";
            List<Reservation> reservationsOfOneRoom = connection.Query<Reservation>(sql, new { roomId = roomId }, transaction).ToList();
            transaction.Commit();
            connection.Close();
            return reservationsOfOneRoom;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Transaction faild: {e.Message}");
            transaction.Rollback();
            throw;
        }

    }


}


