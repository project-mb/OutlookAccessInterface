using System.Runtime.CompilerServices;

namespace OutlookAccessInterface.configuration.configObjects;

public class FileFilters
{
	//NSEC: singleton
	private static FileFilters _instance = null!;
	public static FileFilters get_instance() { return (_instance != null!) ? _instance : _instance = new FileFilters(); }

	//NSEC: default filter
	public static readonly string[]? DEFAULT_CALENDARFILTER = { "ics files (*.ics)|*.ics" };
	public static readonly string[]? DEFAULT_DATABASEFILTER = { "accdb files (*.accdb)|*.accdb" };

	//NSEC: member attributes
	private string[]? calendarFilter = DEFAULT_CALENDARFILTER;
	private string[]? databaseFilter = DEFAULT_DATABASEFILTER;

	//N: calendar filter for file selection
	public string[]? CalendarFilter { get => this.calendarFilter; }
	public void set_calendarFilter(string[]? filter) { this.calendarFilter = filter; }

	//N: database filter for file selection
	public string[]? DatabaseFilter { get => this.databaseFilter; }
	public void set_databaseFilter(string[]? filter) { this.databaseFilter = filter; }
}
