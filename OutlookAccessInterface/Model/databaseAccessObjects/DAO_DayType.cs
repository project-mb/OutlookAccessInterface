using OutlookAccessInterface.model.databaseEntityObjects;
using OutlookAccessInterface.utility;
using static OutlookAccessInterface.model.databaseEntityObjects.DBDayType.Table;

namespace OutlookAccessInterface.model.databaseAccessObjects;

public class DAO_DayType(IDBConnection idbConnection) : IDAO<DBDayType>
{
	public void create(DBDayType DBObject)
	{
		idbConnection.insertInto([Table_LU_Tagestyp], [Tagestyp],
		[
			$"{DBObject.DayType}"
		]);
	}
	
	public void update(DBDayType DBObject)
	{
		idbConnection.update([Table_LU_Tagestyp],
			$"{Tagestyp} = {DBObject.DayType}",
			$"{Tagestyp_ID} = {DBObject.Id}");
	}
	
	public void delete(DBDayType DBObject) { idbConnection.deleteFrom([Table_LU_Tagestyp], $"{Tagestyp_ID} = {DBObject.Id}"); }

	public List<DBDayType> select_all()
	{
		List<DBDayType> dbDayTypes = [];
		Dictionary<string, List<string>> table = idbConnection.select([Tagestyp_ID, Tagestyp], Table_LU_Tagestyp);

		for (int i = 0; i < table.Count; i++) {
			DBDayType newDayType = new(i, table);

			if(RecordDatabase.Clients.Exists(x => x.Id == newDayType.Id)) continue;

			dbDayTypes.Add(newDayType);
		}

		return dbDayTypes;
	}
}
