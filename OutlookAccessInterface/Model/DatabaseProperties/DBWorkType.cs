namespace OutlookAccessInterface.model.databaseProperties;

public class DBWorkType : DBBaseObject
{
	private string addition;
	private string workType;

	public DBWorkType(int id, EntryType entryType, string workType, string addition) : base(id, entryType)
	{
		this.workType = workType;
		this.addition = addition;
	}
}
