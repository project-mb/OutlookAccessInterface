namespace OutlookAccessInterface.ConfigController.ConfigObjects
{
	public static class HolidayFilters
	{
		//NSEC: default holidays
		public static readonly string[] defaultHolidays = {
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

		//N: list of holidays
		public static string[] holidays { get; internal set; }
	}
}
