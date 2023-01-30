using System.Collections.Generic;

namespace OutlookAccessInterface.Model.CalendarProperties
{
	public class Day
	{
		public string Date { get; }
		public string DayType { get; }

		public double StartTime { get; }
		public List<RecordEntry> Records { get; }
	}
}
