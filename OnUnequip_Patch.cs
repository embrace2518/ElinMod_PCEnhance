// Decompiled with JetBrains decompiler
// Type: GodArtifactLimitRemove.OnUnequip_Patch
// Assembly: GodArtifactLimitRemove, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8910B3E3-1BAF-4A03-8C48-E87B84E8104C
// Assembly location: F:\Steam\steamapps\workshop\content\2135150\3364742845\GodArtifactLimitRemove.dll

using HarmonyLib;
using System;

#nullable disable
namespace GodArtifactLimitRemove;

[HarmonyPatch(typeof (ElementContainerFaction), "OnUnequip", new Type[] {typeof (Thing)})]
internal static class OnUnequip_Patch
{
  [HarmonyPrefix]
  public static bool Prefix(Thing t)
  {
    if (((Card) t).HasTag((CTAG) 29))
      GodArtifactLimitRemove.GodArtifactLimitRemove.Reforge(t, -1);
    return true;
  }
}
