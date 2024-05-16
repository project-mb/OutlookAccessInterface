using OutlookAccessInterface.configuration.configObjects;

namespace OutlookAccessInterface.utility;

public class OLEDBDateTime(DateTime inner)
{
	private readonly DateTime _inner = inner;

	public static explicit operator DateTime(OLEDBDateTime mdt) { return mdt._inner; }

	public override string ToString() { return this._inner.ToString(Configuration.DATABASE_TIMEFORMAT); }
}
