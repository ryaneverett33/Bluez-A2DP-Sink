using org.freedesktop.DBus;
using DBus;
using System.Collections.Generic;

namespace player.bluez {
    [Interface("org.freedesktop.DBus.Properties")]
    public interface IProperties {
        object Get(string inter, string name);
        IDictionary<string, object> GetAll(string inter);
        void Set(string inter, string name, object value);
        event PropertiesChangedHandler PropertiesChanged;
    }
    public delegate void PropertiesChangedHandler(string name, IDictionary<string, object> properties, string[] interfaces);
}