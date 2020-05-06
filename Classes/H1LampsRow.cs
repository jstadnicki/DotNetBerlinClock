using System.Text;

namespace BerlinClock
{
    public class H1LampsRow
    {
        public H1LampsRow(BerlinTimeSpan timespan, LightColor color)
        {
            this.Hour = timespan.Hours % 5;
            this.Color = color;
        }

        public int Hour { get; private set; }
        public LightColor Color { get; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < Hour; i++)
            {
                stringBuilder.Append(this.Color.GetDescription());
            }

            for (int i = 4; i > Hour; i--)
            {
                stringBuilder.Append("O");
            }

            return stringBuilder.ToString();
        }
    }


}
