using System;
using System.Diagnostics;
using System.Globalization;
using Ical.Net.Interfaces;
using Ical.Net.Interfaces.Components;
using OutlookAccessInterface.Model.CalendarProperties;
using Calendar = Ical.Net.Calendar;

namespace OutlookAccessInterface.Model
{
	public class CalendarReader
	{
		private readonly string calendarFile;

		public CalendarReader(string calendarFile) { this.calendarFile = calendarFile; }

		public void ReadICS(string startDate = "01.01.0001", string endDate = "31.12.3000")
		{
			ICalendar calendarCollection = Calendar.LoadFromFile(calendarFile)[0];

			DateTime calStartDate = Convert.ToDateTime(startDate);
			DateTime calEndDate = Convert.ToDateTime(endDate);
			DateTime evntStartDate;
			DateTime evntEndDate;

			CalendarEvent calEvnt;


			foreach (IEvent evnt in calendarCollection.Events) {
				if (evnt.Start.Date.CompareTo(calStartDate) < 0 || evnt.Start.Date.CompareTo(calEndDate) > 0) return;

				if (!evnt.IsAllDay) {
					//TODO: remove debug message
					Debug.Print("{0}|{1}:{2}|{3}:{4}|{5}|{6}|{7}", evnt.Start.Date.ToString(CultureInfo.CurrentCulture), evnt.Start.Hour, evnt.Start.Minute, evnt.End.Hour, evnt.End.Minute,
						evnt.Duration, evnt.Class, evnt.Summary);
				}
			}
		}
	}
}
