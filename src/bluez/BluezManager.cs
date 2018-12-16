using System;
using System.Collections;
using System.Collections.Generic;
using org.freedesktop.DBus;
using DBus;

namespace player.bluez {
    public class BluezManager {
        private Bus bus;
        private IObjectManager objectManager;
        private IProperties properties;
        private List<BluetoothInterface> interfaceList;
        //Address->Device
        public Dictionary<string, Tuple<ObjectPath, IDevice>> devices {
            get;
            private set;
        }
        public event DeviceListChangedHandler DeviceListChanged;

        public BluezManager() {
            bus = Bus.System;
            interfaceList = new List<BluetoothInterface>();
            devices = new Dictionary<string, Tuple<ObjectPath, IDevice>>();
            objectManager = bus.GetObject<IObjectManager>("org.bluez", new ObjectPath("/"));
            properties = bus.GetObject<IProperties>("org.bluez", new ObjectPath("/"));
            objectManager.InterfacesAdded += InterfacesAddedHandler;
            objectManager.InterfacesRemoved += InterfacesRemovedHandler;
            loadBluetoothInterfaces();
            Console.WriteLine("Interface Count: {0}", interfaceList.Count);
            //printAdapterProperties();

        }
        public void InterfacesAddedHandler(ObjectPath path, IDictionary<string, IDictionary<string, object>> interfaces) {
            Console.WriteLine("Interfaces Added!");
            Console.WriteLine("Interfaces added at path: {0}", path);
            foreach (string @interface in interfaces.Keys) {
                Console.WriteLine("\tNew Interface: {0}", @interface);
                foreach (string property in interfaces[@interface].Keys) {
                    Console.WriteLine("\t{0} - {1}", property, interfaces[@interface][property]);
                }
            }
        }
        public void InterfacesRemovedHandler(ObjectPath path, string[] interfaces) {
            Console.WriteLine("Interfaces Removed!");
            //Console.WriteLine("Interfaces removed at path: {0}", path);
            /*foreach (string @interface in interfaces) {
                Console.WriteLine("\t Interface {0} removed", @interface);
            }*/
        }
        private void loadBluetoothInterfaces() {
            IDictionary<ObjectPath, IDictionary<string, IDictionary<string, object>>> managedObjects = objectManager.GetManagedObjects();
            foreach (ObjectPath path in managedObjects.Keys) {
                string[] pathSplit = Utils.splitObjectPath(path);
                if (pathSplit[pathSplit.Length - 1].Contains("hci")) {
                    BluetoothInterface hci = new BluetoothInterface(path);
                    //Console.WriteLine("Bluetooth Interface: {0}", hci.index);
                    IDictionary<string, IDictionary<string, object>> objectList = managedObjects[path];
                    foreach (string managedObject in objectList.Keys) {
                        IDictionary<string, object> properties = objectList[managedObject];
                        //Console.WriteLine("\t{0}, Property Count: {1}", managedObject, properties.Count);
                        hci.AddInterface(managedObject);
                        foreach (string property in properties.Keys) {
                            //Console.WriteLine("\t\t{0}:{1}", property, properties[property]);
                        }
                    }
                    interfaceList.Add(hci);
                }
                if (pathSplit[pathSplit.Length - 1].Contains("dev")) {
                    IDevice device = bus.GetObject<IDevice>("org.bluez", path);
                    string address = device.GetAddress(path), name = device.GetName(path);
                    //Console.WriteLine("Bluetooth Device - Name: {0}, Address: {1}", name, address);
                    if (!devices.ContainsKey(address)) {
                        devices.Add(address, new Tuple<ObjectPath, IDevice>(path, device));
                    }
                }
            }
        }
        private void printManagedObjects() {
            IDictionary<ObjectPath, IDictionary<string, IDictionary<string, object>>> managedObjects = objectManager.GetManagedObjects();
            foreach (ObjectPath path in managedObjects.Keys) {
                Console.WriteLine("Path: {0}", path);
                IDictionary<string, IDictionary<string, object>> objectList = managedObjects[path];
                foreach (string managedObject in objectList.Keys) {
                    IDictionary<string, object> properties = objectList[managedObject];
                    Console.WriteLine("\t{0}, Property Count: {1}", managedObject, properties.Count);
                    foreach (string property in properties.Keys) {
                        Console.WriteLine("\t\t{0}:{1}", property, properties[property]);
                    }
                }
            }
        }
        //Not implemented in dbus-sharp
        private void printAdapterProperties() {
            BluetoothInterface hci = interfaceList[0];
            IAdapter adapter = hci.adapter;
            Console.WriteLine("Name: {0}, Address: {1}, Discovering: {2}", 
                adapter.GetName(hci.path), adapter.GetAddress(hci.path), adapter.GetDiscovering(hci.path));
            Console.WriteLine("AddressType: {0}, Alias: {1}, Class: {2}, Powered: {3}, Discoverable: {4}",
                adapter.GetAddressType(hci.path), adapter.GetAlias(hci.path), adapter.GetClass(hci.path),
                adapter.GetPowered(hci.path), adapter.GetDiscoverable(hci.path));
            Console.WriteLine("DiscoverableTimeout: {0}, Pairable: {1}, PairableTimeout: {2}, Modalias: {3}",
                adapter.GetDiscoverableTimeout(hci.path), adapter.GetPairable(hci.path),
                adapter.GetPairableTimeout(hci.path), adapter.GetModalias(hci.path));
            Console.WriteLine("UUIDs: {0}", adapter.GetUUIDs(hci.path));
        }
        public BluetoothInterface[] getInterfaces() {
            return interfaceList.ToArray();
        }
        public delegate void DeviceListChangedHandler(Dictionary<string, Tuple<ObjectPath, IDevice>> devices);
    }
}