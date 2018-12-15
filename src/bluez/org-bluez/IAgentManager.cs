using DBus;
using org.freedesktop.DBus;

[Interface("org.bluez.AgentManager1")]
public interface IAgentManager {
    //string agent is of DBus type Object Path
    void RegisterAgent(string agent, string capability);
    void RequestDefaultAgent(string agent);
    void UnregisterAgent(string agent);
}