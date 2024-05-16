namespace OutlookAccessInterface.model.databaseEntityObjects;

public abstract class DBBaseObject(int id, EntryType entryType)
{
	//NSEC: class members

	//NSEC: instance members

	//NSEC: fields
	public int Id { get => id; }

	public EntryType EntryType { get; } = entryType;
}
