using System.IO;
using System.Reflection;
using System.Text.Json;
using OutlookAccessInterface.exceptions.jsonException;
using OutlookAccessInterface.utility;

namespace OutlookAccessInterface.configuration.configObjects;

public static class Config
{
	public static readonly string CONFIGFILE = FileLocations.DEFAULT_CONFIG_FILEPATH;

	public static int loadConfigFile()
	{
		if(!File.Exists(CONFIGFILE)) throw new NotJsonFileException("file does not exist");

		//N: check if file is .json file
		int indexOfExtension = CONFIGFILE.IndexOf(".json", StringComparison.Ordinal);
		if(indexOfExtension <= 0) throw new NotValidJsonException("file is not type json");
		string configFileWithoutExt = CONFIGFILE.Remove(indexOfExtension, 5);

		//N: get JSON objects
		string jsonString = File.ReadAllText(CONFIGFILE);
		Dictionary<string, object>? config = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonString);

		int errorCode = -2;
		if(config != null)
			//N: get each json object
			foreach (KeyValuePair<string, object> jsonObject in config) {
				//NSEC: converts jsonObject into string array without json characters
				string? objectString = jsonObject.Value.ToString()?.Replace("\r", "").Replace("\"", "").Replace(",", "");

				//N: converts json object into string array and removes json characters at start and end
				string[]? arr = objectString?.Split('\n').Skip(1).ToArray();
				Array.Resize(ref arr, arr.Length - 1);

				//N: removes leading and trailing whitespaces for every string in array
				for (int i = 0; i < arr.Length; i++) arr[i] = arr[i].Trim();

				//NSEC:END
				errorCode = jsonObject.Key switch {
					"FileLocations" => loadFileLocations(jsonObject.Value.ToString()),
					"CalendarFilter" => loadCalendarFilter(arr),
					"DatabaseFilter" => loadDatabaseFilter(arr),
					"Holydays" => loadHolidays(arr),
					_ => errorCode
				};
			}

		if(errorCode > 0) return 0;

		//N: configFile at path could be corrupted
		//File.Copy(ConfigFile, configFileWithoutExt + "_Backup" + DateTime.Now.Date.ToShortDateString().Replace(".", ""));
		return -2;
	}

	private static int loadFileLocations(string? jsonString)
	{
		Dictionary<string, object>? fileLocationConfig = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonString);

		if(fileLocationConfig == null) return -2;

		foreach (KeyValuePair<string, object> jsonObject in fileLocationConfig) {
			string? value = jsonObject.Value.ToString();

			if(!Utility.setProperty(typeof(FileLocations).GetProperty(jsonObject.Key), value)) return -2;
		}

		return 0;
	}

	private static int loadCalendarFilter(string[]? arr)
	{
		Configuration.FileFilters.set_calendarFilter(arr);
		return Configuration.FileFilters.CalendarFilter.Length;
	}

	private static int loadDatabaseFilter(string[]? arr)
	{
		Configuration.FileFilters.set_databaseFilter(arr);
		return Configuration.FileFilters.DatabaseFilter.Length;
	}

	private static int loadHolidays(string[]? arr)
	{
		Configuration.HolidayFilters.set_holidays(arr);
		return Configuration.HolidayFilters.Holidays.Length;
	}
}
