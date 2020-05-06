using System;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string ConvertTime(string time)
        {
            var dateTime = this.Parse(time);
            var stringBuilder = new StringBuilder();

            var secRow = new SecondsLampRow(2, () => dateTime.Seconds % 2, LightColor.Yellow);

            var h1Row = new LampsRow(4, () => dateTime.Hours / 5, LightColor.Red);
            var h2Row = new LampsRow(4, () => dateTime.Hours % 5, LightColor.Red);

            var m1Row = new MinutesLampsRow(11, () => dateTime.Minutes / 5, LightColor.None);
            var m2Row = new LampsRow(4, () => dateTime.Minutes % 5, LightColor.Yellow);


            stringBuilder.AppendLine(secRow.ToString());
            stringBuilder.AppendLine(h1Row.ToString());
            stringBuilder.AppendLine(h2Row.ToString());
            stringBuilder.AppendLine(m1Row.ToString());
            stringBuilder.Append(m2Row.ToString());

            return stringBuilder.ToString();
        }

        private BerlinTimeSpan Parse(string time)
        {
            var sections = time.Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
            return new BerlinTimeSpan(int.Parse(sections[0]), int.Parse(sections[1]), int.Parse(sections[2]));
        }
    }
}
