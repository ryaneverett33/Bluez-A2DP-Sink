using org.freedesktop.DBus;
using DBus;
using System;
using System.Collections.Generic;

namespace player.bluez {
    /// <summary>
    /// 
    /// </summary>
    /// <documentation>
    /// https://git.kernel.org/pub/scm/bluetooth/bluez.git/tree/doc/device-api.txt
    /// </documentation>
    [Interface("org.bluez.Device1")]
    public interface IDevice {
        void Connect();
        void Disconnect();
        void ConnectProfile(string uuid);
        void DisconnectProfile(string uuid);
        void Pair();
        void CancelPairing();
        string Address {
            get;
        }
        string AddressType {
            get;
        }
        string Name {
            get;
        }
        string Icon {
            get;
        }
        UInt32 Class {
            get;
        }
        UInt16 Appearance {
            get;
        }
        string[] UUIDs {
            get;
        }
        bool Paired {
            get;
        }
        bool Connected {
            get;
        }
        bool Trusted {
            get;
            set;
        }
        bool Blocked {
            get;
            set;
        }
        string Alias {
            get;
        }
        object Adapter {
            get;
        }
        bool LegacyPairing {
            get;
        }
        string Modalias {
            get;
        }
        Int16 RSSI {
            get;
        }
        Int16 TxPower {
            get;
        }
        /*
         * ManufacturerData
         * ServiceData
         * ServicesResolved
         * AdvertisingFlags
         * AdvertisingData
         */
    }
}