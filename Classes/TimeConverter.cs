using System;
using System.ComponentModel;
using System.Linq;
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

            var h1Row = new H5LampsRow(dateTime, LightColor.Red);
            var h2Row = new H1LampsRow(dateTime, LightColor.Red);

            var m1Row = new M5LampsRow(dateTime, LightColor.Yellow);
            var m2Row = new M1LampsRow(dateTime, LightColor.Yellow);


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

    public enum LightColor
    {
        [Description("O")]
        None,
        [Description("R")]
        Red,
        [Description("Y")]
        Yellow
    }

    public static class LightColorExtensions
    {
        public static string GetDescription(this LightColor color)
        {
            var attributes = color.GetType().GetField(color.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attributes[0] as DescriptionAttribute).Description;
        }
    }
}
