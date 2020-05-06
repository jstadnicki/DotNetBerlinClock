using System.Text;

namespace BerlinClock
{
    public class M5LampsRow
    {
        public M5LampsRow(BerlinTimeSpan timespan, LightColor color)
        {
            this.Minutes = timespan.Minutes / 5;
            this.Color = color;
        }

        public int Minutes { get; }
        public LightColor Color { get; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < Minutes; i++)
            {
                stringBuilder.Append((i + 1) % 3 == 0 ? "R" : "Y");
            }

            for (int i = 11; i > Minutes; i--)
            {
                stringBuilder.Append("O");
            }

            return stringBuilder.ToString();
        }
    }
}
