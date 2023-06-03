using System;

namespace OutlookAccessInterface.Exceptions.OAIException
{
	public class CalendarFileMissingException : OAIException
	{
		public CalendarFileMissingException(string message) : base(message) { }

		public CalendarFileMissingException(string message, Exception innerException) : base(message, innerException) { }
	}
}
