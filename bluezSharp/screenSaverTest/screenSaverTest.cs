using System;
using System.Threading;
using DBus;
using org.freedesktop.DBus;

namespace bluezSharp
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			// /org/gnome/ScreenSaver org.gnome.ScreenSaver
			try
			{

				Console.WriteLine("Gonna try and lock the screen!");
				Bus bus = Bus.Session;

				//ScreenSaver saver = bus.GetObject<ScreenSaver>("org.gnome.ScreenSaver", new ObjectPath("/org/gnome/ScreenSaver"));
				ScreenSaver saver = bus.GetObject<ScreenSaver>("org.gnome.Nautilus", new ObjectPath("/com/canonical/unity/launcherentry/1540790312"));
				Console.WriteLine("Got the object successfully");

				//Console.WriteLine("Introspect: {0}", saver.Introspect());
				Console.WriteLine("Version = {0}", saver.Get("com.canonical.dbusmenu", "Version"));
				Console.WriteLine("Status = {0}", saver.Get("com.canonical.dbusmenu", "Status"));
				Console.WriteLine("TextDirection = {0}", saver.Get("com.canonical.dbusmenu", "TextDirection"));

				//saver.Lock();
				saver.SetActive(true);
				System.Threading.Thread.Sleep(5000);
				while (saver.GetActive())
				{
					//Sleep while the screensaver is active
					Console.WriteLine("Active during Saver for {0}", saver.GetActiveTime());
					Thread.Sleep(100);
				}
				Console.WriteLine("ScreenSaver was active for {0} seconds", saver.GetActiveTime());

			}
			catch (Exception e)
			{
				Console.WriteLine("Couldn't get the ScreenSaver object");
				Console.WriteLine("Error: {0}", e.Message);
				Console.WriteLine(e.StackTrace);
			}
		}
	}
	//[Interface ("org.gnome.ScreenSaver")]
//com.canonical.dbusmenu
	[Interface ("org.freedesktop.DBus.Properties")]
	public interface ScreenSaver : Properties, Introspectable, Peer
	{
		bool GetActive();
		UInt32 GetActiveTime();
		void Lock();
		void SetActive(bool value);
		void SimulateUserActivity();
	}
}