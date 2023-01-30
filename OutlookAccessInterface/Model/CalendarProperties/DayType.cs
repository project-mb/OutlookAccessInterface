using System.Collections.Generic;

namespace OutlookAccessInterface.Model.CalendarProperties
{
	public class DayType
	{
		public string Type { get; private set; }
		public List<string> Types { get; }

		public string SelectedDayType
		{
			get => Type;
			set => Type = value;
		}

		public int TypeIdx { get; }
	}
}
