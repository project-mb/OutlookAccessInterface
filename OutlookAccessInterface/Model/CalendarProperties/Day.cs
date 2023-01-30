using System.Collections.Generic;

namespace OutlookAccessInterface.Model.CalendarProperties
{
	public class Day
	{
		public static int ID { get; private set; } //	=> an unique identifier

		public string Date { get; } //					=> date of day
		public string DayType { get; } //				=> day type of day

		public double StartTime { get; } //				=> start time of day
		public List<RecordEntry> Records { get; } //	=> all records that occured on that day

		public Day(string date, string dayType, double startTime, List<RecordEntry> records)
		{
			ID++;
			Date = date;
			DayType = dayType;
			StartTime = startTime;
			Records = records;
		}
	}
}
