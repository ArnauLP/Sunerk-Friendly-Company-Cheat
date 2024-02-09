using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace LethalCompanyTemplate
{
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    public class SunerkMod : BaseUnityPlugin
    {
        private const string PLUGIN_GUID = "LethalCompanyMod";
        private const string PLUGIN_NAME = "Sunerk Mod";
        private const string PLUGIN_VERSION = "0.0.1";

        private readonly Harmony harmony = new Harmony(PLUGIN_GUID);

        private static SunerkMod Instance;

        internal ManualLogSource mls;

        private void Awake()
        {
            // Plugin startup logic
            //Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(PLUGIN_GUID);

            mls.LogInfo("The test mod has awaken:D");

            harmony.PatchAll(typeof(SunerkMod));
        }
    }
}