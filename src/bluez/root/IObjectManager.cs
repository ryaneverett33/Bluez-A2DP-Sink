using org.freedesktop.DBus;
using DBus;

namespace player.bluez { 
	[Interface ("org.freedesktop.DBus.ObjectManager")]
	public interface IObjectManager
	{
		string GetManagedObjects ();
		event InterfaceAddedHandler InterfacesAdded;
		event InterfaceRemovedHandler InterfacesRemoved;
	}
	public delegate void InterfaceAddedHandler (string interfaces);
	public delegate void InterfaceRemovedHandler (string [] interfaces);
}