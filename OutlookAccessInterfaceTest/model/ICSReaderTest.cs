using OutlookAccessInterface.model;
using OutlookAccessInterface.model.calendarProperties;
using OutlookAccessInterface.utility;

namespace OutlookAccessInterfaceTest.model;

public class ICSReaderTest : BaseTest
{
	[Test]
	public void ICSReader_calendar_exists() { Assert.That(File.Exists(TEST_CALENDAR)); }

	[Test]
	public void ICSReader_is_singleton()
	{
		ICSReader _reader1 = ICSReader.get_instance(TEST_CALENDAR);
		ICSReader _reader2 = ICSReader.get_instance(TEST_CALENDAR);

		Assert.That(_reader2, Is.EqualTo(_reader1));

		ICSReader.release_instance();
	}

	[Test]
	public void release_deletes_instance()
	{
		ICSReader _reader1 = ICSReader.get_instance(TEST_CALENDAR);
		ICSReader.release_instance();
		ICSReader _reader2 = ICSReader.get_instance(TEST_CALENDAR);

		Assert.That(_reader2, Is.Not.EqualTo(_reader1));

		ICSReader.release_instance();
	}

	[Test]
	public void create_reader_wasNull_is_notNull()
	{
		Assert.That(ICSReader.get_instance(TEST_CALENDAR), Is.Not.Null);
		ICSReader.release_instance();
	}

	[Test]
	public void create_reader_wasNotNull_is_notNull()
	{
		ICSReader.get_instance(TEST_CALENDAR);

		Assert.That(ICSReader.get_instance(TEST_CALENDAR), Is.Not.Null);
	}

	public class ICSReaderReadTest
	{
		private ICSReader _reader = ICSReader.get_instance(TEST_CALENDAR);
		private List<CalEvent> calendarEvents;

		[Test]
		public void convertIcsEventToCalEvent_creates_validCalEvent() { }

		[Test]
		public void getCalendarEventsFromICSFile_gets_validData() { }
	}
}
