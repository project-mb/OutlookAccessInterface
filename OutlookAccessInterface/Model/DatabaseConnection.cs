using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Windows;

namespace OutlookAccessInterface.Model
{
	public class DatabaseConnection
	{
		// fields
		private OleDbCommand cmd;
		private OleDbDataReader reader;
		private readonly OleDbConnection dbConnection;

		// getter-setter
		public bool IsConnected { get; private set; }

		public Dictionary<string, Dictionary<string, List<string>>> Tabels { get; } = new Dictionary<string, Dictionary<string, List<string>>>();

		// constructor
		public DatabaseConnection(string databaseFilePath)
		{
			this.dbConnection = new OleDbConnection();
			this.dbConnection.ConnectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + databaseFilePath + "; Persist Security Info = False;";
		}

		// class methods
		private int checkCmdForError(OleDbCommand checkCmd, string errorMsg)
		{
			this.cmd.Connection = this.dbConnection;

			try { return checkCmd.ExecuteNonQuery(); }
			catch (Exception e) {
				string exceptionMsg = "\n\n" + e.Message + "\n\nClosing Program";

				MessageBox.Show(errorMsg + exceptionMsg, "Error");
				Environment.Exit(0);
				return -1;
			}
		}

		// methods
		public int Open()
		{
			try {
				this.dbConnection.Open();
				IsConnected = true;
				return 0;
			}
			catch { return -1; }
		}

		public int Close()
		{
			try {
				this.dbConnection.Close();
				IsConnected = false;
				return 0;
			}
			catch { return -1; }
		}

		public Dictionary<string, List<string>> Select(string[] select, string from, string orderBy = "", string where = "")
		{
			this.cmd = new OleDbCommand();

			Dictionary<string, List<string>> output = new Dictionary<string, List<string>>();

			string _select = "";

			foreach (string entry in select) {
				if (_select == "") _select = entry;
				else _select += ", " + entry;

				output.Add(entry, new List<string>());
			}

			if (orderBy != "") orderBy = " ORDER BY " + orderBy;
			if (where != "") where = " WHERE " + where;

			this.cmd.CommandText = "SELECT " + _select + " FROM " + from + orderBy + where;
			this.cmd.Connection = this.dbConnection;

			try { this.reader = this.cmd.ExecuteReader(); }
			catch (Exception e) { MessageBox.Show("[Select]\n" + e.Message + "\n\nClosing Program", "Error"); }

			if (this.reader == null) return null;
			while (this.reader.Read()) {
				foreach (string item in select) { output[item].Add(this.reader[item].ToString()); }
			}

			Tabels.Add(from, output);

			return output;
		}

		public int InsertInto(IEnumerable<string> insertInto, IEnumerable<string> fields, IEnumerable<string> values)
		{
			this.cmd = new OleDbCommand();

			string _insertInto = "";
			string _fields = "";
			string _values = "";

			foreach (string entry in insertInto) {
				if (_insertInto == "") _insertInto = entry;
				else _insertInto += ", " + entry;
			}

			foreach (string entry in fields) {
				if (_fields == "") _fields = entry;
				else _fields += ", " + entry;
			}

			foreach (string entry in values) {
				if (_values == "") _values = "'" + entry + "'";
				else _values += ", " + "'" + entry + "'";
			}

			//MessageBox.Show("INSERT INTO " + _insertInto + " (" + _fields + ") VALUES (" + _values + ")");
			this.cmd.CommandText = "INSERT INTO " + _insertInto + " (" + _fields + ") VALUES (" + _values + ")";

			string errorMsg = "[InsertInto]: " + "INSERT INTO " + _insertInto + " (" + _fields + ") VALUES (" + _values + ")";
			return checkCmdForError(this.cmd, errorMsg);
		}

		public int Update(IEnumerable<string> update, string set, string where)
		{
			this.cmd = new OleDbCommand();

			string _update = "";

			foreach (string entry in update) {
				if (_update == "") _update = entry;
				else _update += ", " + entry;
			}

			this.cmd.CommandText = "UPDATE " + _update + " SET " + set + " WHERE " + where;

			const string errorMsg = "[Update]";
			return checkCmdForError(this.cmd, errorMsg);
		}

		public int DeleteFrom(IEnumerable<string> from, string where)
		{
			this.cmd = new OleDbCommand();

			string _from = "";

			foreach (string entry in from) {
				if (_from == "") _from = entry;
				else _from += ", " + entry;
			}

			this.cmd.CommandText = "DELETE FROM " + _from + " WHERE " + where;

			const string errorMsg = "[DeleteFrom]";
			return checkCmdForError(this.cmd, errorMsg);
		}
	}
}
