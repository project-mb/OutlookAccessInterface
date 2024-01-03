using System.Diagnostics;
using System.Reflection;
using System.Windows;
using OutlookAccessInterface.configuration.configObjects;
using OutlookAccessInterface.exceptions.oaiException;
using OutlookAccessInterface.model;
using OutlookAccessInterface.utility;
using static OutlookAccessInterface.configuration.configObjects.Config;
using static OutlookAccessInterface.utility.Utility;
using static OutlookAccessInterface.configuration.configObjects.Configuration;

namespace OutlookAccessInterface.controller.mainWindow;

public class SelectionViewController
{
	//NSEC: singleton
	private static SelectionViewController _instance = null!;
	public static SelectionViewController get_instance() { return (_instance != null) ? _instance : _instance = new SelectionViewController(); }

	public void onViewOpen()
	{
		//N: when application starts load previous config file
		//handleLoadConfigFile(loadConfigFile());
		// Debug.WriteLine("property: " + Utility.getProperty(typeof(FileLocations).GetProperty(nameof(FileLocations.Calendar_BasePath)), FileLocations.get_instance()));

		// PropertyInfo info = typeof(FileLocations).GetProperty(nameof(FileLocations.Calendar_BasePath));
		// object val = info?.GetValue(FileLocations.get_instance());
		// string basePath = (val != null) ? val.ToString() : "FileLocations.DEFAULT_ROOT_BASEPATH";

		// Debug.WriteLine(basePath);
	}

	public string bt_selCalendarFile_clickhandler() { return CALENDARFILE = getSelectedFile(nameof(Configuration.FileLocations.Calendar_BasePath), "Select Target Calendar", Configuration.FileFilters.CalendarFilter); }

	public string bt_selDatabaseFile_clickhandler() { return DATABASEFILE = getSelectedFile(nameof(Configuration.FileLocations.Database_BasePath), "Select Target Database", Configuration.FileFilters.DatabaseFilter, ".accdb"); }

	public void bt_importData_clickHandler()
	{
		if(CALENDARFILE == null) throw new CalendarFileMissingException("calendar file missing");
		if(DATABASEFILE == null) throw new DatabaseFileMissingException("database file missing");

		ICSReader reader = ICSReader.create(CALENDARFILE);
		DatabaseConnection database = DatabaseConnection.create(DATABASEFILE);

		reader.get_calendarEventsFromICSFile();
		// database.Select();
		Debug.WriteLine("");
	}

	//NSEC: throws information if config file could not be loaded correctly
	private void handleLoadConfigFile(int errorCode)
	{
		switch (errorCode) {
			case 0: break;
			case -1:
				MessageBox.Show("valid configFile needed\n\n" + CONFIGFILE, "no such directory", MessageBoxButton.OK, MessageBoxImage.Exclamation);
				break;
			case -2:
				MessageBox.Show("please repair configFile\ncreated backup of configFile", "configFile corruped", MessageBoxButton.OK, MessageBoxImage.Error);
				break;
			case -3:
				MessageBox.Show(".json file needed\n\n" + CONFIGFILE, "wrong extension", MessageBoxButton.OK, MessageBoxImage.Error);
				break;
			default:
				MessageBox.Show("call dev", "unkown error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
				break;
		}

		if(errorCode < 0) Environment.Exit(0);
	}
}
