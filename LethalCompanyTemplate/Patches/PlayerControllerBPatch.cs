using HarmonyLib;
using GameNetcodeStuff;
using LethalCompanyTemplate.Managers;

namespace LethalCompanyTemplate.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControllerBPatch
    {
        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        static void infiniteSprintPatch(ref float __sprintMeter)
        {
            __sprintMeter = 1f;
        }

        // TODO: no va
        // TODO: change also damage multiplier
        [HarmonyPatch("Damage")]
        [HarmonyPostfix]
        [HarmonyPrefix]
        static void infinitHealthPatch(ref int __health, ref int __maxHealth, ref int __damageAmount, ref int __damageNumber)
        {
            __damageNumber = 0;
            __damageAmount = 0;
            __maxHealth = int.MaxValue;
            __health = __maxHealth;
        }

        [HarmonyPostfix]
        [HarmonyPatch("KillPlayer")]
        static void NotifyPlayersOfDeath(PlayerControllerB __instance)
        {
            if (__instance.IsOwner)
            {
                return;
            }

            if (__instance.isPlayerDead)
            {
                return;
            }

            if (!__instance.AllowPlayerDeath())
            {
                return;
            }

            if (__instance.IsHost || __instance.IsServer)
            {
                NetworkManagerMyMod.instance.DeathNotificationServerRpc(__instance.playerClientId);
            }
            else
            {
                NetworkManagerMyMod.instance.RequestDeathNotificationServerRpc(__instance.playerClientId);
            }
        }
    }
}
