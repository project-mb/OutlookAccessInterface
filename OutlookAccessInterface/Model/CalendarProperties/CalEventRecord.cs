namespace OutlookAccessInterface.model.calendarProperties;

public class CalEventRecord : CalBaseEvent
{
	//NSEC: instance members
	public CalEventRecord(string original, DateTime date, double startTime, double endTime, bool isSunOrHoliday, int projectNumber, string workType, double duration, string addition,
		int cccNumber, int clientNumber, int projectName) : base(date, startTime, endTime)
	{
		this.Original = original;
		this.ClientNumber = clientNumber;
		this.ProjectNumber = projectNumber;
		this.ProjectName = projectName;
		this.WorkType = workType;
		this.Duration = duration;
		this.Addition = addition;
		this.CostCentreClientNumber = cccNumber;
		this.IsSunOrHoliday = isSunOrHoliday;
	}

	//NSEC: instance members
	public string Original { get; } //N: original summary string of calender event

	public int ClientNumber { get; } //N: client number of recordEvent
	public int ProjectNumber { get; } //N: project number of recordEvent
	public int ProjectName { get; } //N: project number of recordEvent
	public string WorkType { get; } //N: workType of recordEvent
	public double Duration { get; } //N: duration of recordEvent
	public string Addition { get; } //N: addition of recordEvent
	public int CostCentreClientNumber { get; } //N: costCentreClient number of recordEvent

	public bool IsSunOrHoliday { get; set; } //N: is the event on a Sunday/Holiday
}
