using System;
using DBus;
namespace player.bluez {
    public static class ProxyExtensionTest {
        public static string GetName(this IAdapterProxy proxy) {
            Console.WriteLine("Called Proxy Extension Method");
            return "proxy name";
        }
    }
    public interface IAdapterProxy { }
}
