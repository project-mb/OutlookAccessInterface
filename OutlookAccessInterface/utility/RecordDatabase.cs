using System.Runtime.CompilerServices;
using OutlookAccessInterface.model.databaseAccessObjects;
using OutlookAccessInterface.model.databaseEntityObjects;

namespace OutlookAccessInterface.utility;

public class RecordDatabase
{
	//NSEC: singleton
	private static RecordDatabase? _instance;
	public static RecordDatabase get_instance(string databaseFilePath) { return _instance ??= new RecordDatabase(databaseFilePath); }
	public static void release_instance() { _instance = null; }
	private RecordDatabase(string databaseFilePath)
	{
		this.databaseConnection = OLEDBConnection.get_instance(databaseFilePath);
		this.daoDay = new DAO_Day(this.databaseConnection);
		this.daoDayType = new DAO_DayType(this.databaseConnection);
		this.daoClient = new DAO_Client(this.databaseConnection);
		this.daoProject = new DAO_Project(this.databaseConnection);
		this.daoWorkType = new DAO_WorkType(this.databaseConnection);
		this.daoCostCentreClient = new DAO_CostCentreClient(this.databaseConnection);
		this.daoRecord = new DAO_Record(this.databaseConnection);
	}

	//NSEC: fields
	private readonly IDBConnection databaseConnection;
	private readonly DAO_Day daoDay;
	private readonly DAO_DayType daoDayType;
	private readonly DAO_Client daoClient;
	private readonly DAO_Project daoProject;
	private readonly DAO_WorkType daoWorkType;
	private readonly DAO_CostCentreClient daoCostCentreClient;
	private readonly DAO_Record daoRecord;

	public static List<DBDay> Days { get; private set; } = [];
	public static List<DBDayType> DayTypes { get; private set; } = [];
	public static List<DBClient> Clients { get; private set; } = [];
	public static List<DBProject> Projects { get; private set; } = [];
	public static List<DBWorkType> WorkTypes { get; private set; } = [];
	public static List<DBCostCentreClient> CostCentreClients { get; private set; } = [];
	public static List<DBRecord> Records { get; private set; } = [];

	public void init()
	{
		this.databaseConnection.connect();

		Days = this.daoDay.select_all();
		DayTypes = this.daoDayType.select_all();
		Clients = this.daoClient.select_all();
		Projects = this.daoProject.select_all();
		WorkTypes = this.daoWorkType.select_all();
		CostCentreClients = this.daoCostCentreClient.select_all();
		Records = this.daoRecord.select_all();

		this.databaseConnection.disconnect();
	}
}
