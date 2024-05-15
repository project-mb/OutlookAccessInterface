namespace OutlookAccessInterface.configuration.configObjects;

public class FileFilters
{
	//NSEC: class members
	//NSEC: default filter
	public static readonly string[]? DEFAULT_CALENDARFILTER = ["ics files (*.ics)|*.ics"];
	public static readonly string[]? DEFAULT_DATABASEFILTER = ["accdb files (*.accdb)|*.accdb"];

	//NSEC: instance members
	//NSEC: singleton
	private static FileFilters? _instance;
	public static FileFilters get_instance() { return _instance ??= new FileFilters(); }

	//NSEC: instance fields
	//N: calendar filter for file selection
	public string[]? CalendarFilter { get; private set; } = DEFAULT_CALENDARFILTER;
	public void set_calendarFilter(string[]? filter) { this.CalendarFilter = filter; }

	//N: database filter for file selection
	public string[]? DatabaseFilter { get; private set; } = DEFAULT_DATABASEFILTER;
	public void set_databaseFilter(string[]? filter) { this.DatabaseFilter = filter; }
}
