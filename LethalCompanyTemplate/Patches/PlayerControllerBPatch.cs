using HarmonyLib;
using GameNetcodeStuff;

namespace LethalCompanyTemplate.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControllerBPatch
    {
        // GodMode Toggle
        public static bool GodModeEnabled = true;

        // Infinite sprint patch
        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        static void InfiniteSprintPatch(ref float ___sprintMeter)
        {
            ___sprintMeter = 1f;
        }

        // GodMode patch -> This method disables orignal game method so damage never (theorically) happens
        [HarmonyPatch("DamagePlayer")]
        [HarmonyPrefix]
        static bool PreFixDamagePlayer(ref int damageNumber)
        {
            return !GodModeEnabled;

            // Disable method to avoid crash (client or server)
            // Execute method
        }
    }
}
