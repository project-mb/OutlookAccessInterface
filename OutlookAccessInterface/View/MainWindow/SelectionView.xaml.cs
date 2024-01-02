using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using OutlookAccessInterface.controller.mainWindow;
using OutlookAccessInterface.exceptions.oaiException;
using static OutlookAccessInterface.controller.Util;

namespace OutlookAccessInterface.view.mainWindow;

public partial class SelectionView : UserControl
{
	private readonly SelectionViewController viewController;

	public SelectionView()
	{
		InitializeComponent();

		this.viewController = new SelectionViewController();
		this.viewController.onViewOpen();
	}


	#region controllerFunctions

	//NSEC: updates ui if a file selection occured
	private void updateOnFileSelection(TextBox tb, string checkStr)
	{
		if(checkStr == null) {
			tb.Text = "-";
			tb.BorderBrush = Brushes.Red;
		} else {
			tb.Text = checkStr.Remove(0, checkStr.LastIndexOf('\\') + 1);
			tb.BorderBrush = Brushes.Black;
		}
	}

	#endregion

	#region uiEvents

	#region clickEvents

	//NSEC: handles click event of calendar file selection and updates ui
	private void bt_selCalendarFile_OnClick(object sender, RoutedEventArgs e)
	{
		string fileName = this.viewController.bt_selCalendarFile_clickhandler();

		updateOnFileSelection(this.tb_selCalendarFile, fileName);
	}

	//NSEC: handles click event of database file selection and updates ui
	private void bt_selDatabaseFile_OnClick(object sender, RoutedEventArgs e)
	{
		string fileName = this.viewController.bt_selDatabaseFile_clickhandler();

		updateOnFileSelection(this.tb_selDatabaseFile, fileName);
	}

	private void bt_importData_OnClick(object sender, RoutedEventArgs e)
	{
		string message = $@"Import from {CALENDARFILE} {"\n"}to {DATABASEFILE}";

		try { this.viewController.bt_importData_clickHandler(); }
		catch (CalendarFileMissingException exception) {
			updateOnFileSelection(this.tb_selCalendarFile, null);
			message = exception.Message;
		}
		catch (DatabaseFileMissingException exception) {
			updateOnFileSelection(this.tb_selDatabaseFile, null);
			message = exception.Message;
		} finally { MessageBox.Show(message); }
	}

	#endregion

	#endregion
}
