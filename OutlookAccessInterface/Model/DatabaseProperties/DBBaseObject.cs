namespace OutlookAccessInterface.model.databaseProperties;

public abstract class DBBaseObject
{
	//NSEC: class members
	
	
	//NSEC: instance members
	protected DBBaseObject(int id, EntryType entryType)
	{
		this.Id = id;
		this.EntryType = entryType;
	}
	
	//NSEC: fields
	public int Id { get; }
	public EntryType EntryType { get; }
}
