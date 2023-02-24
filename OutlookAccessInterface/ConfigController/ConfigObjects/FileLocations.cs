using System;
using System.IO;

namespace OutlookAccessInterface.ConfigController.ConfigObjects
{
	public static class FileLocations
	{
		//NSEC: default file paths
		public static readonly string defaultRootDir = Path.Combine(Environment.GetEnvironmentVariable("AppData"), "OutlookAccessInterface");
		public static readonly string defaultconfDir = Path.Combine(Environment.GetEnvironmentVariable("AppData"), @"OutlookAccessInterface\config.json");

		//N: contains the 'absolute' path of the current root directory (where all files are stored)
		public static string RootDir { get; set; }

		//N: contains the 'absolute' path where the .json config file is stored 
		public static string ConfDir { get; set; }

		//N: contains the 'absolute' path where .ics/.pst Calendar-Files are stored
		public static string CalDir { get; set; }

		//N: contains the 'absolute' path where .accdb AccessDatabase-Files are stored
		public static string DatDir { get; set; }
	}
}
