using OutlookAccessInterface.model.databaseEntityObjects;
using OutlookAccessInterface.utility;
using static OutlookAccessInterface.model.databaseEntityObjects.DBWorkType.Table;

namespace OutlookAccessInterface.model.databaseAccessObjects;

public class DAO_WorkType(IDBConnection idbConnection) : IDAO<DBWorkType>
{
	public void create(DBWorkType DBObject)
	{
		idbConnection.insertInto([Table_LU_Taetigkeit], [Taetigkeit, Ergaenzung],
		[
			$"{DBObject.WorkType}",
			$"{DBObject.Addition}"
		]);
	}

	public void update(DBWorkType DBObject)
	{
		idbConnection.update([Table_LU_Taetigkeit],
			$"{Taetigkeit} = {DBObject.WorkType}," +
			$"{Ergaenzung} = {DBObject.Addition}",
			$"{Taetigkeit_ID} = {DBObject.Id}");
	}

	public void delete(DBWorkType DBObject) { idbConnection.deleteFrom([Table_LU_Taetigkeit], $"{Taetigkeit_ID} = {DBObject.Id}"); }
	
	public List<DBWorkType> select_all()
	{
		List<DBWorkType> workTypes = [];
		Dictionary<string, List<string>> table = idbConnection.select([Taetigkeit_ID, Taetigkeit, Ergaenzung], Table_LU_Taetigkeit);

		for (int i = 0; i < table[Taetigkeit_ID].Count; i++) {
			DBWorkType newWorkType = new(i, table);

			if(RecordDatabase.Clients.Exists(x => x.Id == newWorkType.Id)) continue;

			workTypes.Add(newWorkType);
		}

		return workTypes;
	}
}
