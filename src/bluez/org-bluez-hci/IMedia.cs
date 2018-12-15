using org.freedesktop.DBus;
using DBus;
using System.Collections.Generic;

namespace player.bluez {
    [Interface("org.bluez.Media1")]
    public interface IMedia {
        void RegisterEndpoint(ObjectPath endpoint, IDictionary<string, object> properties);
        void RegisterPlayer(ObjectPath player, IDictionary<string, object> properties);
        void UnregisterEndpoint(ObjectPath endpoint);
        void UnregisterPlayer(ObjectPath player);
    }
}