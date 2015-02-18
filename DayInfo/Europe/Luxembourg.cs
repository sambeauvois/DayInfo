using DayInfo.Internals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Localized = DayInfo.Europe.Resources.Luxembourg;

namespace DayInfo.Europe
{
    public class Luxembourg : DayInfo
    {
        private static List<DayInfo> list;

        public Luxembourg()
            : base("LU")
        {

        }

        //// todo :tester
        public override IEnumerable<DayInfo> All()
        {
            if (list == null)
            {
                list = new List<DayInfo>();
                list.AddRange(new ChristianDayInfo().All());
                list.AddRange(GetHollidays());

            }
            return list;
        }

        private IEnumerable<Luxembourg> GetHollidays()
        {
            return new Luxembourg[]
            {
                new Luxembourg
                {
                    DisplayName = "Nouvel an",
                    EnglishName = "New Year",
                    IsHolliday = true,
                    NativeName = "Nouvel an",
                    Definition = new DayDefinition(1, Months.January)
                },
                new Luxembourg
                {
                    DisplayName = "Fête du travail",
                    EnglishName = "Labour Day",
                    IsHolliday = true,
                    NativeName = "Fête du travail",
                    Definition = new DayDefinition(1, Months.May)
                },
                new Luxembourg
                {
                    DisplayName = Localized.NationalDayTitle,
                    EnglishName = "National Day",
                    IsHolliday = true,
                    NativeName = "Fête nationale",
                    Definition = new DayDefinition(23, Months.June)
                },
                new Luxembourg
                {
                    DisplayName = "St Etienne",
                    EnglishName = "St Etienne",
                    IsHolliday = true,
                    NativeName = "St Etienne",
                    Definition = new DayDefinition(26, Months.December)
                }
            };
        }
    }
}
