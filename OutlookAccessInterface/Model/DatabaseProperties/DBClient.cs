using System.Windows.Documents;

namespace OutlookAccessInterface.model.databaseProperties;

public class DBClient : DBBaseObject
{
	//NSEC: class members
	public static List<DBClient> Clients { get; }

	//NSEC: instance members
	public DBClient(int id, EntryType entryType, string clientName, int clientNumber) : base(id, entryType)
	{
		this.ClientName = clientName;
		this.ClientNumber = clientNumber;
	}

	//NSEC: fields
	public string ClientName { get; }
	public int ClientNumber { get; }
}
