using System.IO;
using System.Windows.Forms;
using OutlookAccessInterface.ConfigController.ConfigObjects;
using DialogRes = System.Windows.Forms.DialogResult;
using static OutlookAccessInterface.ConfigController.ConfigObjects.Config;

namespace OutlookAccessInterface.Controller
{
	public static class Util
	{
		//N: contains the current .ics/.pst Calendar-File
		public static string calendarFile;

		//N: contains the current .accdb AccessDatabase-File
		public static string databaseFile;


		//NSEC: sets properties for file-dialog and returns selected file path if valid

		public static string getSelectedFile(string initialDirectory = FileLocations.defaultRootDir, string title = "Select File", string[] filter = null, string defaultExt = "", bool addExt = true)
		{
			string selectedFilePath = null;


			string filterStr = "";
			if (filter == null) filterStr = "";
			else {
				MessageBox.Show(filter[0]);
				for (int i = 0; i < filter.Length; i++) {
					filterStr += filter[i];
					if (i < filter.Length - 1) filterStr += "|";
				}
			}

			MessageBox.Show(filterStr);

			OpenFileDialog ofd = new OpenFileDialog {
				Title = title,
				InitialDirectory = initialDirectory,
				Filter = filterStr,
				DefaultExt = defaultExt,
				AddExtension = addExt
			};

			if (ofd.ShowDialog() == DialogRes.OK) selectedFilePath = ofd.FileName;
			if (!File.Exists(selectedFilePath)) selectedFilePath = null;

			return selectedFilePath;
		}
	}
}
