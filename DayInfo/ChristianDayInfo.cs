using DayInfo.Internals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Localized = DayInfo.Resources.ChristianDayInfo;

namespace DayInfo
{
    public class ChristianDayInfo : DayInfo
    {
        public ChristianDayInfo()
            : base("CHRISTIAN_DAYS")
        {
        }

        public override IEnumerable<DayInfo> All()
        {
            Days.Add(new ChristianDayInfo
            {
                DisplayName = Localized.EasterTitle,
                DisplayDescription = Localized.EasterDescription,
                EnglishName = "Easter monday",
                IsHolliday = true,
                NativeName = "Pâques",
                Definition = new DayDefinition().DaysAfter(SpecialDays.ChristianEaster, 1)
            });
            Days.Add(new ChristianDayInfo
            {
                DisplayName = "Ascension",
                EnglishName = "Ascension",
                IsHolliday = true,
                NativeName = "Ascension",
                Definition = new DayDefinition().DaysAfter(SpecialDays.ChristianEaster, 39)
            });
            //Days.Add(new ChristianDayInfo
            //{
            //    DisplayName = "Pentecote",
            //    EnglishName = "pentecode_totransalate",
            //    IsHolliday = false,
            //    NativeName = "Pentecode",
            //    Definition = new DayDefinition().DaysAfter(SpecialDays.ChristianEaster, 49)
            //});
            Days.Add(new ChristianDayInfo
            {
                DisplayName = "Lundi de Pentecote",
                EnglishName = "pentecode_totransalate",
                IsHolliday = true,
                NativeName = "Lundi de Pentecote",
                Definition = new DayDefinition().DaysAfter(SpecialDays.ChristianEaster, 50)
            });
            Days.Add(new ChristianDayInfo
            {
                DisplayName = "Assomption",
                EnglishName = "Assumption ",
                IsHolliday = true,
                NativeName = "Assomption",
                Definition = new DayDefinition(15, Months.August)
            });

            Days.Add(new ChristianDayInfo
            {
                DisplayName = "Toussaint",
                EnglishName = "All Saints",
                IsHolliday = true,
                NativeName = "Toussaint",
                Definition = new DayDefinition(1, Months.November)
            });

            Days.Add(new ChristianDayInfo
            {
                DisplayName = "Noël",
                EnglishName = "Christmas",
                IsHolliday = true,
                NativeName = "Noël",
                Definition = new DayDefinition(25, Months.December)
            });
            return base.All();
        }

        public static DateTime Easter
        {
            get
            {
                return GetEasterSunday(DateTime.Today.Year);
            }
        }

        public static DateTime EasterMonday
        {
            get
            {
                return Easter.AddDays(1);
            }
        }

        public static DateTime Pentecote
        {
            get
            {
                return Easter.AddDays(49);
            }
        }

        public static DateTime PentecoteMonday
        {
            get
            {
                return Pentecote.AddDays(1);
            }
        }

        public static DateTime GetEasterSunday(int year)
        {
            int day = 0;
            int month = 0;

            int g = year % 19;
            int c = year / 100;
            int h = (c - (int)(c / 4) - (int)((8 * c + 13) / 25) + 19 * g + 15) % 30;
            int i = h - (int)(h / 28) * (1 - (int)(h / 28) * (int)(29 / (h + 1)) * (int)((21 - g) / 11));

            day = i - ((year + (int)(year / 4) + i + 2 - c + (int)(c / 4)) % 7) + 28;
            month = 3;

            if (day > 31)
            {
                month++;
                day -= 31;
            }

            return new DateTime(year, month, day);
        }
    }

}
