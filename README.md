# DayInfo

The aim of the "DayInfo" lib is to provide information about special days in different countries.

For now it provides the day off for Belgium and Luxembourg

Here is a demo : http://joursferies.eu/

use :
'  IEnumerable<DateInfo> luxembourgDayOff = DateInfo.Get("LU", DateTime.Today.Year);

            IEnumerable<DateInfo> belgiumDayOff = DateInfo.Get("BE", DateTime.Today.Year);

            foreach(var belgiumDate in belgiumDayOff)
            {
                TestContext.WriteLine("date : {0:d}", belgiumDate.Date);
                TestContext.WriteLine("Holliday : {0:d}", belgiumDate.DayInfo.EnglishName);
            }
            
