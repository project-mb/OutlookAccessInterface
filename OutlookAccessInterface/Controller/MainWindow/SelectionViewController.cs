using System.Windows;
using static OutlookAccessInterface.Controller.Util;

namespace OutlookAccessInterface.Controller.MainWindow
{
	public class SelectionViewController
	{
		public string Bt_selCalendarFile_clickhandler() { return calendarFile = getSelectedFile(title: "Select Target Calendar", filter: new[] { CALENDARDEFFILTER }); }

		public string Bt_selDatabaseFile_clickhandler()
		{
			return databaseFile = getSelectedFile(title: "Select Target Database", filter: new[] { DATABASEDEFFILTER }, defaultExt: ".accdb");
		}

		public void Bt_importData_clickHandler() { MessageBox.Show("Import from " + calendarFile + "\nto " + databaseFile); }
	}
}
