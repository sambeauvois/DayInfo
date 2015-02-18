using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayInfo.Europe
{
    public class France : DayInfo
    {
        public France()
            : base("FR")
        {
             
        }

        public override IEnumerable<DayInfo> All()
        {
            Days.AddRange(new ChristianDayInfo().All());      


            return base.All();
        }
    }
}
