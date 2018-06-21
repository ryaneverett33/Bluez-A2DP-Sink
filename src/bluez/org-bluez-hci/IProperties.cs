using org.freedesktop.DBus;
using DBus;
using System.Collections.Generic;

namespace player.bluez { 
	[Interface ("org.freedesktop.DBus.Properties")]
	interface Properties
	{
		//parameter name 'interface' is shortened to 'interfac'
		string Get (string interfac, string name);
		Dictionary<string, string> GetAll (string interfac);
		void Set (string interfac, string name, string value);
		event PropertiesChangedHandler PropertiesChanged;
	}
	public delegate void PropertiesChangedHandler (string name, Dictionary<string, string> properties, string[] idk);
} 