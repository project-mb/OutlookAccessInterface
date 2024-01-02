namespace OutlookAccessInterface.exceptions.databaseException;

public class CouldNotDisconnectFromDatabaseException : DatabaseException
{
	public CouldNotDisconnectFromDatabaseException(string message) : base(message) { }

	public CouldNotDisconnectFromDatabaseException(string message, Exception innerException) : base(message, innerException) { }
}
