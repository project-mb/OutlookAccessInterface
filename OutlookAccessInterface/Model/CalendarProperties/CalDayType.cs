namespace OutlookAccessInterface.model.calendarProperties;

public class CalDayType
{
	//NSEC: class members
	public static List<CalDayType> Types { get; }

	//NSEC: instance members
	public CalDayType() { }

	//NSEC: fields
	public string Type { get; private set; }

	public string DayType { get; }

	public int TypeIdx { get; }
}
