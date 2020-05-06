using System;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string ConvertTime(string time)
        {
            var dateTime = this.Parse(time);

            var sLamp = dateTime.Seconds % 2;

            var stringBuilder = new StringBuilder();

            var h1Row = new H5LampsRow(dateTime);
            var h2Row = new H1LampsRow(dateTime);

            var m1Row = new M5LampsRow(dateTime);
            var m2Row = new M1LampsRow(dateTime);


            stringBuilder.AppendLine(sLamp == 0 ? "Y" : "O");
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
