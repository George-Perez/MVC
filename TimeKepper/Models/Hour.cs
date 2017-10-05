using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeKepper.Models
{
    public class Hour
    {
        public int Id { get; set; }

        public DateTime ClockInClockOut
        {
            get
            {
               return DateTime.Now;
            }

            set
            {
                Clock = DateTime.Now;
            }
        }


        public virtual Hour Hours { get; set; }
        public DateTime Clock { get; private set; }
    }
}