namespace OutlookAccessInterface.ConfigController.ConfigObjects
{
	public static class FileFilters
	{
		//NSEC: default filter
		public static readonly string[] defaultcalFilter = { "ics files (*.ics)|*.ics" };
		public static readonly string[] defaultdatFilter = { "accdb files (*.accdb)|*.accdb" };

		//N: calendar filter for file selection
		public static string[] CalendarFilter { get; internal set; }

		//N: database filter for file selection
		public static string[] DatabaseFilter { get; internal set; }
	}
}
