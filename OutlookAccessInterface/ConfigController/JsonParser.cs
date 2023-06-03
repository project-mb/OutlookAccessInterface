using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json;
using OutlookAccessInterface.Exceptions;

namespace OutlookAccessInterface.ConfigController
{
	public class JsonParser
	{
		private readonly string jsonFile;
		public JsonParser(string jsonFile) { this.jsonFile = jsonFile; }

		public T read<T>() where T : new()
		{
			T instance = new T();

			if(!File.Exists(this.jsonFile)) throw new NotJsonFileException("file does not exist");

			//N: check if file is .json file
			int indexOfExtension = this.jsonFile.IndexOf(".json", StringComparison.Ordinal);
			if(indexOfExtension <= 0) throw new NotValidJsonException("file is not type json");
			string configFileWithoutExt = this.jsonFile.Remove(indexOfExtension, 5);

			//N: get JSON objects
			string jsonString = File.ReadAllText(this.jsonFile);
			Dictionary<string, object> jsonObjects = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonString);

			int errorCode = -2;
			if(jsonObjects != null) {
				//N: get each json object
				foreach (KeyValuePair<string, object> jsonObject in jsonObjects) {
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
							// errorCode = loadFileLocations(jsonObject.Value.ToString());
							break;
						}
						case "CalendarFilter": {
							// errorCode = loadCalendarFilter(arr);
							break;
						}
						case "DatabaseFilter": {
							// errorCode = loadDatabaseFilter(arr);
							break;
						}
						case "Holydays": {
							// errorCode = loadHolidays(arr);
							break;
						}
					}
				}
			}

			if(errorCode > 0) return instance;

			//N: configFile at path could be corrupted
			File.Copy(this.jsonFile, configFileWithoutExt + "_Backup" + DateTime.Now.Date.ToShortDateString().Replace(".", ""));
			throw new Exception("-2");
		}

		// private static int loadFileLocations(string jsonString)
		// {
		// 	Dictionary<string, object> fileLocationConfig = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonString);
		//
		// 	if (fileLocationConfig == null) return -2;
		//
		// 	foreach (KeyValuePair<string, object> jsonObject in fileLocationConfig) {
		// 		string value = jsonObject.Value.ToString();
		//
		// 		PropertyInfo fi = typeof(FileLocations).GetProperty(jsonObject.Key);
		// 		if (fi != null) fi.SetValue(null, value);
		// 		else return -2;
		// 	}
		//
		// 	return 0;
		// }
		//
		// private static int loadCalendarFilter(string[] arr)
		// {
		// 	Filters.CalFilter = arr;
		// 	return Filters.CalFilter.Length;
		// }
		//
		// private static int loadDatabaseFilter(string[] arr)
		// {
		// 	Filters.DatFilter = arr;
		// 	return Filters.DatFilter.Length;
		// }
		//
		// private static int loadHolidays(string[] arr)
		// {
		// 	HolidayFilters.holidays = arr;
		// 	return HolidayFilters.holidays.Length;
		// }
	}
}
