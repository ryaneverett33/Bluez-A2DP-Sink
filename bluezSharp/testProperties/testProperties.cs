using System;
using DBus;
using org.freedesktop.DBus;

namespace testProperties
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			//
			try
			{
				Bus bus = Bus.System;
				//bus.GetObject<Adapter>
			}
			catch (Exception e)
			{

			}
		}
		[
			public interface Adapter : Properties
		{
			void RemoveDevice(ObjectPath device);
			void StartDiscovery();
			void StopDiscovery();

		}
	}
}