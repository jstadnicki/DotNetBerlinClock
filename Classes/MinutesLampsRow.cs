using System;
using System.Text;

namespace BerlinClock
{
    internal class MinutesLampsRow : LampsRow
    {
        public MinutesLampsRow(int max, Func<int> value, LightColor _) : base(max, value, _)
        { }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < this.value; i++)
            {
                stringBuilder.Append((i + 1) % 3 == 0 ? LightColor.Red.GetDescription() : LightColor.Yellow.GetDescription());
            }

            for (int i = this.max; i > this.value; i--)
            {
                stringBuilder.Append(LightColor.None.GetDescription());
            }

            return stringBuilder.ToString();
        }
    }
}