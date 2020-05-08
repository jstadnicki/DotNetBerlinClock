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

    public class BerlinUhrTimeSpanConverter
    {
        // static since lack of ioc
        public static BerlinTimeSpan Parse(string time)
        {
            var sections = time.Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
            return new BerlinTimeSpan(int.Parse(sections[0]), int.Parse(sections[1]), int.Parse(sections[2]));
        }
    }
}
