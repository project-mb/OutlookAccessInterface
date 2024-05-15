using System.Globalization;
using System.Windows.Documents;
using Ical.Net.Interfaces.Components;
using Ical.Net.Interfaces.DataTypes;
using Ical.Net.Interfaces.General;
using OutlookAccessInterface.__development__;
using OutlookAccessInterface.model.calendarProperties;
using OutlookAccessInterface.model.databaseProperties;
using Calendar = Ical.Net.Calendar;

namespace OutlookAccessInterface.utility;

public class ICSReader : ICalendarReader
{
	//NSEC: class members

	//NSEC: instance members
	//NSEC: singleton
	private static ICSReader? _instance;
	public static ICSReader get_instance(string calendarFilePath) { return _instance ??= new ICSReader(calendarFilePath); }
	public static void release_instance() { _instance = null; }
	private ICSReader(string calendarFilePath) { this.calendarFilePath = calendarFilePath; }

	//NSEC: fields
	private readonly string calendarFilePath;
	

	//NSEC: methods
	private CalEvent convert_IEvent_to_CalEvent(IEvent icsEvnt, CalEventType eventType = CalEventType.NORMAL)
	{
		DateTime startDate = get_calEventTime(icsEvnt.Start);
		DateTime endDate = get_calEventTime(icsEvnt.End);

		double startTime = Convert.ToDouble($"{startDate.Hour},{startDate.Minute}");
		double endTime = Convert.ToDouble($"{endDate.Hour},{endDate.Minute}");
		string evntClass = get_calEventClass(icsEvnt);
		string summary = get_calEventSummary(icsEvnt);

		return eventType == CalEventType.NORMAL ?
			new CalEvent(startDate, endDate, startTime, endTime, evntClass, summary) :
			new CalEvent(startDate, endDate, evntClass, summary);
	}

	private static DateTime get_calEventTime(IDateTime time)
	{
		string dateTimeString = time.ToString() ?? string.Empty;
		string[] dateTimeSplit = dateTimeString.Split(' ');

		// date
		string dateString = dateTimeSplit[0];
		DateTime date = Convert.ToDateTime(dateString);

		// time
		if(dateTimeSplit.Length <= 1) return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);

		string[] timeSplit = dateTimeSplit[1].Split(':');
		int hour = Convert.ToInt32(timeSplit[0]);
		int minute = Convert.ToInt32(timeSplit[1]);
		int second = Convert.ToInt32(timeSplit[2]);

		//N: convert 15, 30 and 45 to fracture, for example 15=0.25 based on 0.{minute}{second}
		//N: this is necessary becaus DateTime hours, minutes and seconds only allow integers
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

	private static string get_calEventClass(IEvent icsEvent) { return icsEvent.Class ?? ""; }

	private static string get_calEventSummary(IEvent icsEvent) { return icsEvent.Summary != null ? icsEvent.Summary.TrimStart().TrimEnd() : ""; }

	private CalEventRecord convertCalEventToCalEventRecord(CalEvent calEvnt) { throw new NotImplementedException(); }

	// methods
	private List<CalEvent> get_calendarEventsFromICSFile(DateTime? fromDate, DateTime? toDate)
	{
		List<CalEvent> calEvents = [];
		Dictionary<DateTime, CalDay> calDays = [];
		List<DateTime> days = [];

		CalEvent temp_calEvent;
		CalEvent current_calEvent;

		//N: load all events from ics file
		IUniqueComponentList<IEvent> iEvents = Calendar.LoadFromFile(this.calendarFilePath)[0].Events;

		foreach (IEvent evnt in iEvents) {
			//N: filter out events outside from and to date
			if(evnt.Start.Date.CompareTo(fromDate) < 0 || evnt.Start.Date.CompareTo(toDate) > 0) continue;

			//N: filter out allDay events
			if(evnt.IsAllDay) continue;

			//N: create a temporary CalEvent in case it is a multiday event
			temp_calEvent = this.convert_IEvent_to_CalEvent(evnt);

			//N: split multiday events
			TimeSpan timeSpan = evnt.End.Date - evnt.Start.Date;
			int number_of_days = timeSpan.Days + 1;
			DebugTools.debug($"is spaned over {number_of_days}");

			//N: loop through the number of days an event spans over to create copies of these events
			for (int i = 0; i < number_of_days; i++) {
				current_calEvent = (CalEvent) temp_calEvent.Clone();
				//TODO filter out endTimes that are 00:00:00
				
				//N: update time and date of multiday events
				if(number_of_days > 1) {
					temp_calEvent.set_date(temp_calEvent.Date.AddDays(1));
					current_calEvent.set_startTime(0);
					current_calEvent.set_date(temp_calEvent.Date);
					current_calEvent.set_endDate(temp_calEvent.Date);
					if(i < number_of_days) { current_calEvent.set_endTime(24); } else { current_calEvent.set_endTime(temp_calEvent.EndTime); }
				}

				//N: add the date of the event to the date list
				if(!days.Contains(current_calEvent.Date)) { days.Add(current_calEvent.Date); }

				calEvents.Add(current_calEvent);

				//TODO: remove debug message
				DebugTools.info(String.Format("{0}|{1}:{2}|{3}:{4}|{5}|{6}|{7}", evnt.Start.Date.ToString(CultureInfo.CurrentCulture), evnt.Start.Hour, evnt.Start.Minute, evnt.End.Hour, evnt.End.Minute,
					evnt.Duration, evnt.Class, evnt.Summary));
			}
		}

		return calEvents;
	}

	public List<CalDay> get_calendarDaysWithRecords(DateTime? fromDate, DateTime? toDate)
	{
		List<CalEvent> calEvents = [];
		List<CalDay> calDays = [];

		calEvents = get_calendarEventsFromICSFile(fromDate, toDate);

		throw new NotImplementedException();
	}
	
	//NSEC: interface ICalendarReader
	public List<DBDay> get_days() { throw new NotImplementedException(); }
	public List<DBProject> get_projects() { throw new NotImplementedException(); }
	public List<DBCostCentreClient> get_costCentreClients() { throw new NotImplementedException(); }
	public List<DBRecord> get_records(DateTime? from, DateTime? to) { throw new NotImplementedException(); }
}
