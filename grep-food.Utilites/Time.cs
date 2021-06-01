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
     

        public Time(uint h, uint min) {
            if (min >= 60){
                h = h + min / 60;
                min %= 60;

            }           

            this.Hours = h;
            this.Minutes = min;
      

        }

        public Time(DateTime dt) {
            this.Hours = Convert.ToUInt32(dt.Hour);
            this.Minutes = Convert.ToUInt32(dt.Minute);

        }
        public override string ToString()
        {
            return String.Format("{0:00}:{1:00}",this.Hours, this.Minutes);
        }
    }
}
