using System.Reflection.Emit;

namespace OutlookAccessInterface.Model.CalendarProperties
{
	public class CalEvent : CalBaseEvent
	{
		private string EndDate { get; } //				=> date the event ended
		private string _Class { get; } //				=> class of event (eg. private/public/...)
		private string Summary { get; } //				=> content of event


		// constructors
		public CalEvent(string startDate, string endDate, double startTime, double endTime, string evntClass, string summary) : base(startDate, startTime, endTime)
		{
			EndDate = endDate;
			_Class = evntClass;
			Summary = summary;
		}

		public CalEvent(string startDate, string endDate, string evntClass, string summary) : this(startDate, endDate, 0, 24, evntClass, summary) { }
	}
}
