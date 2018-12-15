using org.freedesktop.DBus;
using DBus;
using System.Collections.Generic;
namespace player.bluez {
    [Interface("org.bluez.ProfileManager1")]
    public interface IProfileManager {
        //string profile is of DBus type Object Path
        void RegisterProfile(string profile, IDictionary<string, object> options);
        void UnregisterProfile(string profile);
    }
}