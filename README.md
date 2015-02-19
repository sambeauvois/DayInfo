# DayInfo

The aim of the "DayInfo" lib is to provide information about special days in different countries.

For now it provides the day off for Belgium and Luxembourg

Here is a demo : http://joursferies.eu/

### use :
```csharp
            IEnumerable<DateInfo> belgiumDayOff = DateInfo.Get("BE", DateTime.Today.Year);// or "LU"

            foreach(var belgiumDate in belgiumDayOff)
            {
                TestContext.WriteLine("date : {0:d}", belgiumDate.Date);
                TestContext.WriteLine("Holiday : {0:d}", belgiumDate.DayInfo.EnglishName);
            }
```         

#### output

```
date : 06/04/2015
Holiday : Easter monday
date : 14/05/2015
Holiday : Ascension
date : 25/05/2015
Holiday : pentecode_totransalate
date : 15/08/2015
Holiday : Assumption 
date : 01/11/2015
Holiday : All Saints
date : 25/12/2015
Holiday : Christmas
date : 01/01/2015
Holiday : New Year
date : 01/05/2015
Holiday : Labour Day
date : 21/07/2015
Holiday : National Day
date : 11/11/2015
Holiday : First Armistice
```
