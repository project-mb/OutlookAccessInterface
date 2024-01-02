namespace OutlookAccessInterface.model.databaseProperties;

public class DBProject : DBBaseObject
{
	private bool isArchived;
	private bool notInSum;
	private string projectName;
	private int projectNumber;

	public DBProject(int id, EntryType entryType, string projectName, int projectNumber, bool notInSum, bool isArchived) : base(id, entryType)
	{
		this.projectName = projectName;
		this.projectNumber = projectNumber;
		this.notInSum = notInSum;
		this.isArchived = isArchived;
	}
}
