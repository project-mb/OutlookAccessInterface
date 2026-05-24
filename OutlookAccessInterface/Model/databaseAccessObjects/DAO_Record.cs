using OutlookAccessInterface.model.databaseEntityObjects;
using OutlookAccessInterface.utility;
using static OutlookAccessInterface.model.databaseEntityObjects.DBRecord.Table;

namespace OutlookAccessInterface.model.databaseAccessObjects;

public class DAO_Record(IDBConnection idbConnection) : IDAO<DBRecord>
{
	public void create(DBRecord DBObject)
	{
		idbConnection.insertInto([Table_Zeiten], [Datum, Projekt, Taetigkeit, Ergaenzung, Zeit, Mandant, KST_Mandant, Bool_alt, alt_Ref],
		[
			$"{DBObject.Day.Id}",
			$"{DBObject.Project.Id}",
			$"{DBObject.WorkType.Id}",
			$"{DBObject.Addition}",
			$"{DBObject.Time}",
			$"{DBObject.Client.Id}",
			$"{DBObject.CostCentreClient.Id}",
			$"{DBObject.HasRecordReference}",
			$"{DBObject.RecordReference}"
		]);
	}

	public void update(DBRecord DBObject)
	{
		idbConnection.update([Table_Zeiten],
			$"{Datum} = {DBObject.Day.Id}," +
			$"{Projekt} = {DBObject.Project.Id}," +
			$"{Taetigkeit} = {DBObject.WorkType.Id}," +
			$"{Ergaenzung} = {DBObject.Addition}," +
			$"{Zeit} = {DBObject.Time}," +
			$"{Mandant} = {DBObject.Client.Id}," +
			$"{KST_Mandant} = {DBObject.CostCentreClient.Id}," +
			$"{Bool_alt} = {DBObject.HasRecordReference}," +
			$"{alt_Ref} = {DBObject.RecordReference},",
			$"{Code} = {DBObject.Id}");
	}

	public void delete(DBRecord DBObject) { idbConnection.deleteFrom([Table_Zeiten], $"{Code} = {DBObject.Id}"); }

	public List<DBRecord> select_all()
	{
		List<DBRecord> records = [];
		Dictionary<string, List<string>> table = idbConnection.select([Code, Datum, Projekt, Taetigkeit, Ergaenzung, Zeit, Mandant, KST_Mandant, Bool_alt, alt_Ref], Table_Zeiten);

		for (int i = 0; i < table[Code].Count; i++) {
			DBRecord newRecord = new(i, table);

			if(RecordDatabase.Clients.Exists(x => x.Id == newRecord.Id)) continue;

			records.Add(newRecord);
		}

		return records;
	}
}
