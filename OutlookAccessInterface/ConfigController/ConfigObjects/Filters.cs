namespace OutlookAccessInterface.ConfigController.ConfigObjects
{
	public class Filters
	{
		//NSEC: default filter
		public static readonly string[] defaultcalFilter = { "ics files (*.ics)|*.ics" };
		public static readonly string[] defaultdatFilter = { "accdb files (*.accdb)|*.accdb" };

		//N: calendar filter for file selection
		public string[] CalFilter { get; internal set; }

		//N: database filter for file selection
		public string[] DatFilter { get; internal set; }

		public Filters() : this(defaultcalFilter, defaultdatFilter) { }

		public Filters(string[] calFilter, string[] datFilter)
		{
			CalFilter = calFilter;
			DatFilter = datFilter;
		}
	}
}
