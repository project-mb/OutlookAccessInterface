namespace OutlookAccessInterface.ConfigController.ConfigObjects
{
	public class FileLocations
	{
		//NSEC: default file paths
		public const string defaultRootDir = "D:\\Privat\\DevPoint\\VSProjects\\AccessImporter_OutlookCalendar\\_Files";
		public const string defaultconfDir = "D:\\Privat\\DevPoint\\#Projects\\_mbGameStudio\\Other\\OutlookAccessInterface\\OutlookAccessInterface\\ConfigController\\config.json";
		public const string defaultcalDir = defaultRootDir;
		public const string defaultdatDir = defaultRootDir;

		//N: contains the 'absolute' path of the current root directory (where all files are stored)
		public string RootDir { get; internal set; }

		//N: contains the 'absolute' path where the .json config file is stored 
		public string ConfDir { get; internal set; }

		//N: contains the 'absolute' path where .ics/.pst Calendar-Files are stored
		public string CalDir { get; internal set; }

		//N: contains the 'absolute' path where .accdb AccessDatabase-Files are stored
		public string DatDir { get; internal set; }

		//NSEC: standard file locations
		public FileLocations() : this(defaultRootDir, defaultconfDir, defaultcalDir, defaultdatDir) { }

		public FileLocations(string rootDir, string confDir, string calDir, string datDir)
		{
			RootDir = rootDir;
			ConfDir = confDir;
			CalDir = calDir;
			DatDir = datDir;
		}
	}
}
