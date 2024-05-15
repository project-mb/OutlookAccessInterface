using OutlookAccessInterface.model.databaseProperties;
using OutlookAccessInterface.utility;

namespace OutlookAccessInterface.model.databaseAccessObjects;

public class DAO_WorkType(IDBConnection idbConnection) : DAO_Base(idbConnection), IDAO<DBWorkType>
{
	public void create(DBWorkType DBObject) { throw new NotImplementedException(); }
	public void update(DBWorkType DBObject) { throw new NotImplementedException(); }
	public void delete(DBWorkType DBObject) { throw new NotImplementedException(); }
	
	public List<DBWorkType> select_all() { throw new NotImplementedException(); }
}
