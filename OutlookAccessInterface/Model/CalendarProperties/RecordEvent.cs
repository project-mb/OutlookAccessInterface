namespace OutlookAccessInterface.Model.CalendarProperties
{
	public class RecordEvent
	{
		public static int ID { get; private set; } //	=> an unique identifier

		public string Original { get; } //				=> original summary string of calender event

		public string Date { get; } //					=> date recordEvent has started
		public double StartTime { get; } //				=> time recordEvent has started
		public double EndTime { get; } //				=> time recordEvent has ended

		public string Client { get; } //				=> client of recordEvent
		public string Project { get; } //				=> project of recordEvent
		public int PrjNum { get; } //					=> project number of recordEvent
		public string WorkType { get; } //				=> workType of recordEvent
		public double Duration { get; } //				=> duration of recordEvent
		public string Addition { get; } //				=> addition of recordEvent
		public string CostCentreClient { get; } //		=> costCentreClient of recordEvent
		public int CCCNum { get; } //					=> costCentreClient number of recordEvent

		public RecordEvent(string original, int id, string date, double startTime, double endTime, string client, string project, int prjNum, string workType, double duration, string addition,
			string costCentreClient, int cccNum)
		{
			ID++;
			Original = original;
			ID = id;
			Date = date;
			StartTime = startTime;
			EndTime = endTime;
			Client = client;
			Project = project;
			PrjNum = prjNum;
			WorkType = workType;
			Duration = duration;
			Addition = addition;
			CostCentreClient = costCentreClient;
			CCCNum = cccNum;
		}
	}
}
