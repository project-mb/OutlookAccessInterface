namespace OutlookAccessInterface.model.databaseProperties;

public class DBDay : DBBaseObject
{
	private DateTime date;
	private DBDayType dayType;
	private double specification;
	private double startTime;

	public DBDay(int id, EntryType entryType, DateTime date, double startTime, double specification, DBDayType dayType) : base(id, entryType)
	{
		this.date = date;
		this.startTime = startTime;
		this.specification = specification;
		this.dayType = dayType;
	}
}
