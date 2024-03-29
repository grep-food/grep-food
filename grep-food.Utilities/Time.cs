﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grep_food.Utilities
{
    public class Time
    {
        public uint Hours { get; set; }
        public uint Minutes { get; set; }

        public Time(int min)
        {
            this.Minutes = (uint)min % 60;
            this.Hours = (uint)min / 60;
        }
        public Time(uint h, uint min)
        {
            if (min >= 60)
            {
                h = h + min / 60;
                min %= 60;

            }

            this.Hours = h;
            this.Minutes = min;


        }

        public Time(DateTime dt)
        {
            this.Hours = Convert.ToUInt32(dt.Hour);
            this.Minutes = Convert.ToUInt32(dt.Minute);

        }
        public override string ToString()
        {
            string res = "";
            if (this.Hours > 0) res += this.Hours.ToString() + " h ";
            if (this.Minutes > 0) res += this.Minutes.ToString() + " m";

            return res;
        }

    }
}