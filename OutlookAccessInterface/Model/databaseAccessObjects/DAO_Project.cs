using OutlookAccessInterface.model.databaseProperties;
using OutlookAccessInterface.utility;

namespace OutlookAccessInterface.model.databaseAccessObjects;

public class DAO_Project(IDBConnection idbConnection) : DAO_Base(idbConnection), IDAO<DBProject>
{
	public void create(DBProject DBObject) { throw new NotImplementedException(); }
	public void update(DBProject DBObject) { throw new NotImplementedException(); }
	public void delete(DBProject DBObject) { throw new NotImplementedException(); }
	
	public List<DBProject> select_all() { throw new NotImplementedException(); }
}
