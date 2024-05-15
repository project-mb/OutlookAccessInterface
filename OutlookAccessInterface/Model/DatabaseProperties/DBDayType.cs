namespace OutlookAccessInterface.model.databaseProperties;

public class DBDayType : DBBaseObject
{
	//NSEC: class members
	public static List<DBDayType> DayTypes { get; }

	//NSEC: instance members
	public DBDayType(int id, EntryType entryType, string dayType) : base(id, entryType) { this.DayType = dayType; }

	//NSEC: fields
	public string DayType { get; }
}
