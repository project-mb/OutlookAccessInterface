using System;
using OutlookAccessInterface.Model;

namespace OutlookAccessInterface.Exceptions.DatabaseException
{
	public class CouldNotDisconnectFromDatabaseException : DatabaseException
	{
		public CouldNotDisconnectFromDatabaseException(string message) : base(message) { }

		public CouldNotDisconnectFromDatabaseException(string message, Exception innerException) : base(message, innerException) { }
	}
}
