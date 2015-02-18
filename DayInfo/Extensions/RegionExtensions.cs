using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayInfo.Extensions
{
    public static class RegionExtensions
    {
        public static IEnumerable<DayInfo> GetDays(this RegionInfo regionInfo)
        {
            return DayInfo.All(regionInfo.TwoLetterISORegionName);
        }
    }
}
