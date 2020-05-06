using System;
using System.Collections.Generic;
using System.Linq;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string ConvertTime(string time)
        {
            var dateTime = this.Parse(time);

            var secondsRow = new SecondsLampRow(2, () => dateTime.Seconds % 2, LightColor.Yellow);

            var bigHoursRow = new LampsRow(4, () => dateTime.Hours / 5, LightColor.Red);
            var smallHoursRow = new LampsRow(4, () => dateTime.Hours % 5, LightColor.Red);

            var bigMinutesRow = new MinutesLampsRow(11, () => dateTime.Minutes / 5, LightColor.None);
            var smallMinutesRow = new LampsRow(4, () => dateTime.Minutes % 5, LightColor.Yellow);

            var berlinClock = new List<LampsRow>();
            berlinClock.Add(secondsRow);
            berlinClock.Add(bigHoursRow);
            berlinClock.Add(smallHoursRow);
            berlinClock.Add(bigMinutesRow);
            berlinClock.Add(smallMinutesRow);

            var result = string.Join(Environment.NewLine, berlinClock.Select(bc => bc.ToString()));
            return result;
        }

        private BerlinTimeSpan Parse(string time)
        {
            var sections = time.Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
            return new BerlinTimeSpan(int.Parse(sections[0]), int.Parse(sections[1]), int.Parse(sections[2]));
        }
    }
}
