using System.IO;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using LethalCompanyTemplate.Managers;
using LethalCompanyTemplate.Patches;
using UnityEngine;

namespace LethalCompanyTemplate
{
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private const string PLUGIN_GUID = "LethalCompanyMod";
        private const string PLUGIN_NAME = "Sunerk Mod";
        private const string PLUGIN_VERSION = "0.0.1";

        private readonly Harmony harmony = new Harmony(PLUGIN_GUID);

        public static Plugin instance;

        public GameObject netManagerPrefab;

        private void Awake()
        {
            // Plugin startup logic

            var types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (var type in types)
            {
                var methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
                foreach (var method in methods)
                {
                    var attributes = method.GetCustomAttributes(typeof(RuntimeInitializeOnLoadMethodAttribute), false);
                    if (attributes.Length > 0)
                    {
                        method.Invoke(null, null);
                    }
                }
            }

            if (instance == null)
            {
                instance = this;
            }

            string assetDir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "Sunerk mod");
            AssetBundle bundle = AssetBundle.LoadFromFile(assetDir);

            netManagerPrefab = bundle.LoadAsset<GameObject>("Assets/LethalCompanyTemplate/NetworkManagerMyMod.prefab");
            netManagerPrefab.AddComponent<NetworkManagerMyMod>();

            harmony.PatchAll(typeof(Plugin));
            harmony.PatchAll(typeof(PlayerControllerBPatch));
            Logger.LogInfo("Patched network");

        }
    }
}
