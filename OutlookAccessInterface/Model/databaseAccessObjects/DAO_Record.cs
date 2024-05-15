using OutlookAccessInterface.model.databaseProperties;
using OutlookAccessInterface.utility;

namespace OutlookAccessInterface.model.databaseAccessObjects;

public class DAO_Record(IDBConnection idbConnection) : DAO_Base(idbConnection), IDAO<DBRecord>
{
	public void create(DBRecord DBObject) { throw new NotImplementedException(); }
	public void update(DBRecord DBObject) { throw new NotImplementedException(); }
	public void delete(DBRecord DBObject) { throw new NotImplementedException(); }
	
	public List<DBRecord> select_all() { throw new NotImplementedException(); }
}
