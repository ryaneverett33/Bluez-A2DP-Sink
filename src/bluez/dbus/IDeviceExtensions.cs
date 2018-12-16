using System;
using org.freedesktop.DBus;
using DBus;

namespace player.bluez {
    public static class IDeviceExtensions {
        private static org.freedesktop.DBus.Properties properties(ObjectPath path) {
            return Bus.System.GetObject<Properties>("org.bluez", path);
        }
        public static string GetAddress(this IDevice device, ObjectPath path) {
            return (string)properties(path).Get("org.bluez.Device1", "Address");
        }
        public static string GetAddressType(this IDevice device, ObjectPath path) {
            return (string)properties(path).Get("org.bluez.Device1", "AddressType");
        }
        public static string GetName(this IDevice device, ObjectPath path) {
            return (string)properties(path).Get("org.bluez.Device1", "Name");
        }
        public static string GetIcon(this IDevice device, ObjectPath path) {
            return (string)properties(path).Get("org.bluez.Device1", "Icon");
        }
        public static UInt32 GetClass(this IDevice device, ObjectPath path) {
            return (UInt32)properties(path).Get("org.bluez.Device1", "Class");
        }
        public static UInt16 GetAppearance(this IDevice device, ObjectPath path) {
            return (UInt16)properties(path).Get("org.bluez.Device1", "Appearance");
        }
        public static string[] GetUUIDs(this IDevice device, ObjectPath path) {
            return (string[])properties(path).Get("org.bluez.Device1", "UUIDs");
        }
        public static bool GetPaired(this IDevice device, ObjectPath path) {
            return (bool)properties(path).Get("org.bluez.Device1", "Paired");
        }
        public static bool GetConnected(this IDevice device, ObjectPath path) {
            return (bool)properties(path).Get("org.bluez.Device1", "Connected");
        }
        public static bool GetTrusted(this IDevice device, ObjectPath path) {
            return (bool)properties(path).Get("org.bluez.Device1", "Trusted");
        }
        public static void Trusted(this IDevice device, ObjectPath path, bool value) {
            properties(path).Set("org.bluez.Device1", "Trusted", value);
        }
        public static bool GetBlocked(this IDevice device, ObjectPath path) {
            return (bool)properties(path).Get("org.bluez.Device1", "Blocked");
        }
        public static void Blocked(this IDevice device, ObjectPath path, bool value) {
            properties(path).Set("org.bluez.Device1", "Blocked", value);
        }
        public static string GetAlias(this IDevice device, ObjectPath path) {
            return (string)properties(path).Get("org.bluez.Device1", "Alias");
        }
        public static object GetAdapter(this IDevice device, ObjectPath path) {
            return (object)properties(path).Get("org.bluez.Device1", "Adapter");
        }
        public static bool GetLegacyPairing(this IDevice device, ObjectPath path) {
            return (bool)properties(path).Get("org.bluez.Device1", "LegacyPairing");
        }
        public static string GetModalias(this IDevice device, ObjectPath path) {
            return (string)properties(path).Get("org.bluez.Device1", "Modalias");
        }
        public static Int16 GetRSSI(this IDevice device, ObjectPath path) {
            return (Int16)properties(path).Get("org.bluez.Device1", "RSSI");
        }
        public static Int16 GetTxPower(this IDevice device, ObjectPath path) {
            return (Int16)properties(path).Get("org.bluez.Device1", "TxPower");
        }
    }
}