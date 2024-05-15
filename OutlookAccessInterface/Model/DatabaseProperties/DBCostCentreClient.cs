using OutlookAccessInterface.model.modelProperties;

namespace OutlookAccessInterface.model.databaseProperties;

public class DBCostCentreClient : DBBaseObject
{
	//NSEC: class members
	public static List<CostCentreClient> CostCentreClients { get; }
	
	//NSEC: instance members
	public DBCostCentreClient(int id, EntryType entryType, DBClient client, DBProject project, int costCentreClientNumber) : base(id, entryType)
	{
		this.Client = client;
		this.Project = project;
		this.CostCentreClientNumber = costCentreClientNumber;
	}
	
	//NSEC: fields
	public DBClient Client { get; }
	public int CostCentreClientNumber { get; }
	public DBProject Project { get; }
}
