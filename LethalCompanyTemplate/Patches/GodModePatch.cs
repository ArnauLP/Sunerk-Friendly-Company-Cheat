using GameNetcodeStuff;
using HarmonyLib;

namespace LethalCompanyTemplate.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    public class GodModePatch
    {
        // GodMode Toggle
        public static bool godModeEnabled = true;

        // GodMode patch -> This method disables orignal game method so damage never (theorically) happens (looks
        // like only fall damage)
        [HarmonyPatch("DamagePlayer")]
        [HarmonyPrefix]
        public static bool DisableDamagePlayerPatch(ref int damageNumber)
        {
            // Disables method to avoid crash (client or server) or Executes method
            // reset damageNumber to 0 to avoid extra damage caused by 'unknwon'
            if (godModeEnabled)
            {
                damageNumber = 0;
                return false;
            }

            return true;
        }

        // Disable player death
        [HarmonyPatch("AllowPlayerDeath")]
        [HarmonyPrefix] // -> Mode
        public static bool DisablePlayerDeath(ref bool __result)
        {
            if (godModeEnabled)
            {
                __result = false; // force result to false, avoid bugs
                return false;
            }

            return true; // allow method execution
        }
    }
}