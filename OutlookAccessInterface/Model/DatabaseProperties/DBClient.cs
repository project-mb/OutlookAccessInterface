namespace OutlookAccessInterface.model.databaseProperties;

public class DBClient : DBBaseObject
{
	public DBClient(int id, EntryType entryType, string clientName, int clientNumber) : base(id, entryType)
	{
		ClientName = clientName;
		ClientNumber = clientNumber;
	}

	public string ClientName { get; }
	public int ClientNumber { get; }
}
