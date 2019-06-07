using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace PicoAndPlacaPredictor
{
    class PicoAndPlacaMenu
    {
        public void DisplayMainMenu(string PlateNumber, string QueryDate, string QueryTime)
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Pico And Placa Checkup");
            Console.WriteLine("-----------------------------------------\n");
            Console.WriteLine("Enter the number of the desired option:");
            Console.Write("\n1. Enter the vehicle plate number: ");
            
           if(PlateNumber != "")
           {
                Console.Write("(Current Plate Number added is {0})", PlateNumber);
           }

           Console.Write("\n2. Enter the date of the query: ");
           if(QueryDate != "")
           {
                Console.Write("(Current Date added is {0})", QueryDate);
           }
           Console.Write("\n3. Enter the time of the query. ");

           if(QueryTime != "")
           {
                Console.Write("(Current Time added is {0})", QueryTime);
           }
            Console.WriteLine("\n4. Checkup car pico and placa. ");
            Console.WriteLine("5. Exit. ");
        }
        
        public void RequestPlateNumber(ref string PlateNumber)
        {
            Console.WriteLine("Please, enter the vehicle Plate Number. (Format: AAA####. Example: ABC1234)");
            PlateNumber = Console.ReadLine();
            var Format = new Regex(@"^\w{3}\d{4}$");

            while(Format.IsMatch(PlateNumber) != true)
            {
                Console.WriteLine("Plate Number format is incorrect, please enter it again.");
                PlateNumber = Console.ReadLine();
            }

        }

        public void RequestQueryDate(ref string QueryDate)
        {
            Console.WriteLine("Please, enter the Date of the desired query. (Format: YYYY-MM-DD. Example: 2019-12-30)");
            QueryDate = Console.ReadLine();
            DateTime Output;
            while(DateTime.TryParseExact(QueryDate,"yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out Output) == false)
            {
                Console.WriteLine("Date format is incorrect, please enter it again.");
                QueryDate = Console.ReadLine();
            }
        }

        public void RequestQueryTime(ref string QueryTime)
        {
            Console.WriteLine("Please, enter the Time of the desired query. (Format: hh:mm. Example: 17:30)");
            QueryTime = Console.ReadLine();
            TimeSpan Output;
            while(TimeSpan.TryParseExact(QueryTime,"hh':'mm", CultureInfo.InvariantCulture, out Output) == false)
            {
                Console.WriteLine("Time format is incorrect, please enter it again.");
                QueryTime = Console.ReadLine();
            }
            
        }

        public void WrongEnteredOptionMessage()
        {
            Console.WriteLine("Incorrect option, press any key and try again");
            Console.ReadKey();
        }

        public void DisplayMessage(string Message)
        {   Console.WriteLine(Message);
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }

        
    }
}
