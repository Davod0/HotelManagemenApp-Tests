
namespace HotelManagementSoftware;
using UtilityLibrary;

public class Menu
{
    private static DBContext database = new DBContext();
    private static HotelCatalogue logic = new HotelCatalogue(database);
    private static UI ui = new UI(logic);

    public void HeadMenu()
    {
        while (true)
        {
            Console.Clear();
            ShowMenu();

            if (int.TryParse(Console.ReadLine(), out int userChoice))
            {
                switch (userChoice)
                {
                    case 1:
                        {
                            ShowAllCustomer();
                            WaitForUserInput();
                            break;
                        }
                    case 2:
                        {
                            AddNewCustomer();
                            WaitForUserInput();
                            break;
                        }
                    case 3:
                        {
                            UpdateCustomerInfo();
                            WaitForUserInput();
                            break;
                        }
                    case 4:
                        {
                            if (FindCustomer())
                            {

                            }
                            else
                            {
                                Console.WriteLine("Ingen kund med matchande info hittades!");
                            }
                            WaitForUserInput();
                            break;
                        }
                    case 5:
                        {
                            DeleteCustomer();
                            WaitForUserInput();
                            break;
                        }
                    case 6:
                        {
                            ShowAllReservation();
                            WaitForUserInput();
                            break;
                        }
                    case 7:
                        {
                            AddNewReservation();
                            WaitForUserInput();
                            break;
                        }
                    case 8:
                        {
                            UpdateReservationInfo();
                            WaitForUserInput();
                            break;
                        }
                    case 9:
                        {
                            if (FindReservation())
                            {

                            }
                            else
                            {
                                Console.WriteLine("Ingen bokning med matchade info hittades!");
                            }
                            WaitForUserInput();
                            break;
                        }
                    case 10:
                        {
                            DeleteReservation();
                            WaitForUserInput();
                            break;
                        }
                    case 11:
                        {
                            ShowAllRoom();
                            WaitForUserInput();
                            break;
                        }
                    case 12:
                        {
                            ShowAvailableRoom();
                            WaitForUserInput();
                            break;
                        }
                    case 13:
                        {
                            UpdateRoomInfo();
                            WaitForUserInput();
                            break;
                        }
                    case 14:
                        {
                            AddNewRoom();
                            WaitForUserInput();
                            break;
                        }
                    case 15:
                        {
                            if (FindRoom())
                            {

                            }
                            else
                            {
                                Console.WriteLine("Ingen bokning med matchade info hittades!");
                            }
                            WaitForUserInput();
                            break;
                        }
                    case 16:
                        {
                            DeleteRoom();
                            WaitForUserInput();
                            break;
                        }
                    case 17:
                        {
                            Console.WriteLine("Programmet avslutades");
                            Environment.Exit(0);
                            break;
                        }
                }
            }
            else
            {
                Console.WriteLine("\nOgiltig val, försök igen!");
                Console.WriteLine("Tryck på valfri knapp för att återvända till menyn");
                Console.ReadKey();
            }
        }



    }


    private void ShowMenu()
    {
        Console.WriteLine("_______________Välkomen_____________________");
        Console.WriteLine("Välja ett av nedanstående alternativen\n");
        Console.WriteLine(" 1. Visa alla kunder: ");
        Console.WriteLine(" 2. Lägg till ny kund: ");
        Console.WriteLine(" 3. Uppdatera kund info: ");
        Console.WriteLine(" 4. Sök efter en kund: ");
        Console.WriteLine(" 5. Tabort en kund: ");
        Console.WriteLine("_______________________");
        Console.WriteLine(" 6. Visa alla bokningar: ");
        Console.WriteLine(" 7. Lägg till ny bokning:");
        Console.WriteLine(" 8. Uppdatera en bokning: ");
        Console.WriteLine(" 9. Sök efter en boknign: ");
        Console.WriteLine(" 10. Tabort en bokning: ");
        Console.WriteLine("_________________________");
        Console.WriteLine(" 11. Visa alla rum: ");
        Console.WriteLine(" 12. Visa samtliga tillgängliga rum för önskat incheckningsdatum: ");
        Console.WriteLine(" 13. Uppdatera rum info: ");
        Console.WriteLine(" 14. Lägg till ny rum: ");
        Console.WriteLine(" 15. Sök rum: ");
        Console.WriteLine(" 16. Tabort ett rum: ");
        Console.WriteLine(" 17. Avsluta programmet");
        Console.Write("\n--> ");
    }



    public void WaitForUserInput()
    {
        Console.WriteLine("\nTryck på valfri knapp för att återvända till menyn");
        Console.ReadKey();
    }


    private void ShowAllCustomer()
    {
        foreach (HotelItem item in ui.GetAllDataFromLogic())
        {
            if (item is Customer _customer)
            {
                Console.WriteLine(_customer);
                Console.WriteLine("_____________________________________________________________________");
            }
        }
    }
    private void AddNewCustomer()
    {
        Customer customer = new()
        {
            Name = Library.GetString("Ange kundens namn: "),
            Email = Library.GetString("Ange kundens Email adress: "),
            PhoneNumber = Library.GetString("Ange kundens telefon nummer: ")
        };
        int customerId = ui.AddDataToLogic(customer);
        if (customerId != 0)
        {
            Console.WriteLine($"Nya kunden registrerades i systemet och har fått id-nummer: {customerId}");
        }
        else
        {
            Console.WriteLine("Ett fel inträffades, registreringen misslyckades!");
        }
    }
    private void UpdateCustomerInfo()
    {
        Customer customer = new()
        {
            Id = Library.GetInt("Ange ID-nummer för kunden som ska få uppdatering på sin information: "),
            Name = Library.GetString("Ange kundens nya namn: "),
            PhoneNumber = Library.GetString("Ange kundens nya telefonnummer: "),
            Email = Library.GetString("Ange kundens nya Email adress: ")
        };
        int customerId = ui.UpdateLogicData(customer);
        if (customerId != 0)
        {
            Console.WriteLine($"Kunden med ID-nummer {customerId} har fått uppdatering på sin information");
        }
        else
        {
            Console.WriteLine("Ett fel inträffades, uppdatering misslyckades!");
        }
    }
    public bool FindCustomer()
    {
        int userChoice = Library.GetInt("Vill du söka efter en kund genom individens namn eller id-nummer? 1.Namn /2.Id-nummer:");
        if (userChoice == 1)
        {
            string customerName = Library.GetString("Ange namnet för kunden du söker: ");
            foreach (HotelItem x in ui.SearchItem(customerName))
            {
                if (x is Customer)
                {
                    Console.WriteLine(x);
                    return true;
                }
            }
        }
        else if (userChoice == 2)
        {

            int customerId = Library.GetInt("Ange id-nummer för kunden du söker: ");
            foreach (HotelItem x in ui.SearchItem(customerId))
            {
                if (x is Customer)
                {
                    Console.WriteLine(x);
                    return true;
                }
            }
        }
        else
        {
            Console.WriteLine("Ogiltig val!");
        }
        return false;
    }
    public void DeleteCustomer()
    {
        Customer customer = new()
        {
            Id = Library.GetInt("Ange id-nummer för kunden som ska raderas: ")
        };
        int customerId = ui.DeleteDataFromLogic(customer);
        if (customerId != 0)
        {
            Console.WriteLine($"Kunden med id-nummer: {customerId} raderades");
        }
        else
        {
            Console.WriteLine("Ett fel inträffades, raderingen misslyckades!");
        }
    }



    public void ShowAllReservation()
    {
        foreach (HotelItem item in ui.GetAllDataFromLogic())
        {
            if (item is Reservation reservation)
            {
                Console.WriteLine(reservation);
                Console.WriteLine("_____________________________________________________________________");
            }
        }
    }
    public void AddNewReservation()
    {
        Reservation reservation = new()
        {
            CheckIn = Library.GetDateTime("Ange incheknings datumet: "),
            CheckOut = Library.GetDateTime("Ange utchcknings datumet: "),
            TotalCost = Library.GetInt("Ange total kostnad för bokningen: "),
            CustomerId = Library.GetInt("Ange ID-nummer för kunden som äger bokningen:  "),
            RoomId = Library.GetInt("Ange ID-nummer för det rum där bokningen gäller:  ")

        };
        int reservationId = ui.AddReservationToLogic(reservation);
        if (reservationId != 0)
        {
            Console.WriteLine($"Nya bokningen registrerades i systemet och har fått id-nummer: {reservationId}");
        }
        else
        {
            Console.WriteLine("Ett fel inträffades, bokningen misslyckades!");
        }
    }
    public void UpdateReservationInfo()
    {
        Reservation reservation = new()
        {
            Id = Library.GetInt("Ange id nummer för den bokning som ska uppdateras: "),
            CheckIn = Library.GetDateTime("Ange nya incheknings datumet: "),
            CheckOut = Library.GetDateTime("Ange nya utchcknings datumet: "),
            TotalCost = Library.GetInt("Ange total kostnad för bokningen: "),
            CustomerId = Library.GetInt("Ange ID-nummer för kunden som äger bokningen:  "),
            RoomId = Library.GetInt("Ange ID-nummer för det rum där bokningen gäller:  ")

        };
        int reservationId = ui.UpdateLogicData(reservation);
        if (reservationId != 0)
        {
            Console.WriteLine($"Uppdatering av en bokning med id-nummer: {reservationId} lyckades");
        }
        else
        {
            Console.WriteLine("Ett fel inträffades, Uppdatering misslyckades!");
        }
    }
    public bool FindReservation()
    {
        int userChoice = Library.GetInt("Vill du söka efter en bokning genom kundens id-nummer eller boknings id-nummer? 1.kund id-nummer/ 2.boknings id-nummer:");
        bool foundReservation = false;
        if (userChoice == 1)
        {
            int customerId = Library.GetInt("Ange kundens id-nummer: ");
            foreach (HotelItem x in ui.SearchItem(customerId))
            {
                if (x is Reservation)
                {
                    foundReservation = true;
                    Console.WriteLine(x);
                    Console.WriteLine("___________________________________________________");
                }
            }
        }
        else if (userChoice == 2)
        {
            string reservationId = Library.GetString("Ange boknings id-nummer: ");
            foreach (HotelItem x in ui.SearchItem(reservationId))
            {
                if (x is Reservation)
                {
                    foundReservation = true;
                    Console.WriteLine(x);
                    Console.WriteLine("_____________________________________________________");
                }
            }
        }
        else
        {
            Console.WriteLine("Ogiltig val!");
        }
        return foundReservation;
    }
    public void DeleteReservation()
    {
        Reservation reservation = new()
        {
            Id = Library.GetInt("Ange id-nummer för bokningen som ska raderas: ")
        };
        int reservationId = ui.DeleteDataFromLogic(reservation);
        if (reservationId != 0)
        {
            Console.WriteLine($"Bokning med id-nummer: {reservationId} raderades");
        }
        else
        {
            Console.WriteLine("Ett fel inträffades, raderingen misslyckades!");
        }
    }





    public void ShowAllRoom()
    {
        foreach (HotelItem item in ui.GetAllDataFromLogic())
        {
            if (item is Room room)
            {
                Console.WriteLine(room);
                Console.WriteLine("_____________________________________________________________________");
            }
        }
    }
    public void ShowAvailableRoom()
    {
        DateTime checkIn = Library.GetDateTime("Ange önskade inchecknings datumet: ");
        foreach (HotelItem x in ui.GetAvailableRoomFromLogic(checkIn))
        {
            if (x is Room)
            {
                Console.WriteLine(x);
            }
        }
    }
    public void UpdateRoomInfo()
    {
        Room room = new()
        {
            Id = Library.GetInt("Ange id-nummer för rummet som ska uppdateras: "),
            RoomNumber = Library.GetInt("Ange nya nummer för rummet: "),
            Type = Library.GetString("Ange nya typen för rummet: "),
            Price = Library.GetInt("Ange kostnaden för rummet: "),
        };
        int roomId = ui.UpdateLogicData(room);
        if (roomId != 0)
        {
            Console.WriteLine($"Rummet med id-nummer {roomId} har fått uppdatering av sin information");
        }
        else
        {
            Console.WriteLine("Ett fel inträffades, det gick inte att uppdatera rummet!");
        }
    }
    public void AddNewRoom()
    {
        Room room = new()
        {
            RoomNumber = Library.GetInt("Ange nummer för nya rummet: "),
            Type = Library.GetString("Ange typen på rummet: "),
            Price = Library.GetInt("Ange kostnaden för rummet: "),
        };
        int roomId = ui.AddDataToLogic(room);
        if (roomId != 0)
        {
            Console.WriteLine($"Nya rummet har lagts till i systemet och har fått id-nummer: {roomId}");
        }
        else
        {
            Console.WriteLine("Ett fel inträffades, det gick inet att lägga till nytt rum!");
        }
    }
    public bool FindRoom()
    {
        int userChoice = Library.GetInt("Vill du söka efter ett rum genom rumnummer eller rumstyp? Vänligen välj: 1. Rumnummer / 2. Rumstyp: ");
        bool foundRoom = false;
        if (userChoice == 1)
        {
            int roomNumber = Library.GetInt("Ange rumnummer på det rum du söker: ");
            foreach (HotelItem x in ui.SearchItem(roomNumber))
            {
                if (x is Room)
                {
                    foundRoom = true;
                    Console.WriteLine(x);
                    Console.WriteLine("___________________________________________________");
                }
            }
        }
        else if (userChoice == 2)
        {
            string roomType = Library.GetString("Ange den typen av rum du söker: ");
            foreach (HotelItem x in ui.SearchItem(roomType))
            {
                if (x is Room)
                {
                    foundRoom = true;
                    Console.WriteLine(x);
                    Console.WriteLine("_____________________________________________________");
                }
            }
        }
        else
        {
            Console.WriteLine("Ogiltig val!");
        }
        return foundRoom;
    }
    public void DeleteRoom()
    {
        Reservation Room = new()
        {
            Id = Library.GetInt("Ange id-nummer för rummet som ska raderas: ")
        };
        int roomId = ui.DeleteDataFromLogic(Room);
        if (roomId != 0)
        {
            Console.WriteLine($"Rummet med id-nummer: {roomId} raderades");
        }
        else
        {
            Console.WriteLine("Ett fel inträffades, raderingen misslyckades!");
        }
    }




}
