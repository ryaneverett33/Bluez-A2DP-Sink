using System;
using DBus;
using org.freedesktop.DBus;
using System.Threading;

namespace SignalsTest
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Gonna try and listen for a signal");

			Bus bus = Bus.System;

			//ScreenSaver saver = bus.GetObject<ScreenSaver>("org.gnome.ScreenSaver", new ObjectPath("/org/gnome/ScreenSaver"));
			NetworkManager manager = bus.GetObject<NetworkManager>("org.freedesktop.NetworkManager", new ObjectPath("/org/freedesktop/NetworkManager"));
			Console.WriteLine("Got the object successfully");
			manager.StateChanged += delegate(uint id) {
				Console.WriteLine("State Changed!");
				Console.WriteLine("ID: " + id);
			};

			manager.state();
			while (true) {
				//Console.WriteLine("Current State: {0}", manager.state());
				Console.Write(" ");
				manager.state();
				Thread.Sleep(500);
			}
		}
	}
	[Interface("org.freedesktop.NetworkManager")]
	public interface NetworkManager
	{
		event StateChangedHandler StateChanged;
		uint state();
	}
	public delegate void StateChangedHandler(uint state);
}
