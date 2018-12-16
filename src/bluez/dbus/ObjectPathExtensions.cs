using System;
using DBus;

namespace player.bluez {
    public static class ObjectPathExtensions {

        //returns a new ObjectPath with the added key
        public static ObjectPath Add(this ObjectPath path, string key) {
            if (key == null)
                return null;
            string tmpKey = key;
            if (key.Contains("/"))
                tmpKey = key.Replace('/', (char)0);
            string currentPath = path.ToString();
            if (currentPath[currentPath.Length - 1] == '/')
                return new ObjectPath(currentPath + key);
            else
                return new ObjectPath(currentPath + '/' + key);
        }
    }
}
