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
    {   // dayinfo factory will return dayinfo, initialized by child classes
        public Luxembourg()
            : base("LU")
        {

        }

        //// todo :tester
        public override IEnumerable<DayInfo> All()
        {
            Days.AddRange(new ChristianDayInfo().All());
            AddHollidays();
        
            return base.All();
        }

        private void AddHollidays()
        {
            Days.Add(new Luxembourg
            {
                DisplayName = "Nouvel an",
                EnglishName = "New Year",
                IsHolliday = true,
                NativeName = "Nouvel an",
                Definition = new DayDefinition(1, Months.January)
            });

            Days.Add(new Luxembourg
            {
                DisplayName = "Fête du travail",
                EnglishName = "Labour Day",
                IsHolliday = true,
                NativeName = "Fête du travail",
                Definition = new DayDefinition(1, Months.May)
            });

            // national day
            Days.Add(new Luxembourg
            {
                DisplayName = Localized.NationalDayTitle,
                EnglishName = "National Day",
                IsHolliday = true,
                NativeName = "Fête nationale",
                Definition = new DayDefinition(23, Months.June)
            });

            Days.Add(new Luxembourg
            {
                DisplayName = "St Etienne",
                EnglishName = "St Etienne",
                IsHolliday = true,
                NativeName = "St Etienne",
                Definition = new DayDefinition(26, Months.December)
            });
        }
    }
}
