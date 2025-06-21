using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace PCEnhance
{
    [BepInPlugin("zh.PCEnhanceMod", "PCEnhanceMod", "0.1.0")]
    public class PCEnhance : BaseUnityPlugin
    {
        private void Awake() => new Harmony(nameof(PCEnhance)).PatchAll();
        // OnStartCore() 是 Elin 游戏在启动后、进行数据初始化之前，自动调用的 Mod 专用方法。
        public void OnStartCore() => GetFeatPatch.GetFeat();
    }
}