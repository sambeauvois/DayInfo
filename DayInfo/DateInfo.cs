using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayInfo
{
    public class DateInfo
    {
        public DateTime Date
        {
            get;
            set;
        }

        public DayInfo DayInfo
        {
            get;
            set;
        }

        private static DateInfo GetDay(int year, DayInfo di)
        {
            return new DateInfo
            {
                Date = di.Definition.GetForYear(year),
                DayInfo = di
            };
        }

        public static IEnumerable<DateInfo> Get(string twoLetterISORegionName, int year)
        {
            foreach (var dayInfo in DayInfo.All(twoLetterISORegionName))
            {
                yield return GetDay(year, dayInfo);
            }
        }
    }
}
