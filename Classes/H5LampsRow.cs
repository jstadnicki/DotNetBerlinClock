using System.Text;

namespace BerlinClock
{
    public class H5LampsRow
    {
        public H5LampsRow(BerlinTimeSpan timespan, LightColor color)
        {
            this.Hour = timespan.Hours / 5;
            this.Color = color;
        }

        public int Hour { get; private set; }
        public LightColor Color { get; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < Hour; i++)
            {
                stringBuilder.Append(this.Color.Encode());
            }

            for (int i = 4; i > Hour; i--)
            {
                stringBuilder.Append("O");
            }

            return stringBuilder.ToString();
        }
    }
}
