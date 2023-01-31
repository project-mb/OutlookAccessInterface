using System;
using System.Diagnostics;
using System.Windows.Forms;
using OutlookAccessInterface.Model;
using static OutlookAccessInterface.ConfigController.ConfigObjects.Config;
using static OutlookAccessInterface.Controller.Util;
using MessageBox = System.Windows.Forms.MessageBox;

namespace OutlookAccessInterface.Controller.MainWindow
{
	public class SelectionViewController
	{
		public void onWindowOpen()
		{
			//N: when application starts load previous config file
			handleLoadConfigFile(loadConfigFile());
		}

		public string bt_selCalendarFile_clickhandler() { return calendarFile = getSelectedFile(title: "Select Target Calendar", filter: Filter.calFilter); }

		public string bt_selDatabaseFile_clickhandler() { return databaseFile = getSelectedFile(title: "Select Target Database", filter: Filter.datFilter, defaultExt: ".accdb"); }

		public string bt_importData_clickHandler()
		{
			if (calendarFile == null) return "calendar file missing";
			if (databaseFile == null) return "database file missing";

			CalendarReader reader = new CalendarReader(calendarFile);

			reader.GetCalendarEventsFromICSFile();
			return "Import from " + calendarFile + "\nto " + databaseFile;
		}

		//NSEC: throws information if config file could not be loaded correctly
		private void handleLoadConfigFile(int errorCode)
		{
			switch (errorCode) {
				case 0: break;
				case -1:
					MessageBox.Show("valid configFile needed\n\n" + ConfigFile, "no such directory", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					break;
				case -2:
					MessageBox.Show("please repair configFile\ncreated backup of configFile", "configFile corruped", MessageBoxButtons.OK, MessageBoxIcon.Error);
					break;
				case -3:
					MessageBox.Show(".json file needed\n\n" + ConfigFile, "wrong extension", MessageBoxButtons.OK, MessageBoxIcon.Error);
					break;
				default:
					MessageBox.Show("call dev", "unkown error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					break;
			}

			if (errorCode < 0) Environment.Exit(0);
		}
	}
}
