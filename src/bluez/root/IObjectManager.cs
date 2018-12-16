using org.freedesktop.DBus;
using DBus;
using System.Collections.Generic;

namespace player.bluez {
    [Interface("org.freedesktop.DBus.ObjectManager")]
    public interface IObjectManager {
        //'/org/bluez', '/org/bluez/hci0'
        IDictionary<ObjectPath, IDictionary<string, IDictionary<string, object>>> GetManagedObjects();
        event InterfacesAddedHandler InterfacesAdded;
        event InterfacesRemovedHandler InterfacesRemoved;
    }
    public delegate void InterfacesAddedHandler(ObjectPath path, IDictionary<string, IDictionary<string, object>> interfaces);
    //public delegate void InterfacesAddedHandler(IDictionary<string, IDictionary<string, object>> interfaces);
    public delegate void InterfacesRemovedHandler(ObjectPath path, string[] interfaces);
    //public delegate void InterfacesRemovedHandler(string[] interfaces);
}