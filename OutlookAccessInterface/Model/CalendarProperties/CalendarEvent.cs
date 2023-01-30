using System.Reflection.Emit;

namespace OutlookAccessInterface.Model.CalendarProperties
{
	public class CalendarEvent
	{
		//N: index for unique identifier
		public static int Index { get; private set; }


		public string Date { get; }
		public double StartTime { get; }
		public double EndTime { get; }
		public double DurationTime { get; }
		public string _Class { get; }
		public string Summary { get; }

		public CalendarEvent(string date, double startTime, double endTime, double durationTime, string _class, string summary)
		{
			Index++;
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
