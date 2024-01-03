using System.IO;
using System.Reflection;
using OutlookAccessInterface.utility;
using Path = System.IO.Path;

namespace OutlookAccessInterface.configuration.configObjects;

public class FileLocations
{
	//NSEC: singleton
	private static FileLocations _instance = null!;
	public static FileLocations get_instance() { return (_instance != null!) ? _instance : _instance = new FileLocations(); }

	//NSEC: default file paths
	public static readonly string DEFAULT_ROOT_BASEPATH = Path.Combine(Environment.GetEnvironmentVariable("AppData") ?? string.Empty, @"OutlookAccessInterface");
	public static readonly string DEFAULT_CONFIG_FILEPATH = Path.Combine(Environment.GetEnvironmentVariable("AppData") ?? string.Empty, @"OutlookAccessInterface\config.json");

	//NSEC: attributes
	private string root_basePath = DEFAULT_ROOT_BASEPATH;
	private string config_filePath = DEFAULT_CONFIG_FILEPATH;
	private string calendar_basePath = DEFAULT_ROOT_BASEPATH;
	private string database_basePath = DEFAULT_ROOT_BASEPATH;

	//NSEC: contains the 'absolute' path of the current root directory (where all files are stored)
	public string Root_BasePath { get => this.root_basePath; }
	public bool set_root_basePath(string path) { return setPath(nameof(Root_BasePath), path); }

	//NSEC: contains the 'absolute' path where the .json config file is stored 
	public string Config_FilePath { get => this.config_filePath; }
	public bool set_config_filePath(string path) { return setPath(nameof(Config_FilePath), path); }

	//NSEC: contains the 'absolute' path where .ics/.pst Calendar-Files are stored
	public string Calendar_BasePath { get => this.calendar_basePath; }
	public bool set_calendar_basePath(string path) { return setPath(nameof(Calendar_BasePath), path); }

	//NSEC: contains the 'absolute' path where .accdb AccessDatabase-Files are stored
	public string Database_BasePath { get => this.database_basePath; }
	public bool set_database_basePath(string path) { return setPath(nameof(Database_BasePath), path); }

	//NSEC: private static methods
	private static bool setPath(string propertyName, string path) { return !File.Exists(path) && Utility.setProperty(typeof(FileLocations).GetProperty(propertyName), path); }
}
