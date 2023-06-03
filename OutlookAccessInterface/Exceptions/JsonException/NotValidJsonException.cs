using System;
using System.Text.Json;

namespace OutlookAccessInterface.Exceptions
{
	public class NotValidJsonException : JsonException
	{
		public NotValidJsonException(string message) : base(message) { }
		public NotValidJsonException(string message, Exception innerException) : base(message, innerException) { }
	}
}
