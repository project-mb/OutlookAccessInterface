using System;

namespace OutlookAccessInterface.Exceptions.DatabaseException
{
	public class DatabaseException : Exception
	{
		public DatabaseException(string message) : base(message) { }

		public DatabaseException(string message, Exception innerException) : base(message, innerException) { }
	}
}
