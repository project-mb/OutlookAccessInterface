using OutlookAccessInterface.model.databaseEntityObjects;

namespace OutlookAccessInterface.controller.databaseWindow;

public class DataEditViewController
{
	//NSEC: singleton
	private static DataEditViewController _instance = null!;
	public static DataEditViewController get_instance() { return (_instance != null) ? _instance : _instance = new DataEditViewController(); }

	private List<DBRecord> _records;
	private List<DBDay> _days;
	private Dictionary<int, List<DBProject>> possibleProjects = new Dictionary<int, List<DBProject>>();
	
	private DataEditViewController()
	{
		this._records = new List<DBRecord>();
	}
}
