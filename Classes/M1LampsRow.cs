using System;
using System.Text;

namespace BerlinClock
{
    public class M1LampsRow
    {
        public M1LampsRow(BerlinTimeSpan timespan, LightColor color)
        {
            this.Minutes = timespan.Minutes % 5;
            this.Color = color;
        }

        public int Minutes { get; private set; }
        public LightColor Color { get; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < Minutes; i++)
            {
                stringBuilder.Append(this.Color.Encode());
            }

            for (int i = 4; i > Minutes; i--)
            {
                stringBuilder.Append("O");
            }

            return stringBuilder.ToString();
        }
    }


}
