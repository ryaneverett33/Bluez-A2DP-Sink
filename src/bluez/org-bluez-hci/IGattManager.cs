using org.freedesktop.DBus;
using DBus;
using System.Collections.Generic;

namespace player.bluez {
	[Interface ("org.bluez.GattManager1")]
	interface IGattManager
	{
		void RegisterApplication (ObjectPath application, Dictionary<string, string> options);
		void UnregisterApplication (ObjectPath application);
	}
}