using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string ConvertTime(string time)
        {
            var dateTime = this.Parse(time);

            var secRow = new SecondsLampRow(2, () => dateTime.Seconds % 2, LightColor.Yellow);

            var h1Row = new LampsRow(4, () => dateTime.Hours / 5, LightColor.Red);
            var h2Row = new LampsRow(4, () => dateTime.Hours % 5, LightColor.Red);

            var m1Row = new MinutesLampsRow(11, () => dateTime.Minutes / 5, LightColor.None);
            var m2Row = new LampsRow(4, () => dateTime.Minutes % 5, LightColor.Yellow);

            var berlinClock = new List<LampsRow>();
            berlinClock.Add(secRow);
            berlinClock.Add(h1Row);
            berlinClock.Add(h2Row);
            berlinClock.Add(m1Row);
            berlinClock.Add(m2Row);

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
