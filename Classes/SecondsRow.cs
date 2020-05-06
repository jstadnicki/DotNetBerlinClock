using System;

namespace BerlinClock
{
    internal class SecondsRow
    {
        private int v;
        private Func<int> p;
        private LightColor yellow;

        public SecondsRow(int v, Func<int> p, LightColor yellow)
        {
            this.v = v;
            this.p = p;
            this.yellow = yellow;
        }
    }
}