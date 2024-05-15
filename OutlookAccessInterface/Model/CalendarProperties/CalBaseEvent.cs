namespace OutlookAccessInterface.model.calendarProperties;

public abstract class CalBaseEvent
{
	//NSEC: class members
	private static int ID { get; set; } //		=> an unique identifier

	//NSEC: instance members
	protected CalBaseEvent(DateTime date, double startTime, double endTime)
	{
		ID++;
		this.Date = date;
		this.StartTime = startTime;
		this.EndTime = endTime;
	}

	//NSEC: fields
	public DateTime Date { get; private set; } //		=> date on which the event occured
	public double StartTime { get; private set; } //		=> time the event has started
	public double EndTime { get; private set; } //			=> time the event ended (can be on the following day)

	//NSEC: setter
	public void set_date(DateTime date) { this.Date = date; }
	public void set_startTime(double startTime) { this.StartTime = startTime; }
	public void set_endTime(double endTime) { this.EndTime = endTime; }
}
