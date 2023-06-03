using System;

namespace OutlookAccessInterface.Model.DatabaseProperties
{
	public class DBDay : DBBaseObject
	{
		private DateTime date;
		private double startTime;
		private double specification;
		private DBDayType dayType;

		public DBDay(int id, EntryType entryType, DateTime date, double startTime, double specification, DBDayType dayType) : base(id, entryType)
		{
			this.date = date;
			this.startTime = startTime;
			this.specification = specification;
			this.dayType = dayType;
		}
	}
}
