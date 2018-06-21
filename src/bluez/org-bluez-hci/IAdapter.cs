using org.freedesktop.DBus;
using DBus;
using System.Collections.Generic;

namespace player.bluez {
	[Interface ("org.bluez.Adapter1")]
	public interface Adapter
	{
		/*
	    for getting properties
	    String name = “org.freedesktop.NetworkManager”;
	    Org.freedesktop.DBus.Properties props = conn.GetObject<Properties>(name, new ObjectPath(“/org/freedesktop/NetworkManager”));
	    UInt32 state = (UInt32) props.Get(name, “*/
		void RemoveDevice (ObjectPath device);
		void SetDiscoveryFilter (Dictionary<string, string> properties);
		void StartDiscovery ();
		void StopDiscovery ();
		/* Properties exposed
		 * UUIDs : string[] (r)
		 * Discoverable : bool (r/w)
		 * Discovering : bool (r)
		 * Pairable : bool (r/w)
		 * Powered : bool (r/w)
		 * Address : string (r)
		 * Alias : string (r/w)
		 * Modalias : string (r)
		 * Name : string (r)
		 * Class : uint32 (r)
		 * DiscoverableTimeout : uint32 (r/w)
		 * PairableTimeout : uint32 (r/w)
		 */
	}
}