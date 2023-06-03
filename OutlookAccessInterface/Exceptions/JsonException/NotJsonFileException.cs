using System;
using System.Text.Json;

namespace OutlookAccessInterface.Exceptions
{
	public class NotJsonFileException : JsonException
	{
		public NotJsonFileException(string message) : base(message) { }
		public NotJsonFileException(string message, Exception innerException) : base(message, innerException) { }
	}
}
