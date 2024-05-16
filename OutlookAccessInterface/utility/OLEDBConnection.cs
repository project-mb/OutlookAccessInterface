using System.Data.OleDb;
using OutlookAccessInterface.__development__;
using OutlookAccessInterface.exceptions.databaseException;

namespace OutlookAccessInterface.utility;

public class OLEDBConnection : IDBConnection
{
	//NSEC: singleton
	private static OLEDBConnection? _instance;
	public static OLEDBConnection get_instance(string databaseFilePath) { return _instance ??= new OLEDBConnection(databaseFilePath); }
	private OLEDBConnection(string databaseFilePath)
	{
		this.dbConnection = new OleDbConnection();
		this.dbConnection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + databaseFilePath + ";Persist Security Info=False;";
	}
	public static void release_instance() { _instance = null; }
	~OLEDBConnection()
	{
		_instance = null;
		((IDBConnection) this).disconnect();
	}

	//NSEC: fields
	private readonly OleDbConnection dbConnection;
	private OleDbCommand? cmd;
	private OleDbDataReader? reader;

	// public Dictionary<string, Dictionary<string, List<string>>> Tabels { get; private set; } = new Dictionary<string, Dictionary<string, List<string>>>();

	//NSEC: getter-setter
	// private Dictionary<string, Dictionary<string, List<string>>> Tabels { get; } = new();

	//NSEC: public methods
	void IDBConnection.connect()
	{
		try { this.dbConnection.Open(); } catch (Exception exception) { throw new CouldNotConnectToDatabaseException(exception.Message, exception); }
	}

	void IDBConnection.disconnect()
	{
		try { this.dbConnection.Close(); } catch (Exception exception) { throw new CouldNotDisconnectFromDatabaseException(exception.Message, exception); }
	}

	// public Dictionary<string, Dictionary<string, List<string>>> getTables()
	// {
	// 	Dictionary<string, Dictionary<string, List<string>>> tables = new();
	//
	// 	while (true) {
	// 		try {
	// 			((IDBConnection) this).connect();
	// 			break;
	// 		} catch (Exception e) { throw new CouldNotConnectToDatabaseException(e.Message, e); }
	// 	}
	//
	// 	tables.Add("Tage", select(["Tag_ID", "Datum"], "Tage"));
	// 	tables.Add("LU_Tagestyp", select(["Tagestyp_ID", "Tagestyp"], "LU_Tagestyp", "Tagestyp"));
	// 	tables.Add("LU_Mandant", select(["Mandant_ID", "Mandant"], "LU_Mandant", "Mandant"));
	// 	tables.Add("LU_Projekt", select(["Projekt_ID", "Projekt", "PRJ_Nummer_AG"], "LU_Projekt", "Projekt"));
	// 	tables.Add("LU_Taetigkeit", select(["Taetigkeit_ID", "Taetigkeit"], "LU_Taetigkeit", "Taetigkeit"));
	// 	tables.Add("LU_Kostenstelle_AG", select(["KST_AG_ID", "Mandant", "Projekt", "KST_Nummer_AG"], "LU_Kostenstelle_AG", "Projekt"));
	//
	// 	while (true) {
	// 		try {
	// 			((IDBConnection) this).disconnect();
	// 			break;
	// 		} catch (Exception e) { throw new CouldNotDisconnectFromDatabaseException(e.Message, e); }
	// 	}
	//
	// 	return tables;
	// }

	Dictionary<string, List<string>> IDBConnection.select(string[] select, string from, string orderBy, string where)
	{
		//SELECT atr1, atr2, ... FROM table ORDER BY ... WHERE ...
		
		this.cmd = new OleDbCommand();

		Dictionary<string, List<string>> output = new();

		string _select = "";

		foreach (string entry in select) {
			if(_select == "") _select = entry;
			else _select += ", " + entry;

			output.Add(entry, new List<string>());
		}

		if(orderBy != "") orderBy = $" ORDER BY {orderBy}";
		if(where != "") where = $" WHERE {where}";

		this.cmd.CommandText = $"SELECT {_select} FROM {from}{orderBy}{where}";
		this.cmd.Connection = this.dbConnection;

		try { this.reader = this.cmd.ExecuteReader(); } catch (Exception exception) {
			string exceptionMsg = $"[Select]\n{exception.Message}\n\nClosing Program";
			throw new NotValidDatabaseSelectException(exceptionMsg, exception);
		}

		if(this.reader == null) throw new NullReferenceException(DebugTools.getDebugString());

		while (this.reader.Read())
			foreach (string item in select)
				output[item].Add(this.reader[item].ToString() ?? throw new InvalidOperationException(DebugTools.getDebugString()));


		return output;
	}

	int IDBConnection.insertInto(IEnumerable<string> insertInto, IEnumerable<string> fields, IEnumerable<string> values)
	{
		//INSERT INTO table1, table2, ... (atr1, atr2, ...) VALUES (val1, val2, ...)
		
		this.cmd = new OleDbCommand();

		string _insertInto = "";
		string _fields = "";
		string _values = "";

		foreach (string entry in insertInto)
			if(_insertInto == "") _insertInto = entry;
			else _insertInto += ", " + entry;

		foreach (string entry in fields)
			if(_fields == "") _fields = entry;
			else _fields += ", " + entry;

		foreach (string entry in values)
			if(_values == "") _values = "'" + entry + "'";
			else _values += ", " + "'" + entry + "'";

		//MessageBox.Show("INSERT INTO " + _insertInto + " (" + _fields + ") VALUES (" + _values + ")");
		this.cmd.CommandText = $"INSERT INTO {_insertInto} ({_fields}) VALUES ({_values})";

		string errorMsg = $"[InsertInto]: INSERT INTO {_insertInto} ({_fields}) VALUES ({_values})";
		return this.checkCmdForError(this.cmd, errorMsg);
	}

	int IDBConnection.update(IEnumerable<string> update, string set, string where)
	{
		//UPDATE table1, table2, ... SET (atr1, atr2, ...) WHERE ...
		this.cmd = new OleDbCommand();

		string _update = "";

		foreach (string entry in update)
			if(_update == "") _update = entry;
			else _update += ", " + entry;

		this.cmd.CommandText = $"UPDATE {_update} SET {set} WHERE {where}";

		const string errorMsg = "[Update]";
		return this.checkCmdForError(this.cmd, errorMsg);
	}

	int IDBConnection.deleteFrom(IEnumerable<string> from, string where)
	{
		this.cmd = new OleDbCommand();

		string _from = "";

		foreach (string entry in from)
			if(_from == "") _from = entry;
			else _from += ", " + entry;

		this.cmd.CommandText = $"DELETE FROM {_from} WHERE {where}";

		const string errorMsg = "[DeleteFrom]";
		return this.checkCmdForError(this.cmd, errorMsg);
	}

	//NSEC: private methods
	private int checkCmdForError(OleDbCommand checkCmd, string errorMsg)
	{
		if(this.cmd == null) throw new NullReferenceException(DebugTools.getDebugString());

		this.cmd.Connection = this.dbConnection;

		try { return checkCmd.ExecuteNonQuery(); } catch (Exception exception) {
			string exceptionMsg = $"{errorMsg}\n\n{exception.Message}\n\nClosing Program";
			throw new NotValidDatabaseCmdException(exceptionMsg, exception);
		}
	}
}
