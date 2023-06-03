using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using OutlookAccessInterface.Model.DatabaseProperties;
using OutlookAccessInterface.Model.Properties;

namespace OutlookAccessInterface.View.BindingSources
{
	public class ComboBoxSource
	{
		public event PropertyChangedEventHandler propertyChanged;

		private List<DBDayType> dbDayTypes;
		private List<DBDay> dbDays;
		private ObservableCollection<DBClient> dbClients;
		private List<DBProject> dbProjects;
		private List<WorkType> dbWorkTypes;
		private List<CostCentreClient> dbCostCentreClients;

		public ObservableCollection<DBClient> DbClients
		{
			get => this.dbClients;
			set {
				this.dbClients = value;
				onPropertyChanged(new PropertyChangedEventArgs("SelectedClient"));
			}
		}

		protected virtual void onPropertyChanged(PropertyChangedEventArgs e) { propertyChanged?.Invoke(this, e); }
	}
}
