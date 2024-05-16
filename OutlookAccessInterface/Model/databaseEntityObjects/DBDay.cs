using OutlookAccessInterface.configuration.configObjects;
using OutlookAccessInterface.utility;
using static OutlookAccessInterface.model.databaseEntityObjects.DBDay.Table;

namespace OutlookAccessInterface.model.databaseEntityObjects;

public class DBDay : DBBaseObject
{
	//NSEC: class members
	public static class Table
	{
		public static string Table_Tage { get => "Tage"; }
		public static string Tag_ID { get => "Tag_ID"; }
		public static string Datum { get => "Datum"; }
		public static string Beginn { get => "Beginn"; }
		public static string Vorgabe { get => "Vorgabe"; }
		public static string Tagestyp { get => "Tagestyp"; }	
	}

	//NSEC: instance members
	public DBDay(int id, EntryType entryType, DateTime date, double startTime, double specification, DBDayType dayType) : base(id, entryType)
	{
		this.Date = date;
		this.StartTime = startTime;
		this.Specification = specification;
		this.DayType = dayType;
	}

	public DBDay(int idx, IReadOnlyDictionary<string, List<string>> table) : base(Convert.ToInt32(table[Tag_ID][idx]), EntryType.EXISTING)
	{
		this.Date = Convert.ToDateTime(table[Datum][idx]);
		this.StartTime = Convert.ToInt32(table[Beginn][idx]);
		this.Specification = Convert.ToInt32(table[Vorgabe][idx]);
		this.DayType = RecordDatabase.DayTypes.Find(x => x.Id == Convert.ToInt32(table[Tagestyp][idx])) ?? throw new InvalidOperationException();
	}

	//NSEC: fields
	public DateTime Date { get; }
	public DBDayType DayType { get; }
	public double StartTime { get; }
	public double Specification { get; }
}
