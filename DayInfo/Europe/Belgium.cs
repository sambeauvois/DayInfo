using DayInfo.Internals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Localized = DayInfo.Europe.Resources.Belgium;

namespace DayInfo.Europe
{
    // [CatholicCountry("test")]
    public class Belgium : DayInfo
    {
        private static List<DayInfo> list;
        // dayinfo factory will return dayinfo, initialized by child classes
        public Belgium()
            : base("BE")
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

        private IEnumerable<Belgium> GetHollidays()
        {
            return new Belgium[]
            {
                new Belgium
                {
                    DisplayName = "Nouvel an",
                    EnglishName = "New Year",
                    IsHolliday = true,
                    NativeName = "Nouvel an",
                    Definition = new DayDefinition(1, Months.January)
                },

                new Belgium
                {
                    DisplayName = Localized.LabourDayTitle,
                    DisplayDescription = Localized.LabourDayDescription,
                    DisplayInfoURL = Localized.LabourDayLink,
                    EnglishName = "Labour Day",
                    IsHolliday = true,
                    NativeName = "Fête du travail",
                    Definition = new DayDefinition(1, Months.May)
                },

                new Belgium
                {
                    DisplayName = Localized.NationalDayTitle,
                    DisplayDescription = Localized.NationalDayDescription,
                    DisplayInfoURL = Localized.NationalDayLink,
                    EnglishName = "National Day",
                    IsHolliday = true,
                    NativeName = "Fête nationale",
                    Definition = new DayDefinition(21, Months.July)
                },

                new Belgium
                {
                    DisplayName = Localized.ArmisticeTitle,
                    DisplayDescription = Localized.ArmisticeDescription,
                    DisplayInfoURL = Localized.ArmisticeLink,
                    EnglishName = "First Armistice",
                    IsHolliday = true,
                    NativeName = "Armistice de 1918",
                    Definition = new DayDefinition(11, Months.November),
                    DisplayInfoURLs = GetLinksFromRessource(Localized.ArmisticeLinks)
                }
            };
        }

        public IEnumerable<Belgium> Carnivals()
        {
            return new Belgium[1]
            {
                new Belgium
                {
                    DisplayName = "Laetare",
                    EnglishName = "Laetare",
                    IsHolliday = false,
                    NativeName = "Laetare",
                    DisplayInfoURL = "http://www.laetare-stavelot.be/",
                    Definition = new DayDefinition().Before(SpecialDays.ChristianEaster, DayDefinition.TimeRelationUnits.Weeks, 3)
                }
            };
        }
    }
}
