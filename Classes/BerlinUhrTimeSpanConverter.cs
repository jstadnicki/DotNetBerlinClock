using System;

namespace BerlinClock
{
    public class BerlinUhrTimeSpanConverter
    {
        // static since lack of ioc
        public static BerlinTimeSpan Parse(string time)
        {
            var sections = time.Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
            var hours = AMPMTo24hConverter.Convert(sections[0]);
            var minutes = int.Parse(sections[1]);
            var seconds = int.Parse(sections[2]);

            if (hours < 0 || hours > 24)
            {
                throw new ArgumentOutOfRangeException(nameof(hours));
            }

            if (minutes < 0 || minutes > 60)
            {
                throw new ArgumentOutOfRangeException(nameof(minutes));
            }

            if (seconds < 0 || seconds > 60)
            {
                throw new ArgumentOutOfRangeException(nameof(seconds));
            }



            return new BerlinTimeSpan(hours, minutes, seconds);
        }
    }
}
