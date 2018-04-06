using System;
using DBus;
using org.freedesktop.DBus;

namespace bluezTest
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Gonna try and lsten for Bluez signals");
			Bus bus = Bus.System;

			ObjectManager manager = bus.GetObject<ObjectManager>("org.bluez", new ObjectPath("/"));
			if (manager == null) {
				Console.WriteLine("Unable to get ObjectManager");
				System.Environment.Exit(-1);
			}
			Console.WriteLine("Got the Manager successfully");
			manager.InterfacesAdded += delegate(string interfaces) {
				Console.WriteLine("Interfaces added!");
				Console.WriteLine("Interfaces: {0}", interfaces);
			};
			manager.InterfacesRemoved += delegate(string[] interfaces) {
				Console.WriteLine("Interfaces Removed!");
				Console.WriteLine("Interface count: {0}", interfaces.Length);
				Console.WriteLine("Interfaces: {0}", String.Join("\n", interfaces));
			};
			string s = manager.GetManagedObjects();
			String[] split = s.Split('\n');
			foreach (string splat in split) {
				Console.WriteLine(splat);
			}
			//Console.WriteLine(manager.GetManagedObjects());
			while (true) {
				//Console.WriteLine("Current State: {0}", manager.state());
				Console.Write(" ");
				System.Threading.Thread.Sleep(500);
			}
		}
	}
}
[Interface("org.freedesktop.DBus.ObjectManager")]
public interface ObjectManager {
	string GetManagedObjects();
	event InterfaceAddedHandler InterfacesAdded;
	event InterfaceRemovedHandler InterfacesRemoved;
}
public delegate void InterfaceAddedHandler(string interfaces);
public delegate void InterfaceRemovedHandler(string[] interfaces);