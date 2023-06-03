namespace OutlookAccessInterface.Model.DatabaseProperties
{
	public class DBClient : DBBaseObject
	{
		public string ClientName { get; }
		public int ClientNumber { get; }

		public DBClient(int id, EntryType entryType, string clientName, int clientNumber) : base(id, entryType)
		{
			this.ClientName = clientName;
			this.ClientNumber = clientNumber;
		}
	}
}
