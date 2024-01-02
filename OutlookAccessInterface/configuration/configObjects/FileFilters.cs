namespace OutlookAccessInterface.configuration.configObjects;

public static class FileFilters
{
	//NSEC: default filter
	public static readonly string[] DEFAULT_CALENDARFILTER = { "ics files (*.ics)|*.ics" };
	public static readonly string[] DEFAULT_DATABASEFILTER = { "accdb files (*.accdb)|*.accdb" };

	//N: calendar filter for file selection
	public static string[] CalendarFilter { get; internal set; }

	//N: database filter for file selection
	public static string[] DatabaseFilter { get; internal set; }
}
