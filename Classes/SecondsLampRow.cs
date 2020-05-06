using System;

namespace BerlinClock
{
    internal class SecondsLampRow : LampsRow
    {
        public SecondsLampRow(int max, Func<int> p, LightColor color) : base(max, p, color)
        {
        }

        public override string ToString()
        {
            return this.value % this.max == 0 ? this.color.GetDescription() : LightColor.None.GetDescription();
        }
    }
}