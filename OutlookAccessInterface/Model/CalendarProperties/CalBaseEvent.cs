namespace OutlookAccessInterface.model.calendarProperties;

public abstract class CalBaseEvent
{
	protected CalBaseEvent(string startDate, double startTime, double endTime)
	{
		ID++;
		StartDate = startDate;
		StartTime = startTime;
		EndTime = endTime;
	}

	private static int ID { get; set; } //		=> an unique identifier

	private string StartDate { get; } //		=> date on which the event occured
	private double StartTime { get; } //		=> time the event has started
	private double EndTime { get; } //			=> time the event ended (can be on the following day)
}
