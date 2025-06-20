// Decompiled with JetBrains decompiler
// Type: GodArtifactLimitRemove.OnLoad_Patch
// Assembly: GodArtifactLimitRemove, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8910B3E3-1BAF-4A03-8C48-E87B84E8104C
// Assembly location: F:\Steam\steamapps\workshop\content\2135150\3364742845\GodArtifactLimitRemove.dll

using HarmonyLib;
using System.Reflection;

#nullable disable
namespace GodArtifactLimitRemove;

[HarmonyPatch(typeof (Game), "OnLoad")]
internal static class OnLoad_Patch
{
  [HarmonyPostfix]
  public static void Postfix(Game __instance)
  {
    Patches patchInfo = Harmony.GetPatchInfo((MethodBase) typeof (ElementContainer).GetMethod("AddNote"));
    if (patchInfo == null || patchInfo.Prefixes.Count <= 0)
      return;
    OnEquip_Patch.Prefixed = true;
  }
}
