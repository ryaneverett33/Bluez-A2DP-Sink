using org.freedesktop.DBus;
using DBus;

namespace player.bluez {
    [Interface("org.freedesktop.DBus.Introspectable")]
    public interface IIntrospectable {
        //returns xml
        string Introspect();
    }
}