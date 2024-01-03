using System.IO;
using System.Reflection;
using Microsoft.Win32;
using OutlookAccessInterface.configuration.configObjects;

namespace OutlookAccessInterface.utility;

public static class Utility
{
	//NSEC: sets properties for file-dialog and returns selected file path if valid

	public static string getSelectedFile(string pathPropertyName, string title = "Select File", string[]? filter = null, string defaultExt = "", bool addExt = true)
	{
		string basePath = Utility.getProperty<string>(typeof(FileLocations).GetProperty(pathPropertyName), FileLocations.get_instance());
		basePath = basePath != null ? basePath : FileLocations.DEFAULT_ROOT_BASEPATH;

		string selectedFilePath = null;

		//N: converts filter array to filter string for OpenFileDialog
		string filterStr = "";
		if(filter == null) filterStr = "";
		else
			for (int i = 0; i < filter.Length; i++) {
				filterStr += filter[i];
				if(i < filter.Length - 1) filterStr += "|";
			}

		OpenFileDialog ofd = new() {
			Title = title,
			InitialDirectory = basePath,
			Filter = filterStr,
			DefaultExt = defaultExt,
			AddExtension = addExt
		};

		if(ofd.ShowDialog()!.Value) selectedFilePath = ofd.FileName;
		if(!File.Exists(selectedFilePath)) selectedFilePath = null;

		return selectedFilePath;
	}
	
	public static bool setProperty<T>(PropertyInfo? property, T value)
	{
		if(property == null!) return false;
		property.SetValue(null, value);
		return true;
	}

	public static T getProperty<T>(PropertyInfo property, object target)
	{
		T value = (T) property.GetValue(target);
		return value;
	}
}
