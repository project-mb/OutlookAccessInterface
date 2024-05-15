namespace OutlookAccessInterface.model.databaseProperties;

public class DBRecord : DBBaseObject
{
	//NSEC: class members
	
	//NSEC: instance members
	public DBRecord(int id, EntryType entryType, DBDay day, DBClient client, DBProject project, DBWorkType workType, string addition, int time, DBCostCentreClient costCentreClient, bool hasRecordReference, int recordReference) : base(id, entryType)
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
	
	//NSEC: fields
	public DBDay Day { get; }
	public DBClient Client { get; }
	public DBProject Project { get; }
	public DBWorkType WorkType { get; }
	public string Addition { get; }
	public int Time { get; }
	public DBCostCentreClient CostCentreClient { get; }
	public bool HasRecordReference { get; }
	public int RecordReference { get; }
}
