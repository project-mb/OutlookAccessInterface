using System;

namespace OutlookAccessInterface.Exceptions.DatabaseException
{
	public class NotValidDatabaseCmdException : DatabaseException
	{
		public NotValidDatabaseCmdException(string message) : base(message) { }

		public NotValidDatabaseCmdException(string message, Exception innerException) : base(message, innerException) { }
	}
}
