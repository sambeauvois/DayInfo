using DayInfo.Internals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayInfo.Europe
{
    public class France : DayInfo
    {
        private static List<DayInfo> list;
        public France()
            : base("FR")
        {

        }

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

        private IEnumerable<France> GetHollidays()
        {
            return new France[]
            {
                new France
                {
                    DisplayName = "Nouvel an",
                    EnglishName = "New Year",
                    IsHolliday = true,
                    NativeName = "Nouvel an",
                    Definition = new DayDefinition(1, Months.January)
                },
                new France
                {
                    DisplayName = "Fête du travail",
                    EnglishName = "Labour Day",
                    IsHolliday = true,
                    NativeName = "Fête du travail",
                    Definition = new DayDefinition(1, Months.May)
                },
                new France
                {
                    DisplayName = "Fête nationale",
                    EnglishName = "National Day",
                    IsHolliday = true,
                    NativeName = "Fête nationale",
                    Definition = new DayDefinition(14, Months.July)
                }
            };
        }
        
        // fêtes http://icalendrier.fr/fetes/fete-des-meres/
    }
}
