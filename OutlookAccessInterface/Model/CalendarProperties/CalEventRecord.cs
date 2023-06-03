namespace OutlookAccessInterface.Model.CalendarProperties
{
	public class CalEventRecord : CalBaseEvent
	{
		private string Original { get; } //				=> original summary string of calender event

		private int ClientNumber { get; } //			=> client number of recordEvent
		private int ProjectNumber { get; } //			=> project number of recordEvent
		private int ProjectName { get; } //				=> project number of recordEvent
		private string WorkType { get; } //				=> workType of recordEvent
		private double Duration { get; } //				=> duration of recordEvent
		private string Addition { get; } //				=> addition of recordEvent
		private int CostCentreClientNumber { get; } //					=> costCentreClient number of recordEvent

		private bool IsSunOrHoliday { get; set; } //		=> is the event on a Sunday/Holiday


		public CalEventRecord(string original, string startDate, double startTime, double endTime, bool isSunOrHoliday, int projectNumber, string workType, double duration, string addition,
			int cccNumber, int clientNumber, int projectName) : base(startDate, startTime, endTime)
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
	}
}
