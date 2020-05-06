﻿namespace BerlinClock
{
    public class BerlinTimeSpan
    {
        public BerlinTimeSpan(int hours, int minutes, int seconds)
        {
            this.Hours = hours;
            this.Minutes = minutes;
            this.Seconds = seconds;
        }

        public int Hours { get;  }
        public int Minutes { get;  }
        public int Seconds { get;  }
    }
}
