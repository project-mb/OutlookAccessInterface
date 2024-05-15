using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using OutlookAccessInterface.__development__;
using OutlookAccessInterface.controller.mainWindow;
using OutlookAccessInterface.exceptions.oaiException;
using static OutlookAccessInterface.configuration.configObjects.Configuration;


namespace OutlookAccessInterface.view.mainWindow;

public partial class SelectionView : UserControl
{
	private readonly SelectionViewController viewController;

	public SelectionView()
	{
		InitializeComponent();

		this.viewController = SelectionViewController.get_instance(this);
		this.viewController.onViewOpen();
	}


	#region controllerFunctions
	
	public void lockView(bool state)
	{
		//NSEC: selectionView
		this.pb_importData.IsIndeterminate = state;
		this.bt_selCalendarFile.IsEnabled = !state;
		this.bt_selDatabaseFile.IsEnabled = !state;
		this.bt_importData.IsEnabled = !state;
		this.dp_selFromDate.IsEnabled = !state;
		this.dp_selToDate.IsEnabled = !state;
	}	

	#endregion

	#region uiEvents

	#region clickEvents

	//NSEC: handles click event of calendar file selection and updates ui
	private void bt_selCalendarFile_OnClick(object sender, RoutedEventArgs e)
	{
		try {
			string fileName = this.viewController.bt_selCalendarFile_clickhandler();
			updateOnFileSelection(this.tb_selCalendarFile, fileName);
		} catch { updateOnFileSelection(this.tb_selCalendarFile, null); }
	}

	//NSEC: handles click event of database file selection and updates ui
	private void bt_selDatabaseFile_OnClick(object sender, RoutedEventArgs e)
	{
		try {
			string fileName = this.viewController.bt_selDatabaseFile_clickhandler();
			updateOnFileSelection(this.tb_selDatabaseFile, fileName);
		} catch { updateOnFileSelection(this.tb_selDatabaseFile, null); }
	}

	private void bt_importData_OnClick(object sender, RoutedEventArgs e)
	{
		//NSEC: hands the import to the viewController
		try {
			this.viewController.bt_importData_clickHandler(this.dp_selFromDate.SelectedDate, this.dp_selToDate.SelectedDate);
			MessageBox.Show($"Import from {CALENDARFILE} \nto {DATABASEFILE}");
		} catch { updateOnFileSelection(this.tb_selDatabaseFile, null); }
	}

	#endregion

	#endregion

	//NSEC: private methods
	//NSEC: updates ui if a file selection occured
	private void updateOnFileSelection(TextBox tb, string? checkStr)
	{
		if(checkStr == null) {
			tb.Text = "-";
			tb.BorderBrush = Brushes.Red;
		} else {
			tb.Text = checkStr.Remove(0, checkStr.LastIndexOf('\\') + 1);
			tb.BorderBrush = Brushes.Black;
		}
	}
}
