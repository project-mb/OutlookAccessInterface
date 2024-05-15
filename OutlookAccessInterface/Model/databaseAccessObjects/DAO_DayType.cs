using OutlookAccessInterface.model.databaseProperties;
using OutlookAccessInterface.utility;

namespace OutlookAccessInterface.model.databaseAccessObjects;

public class DAO_DayType(IDBConnection idbConnection) : DAO_Base(idbConnection), IDAO<DBDayType>
{
	public void create(DBDayType DBObject) { throw new NotImplementedException(); }
	public void update(DBDayType DBObject) { throw new NotImplementedException(); }
	public void delete(DBDayType DBObject) { throw new NotImplementedException(); }
	
	public List<DBDayType> select_all() { throw new NotImplementedException(); }
}
