using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayInfo.Internals
{
    internal enum SpecialDays
    {
        ChristianEaster,
        ChristianChristmas,
        NewYear,
        ChineseNewYear
    }

    internal class DayDefinition
    {
        public DayDefinition(CalculationTypes type = CalculationTypes.relativeToSpecialDate)
        {
            this.CalculationType = type;
        }
        public DayDefinition(SpecialDays specialDay)
            : this(CalculationTypes.relativeToSpecialDate)
        {
            this.ReferenceDay = specialDay;
            this.TimeRelation = TimeRelations.Equal;
        }

        public DayDefinition(int day, Months month)
            : this(CalculationTypes.fixedDay)
        {
            this.FixedDay = day;
            this.FixedMonth = month;
        }

        public enum CalculationTypes
        {
            fixedDay,
            relativeToSpecialDate
        }

        public enum TimeRelations : int
        {
            After = 1,
            Before = -1,
            Equal = 0
        }

        public enum TimeRelationUnits
        {
            Days,
            Weeks,
            Months,
            WeekDay
        }
        public TimeRelationUnits TimeRelationUnit
        {
            get;
            set;
        }

        public int FixedDay
        {
            get;
            set;
        }

        public Months FixedMonth
        {
            get;
            set;
        }

        public int RelativeValue
        {
            get;
            set;
        }

        public CalculationTypes CalculationType
        {
            get;
            set;
        }

        public TimeRelations TimeRelation
        {
            get;
            set;
        }

        public SpecialDays ReferenceDay
        {
            get;
            set;
        }

        public DayDefinition After(SpecialDays specialDay, TimeRelationUnits unit, int value)
        {
            this.CalculationType = CalculationTypes.relativeToSpecialDate;
            this.TimeRelation = TimeRelations.After;
            this.ReferenceDay = specialDay;
            this.TimeRelationUnit = unit;
            this.RelativeValue = value;
            return this;
        }

        public DayDefinition Before(SpecialDays specialDay, TimeRelationUnits unit, int value)
        {
            this.CalculationType = CalculationTypes.relativeToSpecialDate;
            this.TimeRelation = TimeRelations.Before;
            this.ReferenceDay = specialDay;
            this.TimeRelationUnit = unit;
            this.RelativeValue = value;
            return this;
        }

        public DayDefinition DaysAfter(SpecialDays specialDay, int days)
        {
            return this.After(specialDay, TimeRelationUnits.Days, days);
        }
        public DayDefinition WeeksAfter(SpecialDays specialDay, int weeks)
        {
            return this.After(specialDay, TimeRelationUnits.Weeks, weeks);
        }
        //public void WeekDayAfter(SpecialDays specialDay, DayOfWeek dayOfWeek)
        //{

        //}
        public DayDefinition Monthsfter(SpecialDays specialDay, int months)
        {
            return this.After(specialDay, TimeRelationUnits.Months, months);
        }
        public DayDefinition DaysBefore(SpecialDays specialDay, int days)
        {
            return this.Before(specialDay, TimeRelationUnits.Days, days);
        }
        public DayDefinition WeeksBefore(SpecialDays specialDay, int weeks)
        {
            return this.Before(specialDay, TimeRelationUnits.Weeks, weeks);
        }
        //public void WeekDayBefore(SpecialDays specialDay, DayOfWeek dayOfWeek)
        //{

        //}
        public DayDefinition MonthsBefore(SpecialDays specialDay, int months)
        {
            return this.Before(specialDay, TimeRelationUnits.Months, months);
        }

        public DateTime GetForYear(int year)
        {
            if (this.CalculationType == CalculationTypes.fixedDay)
            {
                return new DateTime(year, (int)this.FixedMonth, this.FixedDay);
            }
            else
            {

                DateTime referenceDay = new DateTime(year, 1, 1);
                switch (this.ReferenceDay)
                {
                    case SpecialDays.ChristianEaster:
                        {
                            referenceDay = ChristianDayInfo.GetEasterSunday(year);

                        } break;
                    default:
                        {
                            return referenceDay;
                        }
                }

                switch (this.TimeRelationUnit)
                {
                    case TimeRelationUnits.Months:
                        {
                            return referenceDay.AddMonths((int)this.TimeRelation * this.RelativeValue);
                        }
                    case TimeRelationUnits.Days:
                        {
                            return referenceDay.AddDays((int)this.TimeRelation * this.RelativeValue);
                        }
                    case TimeRelationUnits.Weeks:
                        {
                            return referenceDay.AddDays((int)this.TimeRelation * this.RelativeValue * 7);
                        }
                    default:
                        {
                            return referenceDay;
                        }
                }
            }
        }
    }
}
