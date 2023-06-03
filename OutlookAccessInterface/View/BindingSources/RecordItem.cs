using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Media;
using OutlookAccessInterface.Model.DatabaseProperties;
using OutlookAccessInterface.Model.ModelProperties;

namespace OutlookAccessInterface.View.BindingSources
{
	public class RecordItem
	{
		public event PropertyChangedEventHandler propertyChanged;

		private string client;
		private string project;
		private string workType;
		private double duration;
		private string addition;
		private string costCentreClient;
		private string costCentreClientNumber;
		private bool isAlternative;
		private int recordAlternativeID;

		// private static ObservableCollection<DBClient> dbClients { get; set; }

		private Brush backcolor;
		private Brush backcolor_IsSelected;
		private Brush backcolor_IsModified;

		// cell properties
		public ObservableCollection<DBClient> DbClients { get; set; }

		public string SelectedClient
		{
			get => this.client;
			set {
				this.client = value;
				onPropertyChanged(new PropertyChangedEventArgs("SelectedClient"));
			}
		}

		public string SelectedProject
		{
			get => this.project;
			set {
				this.project = value;
				onPropertyChanged(new PropertyChangedEventArgs("SelectedProject"));
			}
		}

		public string SelectedWorkType
		{
			get => this.workType;
			set {
				this.workType = value;
				onPropertyChanged(new PropertyChangedEventArgs("SelectedWorkType"));
			}
		}

		public double Duration
		{
			get => this.duration;
			set {
				this.duration = value;
				onPropertyChanged(new PropertyChangedEventArgs("ChangedDuration"));
			}
		}

		public string Addition
		{
			get => this.addition;
			set {
				this.addition = value;
				onPropertyChanged(new PropertyChangedEventArgs("ChangedAddition"));
			}
		}

		public string SelectedCostCentreClient
		{
			get => this.costCentreClient;
			set {
				this.costCentreClient = value;
				onPropertyChanged(new PropertyChangedEventArgs("SelectedCCC"));
			}
		}

		public string SelectedCostCentreClientNumber
		{
			get => this.costCentreClientNumber;
			set {
				this.costCentreClientNumber = value;
				onPropertyChanged(new PropertyChangedEventArgs("SelectedCostCentreClientNumber"));
			}
		}

		public bool RecordHasAlternative
		{
			get => this.isAlternative;
			set {
				this.isAlternative = value;
				onPropertyChanged(new PropertyChangedEventArgs("RecordHasAlternative"));
			}
		}

		public int RecordAlternativeID
		{
			get => this.recordAlternativeID;
			set {
				this.recordAlternativeID = value;
				onPropertyChanged(new PropertyChangedEventArgs("RecordAlternativeID"));
			}
		}


		// cell colors
		#region BackgroundColors

		public Brush Backcolor
		{
			get => this.backcolor;
			set {
				this.backcolor = value;
				onPropertyChanged(new PropertyChangedEventArgs("Backcolor"));
			}
		}

		public Brush Backcolor_IsSelected
		{
			get => this.backcolor_IsSelected;
			set {
				this.backcolor_IsSelected = value;
				onPropertyChanged(new PropertyChangedEventArgs("RBackcolorIS"));
			}
		}

		public Brush Backcolor_IsModified
		{
			get => this.backcolor_IsModified;
			set {
				this.backcolor_IsModified = value;
				onPropertyChanged(new PropertyChangedEventArgs("RBackcolorMO"));
			}
		}

		#endregion

		// event handlers
		private void onPropertyChanged(PropertyChangedEventArgs e)
		{
			if(propertyChanged == null) return;

			propertyChanged(this, e);

			switch (e.PropertyName) {
				// case "SelectedClient": Debug.WriteLine(e.PropertyName + " / " + ClientIdx); break;
				// case "SelectedProject": Debug.WriteLine(e.PropertyName + " / " + ProjectIdx); break;
				// case "SelectedWorkType": Debug.WriteLine(e.PropertyName + " / " + WorkTypeIdx); break;
				// case "ChangedDuration": Debug.WriteLine(e.PropertyName + " / " + this.duration); break;
				// case "ChangedAddition": Debug.WriteLine(e.PropertyName + " / " + this.addition); break;
				case "SelectedCCC":
				//     Debug.WriteLine(e.PropertyName + " / " + CCCIdx);
				// if (CCCIdx < 0) break;
				// CC = LutCCCNums[CCCIdx]; break;
				// case "CC": Debug.WriteLine(e.PropertyName + " / " + CCCIdx); break;
				default:
					Debug.WriteLine("Fehler");
					break;
			}
		}
	}
}
