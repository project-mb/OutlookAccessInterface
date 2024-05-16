using static OutlookAccessInterface.model.databaseEntityObjects.DBDayType.Table;

namespace OutlookAccessInterface.model.databaseEntityObjects;

public class DBDayType : DBBaseObject
{
	//NSEC: class members
	public static class Table
	{
		public static string Table_LU_Tagestyp { get => "LU_Tagestyp"; }
		public static string Tagestyp_ID { get => "Tagestyp_ID"; }
		public static string Tagestyp { get => "Tagestyp"; }
	}

	//NSEC: instance members
	public DBDayType(int id, EntryType entryType, string dayType) : base(id, entryType) { this.DayType = dayType; }

	public DBDayType(int idx, IReadOnlyDictionary<string, List<string>> table) : base(Convert.ToInt32(table[Tagestyp_ID][idx]), EntryType.EXISTING) { this.DayType = table[Tagestyp][idx]; }

	//NSEC: fields
	public string DayType { get; }
}
