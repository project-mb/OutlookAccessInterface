using OutlookAccessInterface.model.modelProperties;
using OutlookAccessInterface.utility;
using static OutlookAccessInterface.model.databaseEntityObjects.DBCostCentreClient.Table;

namespace OutlookAccessInterface.model.databaseEntityObjects;

public class DBCostCentreClient : DBBaseObject
{
	//NSEC: class members
	public static class Table
	{
		public static string Table_LU_Kostenstelle_AG { get => "LU_Kostenstelle_AG"; }
		public static string KST_AG_ID { get => "KST_AG_ID"; }
		public static string Mandant { get => "Mandant"; }
		public static string Projekt { get => "Projekt"; }
		public static string KST_Nummer_AG { get => "KST_Nummer_AG"; }
	}

	//NSEC: instance members
	public DBCostCentreClient(int id, EntryType entryType, DBClient client, DBProject project, int costCentreClientNumber) : base(id, entryType)
	{
		this.Client = client;
		this.Project = project;
		this.CostCentreClientNumber = costCentreClientNumber;
	}

	public DBCostCentreClient(int idx, IReadOnlyDictionary<string, List<string>> table) : base(Convert.ToInt32(table[KST_AG_ID][idx]), EntryType.EXISTING)
	{
		this.Client = RecordDatabase.Clients.Find(x => x.Id == Convert.ToInt32(table[Mandant][idx])) ?? throw new InvalidOperationException();
		this.Project = RecordDatabase.Projects.Find(x => x.Id == Convert.ToInt32(table[Projekt][idx])) ?? throw new InvalidOperationException();
		this.CostCentreClientNumber = Convert.ToInt32(table[KST_Nummer_AG][idx]);
	}

	//NSEC: fields
	public DBClient Client { get; }
	public DBProject Project { get; }
	public int CostCentreClientNumber { get; }
}
