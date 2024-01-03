namespace OutlookAccessInterface.controller.databaseWindow;

public class DataEditViewController
{
	//NSEC: singleton
	private static DataEditViewController _instance = null!;
	public static DataEditViewController get_instance() { return (_instance != null) ? _instance : _instance = new DataEditViewController(); }
}
