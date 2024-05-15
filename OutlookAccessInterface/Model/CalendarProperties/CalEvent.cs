namespace OutlookAccessInterface.model.calendarProperties;

public class CalEvent : CalBaseEvent, ICloneable
{
	//NSEC: class members

	//NSEC: instance members
	public CalEvent(DateTime date, DateTime endDate, double startTime, double endTime, string evntClass, string summary) : base(date, startTime, endTime)
	{
		this.EndDate = endDate;
		this._Class = evntClass;
		this.Summary = summary;
	}
	public CalEvent(DateTime date, DateTime endDate, string evntClass, string summary) : this(date, endDate, 0, 24, evntClass, summary) { }

	//NSEC: instance fields
	public DateTime EndDate { get; private set; } //N: end date of event
	public string _Class { get; } //N: class of event (eg. private/public/...)
	public string Summary { get; } //N: content of event

	//NSEC: instance setter
	public void set_endDate(DateTime endDate) { this.EndDate = endDate; }

	//NSEC: instance methods
	public object Clone() { return this.MemberwiseClone(); }
}
