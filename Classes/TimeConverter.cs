using System;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string ConvertTime(string time)
        {
            var dateTime = DateTime.Parse(time);

            var hours = dateTime.Hour;
            var h5Lamps = hours / 5;
            var h1Lamps = hours % 5;

            var minutes = dateTime.Minute;

            var m5Lamps = minutes / 5;
            var m1Lamps = minutes % 5;

            var sLamp = dateTime.Second % 2;

            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(sLamp == 0 ? "Y" : "O");
            
            for (int i = 0; i < h5Lamps; i++)
            {
                stringBuilder.Append("R");
            }

            for (int i = 4; i > h5Lamps; i--)
            {
                stringBuilder.Append("O");
            }

            stringBuilder.AppendLine();

            for (int i = 0; i < h1Lamps; i++)
            {
                stringBuilder.Append("R");
            }

            for (int i = 4; i > h1Lamps; i--)
            {
                stringBuilder.Append("O");
            }

            stringBuilder.AppendLine();

            for (int i = 0; i < m5Lamps; i++)
            {
                stringBuilder.Append("Y");
            }

            for (int i = 11; i > m5Lamps; i--)
            {
                stringBuilder.Append("O");
            }

            stringBuilder.AppendLine();

            for (int i = 0; i < m1Lamps; i++)
            {
                stringBuilder.Append("Y");
            }

            for (int i = 4; i > m1Lamps; i--)
            {
                stringBuilder.Append("O");
            }


            return stringBuilder.ToString();
        }
    }
}
