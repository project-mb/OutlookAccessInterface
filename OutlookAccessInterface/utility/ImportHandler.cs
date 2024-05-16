using static OutlookAccessInterface.configuration.configObjects.Configuration;

namespace OutlookAccessInterface.utility;

public class ImportHandler
{
	//NSEC: singleton
	private static ImportHandler? _instance;
	public static ImportHandler get_instance() { return _instance ??= new ImportHandler(); }
	private ImportHandler() { }

	//NSEC: fields
	private ICalendarReader reader;
	private RecordDatabase database;

	private Dictionary<string, Dictionary<string, List<string>>> Tabels { get; set; } = new();

	public void importData(DateTime? fromDate, DateTime? toDate)
	{
		this.database = RecordDatabase.get_instance(DATABASEFILE);
		this.reader = ICSReader.get_instance(CALENDARFILE);

		this.database.init();
		this.reader.get_records(fromDate, toDate);

		Thread.Sleep(3000);
	}
}
