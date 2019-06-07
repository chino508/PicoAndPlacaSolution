using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicoAndPlacaPredictor
{
    class QuitoPicoAndPlacaManagement
    {
        private DayOfWeek[] PlateLastDigitBlockedDate;
        private List<DayOfWeek> ExcludedDays;
        private List<DateTime> Holidays;
        public List<TimeSpan[]> ActiveTimes;

        public QuitoPicoAndPlacaManagement()
        {
            PlateLastDigitBlockedDate = new DayOfWeek[10];
            PlateLastDigitBlockedDate[0] = DayOfWeek.Friday;
            PlateLastDigitBlockedDate[1] = DayOfWeek.Monday;
            PlateLastDigitBlockedDate[2] = DayOfWeek.Monday;
            PlateLastDigitBlockedDate[3] = DayOfWeek.Tuesday;
            PlateLastDigitBlockedDate[4] = DayOfWeek.Tuesday;
            PlateLastDigitBlockedDate[5] = DayOfWeek.Wednesday;
            PlateLastDigitBlockedDate[6] = DayOfWeek.Wednesday;
            PlateLastDigitBlockedDate[7] = DayOfWeek.Thursday;
            PlateLastDigitBlockedDate[8] = DayOfWeek.Thursday;
            PlateLastDigitBlockedDate[9] = DayOfWeek.Friday;

            ExcludedDays = new List<DayOfWeek>();
            ExcludedDays.Add(DayOfWeek.Saturday);
            ExcludedDays.Add(DayOfWeek.Sunday);

            Holidays = new List<DateTime>(){
                DateTime.Parse("2019-01-01"),
                DateTime.Parse("2019-03-04"),
                DateTime.Parse("2019-03-05"),
                DateTime.Parse("2019-04-19"),
                DateTime.Parse("2019-05-03"),
                DateTime.Parse("2019-05-24"),
                DateTime.Parse("2019-08-10"),
                DateTime.Parse("2019-10-11"),
                DateTime.Parse("2019-11-01"),
                DateTime.Parse("2019-11-04"),
                DateTime.Parse("2019-12-06"),
                DateTime.Parse("2019-12-25"),
            };

            ActiveTimes = new List<TimeSpan[]>();
            TimeSpan[] ValidTimeInterval = new TimeSpan[2];
            ValidTimeInterval[0] = TimeSpan.Parse("07:00");
            ValidTimeInterval[1] = TimeSpan.Parse("09:30");
            ActiveTimes.Add(ValidTimeInterval);
            ValidTimeInterval = new TimeSpan[2];
            ValidTimeInterval[0] = TimeSpan.Parse("16:00");
            ValidTimeInterval[1] = TimeSpan.Parse("19:30");
            ActiveTimes.Add(ValidTimeInterval);

        }
        public string PicoAndPlacaCheck(string PlateNumber, string QueryDate, string QueryTime)
        {
            string ReturnMessage = "";
            string VehicleAvailability = "";

            if (PlateNumber == "" || QueryDate == "" || QueryTime == "")
            {
                ReturnMessage = "Query field/s are missing, please check the entered information and try again";
            }
            else
            {
                DateTime QueryDateInDateTimeFormat = DateTime.Parse(QueryDate);
                DayOfWeek QueryDayOfWeek = QueryDateInDateTimeFormat.DayOfWeek;
                TimeSpan QueryTimeInTimeSpanFormat = TimeSpan.Parse(QueryTime);
                int PlateLastDigit = Int32.Parse(PlateNumber[PlateNumber.Length - 1].ToString());
                bool IsInActiveTime = IsInPicoAndPlacaActiveTime(QueryTimeInTimeSpanFormat);
                bool IsAValidDay = ExcludedDays.Any(r => r != QueryDayOfWeek);
                bool IsNotAHoliday = !Holidays.Contains(QueryDateInDateTimeFormat);
                        

                if (IsInActiveTime && IsAValidDay && IsNotAHoliday && PlateLastDigitBlockedDate[PlateLastDigit] == QueryDayOfWeek)
                {
                    VehicleAvailability = "\nCAN NOT BE ON THE ROAD.\n";
                }
                else
                {
                    VehicleAvailability = "\nCAN BE ON THE ROAD.\n";
                }
                ReturnMessage = "Vehicle with Plate Number: " + PlateNumber + VehicleAvailability +
                                   "(On " + QueryDateInDateTimeFormat.ToString("D", CultureInfo.CreateSpecificCulture("en-US")) +
                                   ", at " + QueryTimeInTimeSpanFormat.ToString(@"hh\:mm") + " )";

            }
            return ReturnMessage;
        }

        private bool IsInPicoAndPlacaActiveTime(TimeSpan TimeToCheck)
        {

            foreach (var ActiveTime in ActiveTimes)
            {
                if (TimeToCheck >= ActiveTime[0] && TimeToCheck <= ActiveTime[1])
                {
                    return true;
                }
            }
            return false;
        }
}
}
