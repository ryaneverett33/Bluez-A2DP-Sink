using System;
using System.Collections.Generic;
using player.bluez;

public class Program {
    public static BluetoothInterface getInterface(BluetoothInterface[] interfaces) {
        for (int i = 0; i < interfaces.Length; i++) {
            Console.WriteLine("{0}: hci{1}", i, interfaces[i].index);
        }
        bool selected = false;
        do {
            Console.WriteLine("Select Interface by index");
            string line = Console.ReadLine();
            try {
                int index = int.Parse(line);
                if (index < 0 || index >= interfaces.Length) {
                    Console.WriteLine("Index out of range, range[0:{0}]", interfaces.Length - 1);
                    selected = false;
                }
                else {
                    selected = true;
                    return interfaces[index];
                }
            }
            catch {
                Console.WriteLine("Invalid index");
                selected = false;
            }
        }
        while (!selected);
        return null;
    }
    public static bool doLoop = true;
    public static void Main(string[] args) {
        Console.CancelKeyPress += myHandler;
        BluezManager manager = new BluezManager();
        BluetoothInterface inter = getInterface(manager.getInterfaces());
        Console.WriteLine("Setting Interface to Discovery Mode");
        IAdapter adapter = inter.adapter;
        adapter.StartDiscovery();
        Console.WriteLine("Discoverable: {0}, Pairable: {1}, Discovering: {2}",
            adapter.GetDiscoverable(inter.path), adapter.GetPairable(inter.path),
            adapter.GetDiscovering(inter.path));
        Console.WriteLine("Printing UUIDs, Ctrl-C to cancel");
        List<string> uuids = new List<string>();

        while(doLoop) {
            string[] tmpUUIDs = adapter.GetUUIDs(inter.path);
            foreach (string uuid in tmpUUIDs) {
                if (!uuids.Contains(uuid)) {
                    uuids.Add(uuid);
                    Console.WriteLine("{0} : {1}", uuids.Count, uuid);
                }
            }
            System.Threading.Thread.Sleep(500);
        }
        adapter.StopDiscovery();
    }
    protected static void myHandler(object sender, ConsoleCancelEventArgs args) {
        doLoop = false;
    }
}