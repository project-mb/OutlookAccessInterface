using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Ical.Net.Interfaces;
using Ical.Net.Interfaces.Components;
using OutlookAccessInterface.Model.CalendarProperties;
using Calendar = Ical.Net.Calendar;
using OutlookAccessInterface.ConfigController.ConfigObjects;
using Day = OutlookAccessInterface.Model.CalendarProperties.Day;

namespace OutlookAccessInterface.Model
{
	public class CalendarReader
	{
		private readonly string calendarFile;

		private List<CalendarEvent> Events { get; }
		private List<CalendarEvent> PublicHolidays { get; }
		private List<CalendarEvent> OtherEvents { get; }
		private List<Day> Days { get; }
		private List<DayType> LutDayType { get; }

		public CalendarReader(string calendarFile)
		{
			this.calendarFile = calendarFile;

			Events = new List<CalendarEvent>();
			PublicHolidays = new List<CalendarEvent>();
			OtherEvents = new List<CalendarEvent>();
			Days = new List<Day>();
			LutDayType = new List<DayType>();
		}

		public void GetCalendarEventsFromICSFile(string startDate = "01.01.0001", string endDate = "31.12.3000")
		{
			ICalendar calendarCollection = Calendar.LoadFromFile(this.calendarFile)[0];

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
				} else {
					//TODO: make holiday list editable (maybe json)

					if (HolidayFilters.holidays.Contains(evnt.Summary.ToLower().Trim())) PublicHolidays.Add(new CalendarEvent(evnt.Start.ToString(), evnt.Summary));
					else OtherEvents.Add(new CalendarEvent(evnt.Start.ToString(), evnt.Summary));
				}
			}
		}
	}
}
