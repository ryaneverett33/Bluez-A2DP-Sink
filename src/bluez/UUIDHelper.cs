using System;
using System.Collections.Generic;
namespace player.bluez {
    //https://www.bluetooth.com/specifications/assigned-numbers/service-discovery
    public static class UUIDHelper {
        public static readonly Guid baseUUID = new Guid("00000000-0000-1000-8000-00805F9B34FB");
        public static readonly Dictionary<Guid, BluetoothProfile> PROFILE_DEFINITIONS = new Dictionary<Guid, BluetoothProfile> {
            {new Guid("00001801-0000-1000-8000-00805F9B34FB"), BluetoothProfile.GATT},
            {new Guid("0000110e-0000-1000-8000-00805F9B34FB"), BluetoothProfile.AVRC},
            {new Guid("00001106-0000-1000-8000-00805F9B34FB"), BluetoothProfile.OBEX_Transfer},
            {new Guid("00001112-0000-1000-8000-00805F9B34FB"), BluetoothProfile.HeadsetAG},
            {new Guid("00001800-0000-1000-8000-00805F9B34FB"), BluetoothProfile.GAP},
            {new Guid("00001105-0000-1000-8000-00805F9B34FB"), BluetoothProfile.OBEX_Push},
            {new Guid("00001200-0000-1000-8000-00805F9B34FB"), BluetoothProfile.PnP_Info},
            {new Guid("0000110c-0000-1000-8000-00805F9B34FB"), BluetoothProfile.AVRC_Target},
            {new Guid("00001104-0000-1000-8000-00805F9B34FB"), BluetoothProfile.IrMC_Sync},
            {new Guid("0000110a-0000-1000-8000-00805F9B34FB"), BluetoothProfile.A2DP_Source},
            {new Guid("0000110b-0000-1000-8000-00805F9B34FB"), BluetoothProfile.A2DP_Sink},
            {new Guid("00001133-0000-1000-8000-00805F9B34FB"), BluetoothProfile.Message_Notification_Server},
            {new Guid("0000112f-0000-1000-8000-00805F9B34FB"), BluetoothProfile.Phonebook_Access_Server},
            {new Guid("00001132-0000-1000-8000-00805F9B34FB"), BluetoothProfile.Message_Access_Server},
            {new Guid("00001108-0000-1000-8000-00805F9B34FB"), BluetoothProfile.Headset},
            {new Guid("00001115-0000-1000-8000-00805F9B34FB"), BluetoothProfile.PANU},
            {new Guid("00001116-0000-1000-8000-00805F9B34FB"), BluetoothProfile.NAP},
            {new Guid("0000111f-0000-1000-8000-00805F9B34FB"), BluetoothProfile.Handsfree_Audio_Gateway},
            {new Guid("0000112d-0000-1000-8000-00805F9B34FB"), BluetoothProfile.SIM_Access}


        };
        public static BluetoothProfile ProfileFromUUID(string uuid) {
            Guid guid = new Guid(uuid);
            if (PROFILE_DEFINITIONS.ContainsKey(guid))
                return PROFILE_DEFINITIONS[guid];
            else
                throw new Exception("Invalid UUID");
        }
        public static Guid UUIDFromProfile(BluetoothProfile profile) {
            foreach (Guid key in PROFILE_DEFINITIONS.Keys) {
                if (PROFILE_DEFINITIONS[key] == profile)
                    return key;
            }
            throw new Exception("Invalid Profile");
        }
    }
    public enum BluetoothProfile {
        GATT,
        AVRC,
        OBEX_Transfer,
        HeadsetAG,
        GAP,
        OBEX_Push,
        PnP_Info,
        AVRC_Target,
        IrMC_Sync,
        A2DP_Source,
        A2DP_Sink,
        Message_Notification_Server,
        Phonebook_Access_Server,
        Message_Access_Server,
        Headset,
        PANU,
        NAP,
        Handsfree_Audio_Gateway,
        SIM_Access
    }
}
