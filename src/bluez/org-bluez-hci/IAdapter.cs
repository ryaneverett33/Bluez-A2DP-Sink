using org.freedesktop.DBus;
using DBus;
using System;
using System.Collections.Generic;

namespace player.bluez {
    [Interface("org.bluez.Adapter1")]
    public interface IAdapter {
        /*
        for getting properties
        String name = “org.freedesktop.NetworkManager”;
        Org.freedesktop.DBus.Properties props = conn.GetObject<Properties>(name, new ObjectPath(“/org/freedesktop/NetworkManager”));
        UInt32 state = (UInt32) props.Get(name, “State”);
         */
        string[] GetDiscoveryFilters();
        void RemoveDevice(ObjectPath device);
        void SetDiscoveryFilter(IDictionary<string, object> properties);
        void StartDiscovery();
        void StopDiscovery();

        //Properties
        string Address {
            get;
        }
        string AddressType {
            get;
        }
        string Name {
            get;
        }
        string Alias {
            get; set;
        }
        UInt32 Class {
            get;
        }
        bool Powered {
            get; set;
        }
        bool Discoverable {
            get; set;
        }
        UInt32 DiscoverableTimeout {
            get; set;
        }
        bool Pairable {
            get; set;
        }
        UInt32 PairableTimeout {
            get; set;
        }
        bool Discovering {
            get;
        }
        string[] UUIDs {
            get;
        }
        string Modalias {
            get;
        }
    }
}