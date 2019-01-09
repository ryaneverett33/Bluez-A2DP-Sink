using org.freedesktop.DBus;
using DBus;
using System;
using System.Collections.Generic;

namespace player.bluez {
    /// <summary>
    /// 
    /// </summary>
    /// <documentation>
    /// https://git.kernel.org/pub/scm/bluetooth/bluez.git/tree/doc/advertising-api.txt
    /// </documentation>
    [Interface("org.bluez.LEAdvertisingManager1")]
    public interface ILEAdvertisingManager {
        void RegisterAdvertisement(ObjectPath advertisement, IDictionary<string, object> options);
        void UnregisterAdvertisement(ObjectPath service);
        string[] SupportedIncludes {
            get;
        }
        byte ActiveInstances {
            get;
        }
        byte SupportedInstances {
            get;
        }
    }
}