using org.freedesktop.DBus;
using DBus;
using System.Collections.Generic;

namespace player.bluez { 
	[Interface ("org.bluez.Media1")]
	interface Media
	{
		void RegisterEndpoint (ObjectPath endpoint, Dictionary<string, string> properties);
		void RegisterPlayer (ObjectPath player, Dictionary<string, string> properties);
		void UnregisterEndpoint (ObjectPath endpoint);
		void UnregisterPlayer (ObjectPath player);
	}
}