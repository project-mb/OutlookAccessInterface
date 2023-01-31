namespace OutlookAccessInterface.ConfigController.ConfigObjects
{
	public class Filters
	{
		//NSEC: default filter
		public static readonly string[] defaultcalFilter = { "ics files (*.ics)|*.ics" };
		public static readonly string[] defaultdatFilter = { "accdb files (*.accdb)|*.accdb" };

		//N: calendar filter for file selection
		public string[] calFilter { get; internal set; }

		//N: database filter for file selection
		public string[] datFilter { get; internal set; }

		public Filters() : this(defaultcalFilter, defaultdatFilter) { }

		public Filters(string[] calFilter, string[] datFilter)
		{
			this.calFilter = calFilter;
			this.datFilter = datFilter;
		}
	}
}
