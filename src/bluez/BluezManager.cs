using System;
using System.Collections;
using System.Collections.Generic;
using org.freedesktop.DBus;
using DBus;

namespace player.bluez {
    public class BluezManager {
        private Bus bus;
        private IObjectManager objectManager;
        private List<BluetoothInterface> interfaceList;

        public BluezManager() {
            bus = Bus.System;
            interfaceList = new List<BluetoothInterface>();
            objectManager = bus.GetObject<IObjectManager>("org.bluez", new ObjectPath("/"));
            objectManager.InterfacesAdded += InterfacesAddedHandler;
            objectManager.InterfacesRemoved += InterfacesRemovedHandler;
            loadBluetoothInterfaces();
            Console.WriteLine("Interface Count: {0}", interfaceList.Count);
        }
        private void InterfacesAddedHandler(IDictionary<string, object> interfaces) {
            foreach (string key in interfaces.Keys) {
                object value = interfaces[key];
                Console.WriteLine("Interface Added: {0} {1}", key, value);
            }
        }
        private void InterfacesRemovedHandler(string[] interfaces) {
            foreach (string inter in interfaces) {
                Console.WriteLine("Interface Removed: {0}", inter);
            }
        }
        private void loadBluetoothInterfaces() {
            IDictionary<ObjectPath, IDictionary<string, IDictionary<string, object>>> managedObjects = objectManager.GetManagedObjects();
            foreach (ObjectPath path in managedObjects.Keys) {
                string[] pathSplit = Utils.splitObjectPath(path);
                if (!pathSplit[pathSplit.Length - 1].Contains("hci"))
                    continue;
                BluetoothInterface hci = new BluetoothInterface(path);
                Console.WriteLine("Bluetooth Interface: {0}", hci.index);
                IDictionary<string, IDictionary<string, object>> objectList = managedObjects[path];
                foreach (string managedObject in objectList.Keys) {
                    IDictionary<string, object> properties = objectList[managedObject];
                    Console.WriteLine("\t{0}, Property Count: {1}", managedObject, properties.Count);
                    Console.WriteLine("Added Interface: {0}", hci.AddInterface(managedObject));
                    foreach (string property in properties.Keys) {
                        Console.WriteLine("\t\t{0}:{1}", property, properties[property]);
                    }
                }
                interfaceList.Add(hci);
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
        /*private void printAdapterProperites() {
            BluetoothInterface hci = interfaceList[0];
            IAdapter adapter = hci.adapter;
            Console.WriteLine("Name: {0}, Address: {1}, Discovering: {2}", adapter.Name, adapter.Address, adapter.Discovering);
        }*/
    }
}