namespace OutlookAccessInterface.model.calendarProperties;

public class CalDay
{
	//NSEC: class members
	public static int ID { get; private set; } //	=> an unique identifier

	//NSEC: instance members
	public CalDay(DateTime date, string dayType, double startTime, List<CalEventRecord> records)
	{
		ID++;
		this.Date = date;
		this.DayType = dayType;
		this.StartTime = startTime;
		this.Records = records;
	}

	//NSEC: fields
	public DateTime Date { get; } //N: date of day
	public string DayType { get; } //N: day type of day

	public double StartTime { get; } //N: start time of day
	public List<CalEventRecord> Records { get; } //N: all CalEventRecords that occured on that day
}
