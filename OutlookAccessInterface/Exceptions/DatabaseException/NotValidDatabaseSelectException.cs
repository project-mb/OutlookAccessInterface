namespace OutlookAccessInterface.exceptions.databaseException;

public class NotValidDatabaseSelectException : NotValidDatabaseCmdException
{
	public NotValidDatabaseSelectException(string message) : base(message) { }

	public NotValidDatabaseSelectException(string message, Exception innerException) : base(message, innerException) { }
}
