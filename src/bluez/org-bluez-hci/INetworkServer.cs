using org.freedesktop.DBus;
using DBus;

namespace player.bluez {
    [Interface("org.bluez.NetworkServer1")]
    public interface INetworkServer {
        void Register(string uuid, string bridge);
        void Unregister(string uuid);
    }
}