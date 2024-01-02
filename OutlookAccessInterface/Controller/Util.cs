using System.IO;
using System.Reflection;
using Microsoft.Win32;
using OutlookAccessInterface.configuration.configObjects;

// using DialogRes = Microsoft.Win32..DialogResult;

namespace OutlookAccessInterface.controller;

public static class Util
{
	//N: contains the current .ics/.pst Calendar-File
	public static string CALENDARFILE;

	//N: contains the current .accdb AccessDatabase-File
	public static string DATABASEFILE;


	//NSEC: sets properties for file-dialog and returns selected file path if valid

	public static string getSelectedFile(string initialDirectory, string title = "Select File", string[] filter = null, string defaultExt = "", bool addExt = true)
	{
		PropertyInfo info = typeof(FileLocations).GetProperty(initialDirectory);
		object val = info?.GetValue(null);
		initialDirectory = val == null ? FileLocations.DEFAULT_ROOTDIR : val.ToString();

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
			InitialDirectory = initialDirectory,
			Filter = filterStr,
			DefaultExt = defaultExt,
			AddExtension = addExt
		};

		if(ofd.ShowDialog()!.Value) selectedFilePath = ofd.FileName;
		if(!File.Exists(selectedFilePath)) selectedFilePath = null;

		return selectedFilePath;
	}
}
