using BepInEx;
using HarmonyLib;

namespace LethalCompanyTemplate
{
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private const string PLUGIN_GUID = "com.Sunerk.LethalCompanyCheat";
        private const string PLUGIN_NAME = "Sunerk's Friendly Company";
        private const string PLUGIN_VERSION = "0.0.1";

        private readonly Harmony harmony = new Harmony(PLUGIN_GUID);

        public static Plugin instance;

        private void Awake()
        {
            // Plugin startup logic
            if (instance == null)
            {
                instance = this;
            }

            // harmony.PatchAll(typeof(Plugin));
            // harmony.PatchAll(typeof(PlayerControllerBPatch));
            harmony.PatchAll();
            Logger.LogInfo("Patched Binaries");
        }
    }
}
