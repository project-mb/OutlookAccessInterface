using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace OutlookAccessInterface.ConfigController.ConfigObjects
{
	public static class Config
	{
		public const string ConfigFile = FileLocations.defaultconfDir;

		private static FileLocations FileLocation { get; } = new FileLocations();
		public static Filters Filter { get; } = new Filters();

		public static HolidayFilters HolidayFilter { get; } = new HolidayFilters();

		public static int loadConfigFile()
		{
			if (!File.Exists(ConfigFile)) return -1;

			//N: check if file is .json file
			int indexOfExtension = ConfigFile.IndexOf(".json", StringComparison.Ordinal);
			if (indexOfExtension <= 0) return -3;
			string configFileWithoutExt = ConfigFile.Remove(indexOfExtension, 5);

			//N: get JSON objects
			string jsonString = File.ReadAllText(ConfigFile);
			Dictionary<string, object> config = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonString);

			int errorCode = -2;
			if (config != null) {
				//N: get each object
				foreach (KeyValuePair<string, object> jsonObject in config) {
					string[] arr = jsonObject.Value.ToString().Split('\n').Skip(1).ToArray();
					Array.Resize(ref arr, arr.Length - 1);

					switch (jsonObject.Key) {
						case "FileLocations": {
							errorCode = loadFileLocations(jsonObject.Value.ToString());
							break;
						}
						case "CalendarFilter": {
							errorCode = loadCalendarFilter(arr);
							break;
						}
						case "DatabaseFilter": {
							errorCode = loadDatabaseFilter(arr);
							break;
						}
						case "Holydays": {
							errorCode = loadHolidays(arr);
							break;
						}
					}
				}
			}

			if (errorCode > 0) return 0;

			//N: configFile at path could be corrupted
			File.Copy(ConfigFile, configFileWithoutExt + "_Backup" + DateTime.Now.Date.ToShortDateString().Replace(".", ""));
			return -2;
		}

		private static int loadFileLocations(string jsonString)
		{
			Dictionary<string, object> fileLocationConfig = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonString);

			if (fileLocationConfig == null) return -2;

			foreach (KeyValuePair<string, object> jsonObject in fileLocationConfig) {
				string value = jsonObject.Value.ToString();
				switch (jsonObject.Key) {
					case "rootDir":
						FileLocation.RootDir = value;
						break;
					case "confDir":
						FileLocation.ConfDir = value;
						break;
					case "cal_Dir":
						FileLocation.CalDir = value;
						break;
					case "dat_Dir":
						FileLocation.DatDir = value;
						break;
					default:
						return -2;
				}
			}

			return 0;
		}

		private static int loadCalendarFilter(string[] arr)
		{
			Filter.calFilter = arr;
			return arr.Length;
		}

		private static int loadDatabaseFilter(string[] arr)
		{
			Filter.datFilter = arr;
			return arr.Length;
		}

		private static int loadHolidays(string[] arr)
		{
			HolidayFilter.holidays = arr;
			return arr.Length;
		}
	}
}
