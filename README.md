# DayInfo

The aim of the "DayInfo" lib is to provide information about special days in different countries.

For now it provides the day off for Belgium and Luxembourg

Here is a demo : http://joursferies.eu/

use :
'
            IEnumerable<DateInfo> belgiumDayOff = DateInfo.Get("BE", DateTime.Today.Year);// or "LU"

            foreach(var belgiumDate in belgiumDayOff)
            {
                TestContext.WriteLine("date : {0:d}", belgiumDate.Date);
                TestContext.WriteLine("Holliday : {0:d}", belgiumDate.DayInfo.EnglishName);
            }
            
output
'
date : 06/04/2015
Holliday : Easter monday
date : 14/05/2015
Holliday : Ascension
date : 25/05/2015
Holliday : pentecode_totransalate
date : 15/08/2015
Holliday : Assumption 
date : 01/11/2015
Holliday : All Saints
date : 25/12/2015
Holliday : Christmas
date : 01/01/2015
Holliday : New Year
date : 01/05/2015
Holliday : Labour Day
date : 21/07/2015
Holliday : National Day
date : 11/11/2015
Holliday : First Armistice
