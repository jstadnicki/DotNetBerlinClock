using System;

namespace BerlinClock
{
    public static class AMPMTo24hConverter
    {
        static string AnteMeridiem = "am";
        static string PostMeridiem = "pm";

        // statice, since lack of IOC
        static public int Convert(string time)
        {
            if (string.IsNullOrEmpty((string)time))
            {
                throw new ArgumentNullException();
            }

            var timeLowerCase = time.ToLower();

            if (timeLowerCase.EndsWith(PostMeridiem))
            {
                return ConvertFromPM(timeLowerCase);
            }

            if (timeLowerCase.EndsWith(AnteMeridiem))
            {
                return ConvertFromAM(timeLowerCase);
            }

            return int.Parse(time);
        }

        private static int ConvertFromAM(string timeLowerCase)
        {
            var hourPart = timeLowerCase.Split(new[] { AnteMeridiem }, 2, StringSplitOptions.RemoveEmptyEntries)[0];
            return int.Parse(hourPart);
        }

        private static int ConvertFromPM(string timeLowerCase)
        {
            var hourPart = timeLowerCase.Split(new[] { PostMeridiem }, 2, StringSplitOptions.RemoveEmptyEntries)[0];
            return int.Parse(hourPart) + 12;
        }
    }
}
