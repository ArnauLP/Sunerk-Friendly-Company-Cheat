using HarmonyLib;

namespace LethalCompanyTemplate.Patches
{
    [HarmonyPatch(typeof(DoorLock))]
    public class DoorLockPatch
    {
        public static bool lockedDoorsEnabled = false;

        // If rarely doors is locked or buggy, force unlock
        [HarmonyPatch("UnlockDoor")]
        [HarmonyPostfix]
        public static void AttributesModifierPatch(DoorLock __instance)
        {
            if (__instance.isLocked)
            {
                __instance.UnlockDoor();
                __instance.UnlockDoorServerRpc();
            }
        }

        // Disables blocking doors
        [HarmonyPatch("LockDoor")]
        [HarmonyPrefix]
        public static bool UnlockDoorsPatch()
        {
            return lockedDoorsEnabled;

        }
     }
}