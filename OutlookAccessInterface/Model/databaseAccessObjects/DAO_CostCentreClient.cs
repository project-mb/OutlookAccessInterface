using OutlookAccessInterface.model.databaseProperties;
using OutlookAccessInterface.utility;

namespace OutlookAccessInterface.model.databaseAccessObjects;

public class DAO_CostCentreClient(IDBConnection idbConnection) : DAO_Base(idbConnection), IDAO<DBCostCentreClient>
{
	public void create(DBCostCentreClient DBObject) { throw new NotImplementedException(); }
	public void update(DBCostCentreClient DBObject) { throw new NotImplementedException(); }
	public void delete(DBCostCentreClient DBObject) { throw new NotImplementedException(); }
	
	public List<DBCostCentreClient> select_all() { throw new NotImplementedException(); }
}
