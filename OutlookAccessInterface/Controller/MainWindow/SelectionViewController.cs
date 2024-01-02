using System.Windows;
using OutlookAccessInterface.configuration.configObjects;
using OutlookAccessInterface.exceptions.oaiException;
using OutlookAccessInterface.model;
using static OutlookAccessInterface.configuration.configObjects.Config;
using static OutlookAccessInterface.controller.Util;

namespace OutlookAccessInterface.controller.mainWindow;

public class SelectionViewController
{
	public void onViewOpen()
	{
		//N: when application starts load previous config file
		//handleLoadConfigFile(loadConfigFile());
	}

	public string bt_selCalendarFile_clickhandler() { return CALENDARFILE = getSelectedFile("CalDir", "Select Target Calendar", FileFilters.CalendarFilter); }

	public string bt_selDatabaseFile_clickhandler() { return DATABASEFILE = getSelectedFile("DatDir", "Select Target Database", FileFilters.DatabaseFilter, ".accdb"); }

	public void bt_importData_clickHandler()
	{
		if(CALENDARFILE == null) throw new CalendarFileMissingException("calendar file missing");
		if(DATABASEFILE == null) throw new DatabaseFileMissingException("database file missing");

		DatabaseConnection database = DatabaseConnection.create(DATABASEFILE);
		ICSReader reader = ICSReader.create(CALENDARFILE);

		reader.getCalendarEventsFromICSFile();
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
