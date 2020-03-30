using System;

namespace Lab11 {
    class Program {
        static void Main(string[] args) {
            string sel = "";
            do {
                Console.Write("Enter a time in 24-hour format: ");
                string input = Console.ReadLine();
                try {
                    Console.WriteLine($"Same time in 12-hour format: {To12(input)}");

                    do {
                    Console.Write("Continue [y/n]? ");
                    sel = Console.ReadLine().ToLower();
                    } while (!(sel == "y" || sel == "n"));
                } catch (TimeException e) {
                    Console.WriteLine(e.Message);
                }
            } while (sel != "n");
        }

        static string To12(string inputTime) {
            int hours, minutes;
            string ampm = "AM";

            string[] timeArray = inputTime.Split(':');

            try {
                hours = Convert.ToInt32(timeArray[0]);
            } catch (FormatException e) {
                Console.WriteLine(e.StackTrace);
                throw new TimeException("The hours entered were not a valid number");
            }

            try {
                minutes = Convert.ToInt32(timeArray[1]);
            } catch (FormatException e) {
                Console.WriteLine(e.StackTrace);
                throw new TimeException("The minutes entered were not a valid number");
            } catch (IndexOutOfRangeException e) {
                Console.WriteLine(e.StackTrace);
                throw new TimeException("Colon missing in time given.");
            }
            
            if (hours < 0 || hours > 23)
                throw new TimeException("Hours were not in a valid range.");
            if (minutes < 0 || minutes > 59)
                throw new TimeException("Minutes were not in a valid range.");
            
            if (hours > 12) {
                hours -= 12;
                ampm = "PM";
            }
            return $"{hours}:{minutes:D2} {ampm}";
        }
    }

    class TimeException : Exception {
        public TimeException(string errorMessage) : base(errorMessage) {}
    }
}
