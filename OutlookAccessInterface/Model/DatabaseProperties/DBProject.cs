namespace OutlookAccessInterface.model.databaseProperties;

public class DBProject : DBBaseObject
{
	//NSEC: class members
	public static List<DBProject> Projects { get; }

	//NSEC: instance members
	public DBProject(int id, EntryType entryType, string projectName, int projectNumber, bool notInSum, bool isArchived) : base(id, entryType)
	{
		this.ProjectName = projectName;
		this.ProjectNumber = projectNumber;
		this.NotInSum = notInSum;
		this.IsArchived = isArchived;
	}

	//NSEC: fields
	public bool IsArchived { get; }
	public bool NotInSum { get; }
	public string ProjectName { get; }
	public int ProjectNumber { get; }
}
