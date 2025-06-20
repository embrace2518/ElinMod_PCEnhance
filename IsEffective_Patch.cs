// Decompiled with JetBrains decompiler
// Type: GodArtifactLimitRemove.IsEffective_Patch
// Assembly: GodArtifactLimitRemove, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8910B3E3-1BAF-4A03-8C48-E87B84E8104C
// Assembly location: F:\Steam\steamapps\workshop\content\2135150\3364742845\GodArtifactLimitRemove.dll

using HarmonyLib;

#nullable disable
namespace GodArtifactLimitRemove;

[HarmonyPatch(typeof (ElementContainerFaction), "IsEffective")]
internal static class IsEffective_Patch
{
  [HarmonyPrefix]
  public static bool Prefix(ref bool __result)
  {
    __result = true;
    return false;
  }
}
