namespace OutlookAccessInterface.Model.DatabaseProperties
{
	public class DBDayType : DBBaseObject
	{
		private string dayType;

		public DBDayType(int id, EntryType entryType, string dayType) : base(id, entryType) { this.dayType = dayType; }
	}
}
