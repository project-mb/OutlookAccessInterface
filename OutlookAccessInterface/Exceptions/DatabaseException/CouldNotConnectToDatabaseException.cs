namespace OutlookAccessInterface.exceptions.databaseException;

public class CouldNotConnectToDatabaseException : DatabaseException
{
	public CouldNotConnectToDatabaseException(string message) : base(message) { }

	public CouldNotConnectToDatabaseException(string message, Exception innerException) : base(message, innerException) { }
}
