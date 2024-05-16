using OutlookAccessInterface.model.databaseEntityObjects;
using OutlookAccessInterface.utility;
using static OutlookAccessInterface.model.databaseEntityObjects.DBClient.Table;

namespace OutlookAccessInterface.model.databaseAccessObjects;

public class DAO_Client(IDBConnection idbConnection) : IDAO<DBClient>
{
	public void create(DBClient DBObject)
	{
		idbConnection.insertInto([Table_LU_Mandant], [Mandant, Mandantnummer],
		[
			$"{DBObject.ClientName}",
			$"{DBObject.ClientNumber}"
		]);
	}

	public void update(DBClient DBObject)
	{
		idbConnection.update([Table_LU_Mandant],
			$"{Mandant} = {DBObject.ClientName}," +
			$"{Mandantnummer} = {DBObject.ClientNumber}",
			$"{Mandant_ID} = {DBObject.Id}");
	}
	
	public void delete(DBClient DBObject) { idbConnection.deleteFrom([Table_LU_Mandant], $"{Mandant_ID} = {DBObject.Id}"); }

	public List<DBClient> select_all()
	{
		List<DBClient> clients = [];
		Dictionary<string, List<string>> table = idbConnection.select([Mandant_ID, Mandant, Mandantnummer], Table_LU_Mandant);

		for (int i = 0; i < table.Count; i++) {
			DBClient newClient = new(i, table);

			if(RecordDatabase.Clients.Exists(x => x.Id == newClient.Id)) continue;

			clients.Add(newClient);
		}

		return clients;
	}
}
