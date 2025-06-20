using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace PCEnhance
{
    internal static class ModInfo
    {
        internal const string Guid = "dk.elinplugins.myelinmod";
        internal const string Name = "My Elin Mod";
        internal const string Version = "1.0";
    }

    [BepInPlugin("zh.PCEnhanceMod", "PCEnhanceMod", "0.1.0")]
    public class PCEnhance : BaseUnityPlugin
    {
        private void Start()
        {
            var harmony = new Harmony("zh.PCEnhanceMod");
            harmony.PatchAll();
        }
        public void OnStartCore()
        {
            FeatPatch.OnStartCore();
        }
    }
}