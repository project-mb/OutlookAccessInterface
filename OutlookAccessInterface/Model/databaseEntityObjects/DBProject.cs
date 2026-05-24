using System.Runtime.CompilerServices;
using System.Windows.Documents;
using static OutlookAccessInterface.model.databaseEntityObjects.DBProject.Table;

namespace OutlookAccessInterface.model.databaseEntityObjects;

public class DBProject : DBBaseObject
{
	//NSEC: class members
	public static class Table
	{
		public static string Table_LU_Projekt { get => "LU_Projekt"; }
		public static string Projekt_ID { get => "Projekt_ID"; }
		public static string Projekt { get => "Projekt"; }
		public static string PRJ_Nummer_AG { get => "PRJ_Nummer_AG"; }
		public static string nicht_in_Summe { get => "nicht_in_Summe"; }
		public static string Archiv { get => "Archiv"; }
	}

	//NSEC: instance members
	public DBProject() : base(-1, EntryType.EXISTING)
	{
		this.ProjectName = "";
		this.ProjectNumber = "";
		this.NotInSum = false;
		this.IsArchived = false;
	}
	
	public DBProject(int id, EntryType entryType, string projectName, string projectNumber, bool notInSum, bool isArchived) : base(id, entryType)
	{
		this.ProjectName = projectName;
		this.ProjectNumber = projectNumber;
		this.NotInSum = notInSum;
		this.IsArchived = isArchived;
	}

	public DBProject(int idx, IReadOnlyDictionary<string, List<string>> table) : base(Convert.ToInt32(table[Projekt_ID][idx]), EntryType.EXISTING)
	{
		this.ProjectName = table[Projekt][idx];
		this.ProjectNumber = table[PRJ_Nummer_AG][idx];
		this.NotInSum = Convert.ToBoolean(table[nicht_in_Summe][idx]);
		this.IsArchived = Convert.ToBoolean(table[Archiv][idx]);
	}

	//NSEC: fields
	public string ProjectName { get; }
	public string ProjectNumber { get; }
	public bool NotInSum { get; }
	public bool IsArchived { get; }
}
