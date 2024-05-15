using OutlookAccessInterface.utility;

namespace OutlookAccessInterface.model.databaseAccessObjects;

public class DAO_Base(IDBConnection idbConnection)
{
	protected IDBConnection idbConnection = idbConnection;
}
