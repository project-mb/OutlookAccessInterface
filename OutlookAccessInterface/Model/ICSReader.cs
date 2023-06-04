using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Ical.Net.Interfaces;
using Ical.Net.Interfaces.Components;
using Ical.Net.Interfaces.DataTypes;
using OutlookAccessInterface.Model.CalendarProperties;
using Calendar = Ical.Net.Calendar;
using OutlookAccessInterface.ConfigController.ConfigObjects;

namespace OutlookAccessInterface.Model
{
	public class ICSReader
	{
		//Singleton
		private static ICSReader _reader;
		public static ICSReader create(string calendarFilePath) { return _reader ??= new ICSReader(calendarFilePath); }
		public static void release() { _reader = null; }

		private ICSReader(string calendarFilePath)
		{
			this.calendarFilePath = calendarFilePath;

			CalendarEvents = new List<CalEvent>();
			// PublicHolidays = new List<CalEvent>();
			OtherEvents = new List<CalEvent>();
			CalendarDays = new List<CalDay>();
			LutDayType = new List<DayType>();
		}

		~ICSReader() { _reader = null; }


		private readonly string calendarFilePath;

		private List<CalEvent> CalendarEvents { get; }

		// private List<CalEvent> PublicHolidays { get; }
		private List<CalEvent> OtherEvents { get; }
		private List<CalDay> CalendarDays { get; }
		private List<DayType> LutDayType { get; }

		// class methods
		private CalEvent convertIcsEventToCalEvent(IEvent icsEvnt, bool other = false)
		{
			DateTime startDate = getCalEventTime(icsEvnt.Start);
			DateTime endDate = getCalEventTime(icsEvnt.End);

			string startDateString = startDate.ToShortDateString();
			string endDateString = endDate.ToShortDateString();
			double startTime = Convert.ToDouble($"{startDate.Hour},{startDate.Minute}");
			double endTime = Convert.ToDouble($"{endDate.Hour},{endDate.Minute}");
			string evntClass = getCalEventClass(icsEvnt);
			string summary = getCalEventSummary(icsEvnt);

			return !other ? new CalEvent(startDateString, endDateString, startTime, endTime, evntClass, summary) :
				new CalEvent(startDateString, endDateString, evntClass, summary);
		}

		private DateTime getCalEventTime(IDateTime time)
		{
			string timeString = (time != null) ? time.ToString() : "";
			string[] timeSplit = timeString.Split(' ');

			// date
			string dateString = timeString.Split(' ')[0];
			DateTime date = Convert.ToDateTime(dateString);

			// time
			if(timeSplit.Length <= 1) return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);

			int hour = Convert.ToInt32(timeSplit[1].Split(':')[0]);
			int minute = Convert.ToInt32(timeSplit[1].Split(':')[1]);
			int second = Convert.ToInt32(timeSplit[1].Split(':')[2]);
			switch (minute) {
				case 15:
					minute = 2;
					second = 5;
					break;
				case 30:
					minute = 5;
					second = 0;
					break;
				case 45:
					minute = 7;
					second = 5;
					break;
			}

			return new DateTime(date.Year, date.Month, date.Day, hour, minute, second);
		}

		private string getCalEventClass(IEvent icsEvent) { return icsEvent.Class ?? ""; }
		private string getCalEventSummary(IEvent icsEvent) { return (icsEvent.Summary != null) ? icsEvent.Summary.TrimStart().TrimEnd() : ""; }

		private CalEventRecord convertCalEventToCalEventRecord(CalEvent calEvnt) { throw new NotImplementedException(); }

		// methods
		public void getCalendarEventsFromICSFile(string startDate = "01.01.0001", string endDate = "31.12.3000")
		{
			ICalendar calendarCollection = Calendar.LoadFromFile(this.calendarFilePath)[0];

			DateTime calStartDate = Convert.ToDateTime(startDate);
			DateTime calEndDate = Convert.ToDateTime(endDate);

			List<CalEvent> calEvents = new List<CalEvent>();

			foreach (IEvent evnt in calendarCollection.Events) {
				if(evnt.Start.Date.CompareTo(calStartDate) < 0 || evnt.Start.Date.CompareTo(calEndDate) > 0) return;

				if(!evnt.IsAllDay) {
					//TODO: remove debug message
					Debug.Print("{0}|{1}:{2}|{3}:{4}|{5}|{6}|{7}", evnt.Start.Date.ToString(CultureInfo.CurrentCulture), evnt.Start.Hour, evnt.Start.Minute, evnt.End.Hour, evnt.End.Minute,
						evnt.Duration, evnt.Class, evnt.Summary);

					CalendarEvents.Add(convertIcsEventToCalEvent(evnt));
				} else {
					//TODO: make holiday list editable (maybe json)

					OtherEvents.Add(convertIcsEventToCalEvent(evnt, true));


					//TODO: fix Bug; move function
					//if (HolidayFilters.holidays.Contains(evnt.Summary.ToLower().Trim())) PublicHolidays.Add(new CalEvent(evnt.Start.ToString(), evnt.Summary));
					//else OtherEvents.Add(new CalEvent(evnt.Start.ToString(), evnt.Summary));
				}
			}
		}
	}
}
