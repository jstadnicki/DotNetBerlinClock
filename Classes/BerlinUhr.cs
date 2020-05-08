using System;
using System.Collections.Generic;
using System.Linq;

namespace BerlinClock
{
    internal class BerlinUhr
    {
        private List<LampsRow> berlinClock;

        public BerlinUhr(BerlinTimeSpan dateTime)
        {
            var secondsRow = new SecondsLampRow(2, () => dateTime.Seconds % 2, LightColor.Yellow);

            var bigHoursRow = new LampsRow(4, () => dateTime.Hours / 5, LightColor.Red);
            var smallHoursRow = new LampsRow(4, () => dateTime.Hours % 5, LightColor.Red);

            var bigMinutesRow = new QuarterWithMinutesLampsRow(11, () => dateTime.Minutes / 5, LightColor.None);
            var smallMinutesRow = new LampsRow(4, () => dateTime.Minutes % 5, LightColor.Yellow);

            this.berlinClock = new List<LampsRow>();

            berlinClock.Add(secondsRow);
            berlinClock.Add(bigHoursRow);
            berlinClock.Add(smallHoursRow);
            berlinClock.Add(bigMinutesRow);
            berlinClock.Add(smallMinutesRow);
        }

        public override string ToString() => string.Join(Environment.NewLine, this.berlinClock.Select(bc => bc.ToString()));
    }
}