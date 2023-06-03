namespace OutlookAccessInterface.Model.DatabaseProperties
{
	public class DBCostCentreClient : DBBaseObject
	{
		private DBClient client;
		private DBProject project;
		private int costCentreClientNumber;

		public DBCostCentreClient(int id, EntryType entryType, DBClient client, DBProject project, int costCentreClientNumber) : base(id, entryType)
		{
			this.client = client;
			this.project = project;
			this.costCentreClientNumber = costCentreClientNumber;
		}
	}
}
