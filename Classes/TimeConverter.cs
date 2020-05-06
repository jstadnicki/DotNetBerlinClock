using System;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string ConvertTime(string time)
        {
            var dateTime = this.Parse(time);

            var hours = dateTime.Hours;
            var h5Lamps = hours / 5;
            var h1Lamps = hours % 5;

            var minutes = dateTime.Minutes;

            var m5Lamps = minutes / 5;
            var m1Lamps = minutes % 5;

            var sLamp = dateTime.Seconds % 2;

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
                stringBuilder.Append((i+1) % 3 == 0 ? "R" : "Y");
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

        private BerlinTimeSpan Parse(string time)
        {
            var sections = time.Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
            return new BerlinTimeSpan(int.Parse(sections[0]), int.Parse(sections[1]), int.Parse(sections[2]));
        }
    }

    public class BerlinTimeSpan
    {
        public BerlinTimeSpan(int hours, int minutes, int seconds)
        {
            this.Hours = hours;
            this.Minutes = minutes;
            this.Seconds = seconds;
        }

        public int Hours { get;  }
        public int Minutes { get;  }
        public int Seconds { get;  }
    }
}
