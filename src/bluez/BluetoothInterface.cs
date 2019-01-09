using System;
using System.Collections.Generic;
using DBus;
using org.freedesktop.DBus;

namespace player.bluez {
    //describes an hci interface
    public class BluetoothInterface {
        public int index;
        public ObjectPath path;

        //Interfaces
        public IAdapter adapter { get; private set; }
        public IGattManager gattManager { get; private set; }
        public ILEAdvertisingManager advertisingManager { get; private set; }
        public IMedia media { get; private set; }
        public INetworkServer networkServer { get; private set; }
        public IIntrospectable introspectable { get; private set; }
        public IProperties properties { get; private set; }

        public BluetoothInterface(ObjectPath path) {
            this.path = path;
            resolveIndex();
        }
        private void resolveIndex() {
            string[] split = Utils.splitObjectPath(path);
            string hci = split[split.Length - 1];
            int number = hci.IndexOfAny(new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' });
            index = int.Parse(hci.Substring(number));
        }
        public bool AddInterface(string interfaceName) {
            try {
                if (interfaceExists(interfaceName))
                    return false;
                switch (interfaceName) {
                    case "org.bluez.Adapter1":
                        adapter = Bus.System.GetObject<IAdapter>("org.bluez", path);
                        return adapter != null;
                    case "org.bluez.GattManager1":
                        gattManager = Bus.System.GetObject<IGattManager>("org.bluez", path);
                        return gattManager != null;
                    case "org.bluez.LEAdvertisingManager1":
                        advertisingManager = Bus.System.GetObject<ILEAdvertisingManager>("org.bluez", path);
                        return advertisingManager != null;
                    case "org.bluez.Media1":
                        media = Bus.System.GetObject<IMedia>("org.bluez", path);
                        return media != null;
                    case "org.bluez.NetworkServer1":
                        networkServer = Bus.System.GetObject<INetworkServer>("org.bluez", path);
                        return networkServer != null;
                    case "org.freedesktop.DBus.Introspectable":
                        introspectable = Bus.System.GetObject<IIntrospectable>("org.bluez", path);
                        return introspectable != null;
                    case "org.freedesktop.DBus.Properties":
                        properties = Bus.System.GetObject<IProperties>("org.bluez", path);
                        properties.PropertiesChanged += PropertiesChangedHandler;
                        return properties != null;
                    default:
                        throw new InvalidOperationException("Interface Name is invalid");
                }
            }
            catch (InvalidInterfaceException e) {
                Console.WriteLine("Failed to add Interface, exception: {0}", e.Message);
                return false;
            }
        }
        //whether we already have the interface object or not
        private bool interfaceExists(string interfaceName) {
            //There's probably a better way to do this
            switch (interfaceName) {
                case "org.bluez.Adapter1":
                    return adapter != null;
                case "org.bluez.GattManager1":
                    return gattManager != null;
                case "org.bluez.Media1":
                    return media != null;
                case "org.bluez.NetworkServer1":
                    return networkServer != null;
                case "org.freedesktop.DBus.Introspectable":
                    return introspectable != null;
                case "org.freedesktop.DBus.Properties":
                    return properties != null;
                default:
                    throw new InvalidInterfaceException(String.Format("Interface {0} not recognized", interfaceName));
            }
        }
        private void PropertiesChangedHandler(string name, IDictionary<string, object> props, string[] interfaces) {
            /*Console.WriteLine("Property {0} changed!", name);
            foreach (string @interface in interfaces) {
                Console.WriteLine("\tInterface changed {0}", @interface);
            }
            foreach (string key in props.Keys) {
                Console.WriteLine("\t\t{0} - {1}", key, props[key]);
            }*/
        }
    }
    public class InvalidInterfaceException : Exception {
        public InvalidInterfaceException() : base() { }
        public InvalidInterfaceException(string message) : base(message) { }
    }
}