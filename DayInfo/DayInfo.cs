using DayInfo.Internals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DayInfo
{

    /// <summary>
    /// A class that provides information about a specific day in the year
    /// </summary>
    public abstract class DayInfo
    {
        private static List<DayInfo> dayinfosList = RegisterAllDerived();
        public DayInfo(string twoLetterISORegionName)
        {
            this.TwoLetterISORegionName = twoLetterISORegionName;
            this.WeekEndDays = new List<DayOfWeek>(new[] { DayOfWeek.Saturday, DayOfWeek.Sunday });
        }

        public List<DayOfWeek> WeekEndDays
        {
            get;
            set;
        }

        public string TwoLetterISORegionName
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
        public string NativeName
        {
            get;
            set;
        }
        public string EnglishName
        {
            get;
            set;
        }
        public string DisplayName
        {
            get;
            set;
        }
        public string DisplayDescription
        {
            get;
            set;
        }
        public string DisplayInfoURL
        {
            get;
            set;
        }

        public class Url
        {
            public string Title { get; set; }
            public string URL { get; set; }
        }

        public IEnumerable<Url> DisplayInfoURLs
        {
            get;
            set;
        }

        public bool IsHolliday
        {
            get;
            set;
        }

        internal DayDefinition Definition
        {
            get;
            set;
        }

        void foo()
        {
            //RegionInfo r = new RegionInfo("be-fr");

        }
        private List<DayInfo> days;
        protected List<DayInfo> Days
        {
            get
            {
                if (this.days == null)
                {
                    this.days = new List<DayInfo>();
                }
                return this.days;
            }
            set
            {
                this.days = value;
            }
        }
        public virtual IEnumerable<DayInfo> All()
        {
            Attribute assembly = this.GetType().GetTypeInfo().GetCustomAttribute(typeof(CatholicCountryAttribute));
            if (assembly != null)
            {
                ChristianDayInfo cdi = new ChristianDayInfo();
                Days.AddRange(cdi.All());
            }
            return Days;
        }

        public static IEnumerable<DayInfo> All(string twoLetterISORegionName)
        {
            var di = dayinfosList.FirstOrDefault(x => x.TwoLetterISORegionName == twoLetterISORegionName);
            if (di != null)
            {
                di.Days.Clear();// hack: avoid duplicates at every call ... ==> fix that later
                return di.All();
            }
            return null;
        }


        private static List<DayInfo> RegisterAllDerived()
        {
            List<DayInfo> dayinfos = new List<DayInfo>();

            Assembly currAssembly = typeof(DayInfo).GetTypeInfo().Assembly;
            Type baseType = typeof(DayInfo);

            var types = currAssembly.DefinedTypes.Where(x => x.IsClass && !x.IsAbstract && x.IsSubclassOf(baseType)).Select(x => x.AsType());
            foreach (Type type in types)
            {
                DayInfo derivedObject = System.Activator.CreateInstance(type) as DayInfo;
                if (derivedObject != null)
                {
                    dayinfos.Add(derivedObject);
                }
            }

            return dayinfos;
        }

        /// <summary>
        /// format TITLE:URL, TITLE:URL, TITLE:URL
        /// </summary>
        /// <param name="rawLinks"></param>
        /// <returns></returns>
        protected IEnumerable<Url> GetLinksFromRessource(string rawLinks)
        {
            // format spécial pour liens dans le fichier ressource?
            string[] linksAndtitle = rawLinks.Split(new char[] { ',' });
            if (linksAndtitle.Length <= 1)
            {
                yield return new Url
                {
                    URL = rawLinks
                };
            }
            else
            {
                foreach (string linkAntTitle in linksAndtitle)
                {
                    string[] parts = linkAntTitle.Split(new char[] { ':' });
                    if (parts.Length != 2)
                    {
                        yield return new Url
                        {
                            URL = linkAntTitle
                        };
                    }
                    else
                    {
                        yield return new Url
                        {
                            Title = parts[0],
                            URL = parts[1]
                        };
                    }
                }
            }

        }
    }
}
