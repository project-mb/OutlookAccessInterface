namespace OutlookAccessInterface.ConfigController.ConfigObjects
{
	public static class Filters
	{
		//NSEC: default filter
		public static readonly string[] defaultcalFilter = { "ics files (*.ics)|*.ics" };
		public static readonly string[] defaultdatFilter = { "accdb files (*.accdb)|*.accdb" };

		//N: calendar filter for file selection
		public static string[] CalFilter { get; internal set; }

		//N: database filter for file selection
		public static string[] DatFilter { get; internal set; }
	}
}
