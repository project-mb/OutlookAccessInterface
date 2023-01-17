using System;
using System.Diagnostics;
using Ical.Net;
using Ical.Net.Interfaces;
using Ical.Net.Interfaces.Components;

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
			ICalendar calendarCollection = Calendar.LoadFromFile(calendarFile)[0];

			DateTime calStartDate = Convert.ToDateTime(startDate);
			DateTime calEndDate = Convert.ToDateTime(startDate);
			DateTime evntStartDate;
			DateTime evntEndDate;

			foreach (IEvent evnt in calendarCollection.Events) {
				if (evnt.Start.Date.CompareTo(startDate) < 0 || evnt.Start.Date.CompareTo(endDate) > 0) return;

				Debug.Print(evnt.ToString());

				if (!evnt.IsAllDay) { }
			}
		}
	}
}
