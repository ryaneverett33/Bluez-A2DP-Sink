using System;
using DBus;
using System.Collections.Generic;

namespace player.bluez {
    public abstract class Utils {
        /* implemented in root/ObjectIntrospect.cs */
        public abstract Object ObjectIntrospect(string xml);

        /// <summary>
        /// Splits an object path to its parts
        /// </summary>
        /// <returns>String array of the path parts</returns>
        /// <example>(/org/bluez) -> 'org','bluez'</example>
        /// <param name="path">The ObjectPath to be split</param>
        public static string[] splitObjectPath(ObjectPath path) {
            if (path == null)
                return null;
            string objectPathStr = path.ToString();
            if (objectPathStr.Length == 0)
                return null;
            if (objectPathStr[0] == '/')
                objectPathStr = objectPathStr.Substring(1);
            return objectPathStr.Split('/');
        }
    }
}