using HarmonyLib;
using Unity.Netcode;

namespace LethalCompanyTemplate.Patches
{
    [HarmonyPatch(typeof(GameNetworkManagerPatcher))]
    internal class GameNetworkManagerPatcher
    {
        [HarmonyPostfix]
        [HarmonyPatch("Start")]
        static void AddToPrefabs(ref GameNetworkManager __instance)
        {
            __instance.GetComponent<NetworkManager>().AddNetworkPrefab(Plugin.instance.netManagerPrefab);
        }
    }
}
