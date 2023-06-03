namespace OutlookAccessInterface.Model.DatabaseProperties
{
	public class DBProject : DBBaseObject
	{
		private string projectName;
		private int projectNumber;
		private bool notInSum;
		private bool isArchived;

		public DBProject(int id, EntryType entryType, string projectName, int projectNumber, bool notInSum, bool isArchived) : base(id, entryType)
		{
			this.projectName = projectName;
			this.projectNumber = projectNumber;
			this.notInSum = notInSum;
			this.isArchived = isArchived;
		}
	}
}
