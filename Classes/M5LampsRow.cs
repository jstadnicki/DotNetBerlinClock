using System.Text;

namespace BerlinClock
{
    public class M5LampsRow
    {
        public M5LampsRow(BerlinTimeSpan timespan)
        {
            this.Minutes = timespan.Minutes / 5;
        }

        public int Minutes { get; }

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
