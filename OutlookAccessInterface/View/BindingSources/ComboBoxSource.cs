using System.Collections.ObjectModel;
using System.ComponentModel;
using OutlookAccessInterface.model.databaseProperties;
using OutlookAccessInterface.model.modelProperties;

namespace OutlookAccessInterface.view.bindingSources;

public class ComboBoxSource
{
	private ObservableCollection<DBClient> dbClients;
	private List<CostCentreClient> dbCostCentreClients;
	private List<DBDay> dbDays;

	private List<DBDayType> dbDayTypes;
	private List<DBProject> dbProjects;
	private List<WorkType> dbWorkTypes;

	public ObservableCollection<DBClient> DbClients
	{
		get => this.dbClients;
		set {
			this.dbClients = value;
			onPropertyChanged(new PropertyChangedEventArgs("SelectedClient"));
		}
	}

	public event PropertyChangedEventHandler propertyChanged;

	protected virtual void onPropertyChanged(PropertyChangedEventArgs e) { propertyChanged?.Invoke(this, e); }
}
