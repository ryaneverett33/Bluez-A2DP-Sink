using org.freedesktop.DBus;
using DBus;
using System.Collections.Generic;

namespace player.bluez {
	[Interface ("org.bluez.ProfileManager1")]
	public interface ProfileManager
	{
		//string profile is of DBus type Object Path
		void RegisterProfile (ObjectPath profile, string UUID, Dictionary<string, string> options);
		void UnregisterProfile (string profile);
	}
}