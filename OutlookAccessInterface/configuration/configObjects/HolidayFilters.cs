using System.Runtime.CompilerServices;

namespace OutlookAccessInterface.configuration.configObjects;

public class HolidayFilters
{
	//NSEC: singleton
	private static HolidayFilters _instance = null!;
	public static HolidayFilters get_instance() { return (_instance != null) ? _instance : _instance = new HolidayFilters(); }

	//NSEC: default holidays
	private static readonly string[]? DEFAULT_HOLIDAYS = {
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
	};

	//NSEC: member attributes

	//N: list of holidays
	public string[]? Holidays { get; private set; } = DEFAULT_HOLIDAYS;

	public void set_holidays(string[]? holidays) { this.Holidays = holidays; }
}
