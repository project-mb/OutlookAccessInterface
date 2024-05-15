namespace OutlookAccessInterface.utility;

public interface IDBConnection
{
	void connect();
	void disconnect();

	Dictionary<string, List<string>> select(string[] select, string from, string orderBy = "", string where = "");
	int insertInto(IEnumerable<string> insertInto, IEnumerable<string> fields, IEnumerable<string> values);
	int update(IEnumerable<string> update, string set, string where);
	int deleteFrom(IEnumerable<string> from, string where);
}
