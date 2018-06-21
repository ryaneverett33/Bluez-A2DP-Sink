using org.freedesktop.DBus;
using DBus;

namespace player.bluez {
	[Interface("org.bluez.AgentManager1")]
	public interface IAgentManager
	{
		void RegisterAgent(ObjectPath agent, string capability);
		void RequestDefaultAgent(ObjectPath agent);
		void UnregisterAgent(ObjectPath agent);
	}
}