namespace OutlookAccessInterface.exceptions.oaiException;

public class CalendarFileMissingException : OAIException
{
	public CalendarFileMissingException(string message) : base(message) { }

	public CalendarFileMissingException(string message, Exception innerException) : base(message, innerException) { }
}
