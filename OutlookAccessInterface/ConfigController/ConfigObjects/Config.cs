using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Windows.Forms;

namespace OutlookAccessInterface.ConfigController.ConfigObjects
{
	public static class Config
	{
		public static readonly string ConfigFile = FileLocations.defaultconfDir;

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
				//N: get each json object
				foreach (KeyValuePair<string, object> jsonObject in config) {
					//NSEC: converts jsonObject into string array without json characters
					string objectString = jsonObject.Value.ToString().Replace("\r", "").Replace("\"", "").Replace(",", "");

					//N: converts json object into string array and removes json characters at start and end
					string[] arr = objectString.Split('\n').Skip(1).ToArray();
					Array.Resize(ref arr, arr.Length - 1);

					//N: removes leading and trailing whitespaces for every string in array
					for (int i = 0; i < arr.Length; i++) { arr[i] = arr[i].Trim(); }
					//NSEC:END

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

				PropertyInfo fi = typeof(FileLocations).GetProperty(jsonObject.Key);
				if (fi != null) fi.SetValue(null, value);
				else return -2;
			}

			return 0;
		}

		private static int loadCalendarFilter(string[] arr)
		{
			Filters.CalFilter = arr;
			return Filters.CalFilter.Length;
		}

		private static int loadDatabaseFilter(string[] arr)
		{
			Filters.DatFilter = arr;
			return Filters.DatFilter.Length;
		}

		private static int loadHolidays(string[] arr)
		{
			HolidayFilters.holidays = arr;
			return HolidayFilters.holidays.Length;
		}
	}
}
