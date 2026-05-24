using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using OutlookAccessInterface.configuration.configObjects;
using OutlookAccessInterface.utility;
using static OutlookAccessInterface.model.databaseEntityObjects.DBDay.Table;

namespace OutlookAccessInterface.model.databaseEntityObjects;

public class DBDay : DBBaseObject
{
	//NSEC: backing fields
	private readonly DateTime date;
	private readonly DBDayType dayType;
	private readonly double startTime;
	private readonly double specification;

	//NSEC: fields
	public DateTime Date { get => this.date; }
	public DBDayType DayType { get => this.dayType; }
	public double StartTime { get => this.startTime; }
	public double Specification { get => this.specification; }

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
	public DBDay() : base(-1, EntryType.EXISTING)
	{
		this.date = DateTime.Parse("0001-01-01 00:00:00");
		this.dayType = new DBDayType();
		this.startTime = -1;
		this.specification = -1;
	}

	public DBDay(int id, EntryType entryType, DateTime date, double startTime, double specification, DBDayType dayType) : base(id, entryType)
	{
		this.date = date;
		this.dayType = dayType;
		this.startTime = startTime;
		this.specification = specification;
	}

	public DBDay(int idx, IReadOnlyDictionary<string, List<string>> table) : base(Convert.ToInt32(table[Tag_ID][idx]), EntryType.EXISTING)
	{
		this.date = Utility.tryParse(table[Datum][idx], DateTime.Parse("0001-01-01 00:00:00"));
		this.dayType = RecordDatabase.DayTypes.Find(x => x.Id == Utility.tryParse(table[Tagestyp][idx], -1)) ?? new DBDayType();
		this.startTime = Utility.tryParse(table[Beginn][idx], -1);
		this.specification = Utility.tryParse(table[Vorgabe][idx], -1);
	}
}
