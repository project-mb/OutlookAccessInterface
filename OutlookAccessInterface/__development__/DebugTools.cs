using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace OutlookAccessInterface.__development__;

public static class DebugTools
{
	private const string DEBUG_LOGSEPERATOR = "::";

	private const string DEBUG_LINEEND = "$";

	// private const string PREFIX_SEPERATOR = ".";
	public const string PREFIX_DEBUG = "DEBUG";
	public const string PREFIX_INFO = "INFO";
	public const string PREFIX_ERROR = "ERROR";
	private const int PREFIX_ALIGNMENT = -10;

	public static void debug(string text, [CallerFilePath] string file = "", [CallerMemberName] string member = "", [CallerLineNumber] int line = 0) { Debug.WriteLine(getDebugString(PREFIX_DEBUG, text, file, member, line)); }
	public static void error(string text, [CallerFilePath] string file = "", [CallerMemberName] string member = "", [CallerLineNumber] int line = 0) { Debug.WriteLine(getDebugString(PREFIX_ERROR, text, file, member, line)); }

	public static void info(string text) { Debug.WriteLine($"{PREFIX_INFO,PREFIX_ALIGNMENT} {text}"); }

	public static string getDebugString(string prefix = PREFIX_DEBUG, string text = "", [CallerFilePath] string file = "", [CallerMemberName] string member = "", [CallerLineNumber] int line = 0)
	{
		//N: for example: DEBUG SelectionViewController.cs::bt_importData_clickHandler::56$ test
		return $"{prefix,PREFIX_ALIGNMENT} {file.Split('\\').Last()}{DEBUG_LOGSEPERATOR}{member}{DEBUG_LOGSEPERATOR}{line}{DEBUG_LINEEND} {text}";
	}
}
