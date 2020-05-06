using System.Text;

namespace BerlinClock
{
    public class H5LampsRow
    {
        public H5LampsRow(BerlinTimeSpan timespan)
        {
            this.Hour = timespan.Hours / 5;
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
}
