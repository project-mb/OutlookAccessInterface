using OutlookAccessInterface.configuration.configObjects;
using OutlookAccessInterface.model.databaseEntityObjects;
using OutlookAccessInterface.utility;
using static OutlookAccessInterface.model.databaseEntityObjects.DBDay.Table;

namespace OutlookAccessInterface.model.databaseAccessObjects;

public class DAO_Day(IDBConnection idbConnection) : IDAO<DBDay>
{
	public void create(DBDay DBObject)
	{
		idbConnection.insertInto([Table_Tage], [Datum, Beginn, Vorgabe, Tagestyp],
		[
			$"{Utility.dateTimeToString(DBObject.Date)}",
			$"{DBObject.StartTime}",
			$"{DBObject.Specification}",
			$"{DBObject.DayType.Id}"
		]);
	}

	public void update(DBDay DBObject)
	{
		idbConnection.update([Table_Tage],
			$"{Datum} = {Utility.dateTimeToString(DBObject.Date)}," +
			$"{Beginn} = {DBObject.StartTime}," +
			$"{Vorgabe} = {DBObject.Specification}," +
			$"{Tagestyp} = {DBObject.DayType.Id}",
			$"{Tag_ID} = {DBObject.Id}");
	}

	public void delete(DBDay DBObject) { idbConnection.deleteFrom([Table_Tage], $"{Tag_ID} = {DBObject.Id}"); }

	public List<DBDay> select_all()
	{
		List<DBDay> days = [];
		Dictionary<string, List<string>> table = idbConnection.select([Tag_ID, Datum, Beginn, Vorgabe, Tagestyp], Table_Tage);

		for (int i = 0; i < table.Count; i++) {
			DBDay newDay = new(i, table);

			if(RecordDatabase.Days.Exists(x => x.Id == newDay.Id)) continue;

			days.Add(newDay);
		}

		return days;
	}
}
