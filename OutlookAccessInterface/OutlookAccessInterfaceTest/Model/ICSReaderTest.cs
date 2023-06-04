using System.Diagnostics.Tracing;
using Ical.Net;
using Ical.Net.Interfaces;
using Ical.Net.Interfaces.Components;
using OutlookAccessInterface.Model;
using OutlookAccessInterface.Model.CalendarProperties;

namespace OutlookAccessInterfaceTest.Model;

public class ICSReaderTest : BaseTest
{
	[Test]
	public void ICSReader_calendar_exists() { Assert.That(File.Exists(TEST_CALENDAR)); }

	[Test]
	public void ICSReader_is_singleton()
	{
		ICSReader _reader1 = ICSReader.create(TEST_CALENDAR);
		ICSReader _reader2 = ICSReader.create(TEST_CALENDAR);

		Assert.That(_reader2, Is.EqualTo(_reader1));

		ICSReader.release();
	}

	[Test]
	public void release_deletes_instance()
	{
		ICSReader _reader1 = ICSReader.create(TEST_CALENDAR);
		ICSReader.release();
		ICSReader _reader2 = ICSReader.create(TEST_CALENDAR);

		Assert.That(_reader2, Is.Not.EqualTo(_reader1));

		ICSReader.release();
	}

	[Test]
	public void create_reader_wasNull_is_notNull()
	{
		Assert.That(ICSReader.create(TEST_CALENDAR), Is.Not.Null);
		ICSReader.release();
	}

	[Test]
	public void create_reader_wasNotNull_is_notNull()
	{
		ICSReader.create(TEST_CALENDAR);

		Assert.That(ICSReader.create(TEST_CALENDAR), Is.Not.Null);
	}

	public class ICSReaderReadTest
	{
		private ICSReader _reader = ICSReader.create(TEST_CALENDAR);
		private List<CalEvent> calendarEvents;

		[Test]
		public void convertIcsEventToCalEvent_creates_validCalEvent() { }

		[Test]
		public void getCalendarEventsFromICSFile_gets_validData() { }
	}
}
