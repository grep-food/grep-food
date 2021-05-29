using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grep_food.Utilites
{
    public class Time
    {
        public uint Hours { get; set; }
        public uint Minutes { get; set; }
        public uint Seconds { get; set; }

        public Time(uint h, uint min, uint sec) {
            if (sec > 59)
            {
                min += sec / 60;
                sec = sec % 60;
            }
            if (min > 59) {
                h += min/60;
                min = min % 60;
            }
           
            this.Hours = h;
            this.Minutes = min;
            this.Seconds = sec;

        }

        public Time(DateTime dt) {
            this.Hours = Convert.ToUInt32(dt.Hour);
            this.Minutes = Convert.ToUInt32(dt.Minute);
            this.Seconds = Convert.ToUInt32(dt.Second);
        }
        public override string ToString()
        {
            return String.Format("{0:00}:{1:00}:{2:00}",this.Hours, this.Minutes, this.Seconds);
        }
    }
}
