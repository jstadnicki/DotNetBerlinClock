using System;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string ConvertTime(string time)
        {
            if (string.IsNullOrWhiteSpace(time))
            {
                throw new ArgumentNullException(nameof(time));
            }

            var dateTime = BerlinUhrTimeSpanConverter.Parse(time);

            var clock = new BerlinUhr(dateTime);

            return clock.ToString();
        }
    }
}
