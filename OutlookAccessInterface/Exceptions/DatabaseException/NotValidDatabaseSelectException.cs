using System;

namespace OutlookAccessInterface.Exceptions.DatabaseException
{
	public class NotValidDatabaseSelectException : NotValidDatabaseCmdException
	{
		public NotValidDatabaseSelectException(string message) : base(message) { }

		public NotValidDatabaseSelectException(string message, Exception innerException) : base(message, innerException) { }
	}
}
