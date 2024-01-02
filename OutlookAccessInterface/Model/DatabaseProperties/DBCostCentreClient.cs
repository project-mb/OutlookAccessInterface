namespace OutlookAccessInterface.model.databaseProperties;

public class DBCostCentreClient : DBBaseObject
{
	private DBClient client;
	private int costCentreClientNumber;
	private DBProject project;

	public DBCostCentreClient(int id, EntryType entryType, DBClient client, DBProject project, int costCentreClientNumber) : base(id, entryType)
	{
		this.client = client;
		this.project = project;
		this.costCentreClientNumber = costCentreClientNumber;
	}
}
