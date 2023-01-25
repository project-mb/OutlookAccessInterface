using System.IO;
using System.Windows.Forms;
using DialogRes = System.Windows.Forms.DialogResult;

namespace OutlookAccessInterface.Controller
{
	public static class Util
	{
		//N: 
		public const string ROOTDIR = "D:\\Privat\\DevPoint\\VSProjects\\AccessImporter_OutlookCalendar\\_Files";

		//N: contains the 'absolute' path where .ics/.pst Calendar-Files are stored
		public const string CALENDARFILEPATH = ROOTDIR;

		//N: de
		public const string CALENDARDEFFILTER = "ics files (*.ics)|*.ics";

		//N: contains the current .ics/.pst Calendar-File
		public static string calendarFile;

		//N: contains the 'absolute' path where .accdb AccessDatabase-Files are stored
		public const string DATABASEFILEPATH = ROOTDIR;

		//N: contains the current .accdb AccessDatabase-File
		public static string databaseFile;

		//N: default database filter for file selection
		public const string DATABASEDEFFILTER = "accdb files (*.accdb)|*.accdb";

		//NSEC: sets properties for file-dialog and returns selected file path if valid
		public static string getSelectedFile(string initialDirectory = ROOTDIR, string title = "Select File", string[] filter = null, string defaultExt = "", bool addExt = true)
		{
			string selectedFilePath = "";

			string filterStr = "";
			if (filter == null) filterStr = "";
			else {
				for (int i = 0; i < filter.Length; i++) {
					filterStr += filter[i];
					if (i < filter.Length - 1) filterStr += "|";
				}
			}

			OpenFileDialog ofd = new OpenFileDialog {
				Title = title,
				InitialDirectory = initialDirectory,
				Filter = filterStr,
				DefaultExt = defaultExt,
				AddExtension = addExt
			};

			if (ofd.ShowDialog() == DialogRes.OK) selectedFilePath = ofd.FileName;
			else if (!File.Exists(calendarFile)) selectedFilePath = "";

			return selectedFilePath;
		}
	}
}
