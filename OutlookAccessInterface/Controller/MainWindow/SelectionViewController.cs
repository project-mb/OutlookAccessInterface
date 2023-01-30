using System.Diagnostics;
using System.Windows;
using OutlookAccessInterface.Model;
using static OutlookAccessInterface.Controller.Util;

namespace OutlookAccessInterface.Controller.MainWindow
{
	public class SelectionViewController
	{
		public string bt_selCalendarFile_clickhandler() { return calendarFile = getSelectedFile(title: "Select Target Calendar", filter: new[] { CALENDARDEFFILTER }); }

		public string bt_selDatabaseFile_clickhandler() { return databaseFile = getSelectedFile(title: "Select Target Database", filter: new[] { DATABASEDEFFILTER }, defaultExt: ".accdb"); }

		public void bt_importData_clickHandler()
		{
			CalendarReader reader = new CalendarReader(calendarFile);

			MessageBox.Show("Import from " + calendarFile + "\nto " + databaseFile);
			reader.ReadICS();
			Debug.Print("adösldkjf");
		}
	}
}
