namespace OutlookAccessInterface.model.databaseProperties;

public abstract class DBBaseObject
{
	private EntryType entryType;
	private int id;

	protected DBBaseObject(int id, EntryType entryType)
	{
		this.id = id;
		this.entryType = entryType;
	}
}
