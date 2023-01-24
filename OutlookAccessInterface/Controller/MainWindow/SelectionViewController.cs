using System.Windows;
using static OutlookAccessInterface.Controller.Util;

namespace OutlookAccessInterface.Controller.MainWindow
{
	public class SelectionViewController
	{
		public string Bt_selCalendarFile_clickhandler()
		{
			string[] defFilter = new[] {
				"ics files (*.ics)|*.ics",
				//TODO: implement pst file reader and filter settings for user
				//"pst files (*.pst)|*.pst"
			};

			return calendarFile = getSelectedFile(title: "Select Target Calendar", filter: defFilter);
		}

		public string Bt_selDatabaseFile_clickhandler()
		{
			string[] defFilter = new[] { "accdb files (*.accdb)|*.accdb" };

			return databaseFile = getSelectedFile(title: "Select Target Database", filter: defFilter, defaultExt: ".accdb");
		}

		public void Bt_importData_clickHandler() { MessageBox.Show("Import from " + calendarFile + "\nto " + databaseFile); }
	}
}
