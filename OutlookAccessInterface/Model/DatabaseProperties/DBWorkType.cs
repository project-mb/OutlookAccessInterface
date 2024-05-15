namespace OutlookAccessInterface.model.databaseProperties;

public class DBWorkType : DBBaseObject
{
	//NSEC: class members
	private static List<DBWorkType> WorkTypes { get; }

	//NSEC: instance members
	public DBWorkType(int id, EntryType entryType, string workType, string addition) : base(id, entryType)
	{
		this.WorkType = workType;
		this.Addition = addition;
	}

	//NSEC: fields
	public string Addition { get; }
	public string WorkType { get; }
}
