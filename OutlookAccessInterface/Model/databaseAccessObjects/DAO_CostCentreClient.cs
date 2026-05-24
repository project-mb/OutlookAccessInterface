using OutlookAccessInterface.model.databaseEntityObjects;
using OutlookAccessInterface.utility;
using static OutlookAccessInterface.model.databaseEntityObjects.DBCostCentreClient.Table;

namespace OutlookAccessInterface.model.databaseAccessObjects;

public class DAO_CostCentreClient(IDBConnection idbConnection) : IDAO<DBCostCentreClient>
{
	public void create(DBCostCentreClient DBObject)
	{
		idbConnection.insertInto([Table_LU_Kostenstelle_AG], [Mandant, Projekt, KST_Nummer_AG],
		[
			$"{DBObject.Client.Id}",
			$"{DBObject.Project.Id}",
			$"{DBObject.CostCentreClientNumber}"
		]);
	}
	public void update(DBCostCentreClient DBObject)
	{
		idbConnection.update([Table_LU_Kostenstelle_AG],
			$"{Mandant} = {DBObject.Client.Id}," +
			$"{Projekt} = {DBObject.Project.Id}" +
			$"{KST_Nummer_AG} = {DBObject.CostCentreClientNumber}",
			$"{KST_AG_ID} = {DBObject.Id}");
	}
	public void delete(DBCostCentreClient DBObject) { idbConnection.deleteFrom([Table_LU_Kostenstelle_AG], $"{KST_AG_ID} = {DBObject.Id}"); }

	public List<DBCostCentreClient> select_all()
	{
		List<DBCostCentreClient> costCentreClients = [];
		Dictionary<string, List<string>> table = idbConnection.select([KST_AG_ID, Mandant, Projekt, KST_Nummer_AG], Table_LU_Kostenstelle_AG);

		for (int i = 0; i < table[KST_AG_ID].Count; i++) {
			DBCostCentreClient newCostCentreClient = new(i, table);

			if(RecordDatabase.Clients.Exists(x => x.Id == newCostCentreClient.Id)) continue;

			costCentreClients.Add(newCostCentreClient);
		}

		return costCentreClients;
	}
}
