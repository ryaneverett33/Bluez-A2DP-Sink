using System;
using System.Collections.Generic;
namespace player.bluez {
    //https://www.bluetooth.com/specifications/assigned-numbers/service-discovery
    public static class UUIDHelper {
        public static readonly Guid baseUUID = new Guid("00000000-0000-1000-8000-00805F9B34FB");
        public static readonly Dictionary<int, BluetoothProfile> PROFILE_DEFINITIONS = new Dictionary<int, BluetoothProfile> {
            {0x110D, BluetoothProfile.A2DP},
            {0x111A, BluetoothProfile.BIP},
        };
    }
    public enum BluetoothProfile {
        A2DP,
        BIP,
    }
}
