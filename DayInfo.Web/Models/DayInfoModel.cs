using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DayInfo.Web.Models
{
    public class DayInfoModel
    {
        public int Year { get; set; }
        public IEnumerable<DateInfo> Luxembourg { get; set; }
        public IEnumerable<DateInfo> Belgium { get; set; }

    }
}