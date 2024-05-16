using OutlookAccessInterface.utility;
using static OutlookAccessInterface.model.databaseEntityObjects.DBRecord.Table;

namespace OutlookAccessInterface.model.databaseEntityObjects;

public class DBRecord : DBBaseObject
{
	//NSEC: class members
	public static class Table
	{
		public static string Table_Zeiten { get => "Zeiten"; }
		public static string Code { get => "Code"; }
		public static string Datum { get => "Datum"; }
		public static string Projekt { get => "Projekt"; }
		public static string Taetigkeit { get => "Taetigkeit"; }
		public static string Ergaenzung { get => "Ergaenzung"; }
		public static string Zeit { get => "Zeit"; }
		public static string Mandant { get => "Mandant"; }
		public static string KST_Mandant { get => "KST_Mandant"; }
		public static string Bool_alt { get => "Bool_alt"; }
		public static string alt_Ref { get => "alt_Ref"; }
	}

	//NSEC: instance members
	public DBRecord(int id, EntryType entryType, DBDay day, DBClient client, DBProject project, DBWorkType workType, string addition, double time, DBCostCentreClient costCentreClient, bool hasRecordReference, int recordReference) : base(id, entryType)
	{
		this.Day = day;
		this.Client = client;
		this.Project = project;
		this.WorkType = workType;
		this.Addition = addition;
		this.Time = time;
		this.CostCentreClient = costCentreClient;
		this.HasRecordReference = hasRecordReference;
		this.RecordReference = recordReference;
	}

	public DBRecord(int idx, IReadOnlyDictionary<string, List<string>> table) : base(Convert.ToInt32(table[Code][idx]), EntryType.EXISTING)
	{
		this.Day = RecordDatabase.Days.Find(x => x.Id == Convert.ToInt32(table[Datum][idx])) ?? throw new InvalidOperationException();
		this.Project = RecordDatabase.Projects.Find(x => x.Id == Convert.ToInt32(table[Projekt][idx])) ?? throw new InvalidOperationException();
		this.WorkType = RecordDatabase.WorkTypes.Find(x => x.Id == Convert.ToInt32(table[Taetigkeit][idx])) ?? throw new InvalidOperationException();
		this.Addition = table[Ergaenzung][idx];
		this.Time = Convert.ToDouble(table[Zeit][idx]);
		this.Client = RecordDatabase.Clients.Find(x => x.Id == Convert.ToInt32(table[Mandant][idx])) ?? throw new InvalidOperationException();
		this.CostCentreClient = RecordDatabase.CostCentreClients.Find(x => x.Id == Convert.ToInt32(table[KST_Mandant][idx])) ?? throw new InvalidOperationException();
		this.HasRecordReference = Convert.ToBoolean(table[Bool_alt][idx]);
		this.RecordReference = Convert.ToInt32(table[alt_Ref][idx]);
	}

	//NSEC: fields
	public DBDay Day { get; }
	public DBProject Project { get; }
	public DBWorkType WorkType { get; }
	public string Addition { get; }
	public double Time { get; }
	public DBClient Client { get; }
	public DBCostCentreClient CostCentreClient { get; }
	public bool HasRecordReference { get; }
	public int RecordReference { get; }
}
