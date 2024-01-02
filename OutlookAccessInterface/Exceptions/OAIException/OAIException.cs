namespace OutlookAccessInterface.exceptions.oaiException;

public class OAIException : Exception
{
	public OAIException(string message) : base(message) { }

	public OAIException(string message, Exception innerException) : base(message, innerException) { }
}
