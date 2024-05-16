using System.Windows;
using OutlookAccessInterface.configuration.configObjects;

namespace OutlookAccessInterface.view.mainWindow;

/// <summary>
///   Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();
		this.selectionView = this.ui_selectionView;
		this.settingsView = this.ui_settingsView;
	}

	//NSEC: fields
	private SelectionView selectionView;
	private SettingsView settingsView;

	//NSEC: methods
}
