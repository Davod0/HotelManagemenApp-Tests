namespace UtilityLibrary;


public class Library
{



    public static string GetString(string message)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(message);
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            else
            {
                Console.WriteLine("Ogiltig inmatning! försök igen.");
                Console.ReadKey();
            }
        }
    }

    public static int GetInt(string message)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(message);
            if (int.TryParse(Console.ReadLine(), out int input))
            {
                return input;
            }
            else
            {
                Console.WriteLine("Ogiltig inmatning! försök igen.");
                Console.ReadKey();
            }
        }
    }

    public static bool GetYesOrNO(string message)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(message);
            string input = Console.ReadLine().ToLower();
            if (input == "ja")
            {
                return true;
            }
            else if (input == "nej")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Ogiltig inmatning! svara med ja eller nej!");
                Console.ReadKey();
            }

        }
    }

    public static DateTime GetDateTime(string message)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(message);
            if (DateTime.TryParse(Console.ReadLine(), out DateTime input))
            {
                return input;
            }
            else
            {
                Console.WriteLine("Ogiltig inmatning! försök igen (yyyy,MM,dd).");
                Console.ReadKey();
            }
        }
    }

    public static DateOnly GetDateOnly(string message)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(message);
            if (DateOnly.TryParse(Console.ReadLine(), out DateOnly input))
            {
                return input;
            }
            else
            {
                Console.WriteLine("Ogiltig inmatning! försök igen (yyyy,MM,dd):");
                Console.ReadKey();
            }
        }
    }




    public static string SafeReadFile(string message)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(message);
            var filePath = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(filePath))
            {
                if (File.Exists(filePath))
                {
                    return File.ReadAllText(filePath);
                }
                else
                {
                    Console.WriteLine("Filen hittades inte! Ange sök adressen utan citationstecken (\" \") ");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Ogiltig inmatning!");
                Console.WriteLine("Vill du försöka igen! Ja/Nej");
                string userChoice = Console.ReadLine();
                if (userChoice == "Nej" || userChoice == "nej")
                {
                    return null;
                }
            }
        }
    }


    public static string ReadFileContents(string message)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(message);
            var filePath = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(filePath))
            {
                if (File.Exists(filePath))
                {
                    StreamReader reader = new StreamReader(filePath);
                    return reader.ReadToEnd();
                }
                else
                {
                    Console.WriteLine("Filen hittades inte! Ange sök adressen utan citationstecken (\" \") ");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Ogiltig inmatning!");
                Console.WriteLine("Vill du försöka igen? ja/nej");
                string userChoice = Console.ReadLine();
                if (userChoice == "nej" || userChoice == "Nej")
                {
                    return null;
                }
            }

        }

    }





}
