using GameNetcodeStuff;
using HarmonyLib;

namespace LethalCompanyTemplate.Patches
{
    [HarmonyPatch(typeof(HoarderBugAI))]
    public class HoarderBugAIPatch
    {
        // Disables Hoarders chasing modded players
        public static void NoChasePatch(ref bool ___inChase, ref bool ___lostPlayerInChase, ref bool ___isAngry)
        {
            ___inChase = false;
            ___lostPlayerInChase = true;
            ___isAngry = false;
        }
    }

}

