namespace OutlookAccessInterface.configuration.configObjects;

public class HolidayFilters
{
	//NSEC: class members
	private static readonly List<string>? DEFAULT_HOLIDAYS = [
		"allerheiligen",
		"christihimmelfahrt",
		"mariämimmelfahrt",
		"fronleichnam",
		"ostersonntag",
		"ostermontag",
		"heiligedreikönige",
		"mariäempfängnis",
		"nationalfeiertag",
		"neujahrstag",
		"pfingstmontag",
		"pfingstsonntag",
		"tagderarbeit",
		"weihnachtstag",
		"stephanitag",
		"gründonnerstag",
		"karfreitag",
		"silvester",
		"heiligerabend"
	]; //N: default holidays

	//NSEC: instance members
	//NSEC: singleton
	private static HolidayFilters? _instance;
	public static HolidayFilters get_instance() { return _instance ??= new HolidayFilters(); }

	//NSEC: member attributes
	public List<string>? Holidays { get; private set; } = DEFAULT_HOLIDAYS; //N: list of holidays

	//NSEC: setter
	public void set_holidays(List<string>? holidays) { this.Holidays = holidays; }
}
