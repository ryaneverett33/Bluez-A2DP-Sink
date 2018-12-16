using System;
using org.freedesktop.DBus;
using DBus;

namespace player.bluez{
    public static class IAdapterExtensions {
        private static org.freedesktop.DBus.Properties properties(ObjectPath path) {
            return Bus.System.GetObject<Properties>("org.bluez", path);
        }

        //Extension Properties
        public static string GetName(this IAdapter adapter, ObjectPath path) {
            return (string)properties(path).Get("org.bluez.Adapter1", "Name");
        }
        public static string GetAddress(this IAdapter adapter, ObjectPath path) {
            return (string)properties(path).Get("org.bluez.Adapter1", "Address");
        }
        public static string GetAddressType(this IAdapter adapter, ObjectPath path) {
            return (string)properties(path).Get("org.bluez.Adapter1", "AddressType");
        }
        public static string GetAlias(this IAdapter adapter, ObjectPath path) {
            return (string)properties(path).Get("org.bluez.Adapter1", "Alias");
        }
        public static void SetAlias(this IAdapter adapter, ObjectPath path, string value) {
            properties(path).Set("org.bluez.Adapter1", "Alias", value);
        }
        public static UInt32 GetClass(this IAdapter adapter, ObjectPath path) {
            return (UInt32)properties(path).Get("org.bluez.Adapter1", "Class");
        }
        public static bool GetPowered(this IAdapter adapter, ObjectPath path) {
            return (bool)properties(path).Get("org.bluez.Adapter1", "Powered");
        }
        public static void SetPowered(this IAdapter adapter, ObjectPath path, bool value) {
            properties(path).Set("org.bluez.Adapter1", "Powered", value);
        }
        public static bool GetDiscoverable(this IAdapter adapter, ObjectPath path) {
            return (bool)properties(path).Get("org.bluez.Adapter1", "Discoverable");
        }
        public static void SetDiscoverable(this IAdapter adapter, ObjectPath path, bool value) {
            properties(path).Set("org.bluez.Adapter1", "Discoverable", value);
        }
        public static UInt32 GetDiscoverableTimeout(this IAdapter adapter, ObjectPath path) {
            return (UInt32)properties(path).Get("org.bluez.Adapter1", "DiscoverableTimeout");
        }
        public static void SetDiscoverableTimeout(this IAdapter adapter, ObjectPath path, UInt32 value) {
            properties(path).Set("org.bluez.Adapter1", "DiscoverableTimeout", value);
        }
        public static bool GetPairable(this IAdapter adapter, ObjectPath path) {
            return (bool)properties(path).Get("org.bluez.Adapter1", "Pairable");
        }
        public static void SetPairable(this IAdapter adapter, ObjectPath path, bool value) {
            properties(path).Set("org.bluez.Adapter1", "Pairable", value);
        }
        public static UInt32 GetPairableTimeout(this IAdapter adapter, ObjectPath path) {
            return (UInt32)properties(path).Get("org.bluez.Adapter1", "PairableTimeout");
        }
        public static void SetPairableTimeout(this IAdapter adapter, ObjectPath path, UInt32 value) {
            properties(path).Set("org.bluez.Adapter1", "PairableTimeout", value);
        }
        public static bool GetDiscovering(this IAdapter adapter, ObjectPath path) {
            return (bool)properties(path).Get("org.bluez.Adapter1", "Discovering");
        }
        public static string[] GetUUIDs(this IAdapter adapter, ObjectPath path) {
            return (string[])properties(path).Get("org.bluez.Adapter1", "UUIDs");
        }
        public static string GetModalias(this IAdapter adapter, ObjectPath path) {
            return (string)properties(path).Get("org.bluez.Adapter1", "Modalias");
        }
    }
}
