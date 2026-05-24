using static OutlookAccessInterface.model.databaseEntityObjects.DBWorkType.Table;

namespace OutlookAccessInterface.model.databaseEntityObjects;

public class DBWorkType : DBBaseObject
{
	//NSEC: class members
	public static class Table
	{
		public static string Table_LU_Taetigkeit { get => "LU_Taetigkeit"; }
		public static string Taetigkeit_ID { get => "Taetigkeit_ID"; }
		public static string Taetigkeit { get => "Taetigkeit"; }
		public static string Ergaenzung { get => "Ergänzung"; }
	}

	//NSEC: instance members
	public DBWorkType() : base(-1, EntryType.EXISTING)
	{
		this.WorkType = "";
		this.Addition = "";
	}

	public DBWorkType(int id, EntryType entryType, string workType, string addition) : base(id, entryType)
	{
		this.WorkType = workType;
		this.Addition = addition;
	}

	public DBWorkType(int idx, IReadOnlyDictionary<string, List<string>> table) : base(Convert.ToInt32(table[Taetigkeit_ID][idx]), EntryType.EXISTING)
	{
		this.WorkType = table[Taetigkeit][idx];
		this.Addition = table[Ergaenzung][idx];
	}

	//NSEC: fields
	public string WorkType { get; }
	public string Addition { get; }
}
