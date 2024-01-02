using System.Text.Json;

namespace OutlookAccessInterface.exceptions.jsonException;

public class NotJsonFileException : JsonException
{
	public NotJsonFileException(string message) : base(message) { }
	public NotJsonFileException(string message, Exception innerException) : base(message, innerException) { }
}
