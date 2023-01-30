namespace OutlookAccessInterface.Model.CalendarProperties
{
	public class RecordEvent
	{
		public string Original { get; }

		public int ID { get; }

		public string Date { get; }
		public double StartTime { get; }
		public double EndTime { get; }

		public string Client { get; }
		public string Project { get; }
		public int PrjNum { get; }
		public string WorkType { get; }
		public double Duration { get; }
		public string Addition { get; }
		public string CostCentreClient { get; }
		public int CCCNum { get; }
	}
}
