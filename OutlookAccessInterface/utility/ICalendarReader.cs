using OutlookAccessInterface.model.databaseProperties;

namespace OutlookAccessInterface.utility;

public interface ICalendarReader
{
	List<DBDay> get_days();
	//protected DBDayType get_dayTyps();			//N: only receivable from DB
	//protected DBClient get_clients();				//N: only receivable from DB
	List<DBProject> get_projects();
	//protected DBWorkType get_workTypes();		//N: only receivable from DB
	List<DBCostCentreClient> get_costCentreClients();
	
	/// <summary>
	/// 
	/// </summary>
	/// <param name="from">First date to import (inclusive)</param>
	/// <param name="to">Last date to import (inclusive)</param>
	/// <returns></returns>
	List<DBRecord> get_records(DateTime? from, DateTime? to);
}
