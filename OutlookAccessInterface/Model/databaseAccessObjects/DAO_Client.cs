using OutlookAccessInterface.model.databaseProperties;
using OutlookAccessInterface.utility;

namespace OutlookAccessInterface.model.databaseAccessObjects;

public class DAO_Client(IDBConnection idbConnection) : DAO_Base(idbConnection), IDAO<DBClient>
{
	public List<DBClient> select_all() { throw new NotImplementedException(); }
	public void create(DBClient DBObject) { throw new NotImplementedException(); }
	public void update(DBClient DBObject) { throw new NotImplementedException(); }
	public void delete(DBClient DBObject) { throw new NotImplementedException(); }
}
