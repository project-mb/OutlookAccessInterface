using System;
using System.Windows.Forms;
using OutlookAccessInterface.ConfigController.ConfigObjects;
using OutlookAccessInterface.Exceptions.OAIException;
using OutlookAccessInterface.Model;
using static OutlookAccessInterface.ConfigController.ConfigObjects.Config;
using static OutlookAccessInterface.Controller.Util;
using MessageBox = System.Windows.Forms.MessageBox;

namespace OutlookAccessInterface.Controller.MainWindow
{
	public class SelectionViewController
	{
		public void onViewOpen()
		{
			//N: when application starts load previous config file
			//handleLoadConfigFile(loadConfigFile());
		}

		public string bt_selCalendarFile_clickhandler() { return CALENDARFILE = getSelectedFile("CalDir", title: "Select Target Calendar", filter: FileFilters.CalendarFilter); }

		public string bt_selDatabaseFile_clickhandler() { return DATABASEFILE = getSelectedFile("DatDir", title: "Select Target Database", filter: FileFilters.DatabaseFilter, defaultExt: ".accdb"); }

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
					MessageBox.Show("valid configFile needed\n\n" + CONFIGFILE, "no such directory", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					break;
				case -2:
					MessageBox.Show("please repair configFile\ncreated backup of configFile", "configFile corruped", MessageBoxButtons.OK, MessageBoxIcon.Error);
					break;
				case -3:
					MessageBox.Show(".json file needed\n\n" + CONFIGFILE, "wrong extension", MessageBoxButtons.OK, MessageBoxIcon.Error);
					break;
				default:
					MessageBox.Show("call dev", "unkown error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					break;
			}

			if(errorCode < 0) Environment.Exit(0);
		}
	}
}
