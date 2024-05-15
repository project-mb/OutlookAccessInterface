using OutlookAccessInterface.model.databaseProperties;
using OutlookAccessInterface.utility;

namespace OutlookAccessInterface.model.databaseAccessObjects;

public class DAO_Day(IDBConnection idbConnection) : DAO_Base(idbConnection), IDAO<DBDay>
{
	public void create(DBDay DBObject)
	{
		this.idbConnection.insertInto(["Tage"], ["Datum", "Beginn", "Vorgabe", "Tagestyp"], [
			DBObject.Date.ToString(),
			DBObject.StartTime.ToString(),
			DBObject.Specification.ToString(),
			DBObject.DayType.Id.ToString()
		]);
	}

	public void update(DBDay DBObject)
	{
		this.idbConnection.update(["Tage"],
			$"Datum = {DBObject.Date.ToString()}," +
			$"Beginn = {DBObject.StartTime.ToString()}," +
			$"Vorgabe = {DBObject.Specification.ToString()}," +
			$"Tagestyp = {DBObject.DayType.Id}",
			$"Tag_ID = {DBObject.Id}");
	}

	public void delete(DBDay DBObject) { this.idbConnection.deleteFrom(["Tage"], $"Tag_ID = {DBObject.Id}"); }

	public List<DBDay> select_all()
	{
		List<DBDay> days = [];
		Dictionary<string, List<string>> table = this.idbConnection.select(["Tag_ID", "Datum", "Beginn", "Vorgabe", "Tagestyp"], "Tage");

		for (int i = 0; i < table.Count; i++) {
			DBDay newDay = new(i, table);

			if(RecordDatabase.Days.Exists(x => x.Date == newDay.Date)) continue;

			days.Add(newDay);
		}

		return days;
	}
}
