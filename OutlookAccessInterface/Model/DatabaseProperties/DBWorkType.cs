namespace OutlookAccessInterface.Model.DatabaseProperties
{
	public class DBWorkType : DBBaseObject
	{
		private string workType;
		private string addition;

		public DBWorkType(int id, EntryType entryType, string workType, string addition) : base(id, entryType)
		{
			this.workType = workType;
			this.addition = addition;
		}
	}
}
