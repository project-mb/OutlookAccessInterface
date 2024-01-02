namespace OutlookAccessInterface.exceptions.calendarException;

public class CalendarException : Exception
{
	public CalendarException(string message) : base(message) { }

	public CalendarException(string message, Exception innerException) : base(message, innerException) { }
}
