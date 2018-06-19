using org.freedesktop.DBus;

[Interface("org.bluez.ProfileManager1")]
public interface ProfileManager {
    //string profile is of DBus type Object Path
    void RegisterProfile(string profile, string[] options);
    void UnregisterProfile(string profile);
}