using OutlookAccessInterface.utility;

namespace OutlookAccessInterface.model.databaseProperties;

public class DBDay : DBBaseObject
{
	//NSEC: class members
	public static List<DBDay> Days { get; }

	//NSEC: instance members
	public DBDay(int id, EntryType entryType, DateTime date, double startTime, double specification, DBDayType dayType) : base(id, entryType)
	{
		this.Date = date;
		this.StartTime = startTime;
		this.Specification = specification;
		this.DayType = dayType;
	}

	public DBDay(int idx, IReadOnlyDictionary<string, List<string>> table) : base(Convert.ToInt32(table["Tag_ID"][idx]), EntryType.EXISTING)
	{
		this.Date = Convert.ToDateTime(table["Datum"][idx]);
		this.StartTime = Convert.ToInt32(table["Beginn"][idx]);
		this.Specification = Convert.ToInt32(table["Vorgabe"][idx]);
		this.DayType = RecordDatabase.DayTypes.Find(x => x.Id == Convert.ToInt32(table["Tagestyp"][idx])) ?? throw new InvalidOperationException();
	}

	//NSEC: fields
	public DateTime Date { get; private set; }
	public DBDayType DayType { get; private set; }
	public double Specification { get; private set; }
	public double StartTime { get; private set; }

	//NSEC: methods

	public string get_attributesStringified()
	{
		return $"Datum = {this.Date.ToString()}," +
					$"Beginn = {this.StartTime.ToString()}," +
					$"Vorgabe = {this.Specification.ToString()}," +
					$"Tagestyp = {this.DayType.Id}";
	}
}
