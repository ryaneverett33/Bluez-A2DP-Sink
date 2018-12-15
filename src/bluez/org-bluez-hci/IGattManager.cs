using org.freedesktop.DBus;
using DBus;
using System.Collections.Generic;

namespace player.bluez {
    [Interface("org.bluez.GattManager1")]
    public interface IGattManager {
        void RegisterApplication(ObjectPath application, IDictionary<string, object> options);
        void UnregisterApplication(ObjectPath application);
    }
}