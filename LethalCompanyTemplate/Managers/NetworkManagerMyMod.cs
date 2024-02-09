using System;
using GameNetcodeStuff;
using Unity.Netcode;

namespace LethalCompanyTemplate.Managers
{
    public class NetworkManagerMyMod : NetworkBehaviour
    {
        public static NetworkManagerMyMod instance;

        private void Awake()
        {
            instance = this;
        }

        [ServerRpc(RequireOwnership = false)]
        public void RequestDeathNotificationServerRpc(ulong id)
        {
            DeathNotificationServerRpc(id);
        }

        [ClientRpc]
        public void DeathNotificationServerRpc(ulong id)
        {
            string name = StartOfRound.Instance.allPlayerObjects[(int) id].GetComponent<PlayerControllerB>().playerUsername;
            HUDManager.Instance.DisplayTip("Player Has Died", $"{name} is now dead!");
        }
    }
}