using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace LCMod
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class SunerkMod : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);

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

            mls = BepInEx.Logging.Logger.CreateLogSource(PluginInfo.PLUGIN_GUID);

            mls.LogInfo("The test mod has awaken:D");

            harmony.PatchAll(typeof(SunerkMod));
        }
    }
}
