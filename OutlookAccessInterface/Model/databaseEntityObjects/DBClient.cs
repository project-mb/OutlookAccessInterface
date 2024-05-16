using static OutlookAccessInterface.model.databaseEntityObjects.DBClient.Table;

namespace OutlookAccessInterface.model.databaseEntityObjects;

public class DBClient : DBBaseObject
{
	//NSEC: class members
	public static class Table
	{
		public static string Table_LU_Mandant { get => "LU_Mandant"; }
		public static string Mandant_ID { get => "Mandant_ID"; }
		public static string Mandant { get => "Mandant"; }
		public static string Mandantnummer { get => "Mandantnummer"; }
	}

	//NSEC: instance members
	public DBClient(int id, EntryType entryType, string clientName, int clientNumber) : base(id, entryType)
	{
		this.ClientName = clientName;
		this.ClientNumber = clientNumber;
	}

	public DBClient(int idx, IReadOnlyDictionary<string, List<string>> table) : base(Convert.ToInt32(table[Mandant_ID][idx]), EntryType.EXISTING)
	{
		this.ClientName = table[Mandant][idx];
		this.ClientNumber = Convert.ToInt32(table[Mandantnummer][idx]);
	}

	//NSEC: fields
	public string ClientName { get; }
	public int ClientNumber { get; }
}
