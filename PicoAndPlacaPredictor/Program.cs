using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicoAndPlacaPredictor
{
    class Program
    {
        static void Main(string[] args)
        {
            string PlateNumber = "";
            string QueryDate = "";
            string QueryTime = "";
            string EnteredOption = "";
            
            PicoAndPlacaMenu Menu = new PicoAndPlacaMenu();

            QuitoPicoAndPlacaManagement PicoAndPlaca = new QuitoPicoAndPlacaManagement();

            while (EnteredOption != "5")
            {
                Menu.DisplayMainMenu(PlateNumber, QueryDate, QueryTime);
                EnteredOption = Console.ReadLine();
                switch(EnteredOption)
                {
                    case "1":
                        Menu.RequestPlateNumber(ref PlateNumber);
                    break;
                    case "2":
                        Menu.RequestQueryDate(ref QueryDate);
                    break;
                    case "3":
                        Menu.RequestQueryTime(ref QueryTime);
                    break;
                    case "4":
                        Menu.DisplayMessage(PicoAndPlaca.PicoAndPlacaCheck(PlateNumber, QueryDate, QueryTime));
                    break;
                    case "5":
                    break;
                    default:
                        Menu.WrongEnteredOptionMessage();
                    break;

                }

            }
        }
    }
}
