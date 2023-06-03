namespace OutlookAccessInterfaceTest.ConfigController.ConfigObjects;

public class FileFiltersTest
{
	[Test]
	public void ValidDefaultCalendarFilter() { Assert.That(FileFilters.DEFAULT_CALENDARFILTER, Is.EqualTo(new[] { "ics files (*.ics)|*.ics" })); }

	[Test]
	public void ValidDefaultDatabaseFilter() { Assert.That(FileFilters.DEFAULT_DATABASEFILTER, Is.EqualTo(new[] { "accdb files (*.accdb)|*.accdb" })); }
}
