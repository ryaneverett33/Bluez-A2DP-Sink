using org.freedesktop.DBus;

[Interface("org.freedesktop.DBus.Introspectable")]
public interface IIntrospectable {
    //returns xml
    string Introspect();
}