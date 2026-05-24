using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;
using OutlookAccessInterface.__development__;
using OutlookAccessInterface.configuration.configObjects;
using OutlookAccessInterface.exceptions.oaiException;
using OutlookAccessInterface.utility;
using OutlookAccessInterface.view.databaseWindow;
using OutlookAccessInterface.view.mainWindow;
using static OutlookAccessInterface.configuration.configObjects.Config;
using static OutlookAccessInterface.configuration.configObjects.Configuration;

namespace OutlookAccessInterface.controller.mainWindow;

public class SelectionViewController
{
	//NSEC: singleton
	private static SelectionViewController? _instance;
	public static SelectionViewController? get_instance() { return _instance; }
	public static SelectionViewController get_instance(SelectionView selectionView) { return _instance ??= new SelectionViewController(selectionView); }
	private SelectionViewController(SelectionView selectionView) { this.selectionView = selectionView; }

	//NSEC: fields
	private readonly SelectionView selectionView;
	private ImportHandler? importHandler;

	public void onViewOpen()
	{
		//N: when application starts load previous config file
		//handleLoadConfigFile(loadConfigFile());
		// Debug.WriteLine("property: " + Utility.getProperty(typeof(FileLocations).GetProperty(nameof(FileLocations.Calendar_BasePath)), FileLocations.get_instance()));

		// PropertyInfo info = typeof(FileLocations).GetProperty(nameof(FileLocations.Calendar_BasePath));
		// object val = info?.GetValue(FileLocations.get_instance());
		// string basePath = (val != null) ? val.ToString() : "FileLocations.DEFAULT_ROOT_BASEPATH";

		// Debug.WriteLine(basePath);
	}

	//NSEC: clickhandler
	public string bt_selCalendarFile_clickhandler() { return CALENDARFILE = Utility.getSelectedFile(nameof(Configuration.FileLocations.Calendar_BasePath), "Select Target Calendar", Configuration.FileFilters.CalendarFilter); }
	public string bt_selDatabaseFile_clickhandler() { return DATABASEFILE = Utility.getSelectedFile(nameof(Configuration.FileLocations.Database_BasePath), "Select Target Database", Configuration.FileFilters.DatabaseFilter, ".accdb"); }
	public void bt_importData_clickHandler(DateTime? fromDate, DateTime? toDate)
	{
		//NSEC: thread references for the import process
		BackgroundWorker bgw_import = new();

		Thread th_import; //N: handles the reading of the .ics calendar file
		Thread th_import_progress; //N: wait for the read process to finish; used for the GUI-progressBar

		if(CALENDARFILE == null) throw new CalendarFileMissingException("calendar file missing");
		if(DATABASEFILE == null) throw new DatabaseFileMissingException("database file missing");

		fromDate ??= Convert.ToDateTime(DEFAULT_FROMTIME);
		toDate ??= Convert.ToDateTime(DEFAULT_TOTIME);

		this.importHandler = ImportHandler.get_instance();
		this.selectionView.lockView(true);

		//TODO: tidy up and change to backgroundWorker
		bgw_import.DoWork += (_, _) => this.importHandler.importData(fromDate, toDate);
		bgw_import.RunWorkerCompleted += (_, _) => handle_importProgress_finish();
		bgw_import.RunWorkerAsync();

		DebugTools.debug("test");
	}

	//NSEC: private methods
	//NSEC: throws information if config file could not be loaded correctly
	private void handleLoadConfigFile(int errorCode)
	{
		switch (errorCode) {
			case 0: break;
			case -1:
				MessageBox.Show("valid configFile needed\n\n" + CONFIGFILE, "no such directory", MessageBoxButton.OK, MessageBoxImage.Exclamation);
				break;
			case -2:
				MessageBox.Show("please repair configFile\ncreated backup of configFile", "configFile corruped", MessageBoxButton.OK, MessageBoxImage.Error);
				break;
			case -3:
				MessageBox.Show(".json file needed\n\n" + CONFIGFILE, "wrong extension", MessageBoxButton.OK, MessageBoxImage.Error);
				break;
			default:
				MessageBox.Show("call dev", "unkown error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
				break;
		}

		if(errorCode < 0) Environment.Exit(0);
	}

	private void handle_importProgress_finish()
	{
		this.selectionView.lockView(false);
		MessageBox.Show("Finished");
		DatabaseWindow window = new();
		window.Show();
		MainWindow.Instance.Close();
		// Application.Current.Dispatcher.BeginInvoke(() => this.selectionView.lockView(true));
	}
}
