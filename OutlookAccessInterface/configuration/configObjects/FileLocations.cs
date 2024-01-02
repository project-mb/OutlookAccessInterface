using System.IO;

namespace OutlookAccessInterface.configuration.configObjects;

public static class FileLocations
{
	//NSEC: default file paths
	public static readonly string DEFAULT_ROOTDIR = Path.Combine(Environment.GetEnvironmentVariable("AppData") ?? string.Empty, "OutlookAccessInterface");
	public static readonly string DEFAULT_CONFDIR = Path.Combine(Environment.GetEnvironmentVariable("AppData") ?? string.Empty, @"OutlookAccessInterface\config.json");

	//N: contains the 'absolute' path of the current root directory (where all files are stored)
	public static string RootDir { get; set; }

	//N: contains the 'absolute' path where the .json config file is stored 
	public static string ConfDir { get; set; }

	//N: contains the 'absolute' path where .ics/.pst Calendar-Files are stored
	public static string CalDir { get; set; }

	//N: contains the 'absolute' path where .accdb AccessDatabase-Files are stored
	public static string DatDir { get; set; }
}
