using System;
using System.Diagnostics;
using Ical.Net;

namespace OutlookAccessInterface.Model
{
    public class CalendarReader
    {
        private readonly string calendarFile;

        public CalendarReader(string calendarFile)
        {
            this.calendarFile = calendarFile;
        }

        public void ReadICS(string startDate = "01.01.0001", string endDate = "31.12.3000")
        {
            var calendarCollection = Calendar.LoadFromFile(calendarFile)[0];

            DateTime calStartDate = Convert.ToDateTime(startDate);
            DateTime calEndDate = Convert.ToDateTime(startDate);
            DateTime evntStartDate;
            DateTime evntEndDate;
            
            foreach (var evnt in calendarCollection.Events)
            {
                Debug.Print(evnt.ToString());
                
                if (!evnt.IsAllDay)
                {
                    
                }
            }
        }
    }
}
