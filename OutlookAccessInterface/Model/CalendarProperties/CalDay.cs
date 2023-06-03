using System.Collections.Generic;

namespace OutlookAccessInterface.Model.CalendarProperties
{
	public class CalDay
	{
		private static int ID { get; set; } //	=> an unique identifier

		private string Date { get; } //					=> date of day
		private string DayType { get; } //				=> day type of day

		private double StartTime { get; } //				=> start time of day
		private List<object> Records { get; } //	=> all records that occured on that day

		public CalDay(string date, string dayType, double startTime, List<object> records)
		{
			ID++;
			Date = date;
			DayType = dayType;
			StartTime = startTime;
			Records = records;
		}
	}
}
