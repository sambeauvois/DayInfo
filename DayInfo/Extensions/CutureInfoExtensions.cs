using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayInfo.Extensions
{
    public static class CutureInfoExtensions
    {
        public static IEnumerable<DayInfo> GetDayInfos(this CultureInfo culture)
        {


            RegionInfo region = new RegionInfo(culture.TwoLetterISOLanguageName);
            // region.TwoLetterISORegionName

            return new List<DayInfo>();
        }
        //CultureInfo.GetCultureInfo(

        //DayInfo.GetDayInfo("region name");
        //DayInfo.GetDayInfo(RegionInfo);
        //DayInfo.GetDays(Enum.kind);
        //DayInfo.CurrentDay.Hollidays()
        //DayInfo.CurrentDay.Weekends();
        //DayInfo.CurrentDay.All();
    }
}
