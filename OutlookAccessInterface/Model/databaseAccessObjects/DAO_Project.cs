using OutlookAccessInterface.model.databaseEntityObjects;
using OutlookAccessInterface.utility;
using static OutlookAccessInterface.model.databaseEntityObjects.DBProject.Table;

namespace OutlookAccessInterface.model.databaseAccessObjects;

public class DAO_Project(IDBConnection idbConnection) : IDAO<DBProject>
{
	public void create(DBProject DBObject)
	{
		idbConnection.insertInto([Table_LU_Projekt], [Projekt, PRJ_Nummer_AG, nicht_in_Summe, Archiv],
		[
			$"{DBObject.ProjectName}",
			$"{DBObject.ProjectNumber}",
			$"{DBObject.NotInSum}",
			$"{DBObject.IsArchived}"
		]);
	}

	public void update(DBProject DBObject)
	{
		idbConnection.update([Table_LU_Projekt],
			$"{Projekt} = {DBObject.ProjectName}," +
			$"{PRJ_Nummer_AG} = {DBObject.ProjectNumber}" +
			$"{nicht_in_Summe} = {DBObject.NotInSum}" +
			$"{Archiv} = {DBObject.IsArchived}",
			$"{Projekt_ID} = {DBObject.Id}");
	}

	public void delete(DBProject DBObject) { idbConnection.deleteFrom([Table_LU_Projekt], $"{Projekt_ID} = {DBObject.Id}"); }

	public List<DBProject> select_all()
	{
		List<DBProject> projects = [];
		Dictionary<string, List<string>> table = idbConnection.select([Projekt_ID, Projekt, PRJ_Nummer_AG, nicht_in_Summe, Archiv], Table_LU_Projekt);

		for (int i = 0; i < table.Count; i++) {
			DBProject newProject = new(i, table);

			if(RecordDatabase.Clients.Exists(x => x.Id == newProject.Id)) continue;

			projects.Add(newProject);
		}

		return projects;
	}
}
