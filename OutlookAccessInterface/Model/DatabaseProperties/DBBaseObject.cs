namespace OutlookAccessInterface.Model.DatabaseProperties
{
	public abstract class DBBaseObject
	{
		private int id;
		private EntryType entryType;

		protected DBBaseObject(int id, EntryType entryType)
		{
			this.id = id;
			this.entryType = entryType;
		}
	}
}
