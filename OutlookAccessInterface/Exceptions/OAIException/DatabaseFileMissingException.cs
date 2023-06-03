using System;

namespace OutlookAccessInterface.Exceptions.OAIException
{
	public class DatabaseFileMissingException : OAIException
	{
		public DatabaseFileMissingException(string message) : base(message) { }

		public DatabaseFileMissingException(string message, Exception innerException) : base(message, innerException) { }
	}
}
