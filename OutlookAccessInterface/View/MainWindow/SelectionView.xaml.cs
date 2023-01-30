using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using OutlookAccessInterface.Controller.MainWindow;

namespace OutlookAccessInterface.View.MainWindow
{
	public partial class SelectionView : UserControl
	{
		private readonly SelectionViewController viewController;

		public SelectionView()
		{
			InitializeComponent();

			this.viewController = new SelectionViewController();
		}

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

		private void bt_importData_OnClick(object sender, RoutedEventArgs e) { this.viewController.bt_importData_clickHandler(); }

		#endregion

		#endregion


		#region controllerFunctions

		//NSEC: updates ui if a file selection occured
		private void updateOnFileSelection(TextBox tb, string checkStr)
		{
			if (checkStr == "") {
				tb.Text = "-";
				tb.BorderBrush = Brushes.Red;
			} else {
				tb.Text = checkStr.Remove(0, checkStr.LastIndexOf('\\') + 1);
				tb.BorderBrush = Brushes.Black;
			}
		}

		#endregion
	}
}
