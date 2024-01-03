namespace OutlookAccessInterface.configuration.configObjects;

public static class Configuration
{
	//N: contains the current .ics/.pst Calendar-File
	public static string CALENDARFILE;

	//N: contains the current .accdb AccessDatabase-File
	public static string DATABASEFILE;
	
	public static FileFilters FileFilters { get; } = FileFilters.get_instance();
	public static FileLocations FileLocations { get; } = FileLocations.get_instance();
	public static HolidayFilters HolidayFilters { get; } = HolidayFilters.get_instance();
}
