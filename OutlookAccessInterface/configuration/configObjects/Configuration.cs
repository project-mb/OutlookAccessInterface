namespace OutlookAccessInterface.configuration.configObjects;

public static class Configuration
{
	//NSEC: class members
	//N: contains the current .ics/.pst Calendar-File
	public static string CALENDARFILE;

	//N: contains the current .accdb AccessDatabase-File
	public static string DATABASEFILE;

	public const string DEFAULT_FROMTIME = "01.01.0001";
	public const string DEFAULT_TOTIME = "31.12.3000";
	
	public static FileFilters FileFilters { get; } = FileFilters.get_instance();
	public static FileLocations FileLocations { get; } = FileLocations.get_instance();
	public static HolidayFilters HolidayFilters { get; } = HolidayFilters.get_instance();
}
