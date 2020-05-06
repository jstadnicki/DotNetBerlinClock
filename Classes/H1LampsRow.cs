using System.Text;

namespace BerlinClock
{
    public class H1LampsRow
    {
        public H1LampsRow(BerlinTimeSpan timespan)
        {
            this.Hour = timespan.Hours % 5;
        }

        public int Hour { get; private set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < Hour; i++)
            {
                stringBuilder.Append("R");
            }

            for (int i = 4; i > Hour; i--)
            {
                stringBuilder.Append("O");
            }

            return stringBuilder.ToString();
        }
    }

    public class M1LampsRow
    {
        public M1LampsRow(BerlinTimeSpan timespan)
        {
            this.Minutes = timespan.Minutes % 5;
        }

        public int Minutes { get; private set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < Minutes; i++)
            {
                stringBuilder.Append("Y");
            }

            for (int i = 4; i > Minutes; i--)
            {
                stringBuilder.Append("O");
            }

            return stringBuilder.ToString();
        }
    }


}
