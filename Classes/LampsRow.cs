using System;
using System.Text;

namespace BerlinClock
{
    class LampsRow
    {
        protected int max;
        protected int value;
        protected LightColor color;

        public LampsRow(int max, Func<int> p, LightColor color)
        {
            this.max = max;
            this.value = p();
            this.color = color;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < value; i++)
            {
                stringBuilder.Append(this.color.GetDescription());
            }

            for (int i = max; i > value; i--)
            {
                stringBuilder.Append(LightColor.None.GetDescription());
            }

            return stringBuilder.ToString();
        }
    }
}