using System.Reflection.Emit;

namespace OutlookAccessInterface.Model.CalendarProperties
{
	public class CalendarEvent
	{
		public static int ID { get; private set; } //	=> an unique identifier

		public string Date { get; } //					=> date on which the event occured
		public double StartTime { get; } //				=> time the event has started
		public double EndTime { get; } //				=> time the event ended (can be on the following day)
		public double DurationTime { get; } //			=> duration of event
		public string _Class { get; } //				=> class of event (eg. private/public/...)
		public string Summary { get; } //				=> content of event

		public CalendarEvent(string date, double startTime, double endTime, double durationTime, string _class, string summary)
		{
			ID++;
			Date = date;
			StartTime = startTime;
			EndTime = endTime;
			DurationTime = durationTime;
			_Class = _class;
			Summary = summary;
		}

		public CalendarEvent(string date, string summary) : this(date, 0, 24, 24, "", summary) { }
	}
}
